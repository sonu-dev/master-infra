using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

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

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()               
                .CreateLogger();
            return Log.Logger;
        }
    }
}
