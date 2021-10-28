using Master.Core.Logging;
using Master.Microservices.Common.Messages;
using Master.Microservices.Common.RabbitMq.Consumer;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.Consumers
{
    public class CreateOrderPaymentResponse : ConsumerBase<CreateOrderPaymentResponse, OrderPaymentResponseMessage>
    {
        public CreateOrderPaymentResponse(ILog<CreateOrderPaymentResponse> log): base(log)
        {
        }
        protected override async Task ProcessMessageAsync(OrderPaymentResponseMessage message)
        {          
            await Task.CompletedTask;
        }
    }
}
