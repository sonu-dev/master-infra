using MassTransit;
using Master.Core.Logging;
using System.Threading.Tasks;

namespace Master.Core.MassTransit.Bases
{
    public abstract class EventConsumerBase<TConsumer, TMessage> : IConsumer<TMessage>
       where TMessage : class
       where TConsumer : class
    {
        protected readonly ILog<TConsumer> Log;
        public EventConsumerBase(ILog<TConsumer> log)
        {
            Log = log;
        }

        public async Task Consume(ConsumeContext<TMessage> context)
        {
            await ProcessMessageAsync(context);
        }

        protected abstract Task ProcessMessageAsync(ConsumeContext<TMessage> context);
    }
}
