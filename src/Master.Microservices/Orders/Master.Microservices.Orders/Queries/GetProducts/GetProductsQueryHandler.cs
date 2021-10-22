using Master.Core.Logging;
using Master.Microservices.Orders.DataAccess.Models;
using Master.Microservices.Orders.DataAccess.Services;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<Product>>
    {
        #region Data Members
        private readonly ILog<GetProductsQueryHandler> _log;
        private readonly IProductService _service;
        #endregion

        #region Constructors
        public GetProductsQueryHandler(ILog<GetProductsQueryHandler> log, IProductService service)
        {
            _log = log;
            _service = service;
        }
        #endregion

        #region Implements IRequestHandler
        public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _service.GetAllProductsAsync(request.ProductIds);
            return products;
        }
        #endregion
    }
}
