using NUDES.Retornator.Base;
using NUDES.Retornator.Sample.Errors;
using NUDES.Retornator.Sample.Features.Values.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUDES.Retornator.Sample.Features.Values
{
    public class Delete
    {
        public static async Task<BaseResult.Empty> Handle(bool returnWithError)
        {
            if (returnWithError)
                return BaseResult.Empty.Throw(new ValueNotFoundError(1));

            return new BaseResult.Empty();
        }
    }
}
