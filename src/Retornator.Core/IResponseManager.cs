using System;
using System.Collections.Generic;
using System.Text;

namespace Nudes.Retornator.Core
{
    public interface IResponseManager<T>
    {
        /// <summary>
        /// Registers a function used to transform a instance of TError into an instance of type T
        /// </summary>
        /// <typeparam name="TError">A type who is or inherits from Error.</typeparam>
        /// <param name="translate">A function to be used with IResponseManager.Translate to convert errors to the translation type needed.</param>
        /// <returns>This instance of IResponseManager to method chaining.</returns>
        IResponseManager<T> RegisterError<TError>(Func<Error, T> translate) where TError : Error;

        /// <summary>
        /// Executes a previously registered translation function to transform a Retornator.Base.Error on the specified type. For more information, see IResponseManager.RegisterError&lt;T&gt;.
        /// </summary>
        /// <param name="error">Error to be translated</param>
        /// <returns>The translation</returns>
        T Translate(Error error);
    }
}
