using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using ShopManagement.Domain.Contracts;
using ShopManagement.Domain.Entities;
using ShopManagement.Framework;
using ShopManagement.MvcUI.Models.ProductManagement;
using ShopManagement.MvcUI.WebFramework;




namespace ShopManagement.MvcUI.Controllers
{

    public abstract class MyCustomRazorPage<T> : RazorPage<T>
    {

        public string GetName(string name) => name;

    }

    public class MyCustomController : Controller
    {
        public string GetName(string name) => name + name;
    }


    //public class Person
    //{
    //    public int Id { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //}

    [Authorize]
    public class ProductsManagementController : MyCustomController
    {
        private readonly IProductAppServices _productAppServices;

        public ProductsManagementController(IProductAppServices productAppServices)
        {
            _productAppServices = productAppServices;

            //Person p1 = new()
            //{
            //    Id = 1,
            //    FirstName = "Ali",
            //    LastName = "Ali"
            //};
            //string json = JsonSerializer.Serialize(p1);

            //Person? p2 = JsonSerializer.Deserialize<Person>(json);
        }

        [HttpPost]
        // Model Binding
        // Model Validating ***
        public bool ApiAdd(AddProductViewModel model)
        {
            var userId = User.GetUserId();
            // validate model
            if (ModelState.IsValid)
            {
                _productAppServices.AddProducts(model.Name, model.Price, model.Qty, userId);
                return true;
            }
            return false;
            //else
            //{
            //    ModelState.AddModelError(string.Empty, "چرا همه فرم رو خالی فرستادی");
            //    ModelState.AddModelError(string.Empty, "فیلد ها رو درست پر کن");
            //    return View(model);
            //}
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
            List<Product> products = await _productAppServices.GetListOfProducts();
            return View(products);
            //return GetName("");
        }


        public string GetName()
        {
            return GetName("");
        }

        #region Add-Product
        public IActionResult Add()
        {
            AddProductViewModel model = new();
            //model.CategoryList = new List<SelectListOpt>()
            //{
            //    new() { Value = 1, Title = "Digital" },
            //    new() { Value = 2, Title = "Home" },
            //};

            //ViewBag.CategoryList = new List<SelectListOpt>()
            //{
            //    new() { Value = 1, Title = "Digital" },
            //    new() { Value = 2, Title = "Home" },
            //};

            //var categories = await _categoryAppService.GetAllCategories();
            
            ViewBag.CategoryList = EnumUtility.GetEnumList<ProductCategoryEnum>();
            return View(model);
        }


        [HttpPost]
        // Model Binding
        // Model Validating ***
        public IActionResult Add(AddProductViewModel model)
        {
            var userId = User.GetUserId();
            // validate model
            if (ModelState.IsValid)
            {
                _productAppServices.AddProducts(model.Name, model.Price, model.Qty, userId);
                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "چرا همه فرم رو خالی فرستادی");
                ModelState.AddModelError(string.Empty, "فیلد ها رو درست پر کن");
                return View(model);
            }
        }
        #endregion


        #region Edit-Product
        public IActionResult Edit(int id)
        {

            if (id < 0)
                return NotFound();

            Product model = _productAppServices.GetProductDetails(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, string name, int price, int quantity)
        {
            var userId = User.GetUserId();
            _productAppServices.EditProducts(id, name, price, quantity, userId);
            return RedirectToAction("List");
        }
        #endregion

    }
}
