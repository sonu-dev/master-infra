using MassTransit;
using Master.Core.Host.Bases;
using Master.Microservices.Common.Bases.Cqrs;
using Master.Microservices.Common.Host.Extensions;
using Master.Microservices.Common.RabbitMq.Configurations;
using Master.Microservices.Common.RabbitMq.Producer;
using Master.Microservices.Orders.Consumers;
using Master.Microservices.Orders.DataAccess.Models;
using Master.Microservices.Orders.DataAccess.Repository;
using Master.Microservices.Orders.DataAccess.Services;
using Master.Microservices.Orders.Handlers.Order;
using Master.Microservices.Orders.Host.HostedServices;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Master.Microservices.Orders.Host
{
    public class Startup : ServiceStartupBase
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }

        #region ServiceStartupBase Members
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            ConfigureEfCore(services);
            RegisterServices(services);
            RegisterMassTransit(services);
            RegisterCqrsHandlers(services);
            services.AddHealthChecks();
            services.AddSwagger("OrdersService", "v1");
        }
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            base.Configure(app, env);          
            app.ConfigureSwagger("/swagger/v1/swagger.json", "Orders API");
        }
        public override void AddHostedService(IServiceCollection services)
        {
            services.AddHostedService<OrderHostedService>();
        }

        public override void ConfigureHealthCheckServices(IHealthChecksBuilder healthChecksBuilder)
        {
            base.ConfigureHealthCheckServices(healthChecksBuilder);
            healthChecksBuilder.AddSqlServer(Configuration.GetConnectionString("DbConnectionString"), name: "orders-service-db-sql", tags: new string[] { "Orders-Schema" });
        }
        #endregion

        #region Private Methods
        private void ConfigureEfCore(IServiceCollection services)
        {
            services.AddDbContext<OrderDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbConnectionString"),
                b => b.MigrationsAssembly("Master.Microservices.Orders.DataAccess")));
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
        }

        private void RegisterCqrsHandlers(IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateOrderCommandHandler).Assembly);
            services.AddScoped<IMediatorPublisher, MediatorPublisher>();
        }
        private void RegisterMassTransit(IServiceCollection services)
        {
            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumer<CreateOrderPaymentResponse>();
                cfg.SetKebabCaseEndpointNameFormatter();
                cfg.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(configure =>
                {
                    BusConfigurator.ConfigureBus(configure);
                    configure.ConfigureEndpoints(provider);
                }));
            });
            services.AddMassTransitHostedService();
            services.AddScoped<IQueueProducer, QueueProducer>();
        }
        #endregion
    }
}
