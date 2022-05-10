using Nudes.Retornator.Core;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Nudes.Retornator.AspnetCore.Converters;

/// <summary>
/// Converter of field error
/// </summary>
public class FieldErrorJsonConverter : JsonConverter<FieldErrors>
{
    /// <summary>
    /// Read
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public override FieldErrors Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dictionary = JsonSerializer.Deserialize<Dictionary<string, IEnumerable<String>>>(ref reader, options);
        return new FieldErrors(dictionary);
    }

    /// <summary>
    /// Write
    /// </summary>
    public override void Write(Utf8JsonWriter writer, FieldErrors value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (Dictionary<string,List<string>>)value, options);
    }
}
