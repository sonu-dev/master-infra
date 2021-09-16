using Master.Microservices.Catalog.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Microservices.Catalog.DataAccess.Services
{
    public interface ICatalogService
    {
        Task<List<ProductCategory>> GetCategoriesAsync();
        Task<ProductCategory> GetCategoryByIdAsync(int categoryId);
    }
}
