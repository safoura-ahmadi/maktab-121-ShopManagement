using Microsoft.AspNetCore.Mvc;
using ShopManagement.Framework;
using ShopManagement.UI.Models;
using System.Diagnostics;

namespace ShopManagement.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<HomeController> _logger;
        private readonly SettingsModel _settings;

        public HomeController(
            IConfiguration configuration,
            ILogger<HomeController> logger,
            SettingsModel settings)
        {
            _configuration = configuration;
            _logger = logger;
            _settings = settings;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("About page visited at {Time} by User {UserId}", DateTime.UtcNow.ToLongTimeString(), 5);
            //_logger.LogInformation("About page visited at " + DateTime.UtcNow.ToLongTimeString());
            //_logger.Log(LogLevel.Trace, "کاربر خریدش رو تکمیل کرد");
            //_logger.Log(LogLevel.Debug, "کاربر خریدش رو تکمیل کرد");
            //_logger.Log(LogLevel.Information, "کاربر خریدش رو تکمیل کرد");
            //_logger.Log(LogLevel.Warning, "کاربر خریدش رو تکمیل کرد");
            //_logger.Log(LogLevel.Error, "کاربر خریدش رو تکمیل کرد");
            //_logger.Log(LogLevel.Critical, "کاربر خریدش رو تکمیل کرد");
            return View();
        }
        public IActionResult Env()
        {
            return View();
        }
        public IActionResult RazorSyntax()
        {
            return View();
        }
        public IActionResult Config()
        {
            //string universityName = _configuration.GetSection("Settings:ApplicationName").Value;
            string universityName = _settings.ApplicationName;
            return View("Config", universityName);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult A1()
        {
            return View("CommonView");
        }

        public IActionResult A2()
        {
            return View("CommonView");
        }

        public IActionResult A3()
        {
            return View("CommonView");
        }

        public IActionResult A4()
        {
            return View("CommonView");
        }

        public IActionResult A5()
        {
            return View("CommonView");
        }

        public IActionResult FindView(int vNumber)
        {
            switch (vNumber)
            {
                case 1: return View("v1");
                case 2: return View("v2");
                case 3: return View("v3");
            }

            return View("CommonView");
        }

        public bool IdentitySeedData()
        {
            // Create Role Admin
            // Create Role Supplier
            // Create Role Customer

            // Create Admin user And add to Admin Role


            return true;
        }

    }
}
