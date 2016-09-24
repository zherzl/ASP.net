using EBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace EBudget.Controllers
{
    public class PregledTrosakController : Controller
    {
        UsersContext db = new UsersContext();
        //
        // GET: /PregledTrosak/
        public ActionResult Index()
        {
            DetaljiTrosakPrihodModelView dtpmv = new DetaljiTrosakPrihodModelView();
            return View("Index", dtpmv);
        }

            
        [HttpGet]
        public ActionResult Edit(int? idTrosak)
        {
        
            CreateTrosakView ct = new CreateTrosakView();
            ct.Trosak = db.PrihodTrosak.Find(idTrosak);
            return View("Edit", ct);
        }

        [HttpPost]
        public ActionResult Edit(CreateTrosakView ct)
        {
            //ct.Trosak.KategorijaID = int.Parse(ct.Kategorije[0].Value);
            //db.Entry(ct.Trosak).State = System.Data.EntityState.Modified;
            //db.SaveChanges();
            Repozitorij.UpdateTrosak(ct.Trosak);

            return RedirectToAction("Index");
        }
    }
}
