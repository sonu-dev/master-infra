using MassTransit;
using Master.Core.Logging;
using System;
using System.Threading.Tasks;

namespace Master.Microservices.Common.RabbitMq.Consumer
{
    public abstract class ConsumerBase<TConsumer, TMessage> : IConsumer<TMessage>
         where TMessage : class
         where TConsumer : class
    {
        protected readonly ILog<TConsumer> Log;
        public ConsumerBase(ILog<TConsumer> log)
        {
            Log = log;
        }

        #region IConsumer Members
        public async Task Consume(ConsumeContext<TMessage> context)
        {
            Log.Debug($"Executing {typeof(TConsumer).FullName}");

            var message = context.Message;
            if (message is null)
            {
                throw new ArgumentNullException(typeof(TMessage).Name);
            }
            await ProcessMessageAsync(message);
        }
        #endregion

        #region Abstract Methods
        protected abstract Task ProcessMessageAsync(TMessage message);
        #endregion
    }
}
