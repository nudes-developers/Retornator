using Nudes.Retornator.Core;
using Nudes.Retornator.Sample.Features.Values.Errors;
using System.Threading.Tasks;

namespace Nudes.Retornator.Sample.Features.Values
{
    public class Delete
    {
        public static Task<BaseResult.Empty> Handle(bool returnWithError)
        {
            if (returnWithError)
                return Task.FromResult(BaseResult.Empty.Throw(new ValueNotFoundError(1)));

            return Task.FromResult(new BaseResult.Empty());
        }
    }
}
