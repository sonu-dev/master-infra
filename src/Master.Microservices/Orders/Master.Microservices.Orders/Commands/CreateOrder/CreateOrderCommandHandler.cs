using Master.Core.Logging;
using Master.Microservices.Orders.Commands.CreateOrder;
using Master.Microservices.Orders.DataAccess.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.Handlers.Order
{
    #region OrderCommandHandler
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>       
    {
        #region Data Members
        private readonly ILog<CreateOrderCommandHandler> _log;
        private readonly IOrderService _service;
        #endregion

        #region Constructors
        public CreateOrderCommandHandler(ILog<CreateOrderCommandHandler> log, IOrderService service)
        {
            _log = log;
            _service = service;
        }
        #endregion

        #region Handlers
        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            if (request.ProductIds == null || request.ProductIds.Count == 0)
            {
                throw new ArgumentNullException(nameof(request.ProductIds));
            }

            var result = await _service.CreateOrderAsync(request.ProductIds, request.OrderDescription);
            return result;
        }       
        #endregion
    }
    #endregion
}
