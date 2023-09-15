using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Polly;
using Polly.CircuitBreaker;
using System.Net.Http;

namespace CircuitBreakerTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            HttpClient httpClient = new HttpClient()
            {

                BaseAddress = new Uri("http://localhost:60371/api/")
            };
            AsyncCircuitBreakerPolicy<HttpResponseMessage> circuitBreakerPolicy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .CircuitBreakerAsync(2, TimeSpan.FromSeconds(20), OnBreak, onReset: OnReset, onHalfOpen: OnHalfOpen);
            services.AddSingleton<AsyncCircuitBreakerPolicy<HttpResponseMessage>>(circuitBreakerPolicy);
            services.AddSingleton<HttpClient>(httpClient);
            services.AddControllers();
        }
        private void OnBreak(DelegateResult<HttpResponseMessage> delegateResult, TimeSpan tSpan)
        {
            Console.WriteLine($"Timespan is {tSpan}");
        }
        private void OnReset()
        {
        }
        private void OnHalfOpen()
        {
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
