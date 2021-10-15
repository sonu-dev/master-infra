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
        public async Task<bool> CreateOrderAsync(List<Product> products, string orderDescription)
        {
            // Create New Order
            var newOrder = new Order
            {
                Amount = products.Sum(p => p.Price),
                Description = orderDescription,
                Status = (int)OrderStatus.UnPaid,    
                CreatedBy = 1,
                CreateTime = DateTime.Now,
            };

            await DataContext.Orders.AddAsync(newOrder);
            await DataContext.SaveChangesAsync();

            // Create Order Items
            return await CreateOrderItemsAsync(newOrder.Id, products);
        }
        #endregion

        #region Private Methods
        private async Task<bool> CreateOrderItemsAsync(int orderId, List<Product> products)
        {
            var items = new List<OrderItem>();
            products.ForEach(p =>
            {
                items.Add(new OrderItem { OrderId = orderId, ProductId = p.Id, CreateTime = DateTime.Now });
            });

            await DataContext.OrderItems.AddRangeAsync(items);
            await DataContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
