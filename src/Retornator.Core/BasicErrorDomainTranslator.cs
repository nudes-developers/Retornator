using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Nudes.Retornator.Core;

/// <summary>
/// Basic error domain translator, this class translates error to type T, based on configurations in its InnerDelegations
/// </summary>
public class BasicErrorDomainTranslator<T> : IErrorDomainTranslator<T>
{
    /// <summary>
    /// Inner delegations
    /// </summary>
    public ReadOnlyDictionary<Type, Func<Error, T>> InnerDelegations { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="delegations"></param>
    public BasicErrorDomainTranslator(Dictionary<Type, Func<Error, T>> delegations)
    {
        InnerDelegations = new ReadOnlyDictionary<Type, Func<Error, T>>(delegations);
    }

    /// <summary>
    /// Translates an error to http status code
    /// </summary>
    /// <param name="error">error</param>
    /// <returns>http status code</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="NotImplementedException"></exception>
    public T Translate(Error error)
    {
        var errType = error.GetType();
        if (InnerDelegations.TryGetValue(errType, out var delegation))
            try
            {
                return delegation(error);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"{nameof(BasicErrorDomainTranslator<T>)} encountered an error while translating {errType.FullName}", nameof(error), ex)
                {
                    Data =
                    {
                        { nameof(error), error }
                    }
                };
            }

        throw new NotImplementedException($"{nameof(BasicErrorDomainTranslator<T>)} could not translate {error.GetType()}")
        {
            Data =
            {
                { nameof(error), error }
            }
        };
    }
}
