using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;
using Trainig_Project.Contexts;
using Trainning_Project.Model;
using Microsoft.EntityFrameworkCore;

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
            var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=MachinesAssetDB;Trusted_Connection=True;";
            services.AddDbContext<MachineAssetsContexts>(o =>
            {
                o.UseSqlServer(connectionString);
            });
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("TrainingProjectApiAssets", new Microsoft.OpenApi.Models.OpenApiInfo

                {
                    Title = "Trainingprojectapi(Assets)",
                    Version = "1",
                    Description="This API is About Assets"
                });
                setupAction.SwaggerDoc("TrainingProjectApiMachines", new Microsoft.OpenApi.Models.OpenApiInfo

                {
                    Title = "Trainingprojectapi(Machines)",
                    Version = "1",
                    Description = "This API is About Machines"
                });
                setupAction.SwaggerDoc("TrainingProjectApiMachineAssets", new Microsoft.OpenApi.Models.OpenApiInfo

                {
                    Title = "Trainingprojectapi(MachineAssets)",
                    Version = "1",
                    Description = "This API is About MachinesAssets"
                });

                var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);
                setupAction.IncludeXmlComments(xmlFullPath, includeControllerXmlComments: true);
                
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
                setupAction.SwaggerEndpoint("/Swagger/TrainingProjectApiAssets/Swagger.Json", "Trainingprojectapi(Assets)");
                setupAction.SwaggerEndpoint("/Swagger/TrainingProjectApiMachines/Swagger.Json", "Trainingprojectapi()");
                setupAction.SwaggerEndpoint("/Swagger/TrainingProjectApiMachineAssets/Swagger.Json", "Trainingprojectapi(MachineAssets)");
            });
            app.UseMvc();
        }
    }
}
