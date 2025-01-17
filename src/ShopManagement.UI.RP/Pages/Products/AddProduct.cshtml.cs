using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Domain.Contracts;
using ShopManagement.Framework;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.RazorPageUI.Pages.Products
{
    public class AddProductModel : PageModel
    {
        private readonly IProductAppServices _productAppServices;

        public AddProductModel(IProductAppServices productAppServices)
        {
            _productAppServices = productAppServices;
        }


        #region Model
        public List<SelectListOpt> CategoryList { get; set; }

        [BindProperty]
        public AddProductPageModel Product { get; set; }
        #endregion



        public void OnGet()
        {
            CategoryList = EnumUtility.GetEnumList<ProductCategoryEnum>();
        }

        public IActionResult OnPost()
        {
            // validate model
            if (ModelState.IsValid)
            {
                _productAppServices.AddProducts(Product.Name, Product.Price, Product.Qty);
                return RedirectToPage("/Products/List");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "چرا همه فرم رو خالی فرستادی");
                ModelState.AddModelError(string.Empty, "فیلد ها رو درست پر کن");
                return Page();
            }
        }
    }

    public class AddProductPageModel
    {
        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "وارد نمودن نام محصول اجباری می باشد")]
        [StringLength(10, ErrorMessage = "نام محصول نمی تواند بیش از 10 کاراکتر باشد")]
        public string? Name { get; set; }

        [Display(Name = "گروه کالا")]
        [Required(ErrorMessage = "وارد نمودن گروه کالا اجباری می باشد")]
        public ProductCategoryEnum CategoryId { get; set; }


        public int Price { get; set; }

        [Range(1, 100, ErrorMessage = "تعداد باید بین 1 تا 100 باشد")]
        public int Qty { get; set; }
    }
}
