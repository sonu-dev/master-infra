using Master.Core.Host.Bases;
using Microsoft.AspNetCore.Hosting;

namespace Master.Microservices.Identity
{
    public class IdentityServiceHost : ServiceHostBase
    {
        public override string ServiceName => "IdentityServiceProvider";
        public override void ConfigureWebHost(IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseStartup<Startup>();
        }
    }
}
