using EvidencijaRacunaObrta.Business;
using EvidencijaRacunaObrta.Business.Request;
using EvidencijaRacunaObrta.Business.Response;
using EvidencijaRacunaObrta.Models.ObrtModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvidencijaRacunaObrta.Controllers
{
    public class RacunController : BaseController
    {
        // GET: Racun
        RacunManager man;

        public ActionResult Index()
        {
            return View();
        }

        // GET: Racun/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Racun/Create
        [Authorize]
        [HttpGet]
        public ActionResult Create(int? idRacuna)
        {
            man = new RacunManager(db, CurrentUserId);
            CreateRacunRequest request = new CreateRacunRequest
            {
                RacunId = idRacuna
            };
            
            CreateRacunResponse response = man.GetCreateRacunResponse(request);
                if (!response.Success) DisplayError(response.Error);

            return View(response);
        }



        // POST: Racun/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(CreateRacunResponse response)//FormCollection collection, string[] opis_)
        {
            try
            {
                // TODO: Add insert logic here
                //string[] opis = collection["opis_"].Split(',');
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult AddStavka(int? id)
        {
            man = new RacunManager(db, CurrentUserId);
            CreateStavkeRequest request = new CreateStavkeRequest
            {
                StavkaId = id
            };

            CreateStavkeResponse response = man.GetCreateStavkeResponse(request);

            return PartialView(response.Stavka);
        }

        public ActionResult Top10Stavke()
        {
            man = new RacunManager(db, CurrentUserId);
            GetTop10StavkeResponse response = man.GetTop10StavkeResponse(new GetTop10StavkeRequest());

            return Json(response);
        }



        // GET: Racun/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Racun/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Racun/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Racun/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
