using Master.Core.Logging;

namespace Master.Microservices.Common.Bases
{
    public abstract class RepositoryBase<TRepository, TDataContext>       
    {  
        protected readonly ILog<TRepository> Log;
        protected readonly TDataContext DataContext;
        public RepositoryBase(ILog<TRepository> log, TDataContext dataContext)
        {
            Log = log;
            DataContext = dataContext;
        }        
    }
}
