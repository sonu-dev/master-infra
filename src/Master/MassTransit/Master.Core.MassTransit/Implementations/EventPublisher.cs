using MassTransit;
using Master.Core.Logging;
using Master.Core.MassTransit.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Core.MassTransit.Implementations
{
    public class EventPublisher : IEventPublisher
    {
        readonly IPublishEndpoint _publishEndpoint;
        protected readonly ILog<EventPublisher> Log;

        public EventPublisher(ILog<EventPublisher> log, IPublishEndpoint publishEndpoint)
        {
            Log = log;
            _publishEndpoint = publishEndpoint;
        }

        public Task PublishAsync<TMessage>(TMessage message)
             where TMessage : class
        {
            return _publishEndpoint.Publish(message);
        }

        public Task PublishBatchAsync<TMessage>(IEnumerable<TMessage> messages) 
            where TMessage: class
        {
            return _publishEndpoint.PublishBatch(messages);
        }
    }
}
