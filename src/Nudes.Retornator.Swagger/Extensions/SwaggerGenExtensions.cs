using Microsoft.Extensions.DependencyInjection;
using Nudes.Retornator.Swagger.SwaggerFilters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Nudes.Retornator.Swagger.Extensions
{
    /// <summary>
    /// Extensions for Swagger Retornator
    /// </summary>
    public static class SwaggerGenExtensions
    {
        /// <summary>
        /// Add custom swagger scheme
        /// </summary>
        /// <param name="options"></param>
        public static void AddRetornatorFilters(this SwaggerGenOptions options)
        {
            options.CustomSchemaIds(d => d.GetSchemaId());

            options.DocumentFilter<ResultOfDocumentsFilter>();
            options.OperationFilter<ResultOfOperationFilter>();
        }
    }
}
