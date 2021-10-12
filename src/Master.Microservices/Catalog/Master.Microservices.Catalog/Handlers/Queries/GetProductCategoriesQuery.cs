using Master.Core.Logging;
using Master.Microservices.Catalog.DataAccess.Services;
using Master.Microservices.Catalog.ViewModels;
using Master.Microservices.Common.Bases.Cqrs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Master.Microservices.Catalog.Handlers.Queries
{
    public class GetProductCategoriesQueryRequest : RequestBase<GetProductCategoriesQueryResponse>
    {       
       
    }
    public class GetProductCategoriesQueryResponse
    {
        public IEnumerable<ProductCategoryViewModel> Categories { get; set; }
    }

    public class GetAllCategoriesQuery: GetProductCategoriesQueryRequest
    {
        public class GetAllCategoriesQueryHandler : RequestHandlerBase<GetAllCategoriesQueryHandler, GetProductCategoriesQueryRequest, GetProductCategoriesQueryResponse>
        {
            private readonly ICatalogService _catalogService;
            public GetAllCategoriesQueryHandler(ILog<GetAllCategoriesQueryHandler> log, ICatalogService catalogService) : base(log)
            {
                Log = log;
                _catalogService = catalogService;
            }

            public override async Task<GetProductCategoriesQueryResponse> ProcessAsync(GetProductCategoriesQueryRequest request)
            {
                var response = new GetProductCategoriesQueryResponse();
                var cats = await _catalogService.GetCategoriesAsync();
                response.Categories = cats.Select(c => new ProductCategoryViewModel { Id = c.Id, Name = c.Name, Description = c.Description });
                return response;
            }
        }  
    }
}
