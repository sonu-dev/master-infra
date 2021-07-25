using Master.Core.Host.Bases;
using Master.Microservices.Order.Host;
using Microsoft.AspNetCore.Hosting;

namespace Master.Microservices.Orders.Host
{
    public class OrdersServiceHost : ServiceHostBase
    {
        public override string ServiceName => "OrdersService";
        public override void ConfigureWebHost(IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseStartup<Startup>();
        }
    }
}
