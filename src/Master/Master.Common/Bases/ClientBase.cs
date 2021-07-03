using Master.Common.Logging;
using System.Threading.Tasks;

namespace Master.Common.Bases
{
    public abstract class ClientBase<T> : IClient
    {
        private string _name;
        protected Serilog.ILogger Log;
        public ClientBase()
        {
            InitializeLogger();
            _name = typeof(T).Name;
        }

        private void InitializeLogger()
        {
            var logger = LogManager.InitializeLogger();
            Log = logger;            
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
