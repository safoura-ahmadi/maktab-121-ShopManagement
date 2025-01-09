using Microsoft.AspNetCore.Mvc;
using ShopManagement.MvcUI.Models;
using ShopManagement.UI.Models;
using System.Diagnostics;

namespace ShopManagement.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<HomeController> _logger;
        private readonly Settings _settings;

        public HomeController(
            IConfiguration configuration,
            ILogger<HomeController> logger,
            Settings settings)
        {
            _configuration = configuration;
            _logger = logger;
            _settings = settings;
        }

        public IActionResult Index()
        {
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
    }
}
