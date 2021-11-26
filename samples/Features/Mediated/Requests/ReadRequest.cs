using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nudes.Retornator.Sample.Features.Mediated.Models;

namespace Nudes.Retornator.Sample.Features.Mediated.Requests;

public class ReadRequest : BaseRequest, IRequest<ResultOf<ReadModel>>
{
    [BindNever]
    public int Id { get; set; }

}
