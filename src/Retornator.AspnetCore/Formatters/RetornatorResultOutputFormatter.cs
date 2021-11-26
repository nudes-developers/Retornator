using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Nudes.Retornator.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Nudes.Retornator.AspnetCore
{
    /// <summary>
    /// Class that formats an Result or ResultOf into http with json based on SystemTextJsonOutputFormatter
    /// </summary>
    public class RetornatorResultOutputFormatter : TextOutputFormatter
    {
        private readonly IErrorDomainTranslator<HttpStatusCode> errorHttpTranslator;
        private readonly IEnumerable<TextOutputFormatter> formatters;

        /// <summary>
        /// 
        /// </summary>
        public RetornatorResultOutputFormatter(IErrorDomainTranslator<HttpStatusCode> errorHttpTranslator, IEnumerable<TextOutputFormatter> formatters)
        {
            this.errorHttpTranslator = errorHttpTranslator;
            this.formatters=formatters;
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/json"));
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/*+json"));
        }

        /// <summary>
        /// 
        /// </summary>
        protected override bool CanWriteType(Type type) => typeof(IResult).IsAssignableFrom(type);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="selectedEncoding"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {

            if (context.Object is IResult result && result.Error is { } err)
            {
                context.HttpContext.Response.StatusCode = (int)errorHttpTranslator.Translate(err);
                return WriteInnerResponseBodyAsync(context.HttpContext,
                    context.WriterFactory,
                    err.GetType(),
                    err,
                    selectedEncoding);
            }
            else if (context.ObjectType == typeof(Result))
            {
                return Task.CompletedTask;
            }
            else if (context.ObjectType.GetGenericTypeDefinition() == typeof(ResultOf<>))
            {
                return WriteInnerResponseBodyAsync(context.HttpContext,
                    context.WriterFactory,
                    context.ObjectType.GenericTypeArguments[0],
                    context.ObjectType.GetProperty(nameof(ResultOf<object>.Result)).GetGetMethod().Invoke(context.Object, null),
                    selectedEncoding);
            }
            else
                throw new NotImplementedException($"Retornator cannot write type {context.ObjectType.FullName}");
        }

        private Task WriteInnerResponseBodyAsync(HttpContext httpContext, Func<Stream, Encoding, TextWriter> writerFactory, Type objType, object obj, Encoding selectedEncoding)
        {
            OutputFormatterWriteContext context = new(httpContext, writerFactory, objType, obj);
            foreach (var formatter in formatters)
            {
                if (formatter.CanWriteResult(context))
                    return formatter.WriteResponseBodyAsync(context, selectedEncoding);
            }
            throw new InvalidOperationException($"No textoutputformatter valid for type {context.ObjectType.FullName}, tried {String.Join("; ", formatters.Select(d => d.GetType().FullName))}");
        }
    }
}
