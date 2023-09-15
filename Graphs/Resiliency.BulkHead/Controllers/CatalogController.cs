using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Polly.Bulkhead;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Resiliency.BulkHead.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly AsyncBulkheadPolicy<HttpResponseMessage> asyncBulkheadPolicy;
        private readonly HttpClient httpClient;
        public CatalogController(AsyncBulkheadPolicy<HttpResponseMessage> asyncBulkheadPolicy, HttpClient httpClient)
        {
            this.asyncBulkheadPolicy = asyncBulkheadPolicy;
            this.httpClient = httpClient;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            string requestEndPoint = $"inventory/{ id}";
            HttpResponseMessage response =await this.asyncBulkheadPolicy.ExecuteAsync(()=> httpClient.GetAsync(requestEndPoint));

            if (response.IsSuccessStatusCode)
            {
                int itemStock = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
                return (IActionResult)Ok(itemStock);
            }
            return (IActionResult)StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            string requestEndPoint = $"inventory/{ id}";
            HttpResponseMessage response = await this.asyncBulkheadPolicy.ExecuteAsync(() => httpClient.GetAsync(requestEndPoint));

            if (response.IsSuccessStatusCode)
            {
                int itemStock = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
                return (IActionResult)Ok(itemStock);
            }
            return (IActionResult)StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
        }
    }
}
