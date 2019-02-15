using NUDES.Retornator.Base;
using System;
using System.Net;

namespace NUDES.Retornator.MVC
{
    /// <summary>
    /// Represents a class that implements ResponseManagerConfigurator.RegisterErrors to configure a ResponseManager singleton.
    /// </summary>
    public abstract class ResponseManagerConfigurator
    {
        private readonly ResponseManager responseManager;

        public ResponseManagerConfigurator(ResponseManager responseManager)
        {
            this.responseManager = responseManager;
        }

        /// <summary>
        /// Overrite registering your application errors with ResponseManagerConfigurator.ErrorFor&lt;T&gt;.
        /// </summary>
        public virtual void RegisterErrors() => throw new NotImplementedException();

        /// <summary>
        /// Registers an error on a ResponseManager through ResponseManager.RegisterError&lt;T&gt;.
        /// </summary>
        /// <typeparam name="T">The error type who must inherits from Error.</typeparam>
        /// <param name="func">A function who can convert errors of the chosen type to System.Net.HttpStatusCode.</param>
        public void ErrorFor<T>(Func<DetailedError, HttpStatusCode> func) where T : DetailedError => responseManager.RegisterError<T>(func);
    }
}
