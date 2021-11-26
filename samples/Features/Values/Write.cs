using Nudes.Retornator.Sample.Features.Values.Errors;

namespace Nudes.Retornator.Sample.Features.Values;

public class WriteResult
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class WriteHandler
{

    public static async Task<ResultOf<WriteResult>> Handle(bool returnWithError)
    {
        await Task.CompletedTask;
        if (returnWithError)
            return new ValueInvalidError("5.1");

        return new WriteResult()
        {
            Id = 3,
            Name = "Result of a success write"
        };
    }
}
