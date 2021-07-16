using Master.Core.Logging;
using System.Threading.Tasks;

namespace Master.Core.Common
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

        public Task RunAsync()
        {           
            if (!CanExecute())
            {
                return Task.CompletedTask;
            }
            Log.Debug($"{Name} start.");
            ExecuteAsync();
            Log.Debug($"{Name} stop.");
            return Task.CompletedTask;
        }

        public virtual bool CanExecute() => true;
        public abstract Task ExecuteAsync();      
    }
}
