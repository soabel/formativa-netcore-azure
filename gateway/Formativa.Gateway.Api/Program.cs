using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Formativa.Gateway.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //    .ConfigureLogging((hostingContext, logging) => {
        //        logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        //        logging.AddConsole();
        //        logging.AddDebug();
        //        logging.AddEventSourceLogger();
        //    })
        //    .ConfigureAppConfiguration((hostingContext, config) =>
        //    {
        //        config
        //            .AddJsonFile("configuration.json")
        //            .AddEnvironmentVariables();
        //    })
        //    .UseStartup<Startup>();



        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config
                        .AddJsonFile("configuration.json")
                        .AddEnvironmentVariables();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
