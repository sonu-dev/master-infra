using Master.Microservices.Orders.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.DataAccess.Repository
{
    public interface IProductCategoryRepository
    {
        Task<List<ProductCategory>> GetAllAsync();
        Task<ProductCategory> GetAsync(int categoryId);
    }
}
