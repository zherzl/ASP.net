using LocalizationTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocalizationTest.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            using (MojModel db = new MojModel())
            {
                try
                {
                    Amount am = db.Amounts.Single(x => x.IDAmount == 1);
                    //Amount am = new Amount();
                    am.AmountValue = 550.35M;
                    am.UserID = 1;
                    am.CategoryID = 2;
                    am.CurrencyID = 2;
                    am.Description = "bla bla";
                    am.EntryDate = DateTime.Now;
                    am.InUse = true;

                    //db.Amounts.Add(am);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return View("Error");
                }
                
            }
            return View();
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