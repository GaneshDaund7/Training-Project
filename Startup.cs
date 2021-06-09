using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;

namespace CityInfo.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        // read values from app settings.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddMvcOptions(o =>
            {
                o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                
            });

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("TrainingProjectApiSpecification", new Microsoft.OpenApi.Models.OpenApiInfo

                {
                    Title = "Trainingprojectapi",
                    Version="1"
                }
                    );
                

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseSwagger();
            app.UseSwaggerUI(setupAction=> {
                setupAction.SwaggerEndpoint("/Swagger/TrainingProjectApiSpecification/Swagger.Json", "Trainingprojectapi");
            });
            app.UseMvc();
        
        }
    }
}
