using MassTransit;
using Master.Core.Host.Bases;
using Master.Microservices.Common.Constants;
using Master.Microservices.Common.Dapper;
using Master.Microservices.Common.Host.Extensions;
using Master.Microservices.Common.Identity;
using Master.Microservices.Common.RabbitMq.Configurations;
using Master.Microservices.Common.RabbitMq.Producer;
using Master.Microservices.Payments.Consumers;
using Master.Microservices.Payments.DataAccess.Services;
using Master.Microservices.Payments.Host.HostedServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Master.Microservices.Payments.Host
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
            services.AddControllers();
            ConfigureDapper(services);          
            RegisterServices(services);
            RegisterMassTransit(services);
            services.AddSwagger("PaymentsService", "v1");
            services.AddIdentity(Configuration, new List<IdentityClaim>
            {
                new IdentityClaim(IdentityConstants.ClaimTypes.Scope, "api"),
                new IdentityClaim(IdentityConstants.ClaimTypes.ClientId, "paymentsApiClient")
            });
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            base.Configure(app, env);
            app.ConfigureSwagger("v1/swagger.json", "PaymentService API V1");           
        }

        public override void AddHostedService(IServiceCollection services)
        {
            services.AddHostedService<PaymentHostedService>();
        }

        public override void ConfigureHealthCheckServices(IHealthChecksBuilder healthChecksBuilder)
        {
            base.ConfigureHealthCheckServices(healthChecksBuilder);
            healthChecksBuilder.AddSqlServer(Configuration.GetConnectionString("DbConnectionString"), name: "payments-service-db-sql", tags: new string[] { "Payments-Schema" });
        }

        #endregion

        #region Private Methods
        private void ConfigureDapper(IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
        }
      
        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IPaymentService, PaymentService>();
        }
        private void RegisterMassTransit(IServiceCollection services)
        {
            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumer<CreateOrderPaymentConsumer>();
                cfg.SetKebabCaseEndpointNameFormatter();
                cfg.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(configure =>
                {
                    BusConfigurator.ConfigureBus(configure);
                    configure.ConfigureEndpoints(provider);
                }));
            });

            services.AddMassTransitHostedService();
            services.AddSingleton<IQueueProducer, QueueProducer>();
        }
        #endregion
    }
}
