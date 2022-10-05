using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Polly.Registry;
using Polly;
using Polly.Retry;
using System.Net.Http;
using Microsoft.Extensions.Caching.Memory;
using Polly.Caching.MemoryCache;
using Polly.Caching;

namespace ResiliencyTest
{
    public class Startup
    {
        IPolicyRegistry<string> registry;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            registry = new PolicyRegistry();
            HttpClient httpClient = new HttpClient()
            {

                BaseAddress = new Uri("http://localhost:4153/api/")
            };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            services.AddSingleton<HttpClient>(httpClient);
            services.AddMemoryCache();
            services.AddSingleton<Polly.Caching.IAsyncCacheProvider, Polly.Caching.Memory.MemoryCacheProvider>();
            services.AddSingleton(registry);
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IAsyncCacheProvider cacheProvider)
        {
            //Caching the response for 50 Seconds
           AsyncCachePolicy<HttpResponseMessage> cachePolicy = Policy.CacheAsync<HttpResponseMessage>(cacheProvider, TimeSpan.FromSeconds(50));


            registry.Add("cachePolicy", cachePolicy);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private PolicyRegistry GetPolicyRegistry()
        {
            PolicyRegistry keyValuePairs = new PolicyRegistry();
            var httpRetryPolicy = Policy.HandleResult<HttpResponseMessage>(ret => !ret.IsSuccessStatusCode)
                 .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(retryAttempt), (response, timespan) =>
                 {
                     Console.WriteLine($"Response is {response},tomespan is:{ timespan}");
                 });
            var HttpTimeOutException = RetryPolicy.Handle<HttpRequestException>().WaitAndRetry(1, retryAttempt => TimeSpan.FromSeconds(retryAttempt));

            keyValuePairs.Add("httpRetry", httpRetryPolicy);
            keyValuePairs.Add("httpException", HttpTimeOutException);
            return keyValuePairs;
        }
    }
}
