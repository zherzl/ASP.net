using System.Web;
using System.Web.Mvc;

namespace _Glupost_Ajax_direktURL
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
