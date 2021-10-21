using Microsoft.AspNetCore.Mvc;

namespace Master.Microservices.HealthCheck.Controllers
{
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return Redirect("/healthchecks-ui");
            //return View();
        }
    }
}
