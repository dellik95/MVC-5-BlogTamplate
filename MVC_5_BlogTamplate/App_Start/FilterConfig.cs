using System.Web;
using System.Web.Mvc;

namespace MVC_5_BlogTamplate
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
