using Master.Core.Logging;
using Master.Microservices.Catalog.DataAccess.Models;
using Master.Microservices.Catalog.DataAccess.Services;
using Master.Microservices.Common.Bases;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Microservices.Catalog.DataAccess.Repository
{
    public class CatalogService : ServiceBase<CatalogService, CatalogDataContext>, ICatalogService
    {
       
        public CatalogService(ILog<CatalogService> log, CatalogDataContext dataContext) 
            : base(log, dataContext)
        {
        }

        public async Task<List<ProductCategory>> GetCategoriesAsync()
        {
            return await DataContext.Set<ProductCategory>().ToListAsync();
        }

        public async Task<ProductCategory> GetCategoryByIdAsync(int categoryId)
        {
            return await DataContext.Set<ProductCategory>().FindAsync(categoryId);
        }
    }
}
