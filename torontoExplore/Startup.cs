using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace torontoExplore
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup (IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/error.html");

            if(configuration.GetValue<bool>("EnableDeveloperExceptions"))
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // error handling

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.Contains("invalid"))
                    throw new Exception("Error");
                await next();
            });

            app.UseFileServer();

/*            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });*/
        }
    }
}
