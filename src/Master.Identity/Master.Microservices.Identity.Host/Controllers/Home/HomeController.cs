using IdentityModel.Client;
using IdentityServer4.Services;
using Master.Core.Logging;
using Master.Microservices.Identity.Client;
using Master.Microservices.Identity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using System.Text.Json;
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

        public async Task<IActionResult> GenerateAccessToken([Bind("ClientId, Scope, Secret")]TokenRequestViewModel tokenRequestViewModel)
        {
            var tokenResponse = await IdentityClientManager.GenerateTokenAsync(tokenRequestViewModel.ClientId, tokenRequestViewModel.Scope, tokenRequestViewModel.Secret);
            ViewBag.Token = tokenResponse.AccessToken;
            return View("Index");
        }
        #endregion
    }
}
