using System.ComponentModel.DataAnnotations;

namespace ShopManagement.MvcUI.Models.ProductManagement
{
    public class AddProductViewModel
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

        //public List<SelectListOpt> CategoryList { get; set; }
    }

    public enum ProductCategoryEnum
    {
        [Display(Name = "دیجیتال")]
        Digital = 1,

        [Display(Name = "خانه")]
        Home = 2,
    }
}
