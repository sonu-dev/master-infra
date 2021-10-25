using Master.Core.Logging;
using Master.Microservices.Common.Bases;
using Master.Microservices.Orders.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.DataAccess.Services
{
    public class OrderService : DataServiceBase<OrderService, OrderDataContext>, IOrderService
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
                Status = (int)OrderStatus.Created,
                CreatedBy = 1,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };

            var isOrderCreated = false;
            using var transaction = await DataContext.Database.BeginTransactionAsync();
            try
            {
                await DataContext.Orders.AddAsync(newOrder);
                await DataContext.SaveChangesAsync();

                // Create Order Items
                isOrderCreated = await CreateOrderItemsAsync(newOrder.Id, productIds);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                await transaction.RollbackAsync();
            }
            finally
            {
                await transaction.CommitAsync();
            }
            return isOrderCreated;
        }

        public async Task<IDictionary<int, decimal>> InitiatePayment(List<int> orderIds)
        {
            var result = new Dictionary<int, decimal>();
            if (orderIds == null || orderIds.Count == 0)
            {
                return result;
            }

            var orders = DataContext.Orders.Where(o => orderIds.Contains(o.Id)).ToList();
            orders.ForEach(o => o.Status = (int)OrderStatus.InitiatePayment);
            await DataContext.SaveChangesAsync();
          
            orders.ForEach(o => result.Add(o.Id, o.Amount));
            return result;
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
