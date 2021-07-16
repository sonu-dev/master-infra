using Master.Core.Common;
using Master.Core.Logging;
using System.Threading.Tasks;

namespace Master.QuartzScheduler.Client
{
    public class Client : ClientBase<Client>
    {
        public Client(ILog<Client> log) : base(log)
        {
            Log.Debug("Hello World !");
        }

        public override Task ExecuteAsync()
        {
            Log.Debug("Executing Quarta Jobs");
            return Task.CompletedTask;
        }
    }
}
