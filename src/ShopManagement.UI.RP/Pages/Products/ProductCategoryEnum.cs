using System.ComponentModel.DataAnnotations;

namespace ShopManagement.RazorPageUI.Pages.Products;

public enum ProductCategoryEnum
{
    [Display(Name = "دیجیتال")]
    Digital = 1,

    [Display(Name = "خانه")]
    Home = 2,
}