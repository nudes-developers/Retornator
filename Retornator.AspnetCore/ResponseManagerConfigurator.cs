using Nudes.Retornator.Core;
using System;
using System.Net;

namespace Nudes.Retornator.AspnetCore
{
    /// <summary>
    /// Represents a class who will be used to register errors in a ResponseManager.
    /// </summary>
    public abstract class ResponseManagerConfigurator
    {
        private readonly IResponseManager<HttpStatusCode> responseManager;

        public ResponseManagerConfigurator(IResponseManager<HttpStatusCode> responseManager)
        {
            this.responseManager = responseManager;
        }

        /// <summary>
        /// Override registering your application errors with ResponseManagerConfigurator.ErrorFor&lt;T&gt;.
        /// </summary>
        public virtual void RegisterErrors() => throw new NotImplementedException();

        /// <summary>
        /// Registers an error on a ResponseManager through ResponseManager.RegisterError&lt;T&gt;.
        /// </summary>
        /// <typeparam name="T">The error type who must inherit from Error.</typeparam>
        /// <param name="func">A function to convert errors of the chosen type to System.Net.HttpStatusCode.</param>
        public void ErrorFor<T>(Func<Error, HttpStatusCode> func) where T : Error => responseManager.RegisterError<T>(func);
    }
}
