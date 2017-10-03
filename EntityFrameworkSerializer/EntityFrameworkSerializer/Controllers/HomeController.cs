using DAL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace EntityFrameworkSerializer.Controllers
{
    public class HomeController : Controller
    {
        DALManager manager = new DALManager();

        public ActionResult Index()
        {
            DrzaveResponse response = manager.GetDrzave();
            return View(response);
        }


        public ActionResult GetCountries()
        {
            DrzaveResponse response = manager.GetDrzave();
            var result = Json(JsonConvert.SerializeObject(response));
            return result;
        }


        public ActionResult GetCities()
        {
            CitiesResponse response = manager.GetCities();
            var result = Json(JsonConvert.SerializeObject(response));
            return result;
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            
            return View();
        }
    }
}