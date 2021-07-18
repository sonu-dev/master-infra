using MassTransit;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Master.Core.MassTransit.Testing
{
    public class CreateOrderConsumer : IConsumer<CreateOrderMessage>
    {
        public async Task Consume(ConsumeContext<CreateOrderMessage> context)
        {
            Debug.WriteLine($"Order:{context.Message.OrderId}  Created successfully");
            // Create Order Here
            
            // Notify Order is Submitted
            await context.Publish<SubmittedOrderMessage>(new
            {
                context.Message.OrderId,
                IsOrderCreated = true
            });
        }
    }
}
