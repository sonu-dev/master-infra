using Master.Core.Host.Bases;
using Microsoft.AspNetCore.Hosting;

namespace Master.Microservices.Payments.Host
{
    public class PaymentServiceHost : ServiceHostBase
    {
        public override string ServiceName => "PaymentService";
        public override void ConfigureWebHost(IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseStartup<Startup>();
        }
    }
}