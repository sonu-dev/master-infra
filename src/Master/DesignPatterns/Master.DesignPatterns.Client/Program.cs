using Master.DesignPatterns.Client.Host;

namespace Master.DesignPatterns.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // Run Host
            var host = new DesignPatternsHost().BuildHost(args);
            host.StartAsync().Wait();                      
        }
    }
}
