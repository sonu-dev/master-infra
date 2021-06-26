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
            //Read Configuration from appSettings
            var configuration = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json")
                  .Build();

            Log.Logger = new LoggerConfiguration()
              .ReadFrom.Configuration(configuration)
              .MinimumLevel.Debug()
              .WriteTo.Console()
              .CreateLogger();            
            return Log.Logger;
        }
    }
}
