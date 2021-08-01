using Master.Core.Logging;

namespace Master.Microservices.Common.Bases
{
    public abstract class RepositoryBase<T>
    {
        protected ILog<T> Log;       
        public RepositoryBase(ILog<T> log)
        {
            Log = log;          
        }
    }
}
