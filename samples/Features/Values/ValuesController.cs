using Microsoft.AspNetCore.Mvc;

namespace Nudes.Retornator.Sample.Features.Values;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public Task<ResultOf<ReadResult>> Get([FromQuery] bool error = false) => ReadHandler.Handle(error);

    [HttpPost]
    public Task<ResultOf<WriteResult>> Post([FromQuery] bool error = false) => WriteHandler.Handle(error);

    [HttpPut]
    public Task<ResultOf<UpdateResult>> Put([FromQuery] bool error = false) => UpdateHandler.Handle(error);

    [HttpDelete]
    public Task<Result> Delete([FromQuery] bool error = false) => DeleteHandler.Handle(error);
}
