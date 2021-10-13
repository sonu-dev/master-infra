using Master.Core.Logging;
using Master.Microservices.Catalog.DataAccess.Services;
using Master.Microservices.Catalog.ViewModels;
using Master.Microservices.Common.Bases.Cqrs;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Microservices.Catalog.Handlers.Queries
{   
    public static class GetAllCategoriesQuery
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
            private readonly ICatalogService _catalogService;
            public GetAllCategoriesQueryHandler(ILog<GetAllCategoriesQueryHandler> log, ICatalogService catalogService) : base(log)
            {
                Log = log;
                _catalogService = catalogService;
            }

            public override async Task<Response> ProcessAsync(Query request)
            {
                var response = new Response();
                var cats = await _catalogService.GetCategoriesAsync();
                response.Categories = cats.Select(c => new ProductCategoryViewModel { Id = c.Id, Name = c.Name, Description = c.Description });
                return response;
            }
        }
    }
}
