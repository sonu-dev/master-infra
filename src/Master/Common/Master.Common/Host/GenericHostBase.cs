using Master.Common.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;

namespace Master.Common.Host
{
    public abstract class GenericHostBase 
    {
        public IHost BuildHost(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureHostConfiguration(configure =>
                {
                    ConfigureHostConfiguration(configure, args);
                })
                .ConfigureAppConfiguration(configure =>
                {
                    ConfigureAppConfiguration(configure, args);
                })
                .ConfigureServices(services =>
                {
                    ConfigureServices(services);
                })                
                .UseSerilog(LogManager.LoadLogger())
                .UseConsoleLifetime().Build();
            return builder;
        }

        #region Virtual Members
        public virtual void ConfigureHostConfiguration(IConfigurationBuilder configure, string[] args)
        {
            configure.SetBasePath(Directory.GetCurrentDirectory());            
            configure.AddCommandLine(args);
        }
        public virtual void ConfigureAppConfiguration(IConfigurationBuilder configure, string[] args)
        {
            configure.AddJsonFile("appsettings.json", optional: true);
            configure.AddEnvironmentVariables();

            if (args != null)
            {
                configure.AddCommandLine(args);
            }
        }
        public virtual void ConfigureServices(IServiceCollection services)
        {
            // Adding Common Services
            services.AddOptions();
            AddHostedService(services);
            services.AddSingleton(typeof(ILog<>), typeof(Log<>));
        }
        #endregion

        #region Abstract Members
        public abstract void AddHostedService(IServiceCollection services);
        #endregion
    }
}
