using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CircuitBreakerTest.Controllers
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
            if (reqCount % 4 == 0)
            {
                return Ok(15);

            }
            return StatusCode((int)HttpStatusCode.InternalServerError, "Something went wrong");
        }
    }
}
