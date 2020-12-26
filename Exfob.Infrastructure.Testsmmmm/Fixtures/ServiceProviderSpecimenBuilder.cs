using AutoFixture.Kernel;
using Exfob1;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Exfob.Infrastructure.Tests.Fixtures
{
    public class ServiceProviderSpecimenBuilder : ISpecimenBuilder, IDisposable
    {
        private readonly IServiceScope _serviceScope;
        private IConfigurationRoot Configuration { get; set; }
        public ServiceProviderSpecimenBuilder()
        {
            // var sqlTableOptions = new SqlTablesOptions();
            //var projectDir = Directory.GetCurrentDirectory();
            //var configPath = Path.Combine(projectDir, "appsettings.json");
            var factory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(conf =>
                {
                    conf.ConfigureAppConfiguration((context, conf) =>
                    {
                       // conf.AddJsonFile(configPath);
                        Configuration = conf.Build();
                    });

                    conf.ConfigureServices((context, services) =>
                    {
                       // services.AddScoped(provider => new SqlFormVariablesRepositor
                    });

                    });
            _serviceScope = factory.Services.CreateScope();
        }
        public object Create(object request, ISpecimenContext context)
        {
            if (!(request is ParameterInfo type)) return new NoSpecimen();

            var instance = _serviceScope.ServiceProvider.GetService(type.ParameterType);
            if (instance == null) return new NoSpecimen();

            return instance;
        }

        public void Dispose()
        {
            _serviceScope.Dispose();
        }
    }
}
