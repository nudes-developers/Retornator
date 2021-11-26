using MediatR;
using Nudes.Retornator.Sample.Features.Mediated.Models;
using Nudes.Retornator.Sample.Features.Mediated.Requests;

namespace Nudes.Retornator.Sample.Features.Mediated.Handlers;

public class WriteHandler : IRequestHandler<WriteRequest, ResultOf<ReadModel>>
{
    public async Task<ResultOf<ReadModel>> Handle(WriteRequest request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (request.Error)
            return new Error("bad request", "some internal field has errors")
                .AddFieldErrors(nameof(request.Content), "there are errors here");

        return new ReadModel()
        {
            Id = 1,
            Content = request.Content,
        };
    }
}
