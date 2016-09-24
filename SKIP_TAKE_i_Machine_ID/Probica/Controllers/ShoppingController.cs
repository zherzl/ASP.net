using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Probica.Models;

namespace Probica.Controllers
{
    public class ShoppingController : Controller
    {
        AdvModel db;
        public ActionResult Home()
        {
            db = new AdvModel();
            return View(db.Kupci.OrderBy(x => x.IDKupac).Skip(0).Take(5).ToList());
        }


        public ActionResult DajJosZapisa(int kolikoUcitati, int kolikoPreskociti) 
        {
            db = new AdvModel();
            return Json(db.Kupci.OrderBy(x => x.IDKupac).Skip(0).Take(5).First());
        }
    }
}