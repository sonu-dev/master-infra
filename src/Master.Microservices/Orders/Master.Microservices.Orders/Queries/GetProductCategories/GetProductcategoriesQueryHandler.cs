using Master.Core.Logging;
using Master.Microservices.Orders.DataAccess.Models;
using Master.Microservices.Orders.DataAccess.Services;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.Queries.GetProductCategories
{
    public class GetProductcategoriesQueryHandler : IRequestHandler<GetProductcategoriesQuery, List<ProductCategory>>
    {
        #region Data Members
        private readonly ILog<GetProductcategoriesQueryHandler> _log;
        private readonly IProductService _service;
        #endregion

        #region Constructors
        public GetProductcategoriesQueryHandler(ILog<GetProductcategoriesQueryHandler> log, IProductService service)
        {
            _log = log;
            _service = service;
        }
        #endregion
        public async Task<List<ProductCategory>> Handle(GetProductcategoriesQuery request, CancellationToken cancellationToken)
        {
            var cats = await _service.GetCategoriesAsync();
            return cats;
        }
    }
}
