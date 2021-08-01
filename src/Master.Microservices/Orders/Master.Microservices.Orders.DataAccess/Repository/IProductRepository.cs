using Master.Microservices.Orders.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.DataAccess.Repository
{
    public interface IProductRepository
    {
        Task AddProductsAsync(List<Product> products);
        List<Product> GetProductsAsync();
    }
}
