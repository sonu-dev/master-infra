using Master.Core.Logging;
using Master.Microservices.Common.Messages;
using Master.Microservices.Common.RabbitMq.Consumer;
using Master.Microservices.Payments.DataAccess.Models;
using Master.Microservices.Payments.DataAccess.Services;
using System.Threading.Tasks;

namespace Master.Microservices.Payments.Consumers
{
    public class CreateOrderPaymentConsumer : ConsumerBase<CreateOrderPaymentConsumer, OrderPaymentMessage>
    {
        private readonly IPaymentService _paymentService;
        public CreateOrderPaymentConsumer(ILog<CreateOrderPaymentConsumer> log, IPaymentService paymentService) : base(log)
        {
            _paymentService = paymentService;
        }
        protected override async Task ProcessMessageAsync(OrderPaymentMessage message)
        {
            var orderPayment = new OrderPayment
            {
                OrderId = message.OrderId,
                OrderAmount = message.OrderAmount,
                PaymentStatus = (int)PaymentStatus.UnPaid,
                PaymentType = (int)PaymentType.DebitCard,
                CreateTime = System.DateTime.Now,
                UpdateTime = System.DateTime.Now,
                CreatedBy = 1
            };
        
           await _paymentService.CreateOrderPaymentAsync(orderPayment);           
        }
    }
}
