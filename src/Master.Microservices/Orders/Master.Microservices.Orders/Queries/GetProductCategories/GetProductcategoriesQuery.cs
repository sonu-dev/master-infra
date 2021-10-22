using Master.Microservices.Orders.DataAccess.Models;
using MediatR;
using System.Collections.Generic;

namespace Master.Microservices.Orders.Queries.GetProductCategories
{
    public class GetProductcategoriesQuery : IRequest<List<ProductCategory>>
    {
    }
}
