using Nudes.Retornator.Core;

namespace Nudes.Retornator.AspnetCore.Errors;

/// <summary>
/// Request is not vinculated to a valid actor
/// </summary>
public class UnauthorizedError : Error
{
    /// <summary>
    /// 
    /// </summary>
    public UnauthorizedError() : base("Unauthorized", "User has no authorization")
    { }
}
