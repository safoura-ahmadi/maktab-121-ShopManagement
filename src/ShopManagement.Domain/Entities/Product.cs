using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "وارد نمودن نام محصول اجباری می باشد")]
        [StringLength(10, ErrorMessage = "نام محصول نمی تواند بیش از 10 کاراکتر باشد")]
        public string? Title { get; set; }


        public int Price { get; set; }

        [Range(1, 100, ErrorMessage = "تعداد باید بین 1 تا 100 باشد")]
        public int Qty { get; set; }
    }
}
