using HealthChecks.UI.Client;
using Master.Core.Host.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Master.Core.Host.Bases
{
    public abstract class ServiceStartupBase
    {
        public IConfiguration Configuration { get; }
        public ServiceStartupBase(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #region Virtual Members

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(); 
           // services.AddHealthChecks();
            services.ConfigureCommonServices();
            ConfigureOptions(services);
        }

        public virtual void ConfigureOptions(IServiceCollection services)
        {
            services.AddOptions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSerilogRequestLogging();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
               /* app.UseHealthChecks("/hc", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });*/
            });
        }
        #endregion

        #region Abstract Members
        public abstract void AddHostedService(IServiceCollection services);
        #endregion
    }
}
