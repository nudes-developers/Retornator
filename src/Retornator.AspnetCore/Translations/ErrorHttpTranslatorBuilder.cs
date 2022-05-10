using Nudes.Retornator.AspnetCore.Errors;
using Nudes.Retornator.Core;
using System;
using System.Collections.Generic;
using System.Net;

namespace Nudes.Retornator.AspnetCore;

/// <summary>
/// 
/// </summary>
public class ErrorHttpTranslatorBuilder
{

    private static ErrorHttpTranslatorBuilder _default;
    /// <summary>
    /// Default builder for the most basic errors
    /// </summary>
    public static ErrorHttpTranslatorBuilder Default => _default ??= new ErrorHttpTranslatorBuilder()
                .TranslationFor<BadRequestError>(error => HttpStatusCode.BadRequest)
                .TranslationFor<UnauthorizedError>(error => HttpStatusCode.Unauthorized)
                .TranslationFor<PaymentRequiredError>(error => HttpStatusCode.PaymentRequired)
                .TranslationFor<ForbiddenError>(error => HttpStatusCode.Forbidden)
                .TranslationFor<NotFoundError>(error => HttpStatusCode.NotFound)
                .TranslationFor<UnprocessableEntityError>(error => HttpStatusCode.UnprocessableEntity)
                .TranslationFor<ServiceUnavaiableError>(error => HttpStatusCode.ServiceUnavailable)
                .TranslationFor<InternalServerError>(error => HttpStatusCode.InternalServerError)
                .TranslationFor<Error>(error => HttpStatusCode.BadRequest);

    readonly Dictionary<Type, Func<Error, HttpStatusCode>> _delegations = new();

    /// <summary>
    /// Configure a translation
    /// </summary>
    /// <typeparam name="TError">Error type to translate</typeparam>
    /// <param name="delegation">Delegate that translates</param>
    public ErrorHttpTranslatorBuilder TranslationFor<TError>(Func<Error, HttpStatusCode> delegation) where TError : Error
    {
        var type = typeof(TError);
        return TranslationFor(type, delegation);
    }

    /// <summary>
    /// Configure a translation
    /// </summary>
    /// <param name="errorType">Error type to translate</param>
    /// <param name="delegation">Delegate that translates</param>
    public ErrorHttpTranslatorBuilder TranslationFor(Type errorType, Func<Error, HttpStatusCode> delegation)
    {
        if (_delegations.ContainsKey(errorType))
            throw new ArgumentException($"Build already have definition for translating error type {errorType.FullName}", nameof(errorType));

        _delegations[errorType] = delegation;
        return this;
    }

    /// <summary>
    /// Builds a translator
    /// </summary>
    /// <returns>Translator</returns>
    public IErrorDomainTranslator<HttpStatusCode> Build() => new BasicErrorDomainTranslator<HttpStatusCode>(_delegations);
}
