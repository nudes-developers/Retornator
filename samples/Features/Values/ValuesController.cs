using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nudes.Retornator.Core;

namespace Nudes.Retornator.Sample.Features.Values
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public async Task<Read.Result> Get([FromQuery]bool error = false) => await Read.Handle(error);

        [HttpPost]
        public async Task<Write.Result> Post([FromQuery]bool error = false) => await Write.Handle(error);

        [HttpPut]
        public async Task<ActionResult<Update.Result>> Put([FromQuery]bool error = false) => await Update.Handle(error);

        [HttpDelete]
        public async Task<ActionResult<BaseResult.Empty>> Delete([FromQuery]bool error = false) => await Values.Delete.Handle(error);
    }
}
