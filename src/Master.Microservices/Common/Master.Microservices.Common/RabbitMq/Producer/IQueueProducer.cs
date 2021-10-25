using System.Threading.Tasks;

namespace Master.Microservices.Common.RabbitMq.Producer
{
    public interface IQueueProducer
    {
        Task<bool> SendAsync<TMessage>(TMessage message, string queueName);
    }
}
