using Microsoft.AspNetCore.Mvc;
using ShopManagement.AppServices;
using ShopManagement.Infrastructures.Db;
using ShopManagement.Infrastructures.Repositories;

namespace ShopManagement.UI.Controllers
{
    public class ProductsManagementController : Controller
    {
        public ProductsManagementController()
        {
        }


        public async Task<IActionResult> List()
        {
            //List<Product> products = new()
            //{
            //    new Product() { Id = 1, Price = 10, Qty = 5, Title = "Glass" },
            //    new Product() { Id = 2, Price = 10, Qty = 5, Title = "PC" },
            //    new Product() { Id = 3, Price = 10, Qty = 5, Title = "Tablet" },
            //};

            //ShopDbContext db = new();
            //List<Product> products = db.Products.ToList();


            ShopDbContext db = new();
            ProductRepository repo = new(db);
            ProductAppServices productAppServices = new(repo);
            List<Domain.Entities.Product> products = await productAppServices.GetListOfProducts();
            return View(products);
        }
    }
}
