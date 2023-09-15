using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CircuitBreakerTest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        [HttpGet("({id}")]
        public async Task<IAsyncResult> Get(int id)
        {
            await Task.Delay(1000);
            return (IAsyncResult)Ok(id + 10.27);
        }
    }
}
