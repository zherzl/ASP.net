using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvidencijaRacunaObrta.Controllers
{
    public class HomeController : BaseController
    {

        
        public ActionResult Index()
        {
            string[] role = GetCurrentUserRoles().ToArray();
            return View();
        }

        [Authorize(Roles = "AdminMain, ObicnaRola")]
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