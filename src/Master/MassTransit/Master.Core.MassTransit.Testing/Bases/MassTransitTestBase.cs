using MassTransit.Testing;
using Master.Core.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Master.Core.MassTransit.Testing.Bases
{
    public abstract class MassTransitTestBase
    {
        protected InMemoryTestHarness BusMockService;
        public MassTransitTestBase()
        {
            var provider = new ServiceCollection()
           .AddSingleton(typeof(ILog<>), typeof(Log<>))
           .AddMassTransitInMemoryTestHarness(cfg =>
           {
               cfg.AddConsumer<CreateOrderConsumer>();
               cfg.AddConsumer<SubmittedOrderConsumer>();
               cfg.AddConsumerTestHarness<CreateOrderConsumer>();
               cfg.AddConsumerTestHarness<SubmittedOrderConsumer>();
           })
           .BuildServiceProvider(true);

            BusMockService = provider.GetRequiredService<InMemoryTestHarness>();
        }
       
        public virtual async Task StartAsync()
        {
           await BusMockService.Start();
        }

        public virtual async Task StopAsync()
        {
            await BusMockService.Stop();
        }
    }
}
