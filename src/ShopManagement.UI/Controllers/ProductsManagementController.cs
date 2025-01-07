using Microsoft.AspNetCore.Mvc;
using ShopManagement.Domain.Contracts;
using ShopManagement.Domain.Entities;

namespace ShopManagement.UI.Controllers
{
    public class ProductsManagementController : Controller
    {
        private readonly IProductAppServices _productAppServices;

        public ProductsManagementController(IProductAppServices productAppServices)
        {
            _productAppServices = productAppServices;
        }

        public async Task<IActionResult> List()
        {
            // 01
            //List<Product> products = new()
            //{
            //    new Product() { Id = 1, Price = 10, Qty = 5, Title = "Glass" },
            //    new Product() { Id = 2, Price = 10, Qty = 5, Title = "PC" },
            //    new Product() { Id = 3, Price = 10, Qty = 5, Title = "Tablet" },
            //};

            // 02
            //ShopDbContext db = new();
            //List<Product> products = db.Products.ToList();

            // 03
            //ShopDbContext db = new();
            //ProductRepository repo = new(db);
            //ProductAppServices productAppServices = new(repo);
            //List<Domain.Entities.Product> products = await productAppServices.GetListOfProducts();

            // 04
            List<Domain.Entities.Product> products = await _productAppServices.GetListOfProducts();
            return View(products);
        }


        #region Add-Product
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(string name, int price, int quantity)
        {
            _productAppServices.AddProducts(name, price, quantity);
            return RedirectToAction("List");
        }
        #endregion


        #region Edit-Product
        public IActionResult Edit(int id)
        {
            Product model = _productAppServices.GetProductDetails(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Product model)
        {
            // ...
            return RedirectToAction("List");
        }
        #endregion

    }
}
