using Master.Core.Host.Bases;
using Master.Microservices.Catalog.DataAccess.Models;
using Master.Microservices.Catalog.DataAccess.Repository;
using Master.Microservices.Catalog.DataAccess.Services;
using Master.Microservices.Catalog.Handlers.Queries;
using Master.Microservices.Catalog.Host.HostedServices;
using Master.Microservices.Common.Bases.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using static Master.Microservices.Catalog.Handlers.Queries.GetAllCategoriesQuery;

namespace Master.Microservices.Catalog.Host
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
            services.AddHostedService<CatalogHostedService>();
        }

        #endregion

        #region Private Methods
        private void ConfigureEfCore(IServiceCollection services)
        {
            services.AddDbContext<CatalogDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbConnectionString"),
                b => b.MigrationsAssembly("Master.Microservices.Catalog.DataAccess")));          
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICatalogService, CatalogService>();
        }

        private void RegisterCqrsHandlers(IServiceCollection services)
        {
            services.AddMediatR(typeof(GetAllCategoriesQuery).Assembly);
            services.AddScoped<IMediatorPublisher, MediatorPublisher>();
            services.AddScoped<GetAllCategoriesQueryHandler>();
        }
        #endregion
    }
}
