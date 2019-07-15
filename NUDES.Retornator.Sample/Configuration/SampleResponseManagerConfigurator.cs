using NUDES.Retornator.MVC;
using NUDES.Retornator.Sample.Errors;
using NUDES.Retornator.Sample.Features.Values.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUDES.Retornator.Sample.Configuration
{
    public class SampleResponseManagerConfigurator : ResponseManagerConfigurator
    {
        public SampleResponseManagerConfigurator(ResponseManager responseManager) : base(responseManager)
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
