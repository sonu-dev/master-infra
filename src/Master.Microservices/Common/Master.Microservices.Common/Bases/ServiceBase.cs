using Master.Core.Logging;

namespace Master.Microservices.Common.Bases
{
    public abstract class ServiceBase<TService, TDataContext>       
    {  
        protected readonly ILog<TService> Log;
        protected readonly TDataContext DataContext;
        public ServiceBase(ILog<TService> log, TDataContext dataContext)
        {
            Log = log;
            DataContext = dataContext;
        }        
    }
}
