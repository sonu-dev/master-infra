using Master.Core.Host.Bases;
using Master.Microservices.Common.Bases.Cqrs;
using Master.Microservices.Orders.DataAccess.Models;
using Master.Microservices.Orders.DataAccess.Repository;
using Master.Microservices.Orders.DataAccess.Services;
using Master.Microservices.Orders.Handlers.Order;
using Master.Microservices.Orders.Host.HostedServices;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Master.Microservices.Orders.Host
{
    public class Startup : ServiceStartupBase
    {
        public Startup(IConfiguration configuration): base(configuration)
        {            
        }

        #region ApplicationStartupBase Members
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);           
            ConfigureEfCore(services);
            RegisterServices(services);
            RegisterCqrsHandlers(services);
        }

        public override void AddHostedService(IServiceCollection services)
        {
            services.AddHostedService<OrderHostedService>();
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
            services.AddMediatR(typeof(OrderCommandHandler).Assembly);
            services.AddScoped<IMediatorPublisher, MediatorPublisher>();
        }
        #endregion
    }
}
