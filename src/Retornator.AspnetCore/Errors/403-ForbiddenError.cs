using Nudes.Retornator.Core;

namespace Nudes.Retornator.AspnetCore.Errors;

/// <summary>
/// Actor is vinculated to the request but does not have premission to access the resource
/// </summary>
public class ForbiddenError : Error
{
    /// <summary>
    /// 
    /// </summary>
    public ForbiddenError() : base("Forbidden", "Users currently has no permission to access the resource")
    { }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="resourceName"></param>
    public ForbiddenError(string resourceName) : base("Forbidden", $"Users currently has no permission to access {resourceName}")
    { }
}
