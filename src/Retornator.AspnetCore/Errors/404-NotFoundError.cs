using Nudes.Retornator.Core;

namespace Nudes.Retornator.AspnetCore.Errors;

/// <summary>
/// The requested resource has not been found
/// </summary>
public class NotFoundError : Error
{
    /// <summary>
    /// 
    /// </summary>
    public NotFoundError() : base("Resource not found", "The requested resource has not been found")
    { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="resourceType"></param>
    public NotFoundError(string resourceType) : base("Resource not found", $"The requested {resourceType} has not been found")
    { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    public NotFoundError(object id) : base("Resource not found", $"The requested resource ({id}) has not been found")
    { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="resourceType"></param>
    /// <param name="id"></param>
    public NotFoundError(string resourceType, object id) : base("Resource not found", $"The requested {resourceType} ({id}) has not been found")
    { }
}
