using Master.Core.Logging;
using Master.Microservices.Orders.DataAccess.Models;
using Master.Microservices.Orders.DataAccess.Services;
using Master.Microservices.Orders.ViewModels;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using DataModels = Master.Microservices.Orders.DataAccess.Models;

namespace Master.Microservices.Orders.Handlers.Product
{
    #region Commands
    public class CreateProduct: IRequest<bool> {
        public CreateProduct(DataModels.Product product)
        {
            Product = product;
        }
        public DataModels.Product Product { get; private set; }
    }
    public class CreateProductCategory: IRequest<bool> 
    {

        public CreateProductCategory(ProductCategory productCategory)
        {
            ProductCategory = productCategory;
        }
        public ProductCategory ProductCategory { get; private set; }
    }
    #endregion

    #region ProductHandler
    public class ProductCommandHandler : 
        IRequestHandler<CreateProduct, bool>,
        IRequestHandler<CreateProductCategory, bool>
    {
        #region Data Members
        private readonly ILog<ProductCommandHandler> _log;
        private readonly IProductService _service;
        #endregion

        #region Constructors
        public ProductCommandHandler(ILog<ProductCommandHandler> log, IProductService service)
        {
            _log = log;
            _service = service;
        }
        #endregion

        #region Handlers
        public async Task<bool> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            if (request.Product == null)
            {
                throw new ArgumentNullException(nameof(request.Product));
            }
           
            var response = await _service.CreateProductAsync(request.Product);
            return true;
        }

        public async Task<bool> Handle(CreateProductCategory request, CancellationToken cancellationToken)
        {
            if (request.ProductCategory == null)
            {
                throw new ArgumentNullException(nameof(request.ProductCategory));
            }

            var response = await _service.CreateCategoryAsync(request.ProductCategory);            
            return true;
        }
        #endregion
    }
    #endregion
}
