using Master.Core.Logging;
using Master.Microservices.Common.Messages;
using Master.Microservices.Common.RabbitMq.Producer;
using Master.Microservices.Orders.DataAccess.Services;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.Commands.PayOrder
{
    public class PayOrderCommandHandler : IRequestHandler<PayOrderCommand, bool>
    {
        #region Data Members       
        private readonly IOrderService _service;       
        private readonly IQueueProducer _queueProducer;
        private readonly ILog<PayOrderCommandHandler> _log;
        #endregion

        public PayOrderCommandHandler(ILog<PayOrderCommandHandler> log, IOrderService service, IQueueProducer queueProducer)
        {
            _log = log;
            _service = service;
            _queueProducer = queueProducer;
        }
        public async Task<bool> Handle(PayOrderCommand request, CancellationToken cancellationToken)
        {
            //var result = await _service.InitiatePayment(request.OrderIds);
            //if(result?.Count > 0)
            //{
            // Invoke PaymentService
            var firstItem = new { Key = 1, Value = 280}; //result.First();
                await _queueProducer.SendAsync(new OrderPaymentMessage { OrderId = firstItem.Key, OrderAmount = firstItem.Value }, "master-orderpayment");
           // }
            return true;
        }
    }
}
