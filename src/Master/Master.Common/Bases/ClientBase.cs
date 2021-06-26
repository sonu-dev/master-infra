using Master.Common.Logging;

namespace Master.Common.Bases
{
    public abstract class ClientBase : IClient
    {
        protected Serilog.ILogger Log;
        public ClientBase()
        {
            InitializeLogger();
        }

        private void InitializeLogger()
        {
            var logger = LogManager.InitializeLogger();
            Log = logger;            
        }
    }
}
