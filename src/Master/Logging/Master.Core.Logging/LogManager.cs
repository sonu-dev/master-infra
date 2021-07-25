using Microsoft.Extensions.Configuration;
using Serilog;
using System.IO;
using System.Reflection;

namespace Master.Core.Logging
{
    public class LogManager
    {
        public static ILogger LoadLogger()
        {
            //Read Configuration from logsettings
            var configuration = new ConfigurationBuilder()   
                  .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                  .AddJsonFile("appsettings.json")
                  .Build();

            return new LoggerConfiguration()
                   .ReadFrom.Configuration(configuration)
                   .Enrich.FromLogContext()
                   .CreateLogger();
        }
    }
}
