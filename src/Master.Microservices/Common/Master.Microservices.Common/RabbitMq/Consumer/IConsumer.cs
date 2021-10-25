using MassTransit;
using System.Threading.Tasks;

namespace Master.Microservices.Common.RabbitMq.Consumer
{
    public interface IConsumer<in TMessage> : MassTransit.IConsumer<TMessage>
        where TMessage: class
    {
        Task Consume(ConsumeContext<TMessage> context);
    }
}
