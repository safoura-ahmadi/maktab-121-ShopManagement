using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ShopManagement.Framework
{

    public static class EnumUtility
    {
        public static List<SelectListOpt> GetEnumList<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(e => new SelectListOpt
                {
                    Value = Convert.ToInt32(e),
                    Title = GetDisplayName(e)
                })
                .ToList();
        }
        public static string GetDisplayName<T>(T enumValue) where T : Enum
        {
            MemberInfo? memberInfo = typeof(T).GetMember(enumValue.ToString()).FirstOrDefault();
            if (memberInfo != null)
            {
                DisplayAttribute? displayAttribute = memberInfo.GetCustomAttribute<DisplayAttribute>();
                if (displayAttribute != null)
                {
                    return displayAttribute.Name;
                }
            }
            return enumValue.ToString();
        }
    }
}
