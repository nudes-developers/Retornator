using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Nudes.Retornator.AspnetCore;
using Nudes.Retornator.Sample.Configuration;
using Nudes.Retornator.Sample.Errors;
using Nudes.Retornator.Sample.Features.Values.Errors;

namespace Nudes.Retornator.Sample
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
            ///There are 4 ways to register the response manager and his errors:

            ///Creating one, registering errors and passing it to AddResponseManager:
            //ResponseManager responseManager = new ResponseManager();
            //responseManager.RegisterError<NotFoundError>(error => System.Net.HttpStatusCode.NotFound);
            //services.AddResponseManager(responseManager);

            ///Invoking AddResponseManager (which returns a new already registered ResponseManager) and then registering errors:
            //services.AddResponseManager()
            //  .RegisterError<NotFoundError>(error => System.Net.HttpStatusCode.NotFound);


            ///Creating one and passing it along with a type who inherits from ResponseManagerConfigurator and knows how to register errors:
            //ResponseManager responseManager = new ResponseManager();
            //services.AddResponseManager<SampleResponseManagerConfigurator>(responseManager);


            ///Invoking AddResponseManager passing a type who inherits from ResponseManagerConfigurator and knows how to register errors (thats what we'll use):
            
            services.AddResponseManager<SampleResponseManagerConfigurator>();

            // Retornator uses the default json serializer since aspnetcore 3.1 so we need to inject it separatedly
            services.AddSingleton<JsonSerializerOptions>(new JsonSerializerOptions
            {
                 IgnoreNullValues = true,
                  WriteIndented = true,
            });

            services.AddControllers().AddRetornator();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
