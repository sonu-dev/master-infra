using Master.Core.Host.Bases;
using Master.Microservices.Identity.Data;
using Master.Microservices.Identity.HostServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Master.Microservices.Identity
{
    public class Startup : ServiceStartupBase
    {
        public Startup(IConfiguration configuration): base(configuration)
        {          
        }       

        #region ServiceStartupBase Members
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.AddRouting();           
            //services.AddControllersWithViews();           
            ConfigureIdentityServer(services);
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           // base.Configure(app, env);           
            app.UseIdentityServer();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
        public override void AddHostedService(IServiceCollection services)
        {
            services.AddHostedService<IdentityHostedService>();
        }
        #endregion


        #region Private Methods 
        private void ConfigureIdentityServer(IServiceCollection services)
        {
            var builder = services.AddIdentityServer()
               .AddInMemoryClients(IdentityManager.GetClients())
               .AddInMemoryApiScopes(IdentityManager.GetApiScopes());               

            builder.AddDeveloperSigningCredential(); //This is for dev only scenarios when you don’t have a certificate to use.
        }
        #endregion       
    }
}
