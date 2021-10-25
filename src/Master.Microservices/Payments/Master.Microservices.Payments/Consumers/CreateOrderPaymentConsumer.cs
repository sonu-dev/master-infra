using Master.Core.Logging;
using Master.Microservices.Common.Messages;
using Master.Microservices.Common.RabbitMq.Consumer;
using System.Threading.Tasks;

namespace Master.Microservices.Payments.Consumers
{
    public class CreateOrderPaymentConsumer : ConsumerBase<CreateOrderPaymentConsumer, OrderPaymentMessage>
    {
        public CreateOrderPaymentConsumer(ILog<CreateOrderPaymentConsumer> log) : base(log)
        {
        }
        protected override async Task ProcessMessageAsync(OrderPaymentMessage message)
        {
            await Task.CompletedTask;
        }
    }
}
