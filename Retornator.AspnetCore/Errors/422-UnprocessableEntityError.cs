using Nudes.Retornator.Core;

namespace Nudes.Retornator.AspnetCore.Errors
{
    public class UnprocessableEntityError : Error
    {
        public UnprocessableEntityError() : base("Unprocessable Entity", null)
        { }

        public UnprocessableEntityError(string description) : base("Unprocessable Entity", description)
        { }
    }
}
