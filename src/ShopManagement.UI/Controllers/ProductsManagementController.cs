using Microsoft.AspNetCore.Mvc;
using ShopManagement.Domain.Entities;
using ShopManagement.Infrastructures.Db;

namespace ShopManagement.UI.Controllers
{
    public class ProductsManagementController : Controller
    {
        public IActionResult List()
        {
            //List<Product> products = new()
            //{
            //    new Product() { Id = 1, Price = 10, Qty = 5, Title = "Glass" },
            //    new Product() { Id = 2, Price = 10, Qty = 5, Title = "PC" },
            //    new Product() { Id = 3, Price = 10, Qty = 5, Title = "Tablet" },
            //};

            ShopDbContext db = new();
            List<Product> products = db.Products.ToList();

            return View(products);
        }
    }
}
