using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManager.API
{
    // middleware in here
    // name "Startup" is naming convention, can call it something else!
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // dep inj stuff, logic pr0viding some contract or functionality
        // entry point for dep inj mechanisms
        // setup the container
        // we register all services here
        // IoC
        // eg. 
        // TODO
        // try to understand the diff between AddScoped, AddTransient and AddSingleton
        // see if there is real-world examples
        //
        //
        // then
        // * add some simple authorization (maybe a key)
        // * add UnitTest project and write some simple tests for the controllers
        // focus on guidelines for happy/unhappy path -  see examples in Piotr code
        // https://github.com/PioterB/NetCoreWebApi20210218
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FleetManager.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // this is where middleware is confiugured and applied - what and when
        // how your server will behave and process HTTP requests
        // eg. middleware registration
        //
        // the variable app is given by the IHostBuilder hostbuilder
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FleetManager.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // can slot in your own custom middlewares here
            app.UseTimestampMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
