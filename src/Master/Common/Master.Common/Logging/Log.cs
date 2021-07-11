using Serilog;

namespace Master.Common.Logging
{
    public class Log<T> : ILog<T>
    {
        private readonly ILogger _logger;
        public Log(ILogger logger)
        {
            _logger = logger;
        }
       public void Info(string messageTemplate)
        {
            _logger.Information(messageTemplate);
        }
       public void Debug(string messageTemplate)
        {
            _logger.Debug(messageTemplate);
        }
       public void Error(string messageTemplate)
        {
            _logger.Error(messageTemplate);
        }
    }
}
