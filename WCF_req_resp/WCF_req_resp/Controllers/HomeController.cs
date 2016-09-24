using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF_req_resp.ServiceReference1;

namespace WCF_req_resp.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            AdventureServiceClient client = new AdventureServiceClient();
            GetGradoviRequest gr = new GetGradoviRequest();
            gr.DrzavaId = 1;

            List<Grad> gradovi = client.GetGradoviEf();
            GetGradoviResponse grResp = client.GetGradovi(gr);
            //MojServisClient client = new MojServisClient();
            //string bla = client.GetData(3);
            return View(grResp);
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