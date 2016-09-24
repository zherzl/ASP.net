using System.Web;
using System.Web.Mvc;

namespace ObrisiME_MVC_EF_PovezaneTablice_Ajax
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
