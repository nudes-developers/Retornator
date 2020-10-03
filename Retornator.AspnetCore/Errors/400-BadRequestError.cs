using Nudes.Retornator.Core;

namespace Nudes.Retornator.AspnetCore.Errors
{
    public class BadRequestError : Error
    {
        public BadRequestError() : this(null)
        { }

        public BadRequestError(string description) : base("Bad Request", description)
        { }
    }
}
