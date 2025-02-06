using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string? NationalCode { get; set; }
        public string? City { get; set; }
    }
}
