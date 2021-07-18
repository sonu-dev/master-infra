using Master.Core.Logging;

namespace Master.Core.Common.Bases
{
    public class RespositryBase<T>
    {
        protected readonly ILog<T> Log;

        public RespositryBase(ILog<T> log)
        {
            Log = log;
        }
    }
}
