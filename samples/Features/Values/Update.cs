using Nudes.Retornator.Sample.Features.Values.Errors;

namespace Nudes.Retornator.Sample.Features.Values;

public class UpdateResult
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class UpdateHandler
{
    public static async Task<ResultOf<UpdateResult>> Handle(bool returnWithError)
    {
        await Task.CompletedTask;
        if (returnWithError)
            return new ValueInvalidError("2.0")
                    .AddFieldErrors("Name", "The field name must have 30 or more characters.")
                    .AddFieldErrors("Id", "The field Id cannot be altered.");

        return new UpdateResult()
        {
            Id = 2,
            Name = "Result of a success update"
        };
    }
}
