using Master.Microservices.Orders.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.DataAccess.Repository
{
    public interface IOrderRepository  
    {
        Task<bool> CreateOrdersAsync(List<Order> orders);
        Task<List<Order>> GetOrdersAsync(List<Guid> orderIds);
    }
}
