using Microsoft.Extensions.Configuration;
using Serilog;

namespace Master.Common.Logging
{
    public class LogManager
    {
        public static ILogger InitializeLogger()
        {
            //Read Configuration from logsettings
            var configuration = new ConfigurationBuilder()
                  .AddJsonFile("logSettings.json")
                  .Build();

         return Serilog.Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
        }
    }
}
