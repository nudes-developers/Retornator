using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Nudes.Retornator.Core;
using System;
using System.Buffers;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Nudes.Retornator.AspnetCore
{
    /// <summary>
    /// Class that formats an BaseResult into http with json based on NewtonsoftJsonOUtputFormatter
    /// </summary>
    public class RetornatorOutputFormatter : NewtonsoftJsonOutputFormatter
    {
        private readonly IResponseManager<HttpStatusCode> responseManager;

        public RetornatorOutputFormatter(JsonSerializerSettings serializerSettings, ArrayPool<char> charPool, MvcOptions mvcOptions, IResponseManager<HttpStatusCode> responseManager) : base(serializerSettings, charPool, mvcOptions)
        {
            this.responseManager = responseManager;
        }

        protected override bool CanWriteType(Type type) => typeof(BaseResult).IsAssignableFrom(type);
        public override bool CanWriteResult(OutputFormatterCanWriteContext context) => base.CanWriteResult(context); //?

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            Error err;
            if (context.Object is BaseResult result && (err = result.GetError()) != null)
            {
                context.HttpContext.Response.StatusCode = (int)responseManager.Translate(err);
                return base.WriteResponseBodyAsync(new OutputFormatterWriteContext(context.HttpContext, context.WriterFactory, err.GetType(), err), selectedEncoding);
            }
            return base.WriteResponseBodyAsync(context, selectedEncoding);
        }
    }

    public static class RetornatorMvcCoreBuilderExtensions
    {
        /// <summary>
        /// Inserts an RetornatorOutputFormatter into the mvc outputformatters handling all translation of BaseResult into http response
        /// </summary>
        /// <param name="op"></param>
        /// <param name="sp">service provider</param>
        /// <returns></returns>
        public static MvcOptions AddRetornator(this MvcOptions op, IServiceProvider sp)
        {
            var options = sp.GetRequiredService<IOptions<MvcNewtonsoftJsonOptions>>().Value;
            var charPool = sp.GetRequiredService<ArrayPool<char>>();

            IResponseManager<HttpStatusCode> responseManager;
            try
            {
                responseManager = sp.GetRequiredService<IResponseManager<HttpStatusCode>>();
            }
            catch (Exception)
            {
                throw new Exception("IResponseManager<HttpStatusCode> was not added into the DI, please call services.AddResponseManager() prior to AddControllers/AddMvc");
            }

            op.OutputFormatters.Insert(0, new RetornatorOutputFormatter(options.SerializerSettings, charPool, op, responseManager));
            return op;
        }
    }
}
