using Nudes.Retornator.Sample.Features.Values.Errors;

namespace Nudes.Retornator.Sample.Features.Values;

public class ReadResult
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class ReadHandler
{
    public static async Task<ResultOf<ReadResult>> Handle(bool returnWithError)
    {
        await Task.CompletedTask;
        if (returnWithError)
            return Result.Throw(new ValueNotFoundError(1));

        return new ReadResult()
        {
            Id = 1,
            Name = "Result of a success read"
        };
    }
}
