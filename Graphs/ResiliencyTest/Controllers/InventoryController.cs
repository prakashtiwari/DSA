using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ResiliencyTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        static int reqCount = 0;
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            // await Task.Delay(1000);
            reqCount++;
            //var Auth = Request.Cookies["Auth"];
            //if (reqCount % 4 == 0)
            //{
            //    return Ok(15);

            //}
            await Task.Delay(100);
            return Ok(id + 100);
            // return StatusCode((int)HttpStatusCode.InternalServerError, "Something went wrong");
        }
    }
}
