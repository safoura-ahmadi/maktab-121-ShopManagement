using Microsoft.AspNetCore.Mvc;

namespace ShopManagement.MvcUI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
