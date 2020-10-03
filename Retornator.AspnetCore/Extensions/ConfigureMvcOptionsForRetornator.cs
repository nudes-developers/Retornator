using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Nudes.Retornator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Nudes.Retornator.AspnetCore
{
    /// <summary>
    /// Configures a RetornatorOutputFormatter in the outputformatters of the mvc options
    /// </summary>
    public class ConfigureMvcOptionsForRetornator : IConfigureOptions<MvcOptions>
    {
        private readonly ILogger<MvcOptions> logger;
        private readonly IResponseManager<HttpStatusCode> responseManager;
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public ConfigureMvcOptionsForRetornator(ILogger<MvcOptions> logger, IResponseManager<HttpStatusCode> responseManager, JsonSerializerOptions jsonSerializerOptions)
        {
            this.logger = logger;
            this.responseManager = responseManager;
            this.jsonSerializerOptions = jsonSerializerOptions;
        }

        public void Configure(MvcOptions op)
        {
            logger.LogInformation("Adding Retornator output formatter");
            int index = op.OutputFormatters.IndexOf(op.OutputFormatters.OfType<SystemTextJsonOutputFormatter>().First());
            op.OutputFormatters.Insert(index, new RetornatorOutputFormatter(jsonSerializerOptions, responseManager));
            op.OutputFormatters.Insert(index, new RetornartorStreamOutputFormatter());
        }
    }
}
