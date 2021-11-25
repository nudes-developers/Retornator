using Nudes.Retornator.Core;
using Nudes.Retornator.Sample.Features.Values.Errors;
using System.Threading.Tasks;

namespace Nudes.Retornator.Sample.Features.Values
{
    public class Delete
    {
        public static Task<Result> Handle(bool returnWithError)
        {
            if (returnWithError)
                return Task.FromResult(Result.Throw(new ValueNotFoundError(1)));

            return Task.FromResult(Result.Success);
        }
    }
}
