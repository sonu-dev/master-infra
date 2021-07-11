using Master.Common.Logging;
using System;
using System.Threading.Tasks;

namespace Master.Common.Bases
{
    public abstract class ClientBase<T> : IClient
    {
        protected string Name;
        protected ILog<T> Log;     
        public ClientBase(ILog<T> log)
        {
            Log = log;         
            Name = typeof(T).Name;
        }      

        public Task RunAsync(IServiceProvider serviceProvider = null)
        {           
            if (!CanExecute())
            {
                return Task.CompletedTask;
            }
            Log.Debug($"{Name} start.");
            ExecuteAsync(serviceProvider);
            Log.Debug($"{Name} stop.");
            return Task.CompletedTask;
        }

        public virtual bool CanExecute() => true;
        public abstract Task ExecuteAsync(IServiceProvider serviceProvider = null);      
    }
}
