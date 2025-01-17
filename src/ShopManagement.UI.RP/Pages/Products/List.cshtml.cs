using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Domain.Contracts;
using ShopManagement.Domain.Entities;

namespace ShopManagement.RazorPageUI.Pages
{
    public class ProductManagementModel : PageModel
    {
        private readonly IProductAppServices _productAppServices;

        public ProductManagementModel(IProductAppServices productAppServices)
        {
            _productAppServices = productAppServices;
        }

        // Page Model
        public List<Product> Products = new();

        public async Task OnGet()
        {
            Products = await _productAppServices.GetListOfProducts();
        }
    }
}
