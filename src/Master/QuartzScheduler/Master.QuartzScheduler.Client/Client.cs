using Master.Common.Bases;
using Master.Common.Logging;
using System;
using System.Threading.Tasks;

namespace Master.QuartzScheduler.Client
{
    public class Client : ClientBase<Client>
    {
        public Client(ILog<Client> log) : base(log)
        {
            Log.Debug("Hello World !");
        }

        public override Task ExecuteAsync(IServiceProvider serviceProvider)
        {
            Log.Debug("Executing Quarta Jobs");
            return Task.CompletedTask;
        }
    }
}
