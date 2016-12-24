using FootballDataSource.Models;
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

namespace FootballDataSource
{
    public static class GetFootballData
    {
        public static TeamModel GetTeamModel()
        {
            string url = "http://api.football-data.org/v1/";
                                                                                  //var product = GetProductAsync(path);
                                                                                  //GetRequest(path);

            return RestSharpNacin(url);
            // Obični način - dodati request iz RestSharp u nastavak url-a
            string x = GET(url);
            var serializer = new JavaScriptSerializer();
            TeamModel model = serializer.Deserialize<TeamModel>(x);
            return model;
        }

        private static TeamModel RestSharpNacin(string url)
        {
            var client = new RestClient(url);
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("competitions/398/teams", Method.GET);
            //request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
            //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

            // easily add HTTP Headers
            request.AddHeader("X-Auth-Token", "1da45b53956c477dbca8af43bd407172");

            // add files to upload (works with compatible verbs)
            //request.AddFile(path);

            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string

            // or automatically deserialize result
            // return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            RestResponse<TeamModel> response2 = (RestResponse<TeamModel>)client.Execute<TeamModel>(request);
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

        // Returns JSON string
        static string GET(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                request.Headers.Add(HttpRequestHeader.Authorization, "1da45b53956c477dbca8af43bd407172");
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }
    }
}
