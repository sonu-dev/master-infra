using Master.Microservices.Orders.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.DataAccess.Services
{
    public interface IOrderService
    {
        Task<bool> CreateOrderAsync(List<int> productIds, string orderDescription);
    }
}
