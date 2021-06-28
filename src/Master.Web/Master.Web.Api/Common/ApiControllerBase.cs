using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Master.Web.Api.Common
{
    public abstract class ApiControllerBase<T> : ControllerBase       
    {
        public ILogger Log { get; private set; }
        public ApiControllerBase(ILogger<T> log)
        {
            Log = log;
        }
    }
}
