using Master.Core.Logging;
using Master.Microservices.Orders.DataAccess.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.Handlers.Order
{
    #region Commands
    public class CreateOrder : IRequest<bool>
    {
        public CreateOrder(List<int> productIds, string orderDescription)
        {
            ProductIds = productIds;
            OrderDescription = orderDescription;
        }

        public List<int> ProductIds { get; private set; }
        public string OrderDescription { get; private set; }
    }

    public class DoPayment : IRequest<bool>
    {
        public DoPayment(List<int> orderIds)
        {
            OrderIds = orderIds;
        }

        public List<int> OrderIds { get; private set; }
    }
    #endregion

    #region OrderCommandHandler
    public class OrderCommandHandler : 
        IRequestHandler<CreateOrder, bool>,
        IRequestHandler<DoPayment, bool>
    {
        #region Data Members
        private readonly ILog<OrderCommandHandler> _log;
        private readonly IOrderService _service;
        #endregion

        #region Constructors
        public OrderCommandHandler(ILog<OrderCommandHandler> log, IOrderService service)
        {
            _log = log;
            _service = service;
        }
        #endregion

        #region Handlers
        public async Task<bool> Handle(CreateOrder request, CancellationToken cancellationToken)
        {
            if (request.ProductIds == null || request.ProductIds.Count == 0)
            {
                throw new ArgumentNullException(nameof(request.ProductIds));
            }

            var result = await _service.CreateOrderAsync(request.ProductIds, request.OrderDescription);
            return result;
        }

        public async Task<bool> Handle(DoPayment request, CancellationToken cancellationToken)
        {
            // To Call Payment Microservice...

            return await Task.FromResult(true);
        }
        #endregion
    }
    #endregion
}
