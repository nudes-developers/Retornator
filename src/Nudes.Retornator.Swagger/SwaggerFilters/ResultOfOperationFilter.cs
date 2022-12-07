﻿using Microsoft.OpenApi.Models;
using Nudes.Retornator.Core;
using Nudes.Retornator.Swagger.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nudes.Retornator.Swagger.SwaggerFilters
{
    internal class ResultOfOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var returnType = context.MethodInfo.ReturnType;
            if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Task<>))
            {
                returnType = returnType.GenericTypeArguments[0];
            }

            if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(ResultOf<>))
            {
                var successReturnType = returnType.GenericTypeArguments[0];

                if (successReturnType.IsGenericType && successReturnType.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
                    return;

                var successMediaType = new OpenApiMediaType
                {
                    Schema = new OpenApiSchema
                    {
                        Reference = new OpenApiReference
                        {
                            Id = successReturnType.GetSchemaId(),
                            Type = ReferenceType.Schema
                        }
                    }
                };

                var errorMediaType = new OpenApiMediaType
                {
                    Schema = new OpenApiSchema
                    {
                        Reference = new OpenApiReference
                        {
                            Id = typeof(Error).GetSchemaId(),
                            Type = ReferenceType.Schema
                        }
                    }
                };

                operation.Responses["200"] = new OpenApiResponse
                {
                    Content =
                    {
                        { "application/json",  successMediaType},
                    }
                };

                operation.Responses["400"] = new OpenApiResponse
                {
                    Content =
                    {
                        { "application/json", errorMediaType }
                    }
                };
            }
        }
    }
}
