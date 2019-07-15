using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NUDES.Retornator.Base;
using NUDES.Retornator.MVC;

namespace NUDES.Retornator.Sample.Features.Values
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ResponseManager responseManager;

        public ValuesController(ResponseManager responseManager)
        {
            this.responseManager = responseManager;
        }


        [HttpGet]
        public async Task<ActionResult<Read.Result>> Get([FromQuery]bool error = false)
        {
            var result = await Read.Handle(error);
            return responseManager.ToActionResult(result);
        }

        [HttpPost]
        public async Task<ActionResult<Write.Result>> Post([FromQuery]bool error = false)
        {
            var result = await Write.Handle(error);
            return responseManager.ToActionResult(result, System.Net.HttpStatusCode.Created);
        }

        [HttpPut()]
        public async Task<ActionResult<Update.Result>> Put([FromQuery]bool error = false)
        {
            var result = await Update.Handle(error);
            return responseManager.ToActionResult(result);
        }

        [HttpDelete]
        public async Task<ActionResult<BaseResult.Empty>> Delete([FromQuery]bool error = false)
        {
            var result = await Values.Delete.Handle(error);
            return responseManager.ToActionResult(result, System.Net.HttpStatusCode.NoContent);
        }
    }
}
