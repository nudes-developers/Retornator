using MediatR;
using Nudes.Retornator.Sample.Features.Mediated.Models;

namespace Nudes.Retornator.Sample.Features.Mediated.Requests;

public class WriteRequest : BaseRequest, IRequest<ResultOf<ReadModel>>
{
    public string Content { get; set; }
}
