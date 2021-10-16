using Master.Core.Logging;
using Master.Microservices.Orders.DataAccess.Models;
using Master.Microservices.Common.Bases;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Master.Microservices.Orders.DataAccess.Services
{
    public class OrderService : ServiceBase<OrderService, OrderDataContext>, IOrderService
    {
        public OrderService(ILog<OrderService> log, OrderDataContext dataContext)
            : base(log, dataContext)
        {
        }

        #region IOrderService Members
        public async Task<bool> CreateOrderAsync(List<int> productIds, string orderDescription)
        {
            // Create New Order         
            var products = DataContext.Products.Where(p => productIds.Contains(p.Id));
            var newOrder = new Order
            {
                Amount = products.Sum(p => p.Price),
                Description = orderDescription,
                Status = (int)OrderStatus.UnPaid,    
                CreatedBy = 1,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };

            await DataContext.Orders.AddAsync(newOrder);
            await DataContext.SaveChangesAsync();

            // Create Order Items
            return await CreateOrderItemsAsync(newOrder.Id, productIds);
        }
        #endregion

        #region Private Methods
        private async Task<bool> CreateOrderItemsAsync(int orderId, List<int> productIds)
        {
            var orderItems = new List<OrderItem>();
            productIds.ForEach(pId =>
            {
                orderItems.Add(new OrderItem { OrderId = orderId, ProductId = pId, CreateTime = DateTime.Now, UpdateTime = DateTime.Now });
            });

            await DataContext.OrderItems.AddRangeAsync(orderItems);
            await DataContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
