using Master.Web.Api.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Master.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]    
    public class PingController : ApiControllerBase<PingController>
    {
        public PingController(ILogger<PingController> logger) : base(logger)
        {
        }

        [HttpGet]
        public async Task<string> PingAsync()
        {
            Log.LogDebug($"Called at {DateTime.Now}");
            return await Task.FromResult($"Ping at {DateTime.Now}");
        }
    }
}
