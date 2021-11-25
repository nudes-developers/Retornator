using System;

namespace Nudes.Retornator.Core;

/// <summary>
/// Represents a result of type T
/// </summary>
/// <typeparam name="T">Type of result</typeparam>
public class ResultOf<T> : IResult
{
    /// <summary>
    /// Error returned
    /// </summary>
    public virtual Error Error { get; set; }

    /// <summary>
    /// Expected result returned
    /// </summary>
    public virtual T Result { get; set; }



    /// <summary>
    /// implicit conversion for Result, it will contain the same error but null result
    /// </summary>
    public static implicit operator ResultOf<T>(Result result) => new() { Error = result.Error };







}

/// <summary>
/// Extensions methods for IResult
/// </summary>
public static class ResultExtensions
{

    /// <summary>
    /// Creates a BaseResult&lt;T&gt; with a error. This error shall be detected and handled further on the application. 
    /// </summary>
    /// <param name="result"></param>
    /// <param name="name">Name of the error (a quick description of what happened).</param>
    /// <param name="description">Message describing the error (a deep explanation of what happened).</param>
    /// <returns>A instance of BaseResult&lt;T&gt;/></returns>
    public static IResult Throw(this IResult result, string name, string description) => result.Throw(new Error(name, description));

    /// <summary>
    /// Add a error closely coupled to a field/argument of the request
    /// </summary>
    /// <param name="result"></param>
    /// <param name="fieldName">Name of field that caused the error</param>
    /// <param name="errors">Errors caused by the field value</param>
    /// <returns></returns>
    public static T AddFieldErrors<T>(this T result, string fieldName, params string[] errors) where T : IResult
    {
        if (!result.HasError)
            throw new InvalidOperationException($"Result is not an error. You can't add field errors to a result without errors");

        if (String.IsNullOrEmpty(fieldName))
            throw new ArgumentNullException(nameof(fieldName));

        if (errors.Length == 0)
            throw new ArgumentNullException(nameof(errors));

        result.Error.FieldErrors.AddErrors(fieldName, errors);

        return result;
    }
}