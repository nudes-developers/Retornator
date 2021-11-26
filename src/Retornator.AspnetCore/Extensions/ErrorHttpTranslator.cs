using Microsoft.Extensions.DependencyInjection;
using Nudes.Retornator.Core;
using System.Net;

namespace Nudes.Retornator.AspnetCore;

/// <summary>
/// 
/// </summary>
public static class ErrorHttpTranslator
{
    /// <summary>
    /// Add a singleton translator for erro to http status codes
    /// </summary>
    /// <param name="services">The IServiceCollection instance used to add the singleton.</param>
    /// <param name="builder">A configured builder</param>
    public static void AddErrorTranslator(this IServiceCollection services, ErrorHttpTranslatorBuilder builder)
    {
        services.AddSingleton<IErrorDomainTranslator<HttpStatusCode>>(builder.Build());
    }
}
