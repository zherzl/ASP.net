using Newtonsoft.Json;
using ObrisiMeMVC.Models;
using ObrisiMeMVC.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ObrisiMeMVC.Controllers
{
    public class HomeController : Controller
    {
        AdvRepo repo = new AdvRepo();
        public ActionResult Index()
        {
            var nekeDrzave =
               from d in repo.Drzave()
                where !(from g in repo.Gradovi()
                            select g.DrzavaID).Contains(d.IDDrzava)
                select d;

            

            ViewBag.drzave1 = nekeDrzave;
            //ViewBag.drzave2 = nekeDrzave2;
            return View();
        }

        public ActionResult Gradovi(int? id)
        {
            string json = JsonConvert.SerializeObject(repo.Gradovi(), Formatting.Indented);

            return Json(json);
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}