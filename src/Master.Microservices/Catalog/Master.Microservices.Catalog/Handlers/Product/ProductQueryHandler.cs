using Master.Core.Logging;
using Master.Microservices.Orders.DataAccess.Models;
using Master.Microservices.Orders.DataAccess.Services;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataModels = Master.Microservices.Orders.DataAccess.Models;

namespace Master.Microservices.Orders.Handlers.Product
{
    #region Queries
    public class GetProducts : IRequest<List<DataModels.Product>>
    {
        public GetProducts(List<int> productIds)
        {
            ProductIds = productIds;
        }
        public List<int> ProductIds { get; set; }
    }

    public class GetProductCategories : IRequest<List<ProductCategory>>
    {
    }
    #endregion

    #region ProductQueryHandler
    public class ProductQueryHandler :
        IRequestHandler<GetProducts, List<DataModels.Product>>,
        IRequestHandler<GetProductCategories, List<ProductCategory>>
    {
        #region Data Members
        private readonly ILog<ProductQueryHandler> _log;
        private readonly IProductService _service;
        #endregion

        #region Constructors
        public ProductQueryHandler(ILog<ProductQueryHandler> log, IProductService service)
        {
            _log = log;
            _service = service;
        }
        #endregion

        #region Handlers
        public async Task<List<DataModels.Product>> Handle(GetProducts request, CancellationToken cancellationToken)
        {
            var products = await _service.GetAllProductsAsync(request.ProductIds);
            return products;
        }

        public async Task<List<ProductCategory>> Handle(GetProductCategories request, CancellationToken cancellationToken)
        {
            var cats = await _service.GetCategoriesAsync();
            return cats;
        }
        #endregion
    }
    #endregion
}
