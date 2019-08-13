using Nudes.Retornator.Core;
using Nudes.Retornator.Sample.Features.Values.Errors;
using System.Threading.Tasks;

namespace Nudes.Retornator.Sample.Features.Values
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
