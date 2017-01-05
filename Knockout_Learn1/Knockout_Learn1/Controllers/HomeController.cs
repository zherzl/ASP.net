using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Knockout_Learn1.Models;

namespace Knockout_Learn1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult InteractiveBindings()
        {
            AdventureWorksObpModel db = new AdventureWorksObpModel();
            Grad g = new Grad();

            IEnumerable<SelectListItem> DrzavaID = (db.Drzavas.Select(x => new SelectListItem { Value = x.IDDrzava.ToString(), Text = x.Naziv }).ToList());
            ViewData["DrzavaID"] = DrzavaID;
            return View("InteractiveBindingsAddCity", g);
        }

        [HttpPost]
        public ActionResult InteractiveBindingsAddCity()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Podaci()
        {
            try
            {
                AdventureWorksObpModel db = new AdventureWorksObpModel();
                List<Grad> gradovi = new List<Grad>();

                List<Grad> tmp = db.Grads.ToList();
                foreach (Grad g in tmp)
                {
                    Grad novi = new Grad();
                    novi.Naziv = g.Naziv;
                    novi.DrzavaID = g.DrzavaID;
                    novi.IDGrad = g.IDGrad;

                    gradovi.Add(novi);
                }

                return Json(gradovi, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                string g = ex.Message;
            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}