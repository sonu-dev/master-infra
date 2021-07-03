using Master.Common.Bases;
using Master.DesignPatterns.Behavioral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.DesignPatterns.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /* Bavioral - TemplateMethod */

            var clientType = typeof(IClient);
            var clientTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => clientType.IsAssignableFrom(p));

            var clients = new List<IClient>();

            foreach (var generator in clientTypes)
            {
                clients.Add(Activator.CreateInstance(generator) as IClient);
            }

            clients.ToList().ForEach(async c => await c.RunAsync());
          

            Console.WriteLine("Hello World!");
        }
    }
}
