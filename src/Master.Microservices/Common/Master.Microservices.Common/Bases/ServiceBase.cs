using Master.Core.Logging;

namespace Master.Microservices.Common.Bases
{
    public abstract class ServiceBase<TService>
    {
        protected readonly ILog<TService> Log;
        public ServiceBase(ILog<TService> log)
        {
            Log = log;
        }
    }
}
