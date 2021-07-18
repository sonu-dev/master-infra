using Master.Core.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Master.Web.Api.Common
{
    public abstract class ApiControllerBase<T> : ControllerBase       
    {
        protected ILog<T> Log { get; private set; }
        public ApiControllerBase(ILog<T> log)
        {
            Log = log;
        }
    }
}
