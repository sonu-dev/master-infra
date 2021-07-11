using Master.Common.Bases;
using Master.Common.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Master.DesignPatterns.Creational
{
    public class SingletonClient : ClientBase<SingletonClient>
    {
        public SingletonClient(ILog<SingletonClient> log, IServiceProvider serviceProvider) : base(log)
        {
        }

        #region ClientBase Members
        public override Task ExecuteAsync(IServiceProvider serviceProvider)
        {
            var thread1 = new Thread(new ThreadStart(DisplayCreateSingletonTime));
            var thread2 = new Thread(new ThreadStart(DisplayCreateSingletonTime));

            thread1.Start();
            thread2.Start();

            return Task.CompletedTask;
        }

        public override bool CanExecute()
        {
            return false;
        }

        #endregion

        private void DisplayCreateSingletonTime()
        {
            while (true)
            {
                var singleInstance = Singleton.GetInstance;
                if (singleInstance != null)
                {
                    Thread.Sleep(500);
                    Log.Debug($"{Thread.CurrentThread.Name} - {singleInstance.CreationTime}");
                }
            }
        }
    }
}
