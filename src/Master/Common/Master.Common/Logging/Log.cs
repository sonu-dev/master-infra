using Serilog;

namespace Master.Common.Logging
{
    public abstract class Log<T> : ILog<T>
    {
        private readonly ILogger _logger;
        public Log()
        {
            _logger = LogManager.InitializeLogger();
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
