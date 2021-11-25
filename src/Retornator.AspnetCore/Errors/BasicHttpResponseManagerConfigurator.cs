using Nudes.Retornator.AspnetCore.ResponseManager;
using Nudes.Retornator.Core;
using System.Net;

namespace Nudes.Retornator.AspnetCore.Errors
{
    public class BasicHttpResponseManagerConfigurator : ResponseManagerConfigurator
    {
        public BasicHttpResponseManagerConfigurator(IErrorDomainTranslator<HttpStatusCode> responseManager) : base(responseManager)
        { }

        public override void RegisterErrors()
        {
            ErrorFor<BadRequestError>(error => HttpStatusCode.BadRequest);
            ErrorFor<UnauthorizedError>(error => HttpStatusCode.Unauthorized);
            ErrorFor<PaymentRequiredError>(error => HttpStatusCode.PaymentRequired);
            ErrorFor<ForbiddenError>(error => HttpStatusCode.Forbidden);
            ErrorFor<NotFoundError>(error => HttpStatusCode.NotFound);
            ErrorFor<IamATeapotError>(error => (HttpStatusCode)418);
            ErrorFor<UnprocessableEntityError>(error => HttpStatusCode.UnprocessableEntity);
            ErrorFor<ServiceUnavaiableError>(error => HttpStatusCode.ServiceUnavailable);
            ErrorFor<Error>(error => HttpStatusCode.BadRequest);
        }
    }
}
