using Microsoft.AspNetCore.Mvc;
using ShopManagement.Domain.Contracts;
using ShopManagement.Domain.Entities;

namespace ShopManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class ProductsController : ControllerBase
    {
        private readonly IProductAppServices _productAppServices;

        public ProductsController(IProductAppServices productAppServices)
        {
            _productAppServices = productAppServices;
        }



        [HttpGet("[action]")]
        public async Task<List<Product>> GetAll()
        {
            // [FromHeader]string apikey

            //if (apikey != "2ad67edb-aa21-4deb-a020-d71dc5c8b20f")
            //    throw new Exception("شما دسترسی به این ای پی آی ندارید");

            List<Product> products = await _productAppServices.GetListOfProducts();
            return products;
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
            var id = _productAppServices.AddProducts(model.Title, model.Price, model.Qty);
            return id;
        }

        [HttpPost("edit-product")]
        public void Edit(Product model)
        {
            _productAppServices.EditProducts(model.Id, model.Title, model.Price, model.Qty);            
        }

    }
}
