using Master.Core.Logging;
using Master.Microservices.Common.Bases.Cqrs;
using Master.Microservices.Orders.DataAccess.Services;
using Master.Microservices.Orders.ViewModels;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.Handlers.Queries
{
    public static class GetProductsQuery
    {
        // Query
        public class Query : IRequest<Response>
        {
        }

        // Response
        public class Response
        {
            public List<ProductViewModel> Products { get; set; }
        }

        // Handler
        public class GetProductsQueryHandler : RequestHandlerBase<GetProductsQueryHandler, Query, Response>
        {
            private readonly IProductService _productService;
            public GetProductsQueryHandler(ILog<GetProductsQueryHandler> log, IProductService productService) : base(log)
            {
                _productService = productService;
            }
            public override async Task<Response> ProcessAsync(Query request)
            {
                var products = await _productService.GetAllProductsAsync();
                return new Response
                {
                    Products = products.Select(p => new ProductViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        CategoryId = p.CategoryId,
                        IsAvailable = p.IsAvailable,
                        IsEnabled = p.IsEnabled,
                        Category = new ProductCategoryViewModel
                        {
                            Id = p.Category.Id,
                            Name = p.Category.Name,
                            Description = p.Category.Description
                        }
                    }).ToList()
                };
            }
        }
    }
}
