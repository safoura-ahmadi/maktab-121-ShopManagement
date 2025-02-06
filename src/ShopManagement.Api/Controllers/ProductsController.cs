using Microsoft.AspNetCore.Mvc;
using ShopManagement.Domain.Contracts;
using ShopManagement.Domain.Entities;
using ShopManagement.Framework;

namespace ShopManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class ProductsController : ControllerBase
    {
        private readonly IProductAppServices _productAppServices;
        private readonly SettingsModel settingsModel;

        public ProductsController(IProductAppServices productAppServices,
            SettingsModel settingsModel)
        {
            _productAppServices = productAppServices;
            this.settingsModel = settingsModel;
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> Find(int id)
        {
            return Ok("Salam");
            //return NoContent();
            
            //StatusCodes.
            //return ();
        }


        [HttpGet("[action]")]
        public async Task<List<Product>> GetAll()
        {
            // [FromHeader]string apikey

            //if (apikey != "2ad67edb-aa21-4deb-a020-d71dc5c8b20f")
            //    throw new Exception("شما دسترسی به این ای پی آی ندارید");

            List<Product> products = await _productAppServices.GetListOfProducts();
            return products;

            //var result = Get(5);
            //return new List<Product> { result };
        }

        [HttpGet("[action]")]
        public Product Get(int id)
        {
            Product model = _productAppServices.GetProductDetails(id);
            return model;
        }

        [HttpPost("add-product")]
        public int Add(Product model)
        {
            var id = _productAppServices.AddProducts(model.Title, model.Price, model.Qty, 0);
            return id;
        }

        [HttpPost("edit-product")]
        // ModelState Validated
        public void Edit(Product model)
        {
            _productAppServices.EditProducts(model.Id, model.Title, model.Price, model.Qty, 0);            
        }

    }
}
