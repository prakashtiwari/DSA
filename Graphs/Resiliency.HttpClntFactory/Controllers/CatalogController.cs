using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Resiliency.HttpClntFactory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IHttpClientFactory httpClntFactory;
        public CatalogController(IHttpClientFactory httpClntFactory)
        {
            this.httpClntFactory = httpClntFactory;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            string requestEndPoint = $"inventory/{ id}";
            var client = this.httpClntFactory.CreateClient("RemoteClient");
            HttpResponseMessage response =await client.GetAsync(requestEndPoint);
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
            var client = this.httpClntFactory.CreateClient("RemoteClient");
            HttpResponseMessage response = await client.DeleteAsync(requestEndPoint);
            if (response.IsSuccessStatusCode)
            {
                int itemStock = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
                return (IActionResult)Ok(itemStock);
            }
            return (IActionResult)StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
        }
    }
}
