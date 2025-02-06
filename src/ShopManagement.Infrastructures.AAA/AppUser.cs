using Microsoft.AspNetCore.Identity;

namespace ShopManagement.Mvc.IdentityUI.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string? NationalCode { get; set; }
        public string? City { get; set; }
    }
}
