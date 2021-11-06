using IdentityServer4.Services;
using Master.Core.Logging;
using Master.Microservices.Identity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Master.Microservices.Identity.Controllers.Home
{
    // [SecurityHeaders]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        #region Data Members
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IWebHostEnvironment _environment;
        private readonly ILog<HomeController> _log;
        #endregion

        #region Constructor
        public HomeController(IIdentityServerInteractionService interaction, IWebHostEnvironment environment, ILog<HomeController> log)
        {
            _log = log;
            _environment = environment;
            _interaction = interaction;
        }
        #endregion

        #region Actions
        public IActionResult Index()
        {
            if (_environment.IsDevelopment())
            {
                // only show in development
                return View();
            }

            _log.Info("Homepage is disabled in production. Returning 404.");
            return NotFound();
        }

       public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Error(string errorId)
        {
            var vm = new ErrorViewModel();

            // retrieve error details from identityserver
            var message = await _interaction.GetErrorContextAsync(errorId);
            if (message != null)
            {
                vm.Error = message;
                if (!_environment.IsDevelopment())
                {
                    // only show in development
                    message.ErrorDescription = null;
                }
            }

            return View("Error", vm);
        }
        #endregion
    }
}
