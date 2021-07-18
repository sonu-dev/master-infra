using MassTransit;
using MassTransit.Testing;
using Master.Core.MassTransit.Testing.Bases;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Master.Core.MassTransit.Testing.Tests
{
    [TestFixture]
    public class BasicTest : MassTransitTestBase
    {
        [TestCase()]
        public async Task Test_TestConsumer()
        {
            var createOrderConsumer = BusMockService.Consumer<CreateOrderConsumer>();
            var submittedOrderConsumer = BusMockService.Consumer<SubmittedOrderConsumer>();

            // Start Consumer
            await StartAsync();

            // Send Message
            try
            {
                await BusMockService.InputQueueSendEndpoint.Send<CreateOrderMessage>(new
                {
                    OrderId = 100
                });

                // did the endpoint consume the message
                Assert.That(await BusMockService.Consumed.Any<CreateOrderMessage>());

                // did the actual consumer consume the message
                Assert.That(await createOrderConsumer.Consumed.Any<CreateOrderMessage>());

                // the consumer publish the event
                Assert.That(await BusMockService.Published.Any<SubmittedOrderMessage>());

                // did the actual consumer consume the message
                Assert.That(await submittedOrderConsumer.Consumed.Any<SubmittedOrderMessage>());

                // ensure that no faults were published by the consumer
                Assert.That(await BusMockService.Published.Any<Fault<SubmittedOrderMessage>>(), Is.False);
            }
            finally
            {
                await StopAsync();
            }
        }
    }
}
