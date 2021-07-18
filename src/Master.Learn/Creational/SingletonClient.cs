using System;
using System.Threading;

namespace Master.Learning.DesignPatterns.Creational
{
    public class SingletonClient
    {      
        public void Execute()
        {
            var thread1 = new Thread(new ThreadStart(DisplayCreateSingletonTime));
            var thread2 = new Thread(new ThreadStart(DisplayCreateSingletonTime));

            thread1.Start();
            thread2.Start();
        }
        private void DisplayCreateSingletonTime()
        {
            while (true)
            {
                var singleInstance = Singleton.GetInstance;
                if (singleInstance != null)
                {
                    Thread.Sleep(500);
                    Console.WriteLine($"{Thread.CurrentThread.Name} - {singleInstance.CreationTime}");
                }
            }
        }
    }
}
