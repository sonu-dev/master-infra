using Master.Core.Logging;
using Master.Microservices.Common.Bases.Cqrs;
using Master.Microservices.Orders.DataAccess.Services;
using Master.Microservices.Orders.ViewModels;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Microservices.Catalog.Handlers.Queries
{
    public static class GetProductCategories
    {
        // Query
        public class Query : IRequest<Response>
        {

        }

        // Response
        public class Response
        {
            public IEnumerable<ProductCategoryViewModel> Categories { get; set; }
        }

        // Handler
        public class GetAllCategoriesQueryHandler : RequestHandlerBase<GetAllCategoriesQueryHandler, Query, Response>
        {
            private readonly IProductService _productService;
            public GetAllCategoriesQueryHandler(ILog<GetAllCategoriesQueryHandler> log, IProductService productService) : base(log)
            {              
                _productService = productService;
            }

            public override async Task<Response> ProcessAsync(Query request)
            {
                var response = new Response();
                var cats = await _productService.GetCategoriesAsync();
                response.Categories = cats.Select(c => new ProductCategoryViewModel { Id = c.Id, Name = c.Name, Description = c.Description });
                return response;
            }
        }
    }
}
