using System;

namespace Nudes.Retornator.Core;

/// <summary>
/// Extensions methods for IResult
/// </summary>
public static class ResultExtensions
{
    /// <summary>
    /// Add a error closely coupled to a field/argument of the request
    /// </summary>
    /// <param name="result">result</param>
    /// <param name="fieldName">Name of field that caused the error</param>
    /// <param name="errors">Errors caused by the field value</param>
    /// <returns>result</returns>
    public static T AddFieldErrors<T>(this T result, string fieldName, params string[] errors) where T : IResult
    {
        if (!result.HasError)
            throw new InvalidOperationException($"Result is not an error. You can't add field errors to a result without errors");

        result.Error.AddFieldErrors(fieldName, errors);

        return result;
    }
}