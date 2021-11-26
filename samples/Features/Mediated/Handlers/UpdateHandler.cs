using MediatR;
using Nudes.Retornator.Sample.Errors;
using Nudes.Retornator.Sample.Features.Mediated.Models;
using Nudes.Retornator.Sample.Features.Mediated.Requests;

namespace Nudes.Retornator.Sample.Features.Mediated.Handlers;

public class UpdateHandler : IRequestHandler<UpdateRequest, ResultOf<ReadModel>>
{
    public async Task<ResultOf<ReadModel>> Handle(UpdateRequest request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (request.Error)
            return new MyNotFoundError();
        return new ReadModel()
        {
            Id = request.Id,
            Content = request.Content,
        };
    }
}
