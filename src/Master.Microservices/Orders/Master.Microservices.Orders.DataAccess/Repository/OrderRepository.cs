using Master.Core.Logging;
using Master.Microservices.Common.Bases;
using Master.Microservices.Orders.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.DataAccess.Repository
{
    public class OrderRepository : RepositoryBase<OrderRepository>, IOrderRepository
    {
        private OrdersDataContext _ordersDataContext;
        public OrderRepository(ILog<OrderRepository> log, OrdersDataContext ordersDataContext) : base(log)
        {
            _ordersDataContext = ordersDataContext;
        }
        public async Task<bool> CreateOrdersAsync(List<Order> orders)
        {
            await _ordersDataContext.Orders.AddRangeAsync(orders);
            return true;
        }

        public async Task<List<Order>> GetOrdersAsync(List<int> orderIds)
        {
            if(orderIds == null)
            {
                return await _ordersDataContext.Orders.ToListAsync();
            }
            return await _ordersDataContext.Orders.Where(o => orderIds.Contains(o.Id)).ToListAsync();
        }
    }
}
