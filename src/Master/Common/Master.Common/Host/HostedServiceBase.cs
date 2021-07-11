using Master.Common.Logging;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace Master.Common.Host
{
    public abstract class HostedServiceBase<THostedService> : IHostedService
    {
        private string _serviceName;
        private ILog<THostedService> _log;
        public HostedServiceBase(ILog<THostedService> log)
        {
            _log = log;
            _serviceName = typeof(THostedService).Name;
        }
        public virtual Task StartAsync(CancellationToken cancellationToken)
        {
            _log.Debug($"{_serviceName} start");
            return Task.CompletedTask;
        }

        public virtual Task StopAsync(CancellationToken cancellationToken)
        {
            _log.Debug($"{_serviceName} stop");
            return Task.CompletedTask;
        }
    }
}
