using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Nudes.Retornator.AspnetCore;

class ConfigureJsonSerializerOptionsForRetornator : IConfigureOptions<JsonOptions>
{
    public void Configure(JsonOptions options)
    {
        options.JsonSerializerOptions.Converters.Insert(0, new Converters.FieldErrorJsonConverter());
    }
}
