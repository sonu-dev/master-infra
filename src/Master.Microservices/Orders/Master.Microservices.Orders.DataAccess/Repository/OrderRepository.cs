using Master.Core.Logging;
using Master.Microservices.Common.Bases;
using Master.Microservices.Orders.DataAccess.Models;

namespace Master.Microservices.Orders.DataAccess.Repository
{
    public class OrderRepository : RepositoryBase<OrderRepository, OrdersDataContext>, IOrderRepository
    {
        public OrderRepository(ILog<OrderRepository> log, OrdersDataContext ordersDataContext) : base(log, ordersDataContext)
        {
            
        }
    }
}
