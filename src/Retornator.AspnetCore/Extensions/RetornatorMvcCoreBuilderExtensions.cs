﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Text.Json;


namespace Nudes.Retornator.AspnetCore;

/// <summary>
/// Extensions for Retornator
/// </summary>
public static class RetornatorMvcCoreBuilderExtensions
{
    /// <summary>
    /// Injects ConfigureMvcOptionsForRetornator into the service collection of the mvc builder
    /// </summary>
    /// <returns></returns>
    public static IMvcBuilder AddRetornator(this IMvcBuilder mvcBuilder)
    {
        mvcBuilder.Services.AddSingleton<IConfigureOptions<MvcOptions>, ConfigureMvcOptionsForRetornator>();
        mvcBuilder.Services.AddSingleton<IConfigureOptions<JsonOptions>, ConfigureJsonSerializerOptionsForRetornator>();
        return mvcBuilder;
    }
}
