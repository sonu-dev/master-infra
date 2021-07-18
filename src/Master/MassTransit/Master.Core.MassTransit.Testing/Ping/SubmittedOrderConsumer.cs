using MassTransit;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Master.Core.MassTransit.Testing
{
    public class SubmittedOrderConsumer : IConsumer<SubmittedOrderMessage>
    {
        public async Task Consume(ConsumeContext<SubmittedOrderMessage> context)
        {
            // Recieved Order Creation notification
            if (context.Message.IsOrderCreated)
            {
                Debug.WriteLine($"Order:{context.Message.OrderId}  Created successfully");
            }
            await Task.CompletedTask;
        }
    }  
}
