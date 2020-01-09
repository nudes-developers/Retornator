using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Formatters.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Nudes.Retornator.Core;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Nudes.Retornator.AspnetCore
{
    /// <summary>
    /// Class that formats an BaseResult into http with json based on SystemTextJsonOutputFormatter
    /// </summary>
    public class RetornatorOutputFormatter : TextOutputFormatter
    {
        private readonly JsonSerializerOptions jsonSerializerOptions;
        private readonly IResponseManager<HttpStatusCode> responseManager;

        public RetornatorOutputFormatter(JsonSerializerOptions jsonSerializerOptions, IResponseManager<HttpStatusCode> responseManager)
        {
            this.jsonSerializerOptions = jsonSerializerOptions;
            this.responseManager = responseManager;
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/json"));
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/*+json"));
        }

        protected override bool CanWriteType(Type type) => typeof(BaseResult).IsAssignableFrom(type);

        public override bool CanWriteResult(OutputFormatterCanWriteContext context) => base.CanWriteResult(context);


        /// <summary>
        /// Writes the response in the request body, this code has been taken from the default SystemTextJsonOutputFormatter as it was sealed
        /// </summary>
        /// <param name="context"></param>
        /// <param name="selectedEncoding"></param>
        /// <returns></returns>
        protected virtual async Task NonRetornatorWriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (selectedEncoding == null)
                throw new ArgumentNullException(nameof(selectedEncoding));

            var httpContext = context.HttpContext;

            var writeStream = GetWriteStream(httpContext, selectedEncoding);
            try
            {
                // context.ObjectType reflects the declared model type when specified.
                // For polymorphic scenarios where the user declares a return type, but returns a derived type,
                // we want to serialize all the properties on the derived type. This keeps parity with
                // the behavior you get when the user does not declare the return type and with Json.Net at least at the top level.
                var objectType = context.Object?.GetType() ?? context.ObjectType;
                await JsonSerializer.SerializeAsync(writeStream, context.Object, objectType, jsonSerializerOptions);

                // The transcoding streams use Encoders and Decoders that have internal buffers. We need to flush these
                // when there is no more data to be written. Stream.FlushAsync isn't suitable since it's
                // acceptable to Flush a Stream (multiple times) prior to completion.
                if (writeStream is TranscodingWriteStream transcodingStream)
                {
                    await transcodingStream.FinalWriteAsync(CancellationToken.None);
                }
                await writeStream.FlushAsync();
            }
            finally
            {
                if (writeStream is TranscodingWriteStream transcodingStream)
                {
                    await transcodingStream.DisposeAsync();
                }
            }
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            
            Error err;
            if (context.Object is BaseResult result && (err = result.GetError()) != null)
            {
                context.HttpContext.Response.StatusCode = (int)responseManager.Translate(err);
                return NonRetornatorWriteResponseBodyAsync(new OutputFormatterWriteContext(context.HttpContext, context.WriterFactory, err.GetType(), err), selectedEncoding);
            }
            return NonRetornatorWriteResponseBodyAsync(context, selectedEncoding);
        }

        private Stream GetWriteStream(HttpContext httpContext, Encoding selectedEncoding)
        {
            if (selectedEncoding.CodePage == Encoding.UTF8.CodePage)
            {
                // JsonSerializer does not write a BOM. Therefore we do not have to handle it
                // in any special way.
                return httpContext.Response.Body;
            }

            return new TranscodingWriteStream(httpContext.Response.Body, selectedEncoding);
        }
    }
}
