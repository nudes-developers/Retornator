using Nudes.Retornator.Core;

namespace Nudes.Retornator.AspnetCore.Errors
{
    public class UnauthorizedError : Error
    {
        public UnauthorizedError() : base("Unauthorized", "User has no authorization")
        { }
    }
}
