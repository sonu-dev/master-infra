using Master.Core.Logging;
using Master.Microservices.Common.Bases;
using Master.Microservices.Orders.DataAccess.Models;

namespace Master.Microservices.Orders.DataAccess.Repository
{
    public class ProductRepository : RepositoryBase<ProductRepository, OrdersDataContext>, IProductRepository
    {

        public ProductRepository(ILog<ProductRepository> log, OrdersDataContext dataContext)
            : base(log, dataContext)
        {
        }
    }
}
