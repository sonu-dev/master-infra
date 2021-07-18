using Master.Core.Common;
using Master.Core.Logging;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Master.Core.Host
{
    public abstract class HostedServiceBase<THostedService> : IHostedService
    {
        private string _serviceName;
        private ILog<THostedService> _log;
        private IServiceProvider _serviceProvider;

        public HostedServiceBase(ILog<THostedService> log, IServiceProvider serviceProvider)
        {
            _log = log;
            _serviceName = typeof(THostedService).Name;
            _serviceProvider = serviceProvider;
        }
        public virtual Task StartAsync(CancellationToken cancellationToken)
        {
            _log.Debug($"{_serviceName} start");
            _log.Debug("Setup Di container");
            DiContainer.Setup(_serviceProvider);
            return Task.CompletedTask;
        }

        public virtual Task StopAsync(CancellationToken cancellationToken)
        {
            _log.Debug($"{_serviceName} stop");
            return Task.CompletedTask;
        }
    }
}
