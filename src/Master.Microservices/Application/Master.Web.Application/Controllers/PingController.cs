using Master.Core.Logging;
using Master.Web.Api.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Master.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]    
    public class PingController : ApiControllerBase<PingController>
    {
        public PingController(ILog<PingController> log) : base(log)
        {
        }

        [HttpGet]
        public async Task<string> PingAsync()
        {
            Log.Debug($"Called at {DateTime.Now}");
            return await Task.FromResult($"Ping at {DateTime.Now}");
        }
    }
}
