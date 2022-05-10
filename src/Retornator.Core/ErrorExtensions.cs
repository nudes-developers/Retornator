using System;

namespace Nudes.Retornator.Core;

/// <summary>
/// Extensions methods for Error
/// </summary>
public static class ErrorExtensions
{
    /// <summary>
    /// return an error while adding a new field error
    /// </summary>
    /// <typeparam name="T">Type of error</typeparam>
    /// <param name="error"></param>
    /// <param name="fieldName"></param>
    /// <param name="errors"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">when fieldName is null</exception>
    public static T AddFieldErrors<T>(this T error, string fieldName, params string[] errors) where T : Error
    {
        if (String.IsNullOrEmpty(fieldName))
            throw new ArgumentNullException(nameof(fieldName));

        if (errors.Length == 0)
            throw new ArgumentNullException(nameof(errors));

        error.FieldErrors.Add(fieldName, errors);

        return error;
    }
}