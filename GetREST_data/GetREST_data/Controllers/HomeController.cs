using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using ModelLibrary.Entities;
using FootballDataSource;
using GetREST_data.FootballService;

namespace GetREST_data.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //string url = "http://api.football-data.org/v1/competitions/398/teams";
            //string x = GET(url);
            //var serializer = new JavaScriptSerializer();
            new GetFootballDataSource().GetTeamModel();
            FootballServiceClient client = new FootballServiceClient();
            List<Team> teams = new FootballDataSource.GetFootballDataSource().GetTeamsForCompetition(LeagueCodes.ChampionsLeague);
            client.AddTeamRange(teams);

            return View(teams);
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