using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Nudes.Retornator.Core;
using System.Linq;
using System.Net;

namespace Nudes.Retornator.AspnetCore
{
    /// <summary>
    /// Configures a RetornatorOutputFormatter in the outputformatters of the mvc options
    /// </summary>
    public class ConfigureMvcOptionsForRetornator : IConfigureOptions<MvcOptions>
    {
        private readonly ILogger<MvcOptions> logger;
        private readonly IErrorDomainTranslator<HttpStatusCode> errorHttpTranslator;

        /// <summary>
        /// 
        /// </summary>
        public ConfigureMvcOptionsForRetornator(ILogger<MvcOptions> logger, IErrorDomainTranslator<HttpStatusCode> errorHttpTranslator)
        {
            this.logger = logger;
            this.errorHttpTranslator = errorHttpTranslator;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void Configure(MvcOptions op)
        {
            logger.LogInformation("Adding Retornator output formatter");
            int index = op.OutputFormatters.IndexOf(op.OutputFormatters.OfType<SystemTextJsonOutputFormatter>().First());
            op.OutputFormatters.Insert(index, new RetornatorResultOutputFormatter(errorHttpTranslator, op.OutputFormatters.OfType<TextOutputFormatter>().ToArray()));
        }
    }
}
