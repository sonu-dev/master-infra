using Master.Core.Logging;
using Master.Microservices.Catalog.DataAccess.Models;
using Master.Microservices.Catalog.DataAccess.Services;
using Master.Microservices.Common.Bases;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Microservices.Catalog.Handlers.QueryHandlers
{
    public class GetProductCategoriesQuery : IRequest<IEnumerable<ProductCategory>>
    {       
        public class GetAllCategoriesQueryHandler: RequestHandlerBase<GetProductCategoriesQuery, IEnumerable<ProductCategory>>
        {
            private readonly ICatalogService _catalogService;
            public GetAllCategoriesQueryHandler(ILog<GetProductCategoriesQuery> log, ICatalogService catalogService) : base(log)
            {
                Log = log;
                _catalogService = catalogService;
            }

            public override async Task<IEnumerable<ProductCategory>> ProcessAsync(GetProductCategoriesQuery request)
            {
                var result = await _catalogService.GetCategoriesAsync();
                return result;               
            }
        }
    }
}
