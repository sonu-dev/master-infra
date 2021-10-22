using Master.Microservices.Orders.DataAccess.Models;
using MediatR;
using System.Collections.Generic;

namespace Master.Microservices.Orders.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<List<Product>>
    {
        public GetProductsQuery(List<int> productIds)
        {
            ProductIds = productIds;
        }
        public List<int> ProductIds { get; private set; }
    }
}
