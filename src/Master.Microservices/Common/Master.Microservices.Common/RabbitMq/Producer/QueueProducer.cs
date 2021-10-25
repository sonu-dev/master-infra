using MassTransit;
using Master.Core.Logging;
using Master.Microservices.Common.RabbitMq.Constants;
using System;
using System.Threading.Tasks;

namespace Master.Microservices.Common.RabbitMq.Producer
{
    public class QueueProducer : IQueueProducer
    {
        private readonly IBus _bus;
        private readonly ILog<QueueProducer> _log;
        public QueueProducer(IBus bus, ILog<QueueProducer> log)
        {
            _bus = bus;
            _log = log;
        }

        public async Task<bool> SendAsync<TMessage>(TMessage message, string queueName)
        {
            _log.Debug($"Sending message of type {typeof(TMessage).Name} to {queueName}");

            var uri = new Uri($"{RabbitMqConfigurations.RabbitMqUri}/{queueName}");
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(message);
            return true;
        }
    }
}
