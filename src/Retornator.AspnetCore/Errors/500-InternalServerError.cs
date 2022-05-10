using Nudes.Retornator.Core;

namespace Nudes.Retornator.AspnetCore.Errors;

/// <summary>
/// The request is unprocessable
/// </summary>
public class InternalServerError : Error
{
    /// <summary>
    /// 
    /// </summary>
    public InternalServerError() : base("Internal Server Error", null)
    { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="description"></param>
    public InternalServerError(string description) : base("Internal Server Error", description)
    { }
}
