using Nudes.Retornator.Core;
using System;
using System.Collections.Generic;
using System.Net;

namespace Nudes.Retornator.AspnetCore.ResponseManager
{
    /// <summary>
    /// Represents a service to use in the AspNetCore Controllers to handle what its endpoints returns.
    /// </summary>
    public class HttpResponseManager : IResponseManager<HttpStatusCode>
    {
        private readonly Dictionary<Type, Func<Error, HttpStatusCode>> InnerDelegations;

        public HttpResponseManager()
        {
            InnerDelegations = new Dictionary<Type, Func<Error, HttpStatusCode>>();
        }

        IResponseManager<HttpStatusCode> IResponseManager<HttpStatusCode>.RegisterError<TError>(Func<Error, HttpStatusCode> translate) => RegisterError<TError>(translate);
        
        public HttpResponseManager RegisterError<T>(Func<Error, HttpStatusCode> translate) where T : Error
        {
            var type = typeof(T);
            if (InnerDelegations.ContainsKey(type))
                throw new InvalidOperationException("This error type is already registered.");

            InnerDelegations.Add(type, translate);

            return this;
        }

        public virtual HttpStatusCode Translate(Error error)
        {
            if (!InnerDelegations.ContainsKey(error.GetType()))
                throw new InvalidOperationException($"Error of type { error.GetType().FullName } is not registered for translations.");
            return InnerDelegations[error.GetType()].Invoke(error);
        }

    }
}
