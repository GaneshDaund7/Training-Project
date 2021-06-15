using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;
using Trainning_Project.Model;

namespace Trainig_Project
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
            services.AddControllersWithViews();

            services.AddMvc(o =>
            {
                o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                o.EnableEndpointRouting = false;

            });

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("TrainingProjectApiSpecification", new Microsoft.OpenApi.Models.OpenApiInfo

                {
                    Title = "Trainingprojectapi",
                    Version = "1"
                });

                var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);
                setupAction.IncludeXmlComments(xmlFullPath);
            });
            services.AddScoped<IMachineAssetRepository, MachineAssetRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.UseStatusCodePages();
            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/Swagger/TrainingProjectApiSpecification/Swagger.Json", "Trainingprojectapi");
            });
            app.UseMvc();
        }
    }
}
