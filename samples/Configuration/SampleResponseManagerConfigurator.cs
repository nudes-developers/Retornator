using Nudes.Retornator.AspnetCore;
using Nudes.Retornator.AspnetCore.ResponseManager;
using Nudes.Retornator.Sample.Errors;
using Nudes.Retornator.Sample.Features.Values.Errors;

namespace Nudes.Retornator.Sample.Configuration
{
    public class SampleResponseManagerConfigurator : ResponseManagerConfigurator
    {
        public SampleResponseManagerConfigurator(HttpResponseManager responseManager) : base(responseManager)
        {
        }

        public override void RegisterErrors()
        {
            ErrorFor<NotFoundError>(error => System.Net.HttpStatusCode.NotFound);

            ErrorFor<ValueInvalidError>(error => System.Net.HttpStatusCode.BadRequest);
            ErrorFor<ValueNotFoundError>(error => System.Net.HttpStatusCode.NotFound);
        }
    }
}
