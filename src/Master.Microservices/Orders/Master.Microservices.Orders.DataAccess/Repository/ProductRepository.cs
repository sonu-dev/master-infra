using Master.Core.Logging;
using Master.Microservices.Common.Bases;
using Master.Microservices.Orders.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.DataAccess.Repository
{
    public class ProductRepository : RepositoryBase<ProductRepository>, IProductRepository
    {
        private OrdersDataContext _ordersDataContext;
        public ProductRepository(ILog<ProductRepository> log, OrdersDataContext ordersDataContext) : base(log)
        {
            _ordersDataContext = ordersDataContext;
        }
        public Task AddProductsAsync(List<Product> products)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
