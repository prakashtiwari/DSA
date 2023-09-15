using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Bulkhead;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Resiliency.BulkHead
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
            AsyncBulkheadPolicy<HttpResponseMessage> bulkheadPolicy = Policy.BulkheadAsync<HttpResponseMessage>(1, 4, onBulkheadRejectedAsync: OnBulkheadRejectedAsync);

            HttpClient httpClient = new HttpClient()
            {

                BaseAddress = new Uri("http://localhost:10278/api/")
            };
            
            services.AddSingleton<HttpClient>(httpClient);
            services.AddSingleton<AsyncBulkheadPolicy<HttpResponseMessage>>(bulkheadPolicy);
            services.AddControllers();
        }
        private Task OnBulkheadRejectedAsync(Context context)
        {
            Console.WriteLine("Polly OnBulkheadRejectedAsync executed");
            return Task.CompletedTask;
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
    }
}
