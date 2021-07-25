using Master.Core.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Master.Core.Host.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureCommonServices(this IServiceCollection services)
        {
            services.AddSingleton(typeof(ILog<>), typeof(Log<>));
        }
    }
}
