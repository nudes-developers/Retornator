using NUDES.Retornator.Base;
using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace NUDES.Retornator.MVC
{
    /// <summary>
    /// Represents a service to use within the AspNetCore controllers to handle errors and success responses.  
    /// </summary>
    public class ResponseManager
    {
        private Dictionary<Type, Func<DetailedError, HttpStatusCode>> InnerDelegations;

        public ResponseManager()
        {
            InnerDelegations = new Dictionary<Type, Func<DetailedError, HttpStatusCode>>();
        }

        /// <summary>
        /// Registers a function who can transform a instance of T onto a System.Net.HttpStatusCode.
        /// </summary>
        /// <typeparam name="T">A type who is or inherits from Error.</typeparam>
        /// <param name="translate">A function to be used with ResponseManager.Translate to convert errors of the specified type to HttpStatusCode.</param>
        /// <returns>This instance of ResponseManager.</returns>
        public ResponseManager RegisterError<T>(Func<DetailedError, HttpStatusCode> translate) where T : DetailedError
        {
            var type = typeof(T);
            if (InnerDelegations.ContainsKey(type))
                throw new InvalidOperationException("This error type is already registered.");

            InnerDelegations.Add(type, translate);

            return this;
        }

        /// <summary>
        /// Performs a previously registered translation function to transform a type who inherits from Retornator.Base.Error on a System.Net.HttpStatusCode. For more information, see ResponseManager.RegisterError&lt;T&gt;.
        /// </summary>
        /// <param name="error">The error to translate.</param>
        /// <returns>The HttpStatusCode resulted from the translation function.</returns>
        protected virtual HttpStatusCode Translate(DetailedError error)
        {
            if (!InnerDelegations.ContainsKey(error.GetType()))
                throw new InvalidOperationException($"Error of type { error.GetType().FullName } is not registered for translations");
            return InnerDelegations[error.GetType()].Invoke(error);
        }

        /// <summary> 
        /// Converts a NUDES.Retornator.Base.ResultBase&lt;TResult&gt; to ActionResult&lt;TResult&gt;.
        /// </summary>
        /// <typeparam name="TResult">A type who inherits from Retornator.Base.ResultBase&lt;T&gt;</typeparam>
        /// <param name="result">The entity to return on the body of the response.</param>
        /// <param name="statusToReturnOnSuccess">The status code to return in case of ReturnBase does not have an error.</param>
        /// <returns>
        /// If the provided result argument contains an error, the result will have the Value as the error itself and the StatusCode as the result of ResponseManager.Translate passing the error as parameter.
        /// If not, the Value will be the result argument and the StatusCode will be the statusToReturnOnSuccess argument.
        /// </returns>
        public ActionResult<TResult> ToActionResult<TResult>(TResult result, HttpStatusCode statusToReturnOnSuccess = HttpStatusCode.OK) where TResult : BaseResult 
        {
            DetailedError error = result.GetError();

            if (error is null)
                return new ActionResult<TResult>(new ObjectResult(result) { StatusCode = (int)statusToReturnOnSuccess });
            else
                return new ActionResult<TResult>(new ObjectResult(error) { StatusCode = (int)Translate(error) });
        }
    }

}
