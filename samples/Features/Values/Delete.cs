using Nudes.Retornator.Sample.Features.Values.Errors;

namespace Nudes.Retornator.Sample.Features.Values;

public class DeleteHandler
{
    public static async Task<Result> Handle(bool returnWithError)
    {
        await Task.CompletedTask;
        if (returnWithError)
            return Result.Throw(new ValueNotFoundError(1));

        return Result.Success;
    }
}
