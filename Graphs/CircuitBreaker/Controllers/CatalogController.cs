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
    public class CatalogController : ControllerBase
    {
        private readonly AsyncCircuitBreakerPolicy<HttpResponseMessage> circuitBreakerPolicy;
        private readonly HttpClient httpClient;
        AsyncRetryPolicy<HttpResponseMessage> retryPolicy;
        public CatalogController(AsyncCircuitBreakerPolicy<HttpResponseMessage> circuitBreakerPolicy, HttpClient httpClient)
        {
            this.circuitBreakerPolicy = circuitBreakerPolicy;
            this.httpClient = httpClient;
            this.retryPolicy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode).RetryAsync(2);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
           
            string requestEndPoint = $"inventory/{ id}";
          

            HttpResponseMessage response = await retryPolicy.ExecuteAsync(()=>circuitBreakerPolicy.ExecuteAsync(  () => httpClient.GetAsync(requestEndPoint))); //circuitBreakerPolicy.ExecuteAsync( action: (action )=>  httpClient.GetAsync(requestEndPoint,action)));
             
            if (response.IsSuccessStatusCode)
            {
                int itemStock = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
                return (IActionResult)Ok(itemStock);
            }
            return (IActionResult)StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

        }
    }
}
