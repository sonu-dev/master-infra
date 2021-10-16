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
        public CreateOrder(List<DataAccess.Models.Product> products, string orderDescription)
        {
            Products = products;
            OrderDescription = orderDescription;
        }

        public List<DataAccess.Models.Product> Products { get; private set; }
        public string OrderDescription { get; private set; }
    }
    #endregion

    #region OrderCommandHandler
    public class OrderCommandHandler : IRequestHandler<CreateOrder, bool>
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
            if (request.Products == null || request.Products.Count == 0)
            {
                throw new ArgumentNullException(nameof(request.Products));
            }

            var result = await _service.CreateOrderAsync(request.Products, request.OrderDescription);
            return result;
        }
        #endregion
    }
    #endregion
}
