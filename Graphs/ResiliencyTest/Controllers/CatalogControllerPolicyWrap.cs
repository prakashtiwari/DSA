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
using Polly.Wrap;

namespace ResiliencyTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogPolicyWrapController : ControllerBase
    {
        int cachedResult = 0;
        HttpClient httpClient;
        private readonly AsyncTimeoutPolicy<HttpResponseMessage> timeOutPolicy;
        private readonly AsyncRetryPolicy<HttpResponseMessage> retryPolicy;
        private readonly AsyncFallbackPolicy<HttpResponseMessage> fallBAck;
        private readonly AsyncPolicyWrap<HttpResponseMessage> policyWrap;
        public CatalogPolicyWrapController()
        {
            timeOutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(1, onTimeoutAsync: OnTimeoutDelegate);
            retryPolicy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode).Or<TimeoutRejectedException>().RetryAsync(3, onRetry: OnRetry);
            fallBAck = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode).Or<TimeoutRejectedException>()
                .FallbackAsync(new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    Content = new ObjectContent(cachedResult.GetType(), cachedResult, new JsonMediaTypeFormatter())
                }, onFallbackAsync: OnFallbackAsyncDelegate);
            //way 2 of wrapping;
            policyWrap = PolicyWrap.WrapAsync<HttpResponseMessage>(fallBAck, retryPolicy, timeOutPolicy); //fallBAck.WrapAsync(timeOutPolicy.WrapAsync(timeOutPolicy));

        }
        private void OnRetry(DelegateResult<HttpResponseMessage> delegateResult, int retryCount, Context context)
        {
            if (context.Contains("Host"))
            {

                Console.WriteLine("Host is" + context["Host"]);
            }

            if (delegateResult.Exception is HttpRequestException)
            {
                if (delegateResult.Exception.Message == "The operation timed out")
                {

                }
            }
        }
        private Task OnTimeoutDelegate(Context context, TimeSpan span, Task arg3)
        {
            return Task.CompletedTask;
        }

        private Task OnFallbackAsyncDelegate(DelegateResult<HttpResponseMessage> delegateResult, Context context)
        {
            return Task.CompletedTask;
        }
        private void PerformReAuth()
        {
            httpClient = GetHttpClient("GoodRequest");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            httpClient = GetHttpClient("");
            string requestEndPoint = $"api/inventory/{ id}";
            var host = Request.Headers.FirstOrDefault(h => h.Key == "Host").Value;
            var userAgent = Request.Headers.FirstOrDefault(h => h.Key == "User-Agent").Value;
            IDictionary<string, Object> cont = new Dictionary<string, Object>();
            cont.Add("Host", host);
            cont.Add("User-Agent", userAgent);
            Context contxt = new Context("PolicyContext", cont);
            AsyncRetryPolicy<HttpResponseMessage> retryPolicty = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .RetryAsync(3, onRetry: (httpResponse, retryCount, context) =>
                {
                    if (context.Contains("Host"))
                    {

                        Console.WriteLine("Host is" + context["Host"]);
                    }
                });

            // HttpResponseMessage response = await httpFallBack.ExecuteAsync(() => httpRetry.ExecuteAsync(() => httpClient.GetAsync(requestEndPoint)));
            //  HttpResponseMessage response = await policyWrap.ExecuteAsync(async token => await httpClient.GetAsync(requestEndPoint, token), CancellationToken.None);
            HttpResponseMessage response = await retryPolicty.ExecuteAsync(action: action => httpClient.GetAsync(requestEndPoint),context: contxt);


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
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;

        }
    }
}
