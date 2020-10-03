using Nudes.Retornator.Sample.Features.Values.Errors;
using System.Reflection;
using System.Threading.Tasks;
using Result = Nudes.Retornator.Core.StreamResult;

namespace Nudes.Retornator.Sample.Features.Values
{
    public class Download
    {

        public static Task<Result> Handle(bool returnWithError)
        {
            if (returnWithError)
                return Task.FromResult(Result.Throw(new ValueNotFoundError(1)));

            return Task.FromResult(new Result()
            {
                Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Nudes.Retornator.Sample.EmbeddedResources.logo.png"),
                FileName = "logo.png"
            });
        }
    }
}
