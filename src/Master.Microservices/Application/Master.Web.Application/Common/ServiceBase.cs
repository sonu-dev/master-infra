using Master.Core.Logging;

namespace Master.Web.Api.Common
{
    public abstract class ServiceBase<T>
    {
        protected ILog<T> Log { get; private set; }
        public ServiceBase(ILog<T> log)
        {
            Log = log;
        }
    }
}
