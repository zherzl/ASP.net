using Knockout.DataService.ViewModels;
using Knockout.Repository.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Knockout.DataService.Mapping;

namespace Knockout_EF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (AdventureWorksContext db = new AdventureWorksContext())
            {
                List<DrzavaGradViewModel> gradovi = db.Gradovi.ToList().ToGradViewModel();
                return View(gradovi);
            }
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