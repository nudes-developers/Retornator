using Nudes.Retornator.Core;

namespace Nudes.Retornator.AspnetCore.Errors
{
    public class ForbiddenError : Error
    {
        public ForbiddenError() : base("Forbidden", "Users currently has no permission to access the resource")
        { }

        public ForbiddenError(string resourceName) : base("Forbidden", $"Users currently has no permission to access {resourceName}")
        { }
    }
}
