using Master.Core.Logging;
using Master.Microservices.Common.Bases;
using Master.Microservices.Orders.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.DataAccess.Repository
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategoryRepository, OrdersDataContext>, IProductCategoryRepository
    {
       
        public ProductCategoryRepository(ILog<ProductCategoryRepository> log, OrdersDataContext dataContext) 
            : base(log, dataContext)
        {
        }

        public async Task<List<ProductCategory>> GetAllAsync()
        {
            return await DataContext.Set<ProductCategory>().ToListAsync();
        }

        public async Task<ProductCategory> GetAsync(int categoryId)
        {
            return await DataContext.Set<ProductCategory>().FindAsync(categoryId);
        }
    }
}
