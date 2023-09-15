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

namespace ResiliencyTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {

        readonly AsyncTimeoutPolicy timeoutPolicy;
        readonly AsyncRetryPolicy<HttpResponseMessage> httpRetry;
        readonly AsyncFallbackPolicy<HttpResponseMessage> httpFallBack;
        private ResiliencyPolicy resiliencyPolicy;
        HttpClient httpClient;
        int cachenum = 0;
        PolicyRegistry policyRegistry;
        private RetryPolicy<HttpResponseMessage> RetryPolicy;
        public CatalogController(PolicyRegistry policyRegistry)
        {
            timeoutPolicy = Policy.TimeoutAsync(1);
            this.policyRegistry = policyRegistry;

            //Policy.HandleResult<HttpResponseMessage>(res => !res.IsSuccessStatusCode).Or<HttpRequestException>().RetryAsync(3, onRetry: OnRetry);
            //Policy with wait and retry
            //httpRetry = Policy.HandleResult<HttpResponseMessage>(res => !res.IsSuccessStatusCode).WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)) / 2);

            //httpRetry = Policy.HandleResult<HttpResponseMessage>(res => !res.IsSuccessStatusCode).RetryAsync(3,
            //    (httpResponseMessage, i) =>
            //    {
            //        if (httpResponseMessage.Result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            //        {
            //            PerformReAuth();
            //        }
            //    });
            httpFallBack = Policy.HandleResult<HttpResponseMessage>(r => r.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                .FallbackAsync(new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    Content = new ObjectContent(cachenum.GetType(), cachenum, new JsonMediaTypeFormatter())
                });
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


            var retry = this.policyRegistry.Get<AsyncRetryPolicy<HttpResponseMessage>>("httpRetry");

            httpClient = GetHttpClient("");
            string requestEndPoint = $"api/inventory/{ id}";
            // HttpResponseMessage response = await httpFallBack.ExecuteAsync(() => httpRetry.ExecuteAsync(() => httpClient.GetAsync(requestEndPoint)));
            HttpResponseMessage response = await retry.ExecuteAsync(() => httpClient.GetAsync(requestEndPoint));

            //await httpFallBack.ExecuteAsync(() => httpRetry.ExecuteAsync(() =>
            //timeoutPolicy.ExecuteAsync(async token => await httpClient.GetAsync(requestEndPoint, token), CancellationToken.None))
            //);
            //var response = await httpRetry.ExecuteAsync(async () => await httpClient.GetAsync(requestEndPoint));
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
