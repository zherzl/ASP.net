using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF_Klijent_Ajax_Test.AdvWorksServRef;
using Newtonsoft.Json;
using System.Web.Services;
using System.Web.Script.Services;

namespace WCF_Klijent_Ajax_Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public IEnumerable<Grad> GetGradovi()
        {
            ServiceAdventureWorksClient proxy = new ServiceAdventureWorksClient();
            return (from g in proxy.GetGradovi() select g).AsEnumerable<Grad>();
        }
        //public string GetGradovi()
        //{
        //    ServiceAdventureWorksClient proxy = new ServiceAdventureWorksClient();
        //    var query = from x in proxy.GetGradovi()
        //                select new
        //                {
        //                    IDGrad = x.IDGrad,
        //                    Naziv = x.Naziv,
        //                    Drzava = x.Drzava.Naziv
        //                };

        //    return JsonConvert.SerializeObject(query);
        //}

        [WebMethod]
        public ActionResult GetCities()
        {

            ServiceAdventureWorksClient proxy = new ServiceAdventureWorksClient();

            var list = JsonConvert.SerializeObject(proxy.GetGradovi().ToList(), Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    });

            return Content(list, "application/json");

            return Json(proxy.GetGradovi());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}