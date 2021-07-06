using Master.Common.Logging;
using System.Threading.Tasks;

namespace Master.Common.Bases
{
    public abstract class ClientBase<T> : IClient
    {
        private string _name;
        protected ILog<T> Log;
        public ClientBase(ILog<T> log)
        {
            Log = log;
            _name = typeof(T).Name;
        }

        public async Task RunAsync()
        {
            Log.Debug($"{_name} start.");
            await ExecuteAsync();
            Log.Debug($"{_name} stop.");
        }

        public abstract Task ExecuteAsync();
    }
}
