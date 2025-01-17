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



        [HttpGet]
        public async Task<List<Product>> List([FromHeader] string apiKey)
        {
            List<Product> products = await _productAppServices.GetListOfProducts();
            return products;
        }

    }
}
