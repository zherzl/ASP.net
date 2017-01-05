using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EvidencijaRacunaObrta.Models.ObrtModels;
using EvidencijaRacunaObrta.Business;
using EvidencijaRacunaObrta.Business.Response;

namespace EvidencijaRacunaObrta.Controllers
{
    public class HomeController : BaseController
    {
        [Authorize]
        public ActionResult Index()
        {
            
            EvidencijaContext db = new EvidencijaContext();
            int zapisa = db.Obrti.Where(x => x.UserId == CurrentUserId).Count();

            if (zapisa == 0)
            {
                InicijalnoPunjenje ip = new InicijalnoPunjenje(db, CurrentUserId);
                ResponseBase response = ip.Napuni();

                if (!response.Success)
                {
                    DisplayError(response.Error);
                }
            }
            
            List<Racun> racuni = db.Racuni.ToList();

            //DisplayError("Greška je probna");
            return View(racuni);
        }

        public ActionResult CreateRacun()
        {

            return View();
        }

        [Authorize(Roles = "AdminMain, ObicnaRola")]
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