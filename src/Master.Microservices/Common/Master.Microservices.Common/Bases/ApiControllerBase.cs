using Master.Core.Logging;

namespace Master.Microservices.Common.Bases
{
    public abstract class ApiControllerBase<T>
    {
        protected ILog<T> Log;

        public ApiControllerBase(ILog<T> log)
        {
            Log = log;
        }
    }
}
