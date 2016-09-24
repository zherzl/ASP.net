using EBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBudget.Controllers
{
    public class PregledPrihodController : Controller
    {
        private UsersContext db = new UsersContext();
        //
        // GET: /PregledPrihod/

        public ActionResult Index()
        {
            DetaljiTrosakPrihodModelView dtpmv = new DetaljiTrosakPrihodModelView();
            return View("Index", dtpmv);
        }


        [HttpGet]
        public ActionResult Edit(int? idPrihod)
        {

            CreatePrihodView ct = new CreatePrihodView();
            ct.Prihod = db.PrihodTrosak.Find(idPrihod);
            return View("Edit", ct);
        }

        [HttpPost]
        public ActionResult Edit(CreatePrihodView ct)
        {
            //ct.Trosak.KategorijaID = int.Parse(ct.Kategorije[0].Value);
            //db.Entry(ct.Trosak).State = System.Data.EntityState.Modified;
            //db.SaveChanges();
            Repozitorij.UpdatePrihod(ct.Prihod);

            return RedirectToAction("Index");
        }

    }
}
