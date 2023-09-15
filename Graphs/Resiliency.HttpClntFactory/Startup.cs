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
using System.Net.Http;
using Polly.Retry;
using Polly.Registry;

namespace Resiliency.HttpClntFactory
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
            IPolicyRegistry<string> pollyRegistry = services.AddPolicyRegistry();
            IAsyncPolicy<HttpResponseMessage> simpleRetry = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode).RetryAsync(3);
            pollyRegistry.Add("SimpleRetry", simpleRetry);

            IAsyncPolicy<HttpResponseMessage> waitAndRetry = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode).WaitAndRetryAsync(3, sleep => TimeSpan.FromSeconds(20));
            pollyRegistry.Add("WaitAndRetry", waitAndRetry);

            IAsyncPolicy<HttpResponseMessage> noOpPolict = Policy.NoOpAsync().AsAsyncPolicy<HttpResponseMessage>();

            pollyRegistry.Add("noOp", noOpPolict);
            //IAsyncPolicy<HttpResponseMessage> asyncPolicy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode).RetryAsync(2);
            services.AddHttpClient("RemoteClient", client =>
            {
                client.BaseAddress = new Uri("http://localhost:24173/api/");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            }).AddPolicyHandlerFromRegistry(SelectPolicy);
            services.AddControllers();
        }

        private IAsyncPolicy<HttpResponseMessage> SelectPolicy(IReadOnlyPolicyRegistry<string> policyReg, HttpRequestMessage req)
        {

            if (req.Method == HttpMethod.Get)
            {
                return policyReg.Get<IAsyncPolicy<HttpResponseMessage>>("SimpleRetry");
            }
            else if (req.Method == HttpMethod.Post)
            {
                //Post is not idempotent
                return policyReg.Get<IAsyncPolicy<HttpResponseMessage>>("noOp");
            }
            else
            {
                return policyReg.Get<IAsyncPolicy<HttpResponseMessage>>("WaitAndRetry");
            }

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
