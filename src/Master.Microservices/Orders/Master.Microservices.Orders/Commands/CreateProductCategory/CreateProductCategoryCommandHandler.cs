using Master.Core.Logging;
using Master.Microservices.Orders.DataAccess.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.Commands.CreateProductCategory
{
    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, bool>
    {
        #region Data Members
        private readonly ILog<CreateProductCategoryCommandHandler> _log;
        private readonly IProductService _service;
        #endregion

        #region Constructors
        public CreateProductCategoryCommandHandler(ILog<CreateProductCategoryCommandHandler> log, IProductService service)
        {
            _log = log;
            _service = service;
        }
        #endregion

        #region Implements IRequestHandler
        public async Task<bool> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
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
}
