using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
namespace ContentHub.OrderCloud.Connector
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Links to an Azure App Configuration resource that holds the app settings.
            // Set this in your visual studio Env Variables.
            var appConfigConnectionString = Environment.GetEnvironmentVariable("APP_CONFIG_CONNECTION");

            WebHost.CreateDefaultBuilder(args)
                .UseDefaultServiceProvider(options => options.ValidateScopes = false)
                .ConfigureAppConfiguration((context, config) =>
                {
                    if (appConfigConnectionString != null)
                    {
                       // config.AddAzureAppConfiguration(appConfigConnectionString);
                    }

                    config.AddJsonFile("appSettings.json", optional: true);
                })
                .UseStartup<Startup>()
                .ConfigureServices((ctx, services) =>
                {
                    services.Configure<AppSettings>(ctx.Configuration);
                    services.AddTransient(sp => sp.GetService<IOptionsSnapshot<AppSettings>>().Value);
                })
                .Build()
                .Run();
        }

       
    }
}
