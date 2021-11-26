using Nudes.Retornator.Core;

namespace Nudes.Retornator.AspnetCore.Errors
{
    /// <summary>
    /// Erro for when the request is wrong, changing the request might correct the problem
    /// </summary>
    public class BadRequestError : Error
    {
        /// <summary>
        /// 
        /// </summary>
        public BadRequestError() : this(null)
        { }
        
        /// <summary>
        /// 
        /// </summary>
        public BadRequestError(string description) : base("Bad Request", description)
        { }
    }
}
