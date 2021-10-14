using Master.Microservices.Orders.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.DataAccess.Services
{
    public interface IProductService
    {
        Task<List<ProductCategory>> GetCategoriesAsync();
        Task<ProductCategory> GetCategoryByIdAsync(int categoryId);
        Task<ProductCategory> AddCategoryAsync(ProductCategory productCategory);
        Task<Product> AddProductAsync(Product product);
        Task<List<Product>> GetAllProductsAsync();
    }
}
