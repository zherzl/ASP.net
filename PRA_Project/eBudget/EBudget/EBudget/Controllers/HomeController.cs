using EBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBudget.Controllers
{
    public class HomeController : Controller
    {
        //Inicijalizacija EBudgetContexta
        //private EBudgetContext db = new EBudgetContext();

        public ActionResult Unos(Opis o)
        {
            if (ModelState.IsValid)
            {
                using (UsersContext db = new UsersContext())
                {
                    db.Opis.Add(o);
                    db.SaveChanges();
                }

            }
            return Content("Sve 5!");
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Početna";
            ViewBag.Message = "Dobrodošli na stranice eBudgeta";

            

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Praćenje prihoda, rashoda, primitaka, troškova....";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakt stranica";

            return View();
        }

        
    }
}
