using Master.Core.Host.Bases;
using Master.Core.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Master.Microservices.Payments.Host.HostedServices
{
    public class PaymentHostedService : HostedServiceBase<PaymentHostedService>
    {
        public PaymentHostedService(ILog<PaymentHostedService> log, IServiceProvider serviceProvider) : base(log, serviceProvider)
        {
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
