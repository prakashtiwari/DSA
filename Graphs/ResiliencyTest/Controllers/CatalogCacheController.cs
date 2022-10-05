using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Polly;
using Polly.Retry;
using Polly.Fallback;
using System.Net.Http.Formatting;
using Polly.Timeout;
using System.Threading;
using Polly.Registry;
using Polly.Caching;

namespace ResiliencyTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogCacheController : ControllerBase
    {

        readonly AsyncTimeoutPolicy timeoutPolicy;
        readonly AsyncRetryPolicy<HttpResponseMessage> httpRetry;
        readonly AsyncFallbackPolicy<HttpResponseMessage> httpFallBack;
        private ResiliencyPolicy resiliencyPolicy;
        HttpClient httpClient;
        int cachenum = 0;
        IPolicyRegistry<string> policyRegistry;
        private RetryPolicy<HttpResponseMessage> RetryPolicy;
        AsyncCachePolicy<HttpResponseMessage> AsyncCachePolicy;
        public CatalogCacheController(IPolicyRegistry<string> policyRegistry, HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.AsyncCachePolicy = policyRegistry.Get<AsyncCachePolicy<HttpResponseMessage>>("cachePolicy");

        }
        private void OnRetry(DelegateResult<HttpResponseMessage> delegateResult, int retryCount)
        {
            if (delegateResult.Exception is HttpRequestException)
            {
                if (delegateResult.Exception.Message == "The operation timed out")
                {

                }
            }
        }
        private void PerformReAuth()
        {
            httpClient = GetHttpClient("GoodRequest");


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {



            string requestEndPoint = $"inventory/{ id}";
            Context context = new Context($"GetInventoryById-{id}");

            HttpResponseMessage response = await AsyncCachePolicy.ExecuteAsync(action:action => httpClient.GetAsync(requestEndPoint), context);
            if (response.IsSuccessStatusCode)
            {
                int itemStock = JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
                return (IActionResult)Ok(itemStock);
            }
            return (IActionResult)StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

        }
        private HttpClient GetHttpClient(string req)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(@"http://localhost:4153/api");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            //httpClient.DefaultRequestHeaders.Addc
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;

        }
    }
}
