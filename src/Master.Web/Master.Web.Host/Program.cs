using Master.Common.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using GenericHost = Microsoft.Extensions.Hosting.Host;

namespace Master.Web.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LogManager.InitializeLogger();
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return GenericHost.CreateDefaultBuilder(args)
            // Enable serilog for logging
                .UseSerilog()
             // Host to Kestral web server, that is default asp.net web server
             .ConfigureWebHostDefaults(webBuilder =>
             {
                 webBuilder.UseStartup<Startup>();                          
             });
        }
    }
}
