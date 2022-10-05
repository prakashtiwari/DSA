using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ResiliencyTest
{
    public class ResiliencyPolicy
    {
        public AsyncRetryPolicy<HttpResponseMessage> httpRetryPolicy { get; set; }
        public RetryPolicy HttpTimeOutException { get; set; }
        public ResiliencyPolicy()
        {
            httpRetryPolicy = Policy.HandleResult<HttpResponseMessage>(ret => !ret.IsSuccessStatusCode)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(retryAttempt), (response, timespan) =>
                {
                    Console.WriteLine($"Response is {response},tomespan is:{ timespan}");
                });
            HttpTimeOutException = RetryPolicy.Handle<HttpRequestException>().WaitAndRetry(1, retryAttempt => TimeSpan.FromSeconds(retryAttempt));
        }

    }
}
