using Master.Web.Api.Common;
using Master.Web.Api.Models.Requests;
using Master.Web.Api.Services;
using Master.Web.Host.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Master.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiControllerBase<UsersController>
    {
        private IUserService _userService;

        public UsersController(IUserService userService, ILogger<UsersController> logger): base(logger)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

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

