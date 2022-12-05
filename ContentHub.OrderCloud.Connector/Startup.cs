using ContentHub.OrderCloud.Connector.Repositories;
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

using Newtonsoft.Json;
using ContentHub.OrderCloud.Connector.Helper;
using Microsoft.Extensions.Azure;
using ContentHub.OrderCloud.Connector.Services;

namespace ContentHub.OrderCloud.Connector
{
    public class Startup
    {
        private readonly AppSettings settings;

        public Startup(AppSettings settings)
        {
            this.settings = settings;
        }
        public IConfiguration Configuration { get; }
        public static Dictionary<string, string> ProductMapping { get; private set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ContentHub.OrderCloud.Connector", Version = "v1" });
            }).AddSingleton(x => settings.ContentHubSettings)
            .AddSingleton(x => settings.OrderCloudSettings);
            services.AddScoped<IEntitySyncRepository, EntitySyncRepository>();
            services.AddScoped<IContentHubService, ContentHubService>();
            services.AddScoped<IOrdercloudService, OrdercloudService>();
          
           
            services.AddAzureClients(builder =>
            {
                builder.AddServiceBusClient(Configuration.GetConnectionString("ServiceBus"));
            });
          
            // ProductMapping = Configuration.GetSection("ProductFieldsMapping").Get<Dictionary<string, string>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ContentHub.OrderCloud.Connector v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                               .Build();
            config.Bind(settings);
        }
    }
}
