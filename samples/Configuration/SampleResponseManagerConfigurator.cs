using Nudes.Retornator.AspnetCore;
using Nudes.Retornator.Sample.Errors;
using Nudes.Retornator.Sample.Features.Values.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
