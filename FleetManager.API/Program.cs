using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManager.API
{

    // this initilaizes Dep injection, logging, config, 
    // setup IHostedService
    //
    // it is all defined in code to support cross-platform aspect
    //
    // it is the veneer over the runtime (exec service on windows, daemon on linux)
    // see: MSDN for moar
    public class Program
    {
        // entrypoint to code
        public static void Main(string[] args)
        {
            // create host, build and run
            // Build comes from IHostBuilder
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // we don't instantiate Startup class - we pass it as generic type arg
                    // the methods in Startup (ConfigureSDervices, Configure) will be called
                    // uses reflection mechanism (can google it, a way of determining methods of a class automagically)
                    // typical IoC pattern, container
                    webBuilder.UseStartup<Startup>();
                });
    }
}
