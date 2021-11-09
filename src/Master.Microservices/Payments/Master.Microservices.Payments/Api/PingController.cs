using Master.Core.Logging;
using Master.Microservices.Common.Bases;
using Master.Microservices.Common.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Master.Microservices.Payments.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PingController : ApiControllerBase<PingController>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PingController(ILog<PingController> log, IHttpContextAccessor httpContextAccessor) : base(log)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public ActionResult Get()
        {
            Log.Debug($"Calling PingController at {DateTime.Now}");
            var result = new JsonResult(_httpContextAccessor.HttpContext?.User?.Claims.Select(c => new IdentityClaim(c.Type, c.Value)));
            return result;
        }
    }
}
