using Nudes.Retornator.Core;

namespace Nudes.Retornator.AspnetCore.Errors;

/// <summary>
/// Service required for the request is unavaiable
/// </summary>
public class ServiceUnavaiableError : Error
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="serviceName"></param>
    public ServiceUnavaiableError(string serviceName) : base("Service unavaiable", $"Our service {serviceName} is currently unavaiable")
    { }
}
