using Master.Microservices.Orders.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.DataAccess.Services
{
    public interface IProductService
    {
        Task<List<ProductCategory>> GetCategoriesAsync();
        Task<ProductCategory> GetCategoryByIdAsync(int categoryId);
        Task<ProductCategory> CreateCategoryAsync(ProductCategory productCategory);
        Task<Product> CreateProductAsync(Product product);
        Task<List<Product>> GetAllProductsAsync(List<int> productIds);
    }
}
