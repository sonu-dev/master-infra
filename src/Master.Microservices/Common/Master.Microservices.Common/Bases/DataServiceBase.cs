using Master.Core.Logging;

namespace Master.Microservices.Common.Bases
{
    public abstract class DataServiceBase<TService, TDataContext> : ServiceBase<TService>       
    { 
        protected readonly TDataContext DataContext;
        public DataServiceBase(ILog<TService> log, TDataContext dataContext): base(log)
        {          
            DataContext = dataContext;
        }        
    }
}
