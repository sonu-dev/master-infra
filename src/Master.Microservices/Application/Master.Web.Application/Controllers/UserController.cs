using Master.Core.Logging;
using Master.Microservices.Common.Bases;
using Master.Web.Api.Models.Requests;
using Master.Web.Api.Repositories;
using Master.Web.Host.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Master.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ApiControllerBase<UserController>
    {
        private IUserRepository _userService;

        public UserController(IUserRepository userService, ILog<UserController> log): base(log, null)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);
            if (response == null)
            {
                return new BadRequestResult();
            }

            return new OkObjectResult(response);
        }
        
        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return new OkObjectResult(users);
        }
    }
}

