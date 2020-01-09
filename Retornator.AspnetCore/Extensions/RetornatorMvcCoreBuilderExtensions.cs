using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Nudes.Retornator.AspnetCore
{
    public static class RetornatorMvcCoreBuilderExtensions
    {
        /// <summary>
        /// Injects ConfigureMvcOptionsForRetornator into the service collection of the mvc builder
        /// </summary>
        /// <returns></returns>
        public static IMvcBuilder AddRetornator(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.Services.AddSingleton<IConfigureOptions<MvcOptions>, ConfigureMvcOptionsForRetornator>();
            return mvcBuilder;
        }

        /// <summary>
        /// Injects ConfigureMvcOptionsForRetornator into the service collection of the mvc builder
        /// </summary>
        /// <returns></returns>
        public static IMvcBuilder AddRetornator(this IMvcBuilder mvcBuilder, Action<JsonSerializerOptions> jsonOptions)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            jsonOptions.Invoke(options);
            mvcBuilder.Services.AddSingleton(options);
            mvcBuilder.Services.AddSingleton<IConfigureOptions<MvcOptions>, ConfigureMvcOptionsForRetornator>();
            return mvcBuilder;
        }
    }
}
