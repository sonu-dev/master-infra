using Master.Core.Logging;
using Master.Microservices.Orders.DataAccess.Models;
using Master.Microservices.Common.Bases;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Master.Microservices.Orders.DataAccess.Services
{
    public class OrderService : ServiceBase<OrderService, OrderDataContext>, IOrderService
    {
        public OrderService(ILog<OrderService> log, OrderDataContext dataContext)
            : base(log, dataContext)
        {
        }

        #region IOrderService Members
        public async Task<bool> CreateOrderAsync(List<Product> products)
        {
            // Create New Order
            var newOrder = new Order
            {                
                Amount = 0,
                Description = $"Created cart at {DateTime.Now}",
                Status = (int)OrderStatus.UnPaid               
            };

            await DataContext.Orders.AddAsync(newOrder);
            await DataContext.SaveChangesAsync();

            // Create Order Items
            return await CreateOrderItems(newOrder.Id, products);
        }
        #endregion

        #region Private Methods
        private async Task<bool> CreateOrderItems(int orderId, List<Product> products)
        {
            var items = new List<OrderItem>();
            products.ForEach(p =>
            {
                items.Add(new OrderItem { OrderId = orderId, ProductId = p.Id });
            });

            await DataContext.OrderItems.AddRangeAsync(items);
            await DataContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
