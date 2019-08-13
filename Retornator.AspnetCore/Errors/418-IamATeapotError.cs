using Nudes.Retornator.Core;

namespace Nudes.Retornator.AspnetCore.Errors
{
    public class IamATeapotError : Error
    {
        public IamATeapotError() : base("I'm a teapot", "I refuse to brew coffe")
        { }
    }
}
