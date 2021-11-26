using MediatR;
using Nudes.Retornator.Sample.Errors;
using Nudes.Retornator.Sample.Features.Mediated.Requests;

namespace Nudes.Retornator.Sample.Features.Mediated.Handlers;

public class DeleteHandler : IRequestHandler<DeleteRequest, Result>
{
    public async Task<Result> Handle(DeleteRequest request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (request.Error)
            return new MyNotFoundError();
        return Result.Success;
    }
}
