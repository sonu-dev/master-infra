using Master.Common.Bases;
using Master.Common.Host;
using Master.DesignPatterns.Behavioral;
using Master.DesignPatterns.Creational;
using Microsoft.Extensions.DependencyInjection;

namespace Master.DesignPatterns.Client.Host
{
    public class DesignPatternsHost : GenericHostBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.AddTransient<IClient, SingletonClient>();
            services.AddTransient<IClient, TemplateMethodClient>();            
        }

        public override void AddHostedService(IServiceCollection services)
        {
            services.AddHostedService<DesignPatternsHostedService>();
        }
    }
}
