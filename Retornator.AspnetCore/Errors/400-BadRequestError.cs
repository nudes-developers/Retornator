using Nudes.Retornator.Core;

namespace Nudes.Retornator.AspnetCore.Errors
{
    public class BadRequestError : Error
    {
        public BadRequestError() : base("Bad Request", null)
        { }
    }
}
