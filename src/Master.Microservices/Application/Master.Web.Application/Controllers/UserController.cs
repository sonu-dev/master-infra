using Master.Core.Logging;
using Master.Web.Api.Common;
using Master.Web.Api.Models.Requests;
using Master.Web.Api.Services;
using Master.Web.Host.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Master.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ApiControllerBase<UserController>
    {
        private IUserService _userService;

        public UserController(IUserService userService, ILog<UserController> log): base(log)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);
            if (response == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(response);
        }
        
        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}

