using Nudes.Retornator.Core;

namespace Nudes.Retornator.AspnetCore.Errors
{
    public class NotFoundError : Error
    {
        public NotFoundError() : base("Resource not found", "The requested resource has not been found")
        { }

        public NotFoundError(string resourceType) : base("Resource not found", $"The requested {resourceType} has not been found")
        { }

        public NotFoundError(object id) : base("Resource not found", $"The requested resource ({id}) has not been found")
        { }

        public NotFoundError(string resourceType, object id) : base("Resource not found", $"The requested {resourceType} ({id}) has not been found")
        { }
    }
}
