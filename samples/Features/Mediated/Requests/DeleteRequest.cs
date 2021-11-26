using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Nudes.Retornator.Sample.Features.Mediated.Requests;

public class DeleteRequest : BaseRequest, IRequest<Result>
{
    [BindNever]
    public int Id { get; set; }
}
