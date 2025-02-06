using System.Security.Claims;

namespace ShopManagement.MvcUI.WebFramework
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal principal) =>
           int.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier));
    }

    //public class Mobile
    //{

    //}
}
