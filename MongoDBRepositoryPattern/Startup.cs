using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDAL.DataAccess;
using MongoDAL.Mongo.Context;
using MongoDAL.Mongo.UnitOfWork;
using MongoServices;
using Swashbuckle.AspNetCore.Swagger;

namespace MongoDBRepositoryPattern
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "StoreAPI", Version = "v1" });

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "storeAPI.xml");
                c.IncludeXmlComments(filePath);

            });

            //Register Services
            RegisterServices(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            //Enable middleware to serve generated Swagger as JSON endpoint.
            app.UseSwagger();

            //Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.).
            //Specifying the Swagger JSON endpoint

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Store API v1");
            });
        }

        public void RegisterServices(IServiceCollection services)
        {
            //MongoDB Base
            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Repositories
            services.AddScoped<ICustomRepository, CustomRepository>();
            services.AddScoped<ICustomService, CustomService>();
        }
    }
}
