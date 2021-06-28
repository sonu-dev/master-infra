using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Master.Web.Api.Common
{
    public abstract class ApiControllerBase : ControllerBase
    {
        public ILogger Log { get; private set; }
        public ApiControllerBase(ILogger log)
        {
            Log = log;
        }
    }
}
