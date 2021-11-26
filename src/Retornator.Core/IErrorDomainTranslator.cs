using System;

namespace Nudes.Retornator.Core;

/// <summary>
/// Translator of error for non domain specific need such as serialization or protocol representation
/// </summary>
/// <typeparam name="T">Type of translated result</typeparam>
public interface IErrorDomainTranslator<T>
{
    /// <summary>
    /// Executes a previously registered translation function to transform a Retornator.Base.Error on the specified type. For more information, see IResponseManager.RegisterError&lt;T&gt;.
    /// </summary>
    /// <param name="error">Error to be translated</param>
    /// <returns>The translation</returns>
    T Translate(Error error);
}
