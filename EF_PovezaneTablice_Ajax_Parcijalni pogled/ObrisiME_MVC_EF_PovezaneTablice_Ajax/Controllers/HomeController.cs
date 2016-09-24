using ObrisiME_MVC_EF_PovezaneTablice_Ajax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ObrisiME_MVC_EF_PovezaneTablice_Ajax.Controllers
{
	public class HomeController : Controller
	{
		AdvModel db = new AdvModel();
		public ActionResult Index()
		{
			return View();
		}


//		[ChildActionOnly]
		public ActionResult ParcijalniPogled(int? take, int? skip)
		{
			return PartialView(db.Grads
					.Take(take.Value)
					.OrderBy(x => x.IDGrad)
					.Skip(skip.Value).ToList());
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}