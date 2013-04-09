using System.Web;
using System.Web.Mvc;

namespace MVC40_DynamicUI_Generation_Using_KnockoutJS
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}