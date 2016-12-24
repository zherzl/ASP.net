using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace GetREST_data.Controllers
{
    public static class HttpKlijent
    {
        public static HttpClient client = new HttpClient();
        
        static HttpKlijent()
        {
            RunAsync().Wait();
        }

        

        static async Task RunAsync()
        {
            // New code:
            client.BaseAddress = new Uri("http://api.football-data.org/v1/competitions/398/teams");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
        }
    }
}