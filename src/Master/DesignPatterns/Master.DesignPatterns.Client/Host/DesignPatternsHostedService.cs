using Master.Common.Bases;
using Master.Common.Host;
using Master.Common.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Master.DesignPatterns.Client.Host
{
    public class DesignPatternsHostedService : HostedServiceBase<DesignPatternsHostedService>
    {
        private IServiceProvider _serviceProvider;
        public DesignPatternsHostedService(ILog<DesignPatternsHostedService> log, IServiceProvider serviceProvider) : base(log)
        {
            _serviceProvider = serviceProvider;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            base.StartAsync(cancellationToken);
            var clients = _serviceProvider.GetServices<IClient>().ToList();
            clients.ForEach(async client => await client.RunAsync(_serviceProvider));
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            base.StopAsync(cancellationToken);
            return Task.CompletedTask;
        }
    }
}
