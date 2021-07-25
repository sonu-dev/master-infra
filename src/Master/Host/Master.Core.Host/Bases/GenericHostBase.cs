using Master.Core.Host.Extensions;
using Master.Core.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;

namespace Master.Core.Host.Bases
{
    public abstract class GenericHostBase 
    {
        public IHostBuilder BuildHost(string[] args)
        {
            return new HostBuilder()
                .ConfigureHostConfiguration(configure =>
                {
                    ConfigureHostConfiguration(configure, args);
                })
                .ConfigureAppConfiguration(configure =>
                {
                    ConfigureAppConfiguration(configure, args);
                })
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(services, context.Configuration);
                })
                .UseSerilog(LogManager.LoadLogger())
                .UseConsoleLifetime();
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
        public virtual void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {          
            ConfigureOptions(services);
            AddHostedService(services);
            services.ConfigureCommonServices();
        }

        public virtual void ConfigureOptions(IServiceCollection services)
        {
            services.AddOptions();
        }
        #endregion

        #region Abstract Members
        public abstract void AddHostedService(IServiceCollection services);
        #endregion
    }
}
