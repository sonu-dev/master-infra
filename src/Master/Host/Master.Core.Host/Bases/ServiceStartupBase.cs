﻿using HealthChecks.UI.Client;
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
        public readonly IConfiguration Configuration;
        public ServiceStartupBase(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #region Virtual Members

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {           
            services.ConfigureCommonServices();
            ConfigureHealthCheckServices(services.AddHealthChecks());
            ConfigureOptions(services);
            AddHostedService(services);
        }

        public virtual void ConfigureOptions(IServiceCollection services)
        {
            services.AddOptions();
        }

        public virtual void ConfigureHealthCheckServices(IHealthChecksBuilder healthChecksBuilder)
        {

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
            app.UseSerilogRequestLogging();
            app.UseStaticFiles();  
            ConfigureHealthChecks(app);            
        }
        #endregion

        #region Abstract Members
        public abstract void AddHostedService(IServiceCollection services);
        #endregion

        #region Private Methods
        private void ConfigureHealthChecks(IApplicationBuilder app)
        {
            // HealthCheck middleware
            app.UseHealthChecks("/hc", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        }
        #endregion
    }
}
