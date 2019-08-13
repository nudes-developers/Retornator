using Nudes.Retornator.Core;

namespace Nudes.Retornator.AspnetCore.Errors
{
    public class ServiceUnavaiableError : Error
    {
        public ServiceUnavaiableError(string serviceName) : base("Service unavaiable", $"Our service {serviceName} is currently unavaiable")
        { }
    }
}
