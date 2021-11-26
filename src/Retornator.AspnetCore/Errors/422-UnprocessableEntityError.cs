using Nudes.Retornator.Core;

namespace Nudes.Retornator.AspnetCore.Errors;


/// <summary>
/// The request is unprocessable
/// </summary>
public class UnprocessableEntityError : Error
{
    /// <summary>
    /// 
    /// </summary>
    public UnprocessableEntityError() : base("Unprocessable Entity", null)
    { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="description"></param>
    public UnprocessableEntityError(string description) : base("Unprocessable Entity", description)
    { }
}
