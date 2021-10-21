using Master.Core.Host.Bases;
using Master.Microservices.Common.Bases.Cqrs;
using Master.Microservices.Payments.DataAccess.Models;
using Master.Microservices.Payments.Host.HostedServices;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Plain.RabbitMQ;

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
            ConfigureEfCore(services);
            ConfigureRabbitMq(services);
            RegisterServices(services);
            RegisterCqrsHandlers(services);
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
        private void ConfigureEfCore(IServiceCollection services)
        {
            services.AddDbContext<PaymentDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbConnectionString"),
                b => b.MigrationsAssembly("Master.Microservices.Payments.DataAccess")));
        }

        private void ConfigureRabbitMq(IServiceCollection services)
        {
           // services.AddSingleton<IConnectionProvider>(new ConnectionProvider(Configuration.GetValue<string>("RabbitMqConnection")));
        }

        private void RegisterServices(IServiceCollection services)
        {
           
        }

        private void RegisterCqrsHandlers(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddScoped<IMediatorPublisher, MediatorPublisher>();
        }
        #endregion
    }
}
