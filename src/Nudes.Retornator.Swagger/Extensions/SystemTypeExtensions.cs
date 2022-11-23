using System;
using System.Linq;
using System.Text;

namespace Nudes.Retornator.Swagger.Extensions
{
    internal static class SystemTypeExtensions
    {
        public static string GetSchemaId(this Type type)
        {
            if (type.IsGenericType)
                return new StringBuilder($"{type.Name}")
                    .Replace(string.Format("`{0}", type.GenericTypeArguments.Length), string.Empty)
                    .Append(string.Format("[{0}]", string.Join(",", type.GenericTypeArguments.Select(d => GetSchemaId(d)))))
                    .ToString();
            else
            {
                var assemblyName = type.Assembly.ManifestModule.Name.Replace("dll", String.Empty);
                return $"{type.FullName.Replace(assemblyName, String.Empty)}".Replace("+", ".");
            }
        }
    }
}
