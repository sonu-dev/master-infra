using Master.Core.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using GenericHost = Microsoft.Extensions.Hosting.Host;

namespace Master.Core.Host.Bases
{
    public abstract class ServiceHostBase
    {
        public void Run(string[] args)
        {
            Console.Title = ServiceName;

            //Read Configuration from appSettings
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            //Initialize Logger 
            Log.Logger = LogManager.LoadLogger();
            try
            {
                Log.Information($"{ServiceName} Starting.");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "The Application failed to start.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private IHostBuilder CreateHostBuilder(string[] args)
        {
            return GenericHost.CreateDefaultBuilder(args)              
               .ConfigureWebHostDefaults(webHostBuilder =>
               {
                   ConfigureWebHost(webHostBuilder);
               })
               .UseSerilog((hostingContext, loggerConfiguration) =>
            loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration)); //Uses Serilog instead of default .NET Logger
        }

        public abstract string ServiceName { get; }
        public abstract void ConfigureWebHost(IWebHostBuilder webHostBuilder);
    }
}
