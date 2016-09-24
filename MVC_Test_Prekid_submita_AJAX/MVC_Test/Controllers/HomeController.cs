using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Test.Models;

namespace MVC_Test.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult GetData(int broj)
        {
            AdventureWorksOBPEntities db = new AdventureWorksOBPEntities();
            return PartialView("Kupac", db.Kupac.Single(x => x.IDKupac == broj));
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


       
    }
}