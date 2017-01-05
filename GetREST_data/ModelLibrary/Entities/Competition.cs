using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Entities
{
    public class Competitions : List<Competition>
    {
        // Radi jednostavnijeg mapiranja rest-a prema modelu

        private static int? _apiLinkSezona;
        /// Ako nije ApiLinkSezona postavljena, vraća trenutnu godinu
        static string ApiLinkForSeason = "competitions/?season=" + Sezona; 

        /// null sezona vraća akt. godinu
        public static string GetCompetitionsUrl(string apiVerzija, int? sezona)
        {
            Sezona = sezona;
            return string.Format("{0}/{1}", apiVerzija, ApiLinkForSeason);
        }

        public static int? Sezona
        {
            get
            {
                if (_apiLinkSezona == null)
                    return DateTime.Now.Year;
                return _apiLinkSezona.Value;
            }
            set { _apiLinkSezona = value; }
        }

    }

    public class Competition
    {
        [DeserializeAs(Name = "_links")]
        public List<Link> Links { get; set; }
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }
        [DeserializeAs(Name = "caption")]
        public string Caption { get; set; }
        [DeserializeAs(Name = "year")]
        public int Year { get; set; }
        [DeserializeAs(Name = "league")]
        public string League { get; set; }
        [DeserializeAs(Name = "numberOfTeams")]
        public int NumberOfTeams { get; set; }
        [DeserializeAs(Name = "currentMatchday")]
        public int CurrentMatchday { get; set; }
        [DeserializeAs(Name = "numberOfMatchdays")]
        public int NumberOfMatchdays { get; set; }
        [DeserializeAs(Name = "numberOfGames")]
        public int NumberOfGames { get; set; }
        [DeserializeAs(Name = "lastUpdated")]
        public DateTime LastUpdated { get; set; }

        
    }

    public static class LeagueCodes
    {
        public static string Ger_Bundesliga { get { return "BL1"; } }
        public static string Eng_PremiereLeague { get { return "PL"; } }
        public static string Italy_SerieA { get { return "SA"; } }
        public static string Spain_PrimeraDivision { get { return "PD"; } }
        public static string France_Ligue_1 { get { return "FL1"; } }
        public static string ChampionsLeague { get { return "CL"; } }

        //BL1 Germany	1. Bundesliga
        //BL2 Germany	2. Bundesliga
        //BL3 Germany	3. Bundesliga
        //DFB Germany Dfb-Cup
        //PL  England Premiere League
        //EL1 England League One
        //ELC England Championship
        //FAC England FA-Cup
        //SA  Italy Serie A
        //SB  Italy Serie B
        //PD  Spain Primera Division
        //SD  Spain Segunda Division
        //CDR Spain Copa del Rey
        //FL1 France  Ligue 1
        //FL2 France  Ligue 2
        //DED Netherlands Eredivisie
        //PPL Portugal Primeira Liga
        //GSL Greece Super League
        //CL  Europe Champions-League
        //EL  Europe UEFA-Cup
        //EC  Europe European-Cup of Nations
        //WC  World World-Cup

    }
    //http://api.football-data.org/v1/competitions/?season=2015

    //"_links": {
    //    "self": {
    //        "href": "http://api.football-data.org/v1/competitions/424"
    //    },
    //    "teams": {
    //        "href": "http://api.football-data.org/v1/competitions/424/teams"
    //    },
    //    "fixtures": {
    //        "href": "http://api.football-data.org/v1/competitions/424/fixtures"
    //    },
    //    "leagueTable": {
    //        "href": "http://api.football-data.org/v1/competitions/424/leagueTable"
    //    }
    //},
    //"id": 424,
    //"caption": "European Championships France 2016",
    //"league": "EC",
    //"year": "2016",
    //"currentMatchday": 7,
    //"numberOfMatchdays": 7,
    //"numberOfTeams": 24,
    //"numberOfGames": 51,
    //"lastUpdated": "2016-07-10T21:32:20Z"
}
