using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using RestSharp;
using ModelLibrary.Entities;
using FootballDataSource.ServiceReference1;
//using FootballDataSource.FootballDataService;

namespace FootballDataSource
{
    public class GetFootballDataSource
    {
        private Competitions compt;
        private string _apiVer = "v1";
        private string apiToken = "1da45b53956c477dbca8af43bd407172";

        public string ApiGlavniUrl { get { return "http://api.football-data.org/"; }  }
        public string ApiVerzija { get { return _apiVer; } set { _apiVer = value; } }


        RestClient client;

        public GetFootballDataSource()
        {
            client = new RestClient(this.ApiGlavniUrl);
        }

        public Competitions GetTeamModel()
        {

            string urlCompetitions = Competitions.GetCompetitionsUrl(ApiVerzija, null);
            compt = GetCompetitions(urlCompetitions, client);

            //string urlFixtures = RestSharpNacin(compt)
            return compt;

            //GetRequest(path);
            //var product = GetProductAsync(path);
            // Obični način - dodati request iz RestSharp u nastavak url-a
            //string x = GET(url);
            //var serializer = new JavaScriptSerializer();
            //TeamModel model = serializer.Deserialize<TeamModel>(x);
            //return model;
        }

        public List<Team> GetTeamsForCompetition(string competitionCode)
        {
            Competitions compt = GetTeamModel();
            int competitionId = GetCompetitionId(compt, competitionCode);
            string urlTeamsForCompetition = Teams.GetTeamsForCompetitionLink(ApiVerzija, competitionId);
            Teams teams = GetTeamsForCompetition(urlTeamsForCompetition, client);

            return teams.teams;
        }

        private int GetCompetitionId(Competitions competitions, string leagueCode)
        {
            int compId;

            try
            {
                compId = competitions.FirstOrDefault(x => x.League.Equals(leagueCode)).Id;
            }
            catch (Exception)
            {
                compId = -1;
            }

            return compId;
        }

        private Competitions GetCompetitions(string compUrl, RestClient client)
        {
            
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            //http://api.football-data.org/v1/competitions/?season=2015
            var request = new RestRequest(compUrl, Method.GET);
            //request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
            //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

            // easily add HTTP Headers
            request.AddHeader("X-Auth-Token", apiToken);

            // add files to upload (works with compatible verbs)
            //request.AddFile(path);

            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string
            
            // or automatically deserialize result
            // return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            //RestResponse<List<Competition>> response2 = (RestResponse<List<Competition>>)client.Execute<List<Competition>>(request);
            RestResponse<Competitions> response2 = (RestResponse<Competitions>)client.Execute<Competitions>(request);

            Competitions compet = (Competitions)response2.Data;
            //var name = response2.Data. .Name;

            // easy async support
            //client.ExecuteAsync(request, response => {
            //    Console.WriteLine(response.Content);
            //});

            // async with deserialization
            //var asyncHandle = client.ExecuteAsync<TeamModel>(request, response => {
            //    Console.WriteLine(response.Data.Name);
            //});

            // abort the request on demand
            //asyncHandle.Abort();
            return response2.Data;
        }

        private Teams GetTeamsForCompetition(string teamsUrl, RestClient client)
        {
            var request = new RestRequest(teamsUrl, Method.GET);
            request.AddHeader("X-Auth-Token", apiToken);
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string

            RestResponse<Teams> response2 = (RestResponse<Teams>)client.Execute<Teams>(request);

            Teams compet = (Teams)response2.Data;
            return response2.Data;
        }

        // Returns JSON string
        //static GET(string url)
        //{
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //    try
        //    {
        //        request.Headers.Add(HttpRequestHeader.Authorization, "1da45b53956c477dbca8af43bd407172");
        //        WebResponse response = request.GetResponse();
        //        using (Stream responseStream = response.GetResponseStream())
        //        {
        //            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
        //            return reader.ReadToEnd();
        //        }
        //    }
        //    catch (WebException ex)
        //    {
        //        WebResponse errorResponse = ex.Response;
        //        using (Stream responseStream = errorResponse.GetResponseStream())
        //        {
        //            StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
        //            String errorText = reader.ReadToEnd();
        //            // log errorText
        //        }
        //        throw;
        //    }
        //}
    }



    //private static Competitions GetIt(string url)
    //{
    //    var client = new RestClient(url);
    //    // client.Authenticator = new HttpBasicAuthenticator(username, password);

    //    //http://api.football-data.org/v1/competitions/?season=2015
    //    var request = new RestRequest("competitions/?season=2016", Method.GET);
    //    //request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
    //    //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

    //    // easily add HTTP Headers
    //    request.AddHeader("X-Auth-Token", "1da45b53956c477dbca8af43bd407172");

    //    // add files to upload (works with compatible verbs)
    //    //request.AddFile(path);

    //    // execute the request
    //    IRestResponse response = client.Execute(request);
    //    var content = response.Content; // raw content as string

    //    // or automatically deserialize result
    //    // return content type is sniffed but can be explicitly set via RestClient.AddHandler();
    //    //RestResponse<List<Competition>> response2 = (RestResponse<List<Competition>>)client.Execute<List<Competition>>(request);
    //    RestResponse<Competitions> response2 = (RestResponse<Competitions>)client.Execute<Competitions>(request);

    //    Competitions compet = (Competitions)response2.Data;
    //    //var name = response2.Data. .Name;

    //    // easy async support
    //    //client.ExecuteAsync(request, response => {
    //    //    Console.WriteLine(response.Content);
    //    //});

    //    // async with deserialization
    //    //var asyncHandle = client.ExecuteAsync<TeamModel>(request, response => {
    //    //    Console.WriteLine(response.Data.Name);
    //    //});

    //    // abort the request on demand
    //    //asyncHandle.Abort();
    //    return response2.Data;
    //}
}
