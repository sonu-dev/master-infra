namespace Master.Core.Logging
{
    public interface ILog<T> 
    {
        void Info(string messageTemplate);
        void Debug(string messageTemplate);
        void Error(string messageTemplate);        
    }
}
