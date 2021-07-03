using Master.Common.Bases;
using System.Threading.Tasks;

namespace Master.QuartzScheduler.Client
{
    public class Client : ClientBase<Client>
    {
        public Client() : base()
        {
            Log.Information("Hello World !");
        }

        public override Task ExecuteAsync()
        {
            Log.Debug("Executing Quarta Jobs");
            return Task.CompletedTask;
        }
    }
}
