using System;

namespace Nudes.Retornator.Core;

/// <summary>
/// Protocol of an result
/// </summary>
public interface IResult
{
    /// <summary>
    /// Returns if error is not null
    /// </summary>
    bool HasError => Error is not null;

    /// <summary>
    /// Error returned
    /// </summary>
    Error Error { get; set; }
}

/// <summary>
/// Most basic representation of a result, an empty result
/// </summary>
public class Result : IResult
{
    private static Result _success;
    /// <summary>
    /// Cached success result for minimal allocation
    /// </summary>
    public static Result Success => _success ??= new Result();

    /// <summary>
    /// Error returned
    /// </summary>
    public Error Error { get; set; }
}
