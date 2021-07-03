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

            var templateMethodClient = new TemplateMethodClient();
            await templateMethodClient.RunAsync();          

            Console.ReadKey();
        }
    }
}
