using Master.Core.Host.Bases;
using Microsoft.AspNetCore.Hosting;

namespace Master.Microservices.Orders.Host
{
    public class CatalogServiceHost : ServiceHostBase
    {
        public override string ServiceName => "CatalogService";
        public override void ConfigureWebHost(IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseStartup<Startup>();
        }
    }
}
