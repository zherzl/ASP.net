using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_LoadDataOnMouseScroll.Models;
using System.Web.Script.Serialization;

namespace MVC_LoadDataOnMouseScroll.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        //[HttpPost]
        public ActionResult LoadCustomers(int skip, int take)
        {
            AdventureWorksModel context = new AdventureWorksModel();
            List<Kupac> customers = context.Kupac.OrderBy(x => x.IDKupac).Skip(skip).Take(take).ToList();

            JavaScriptSerializer js = new JavaScriptSerializer();
            //js.Serialize(customers);

            var custQuery = from c in customers
                            select new
                            {
                                IDKupac = c.IDKupac,
                                Ime = c.Ime,
                                Prezime = c.Prezime,
                                Email = c.Email,
                                Grad = c.Grad.Naziv
                            };

            return Json(custQuery.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}