using Master.Core.Host.Bases;
using Microsoft.AspNetCore.Hosting;

namespace Master.Microservices.Orders.Host
{
    public class OrderServiceHost : ServiceHostBase
    {
        public override string ServiceName => "OrderService";
        public override void ConfigureWebHost(IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseStartup<Startup>();
        }
    }
}
