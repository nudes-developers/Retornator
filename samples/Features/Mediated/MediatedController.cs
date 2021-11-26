using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nudes.Retornator.Sample.Features.Mediated.Models;
using Nudes.Retornator.Sample.Features.Mediated.Requests;
using System.ComponentModel;

namespace Nudes.Retornator.Sample.Features.Mediated;

[Route("api/[controller]")]
[ApiController]
public class MediatedController : ControllerBase
{
    private readonly IMediator mediator;

    public MediatedController(IMediator mediator)
    {
        this.mediator=mediator;
    }

    [HttpGet("{id}")]
    public Task<ResultOf<ReadModel>> Get([FromRoute] int id, [FromQuery] ReadRequest request, CancellationToken cancellation)
    {
        request.Id = id;
        return mediator.Send(request, cancellation);
    }

    [HttpPost]
    public Task<ResultOf<ReadModel>> Post([FromBody] WriteRequest request, CancellationToken cancellation)
        => mediator.Send(request, cancellation);

    [HttpPut("{id}")]
    public Task<ResultOf<ReadModel>> Put([FromRoute] int id, [FromBody] UpdateRequest request, [FromQuery] bool error, CancellationToken cancellation)
    {
        request.Id = id;
        request.Error = error;
        return mediator.Send(request, cancellation);
    }

    [HttpDelete("{id}")]
    public Task<Result> Delete([FromRoute] int id, [FromQuery] DeleteRequest request, CancellationToken cancellation)
    {
        request.Id = id;
        return mediator.Send(request, cancellation);
    }

    [HttpGet("nonretornator")]
    public ActionResult<int> NonRetornatorMethod()
    {
        return Ok(1);
    }
}
