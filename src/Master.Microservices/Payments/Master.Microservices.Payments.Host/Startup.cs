using MassTransit;
using Master.Core.Host.Bases;
using Master.Microservices.Common.Constants;
using Master.Microservices.Common.Dapper;
using Master.Microservices.Common.RabbitMq.Constants;
using Master.Microservices.Common.RabbitMq.Host;
using Master.Microservices.Common.RabbitMq.Producer;
using Master.Microservices.Payments.Consumers;
using Master.Microservices.Payments.DataAccess.Services;
using Master.Microservices.Payments.Host.HostedServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

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
            ConfigureDapper(services);          
            RegisterServices(services);
            services.RegisterMassTransit();
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
            services.AddMassTransit(x =>
            {
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(confiure =>
                {                   
                    confiure.Host(new Uri(RabbitMqConfigurations.RabbitMqUri), h =>
                    {
                        h.Username(RabbitMqConfigurations.UserName);
                        h.Password(RabbitMqConfigurations.Password);
                    });

                    confiure.ReceiveEndpoint(QueueNames.OrderPaymentQueue, c =>
                    {
                        c.PrefetchCount = 20;
                        c.ConfigureConsumer<CreateOrderPaymentConsumer>(provider);
                    });
                }));
            });

            services.AddMassTransitHostedService();
            services.AddSingleton<IQueueProducer, QueueProducer>();
        }
        #endregion
    }
}
