using Exfob.Core.Interfaces.Repository;
using Exfob.Infrastructure;
using Exfob.Infrastructure.Repository;
using Exfob1.configs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Exfob1
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(setupAction =>
            {
                setupAction.Filters.Add
                (
                  new ProducesResponseTypeAttribute(StatusCodes.Status200OK));
                setupAction.Filters.Add
                (
                  new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));

                // var jsonOutPutFormatter = setupAction.OutputFormatters
                //.OfType<jsonou>()
            });

            services.AddControllers();


            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.ServiceMapping();
            if (_env.IsDevelopment())
            {
                services.AddDbContext<GestionBoisContext>(opts =>
                 opts.UseSqlServer(Configuration["ConnectionString:QuizzSqlAzure_dev"],
                 providerOptions => providerOptions.EnableRetryOnFailure())
                 );

                services.AddScoped(db =>
                {
                    var connection = new SqlConnection(Configuration["ConnectionString:QuizzSqlAzure_dev"]);
                    connection.Open();
                    return connection;
                });

            }
            else
            {
                services.AddDbContext<GestionBoisContext>(opts =>
                  opts.UseSqlServer(Configuration["ConnectionString:QuizzSqlAzure_dev"],
                  providerOptions => providerOptions.EnableRetryOnFailure())
                );

                services.AddScoped(db =>
                {
                    var connection = new SqlConnection(Configuration["ConnectionString:QuizzSqlAzure_dev"]);
                    connection.Open();
                    return connection;
                });

            }

            services.AddTransient(typeof(IGenericDapperRepository<>), typeof(GenericDapperRepository<>));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Exp Forestiere Service ",
                    Description = "RestFull Api Administration Service",
                    Version = "v1",
                    TermsOfService = new Uri("https://ex.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "SudSoft Inc",
                        Email = string.Empty,
                        Url = new Uri("https://sudsoft.com"),
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Expploitation Forestiere Service REst Administration v1");
                    c.RoutePrefix = string.Empty;

                });
            }
           
           
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
           
        }
    }
}
