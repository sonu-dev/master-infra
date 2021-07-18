using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Core.MassTransit.Interfaces
{
    public interface IEventPublisher
    {
        Task PublishAsync<TMessage>(TMessage message) where TMessage : class;
        Task PublishBatchAsync<TMessage>(IEnumerable<TMessage> messages) where TMessage : class;
    }
}
