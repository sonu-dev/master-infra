using Master.Core.Logging;
using Master.Microservices.Common.Messages;
using Master.Microservices.Common.RabbitMq.Consumer;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.Consumers
{
    public class OrderPaymentCreatedConsumer : ConsumerBase<OrderPaymentCreatedConsumer, OrderPaymentResponseMessage>
    {
        public OrderPaymentCreatedConsumer(ILog<OrderPaymentCreatedConsumer> log): base(log)
        {
        }
        protected override async Task ProcessMessageAsync(OrderPaymentResponseMessage message)
        {          
            await Task.CompletedTask;
        }
    }
}
