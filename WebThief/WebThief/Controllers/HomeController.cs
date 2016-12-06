using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThief.HtmlParser;

namespace WebThief.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ParserMain pm = new ParserMain();
            List<LinkItem> links = pm.ParsedLinks();

            return View(links);
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