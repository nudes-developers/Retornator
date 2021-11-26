using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nudes.Retornator.Sample.Features.Mediated.Models;

namespace Nudes.Retornator.Sample.Features.Mediated.Requests;

public class UpdateRequest : IRequest<ResultOf<ReadModel>>
{
    [BindNever]
    public int Id { get; set; }

    public string Content { get; set; }

    [BindNever]
    public bool Error { get; set; }
}
