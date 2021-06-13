using Lib.CoreImpl;
using Lib.Interfaces;
using Lib.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCaching;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiphyAssignment
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
            services.AddResponseCaching();
            services.AddControllers();

            services.AddSingleton<IGiphySearchSetup>(sp => new GiphySearchSetup(apiUrl : Configuration["GiphyApi:Url"], apiKey : Configuration["GiphyApi:Key"], limit: Configuration["GiphyApi:SearchSetup:Limit"], rating: Configuration["GiphyApi:SearchSetup:Rating"]));
            services.AddSingleton<IGiphySearchService, GiphySearchService>();
            services.AddSingleton<IGiphySearchEngine, GiphySearchImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseResponseCaching();
            app.Use(async (context, next) =>
            {
                var rcf = context.Features.Get<IResponseCachingFeature>();
                rcf.VaryByQueryKeys = new[] { "searchCriterion" };

                await next();
            });
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
