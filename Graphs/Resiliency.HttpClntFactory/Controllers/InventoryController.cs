using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Resiliency.HttpClntFactory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        static int reqCount = 0;
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            reqCount++;
            await Task.Delay(1000);
            if (reqCount % 4 == 0)
            {
                return Ok(15);

            }
            return StatusCode((int)HttpStatusCode.InternalServerError, "Something went wrong");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            reqCount++;
            await Task.Delay(1000);
            if (reqCount % 4 == 0)
            {
                return Ok();

            }
            return StatusCode((int)HttpStatusCode.InternalServerError, "Something went wrong");
        }
    }
}
