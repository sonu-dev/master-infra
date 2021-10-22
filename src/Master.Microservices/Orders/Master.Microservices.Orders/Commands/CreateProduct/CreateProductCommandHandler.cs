using Master.Core.Logging;
using Master.Microservices.Orders.DataAccess.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
     {
        #region Data Members
        private readonly ILog<CreateProductCommandHandler> _log;
        private readonly IProductService _service;
        #endregion

        #region Constructors
        public CreateProductCommandHandler(ILog<CreateProductCommandHandler> log, IProductService service)
        {
            _log = log;
            _service = service;
        }
        #endregion

        #region Implement IRequestHandler
        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (request.Product == null)
            {
                throw new ArgumentNullException(nameof(request.Product));
            }

            var response = await _service.CreateProductAsync(request.Product);
            return true;
        }
        #endregion
    }
}
