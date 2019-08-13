using Microsoft.Extensions.DependencyInjection;
using Nudes.Retornator.Core;
using System;
using System.Net;

namespace Nudes.Retornator.AspnetCore
{
    public static class HttpResponseManagerExtensions
    {
        /// <summary>
        /// Add a ResponseManager as a singleton through a IServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection instance used to add the singleton.</param>
        /// <param name="responseManager">A ResponseManager to be used as singleton. If is null a new isntance will be created.</param>
        /// <returns>The registered ResponseManager.</returns>
        public static HttpResponseManager AddResponseManager(this IServiceCollection services, HttpResponseManager responseManager = null)
        {
            if (responseManager is null)
                responseManager = new HttpResponseManager();

            services.AddSingleton<IResponseManager<HttpStatusCode>>(responseManager);

            return responseManager;
        }

        /// <summary>
        /// Add a ResponseManager as a singleton through a IServiceCollection.
        /// </summary>
        /// <typeparam name="T">A type who inherits from ResponseManagerConfigurator which will be used to register errors.</typeparam>
        /// <param name="services">The IServiceCollection instance used to add the singleton.</param>
        /// <param name="responseManager">A ResponseManager to be used as singleton and to be passed as parameter to T.RegisterErrors. If null a new one will be created.</param>
        /// <returns>The IServiceCollection used to register the singleton.</returns>
        public static IServiceCollection AddResponseManager<T>(this IServiceCollection services, HttpResponseManager responseManager = null) where T : ResponseManagerConfigurator
        {
            if (responseManager is null)
                responseManager = new HttpResponseManager();

            T t = Activator.CreateInstance(typeof(T), responseManager) as T;
            t.RegisterErrors();

            return services.AddSingleton<IResponseManager<HttpStatusCode>>(responseManager);
        }
    }
}
