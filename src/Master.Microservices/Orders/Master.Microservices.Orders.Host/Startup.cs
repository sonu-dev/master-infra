using Master.Core.Host.Bases;
using Master.Microservices.Orders.DataAccess.Models;
using Master.Microservices.Orders.DataAccess.Repository;
using Master.Microservices.Orders.Host.HostedServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Master.Microservices.Order.Host
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

            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
        }

        public override void AddHostedService(IServiceCollection services)
        {
            services.AddHostedService<OrdersHostedService>();
        }

        #endregion

        #region Private Methods
        private void ConfigureEfCore(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DbConnectionString");
            services.AddDbContext<OrdersDataContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Master.Microservices.Orders.DataAccess")));
          
        }
        #endregion
    }
}
