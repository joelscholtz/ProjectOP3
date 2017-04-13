using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Parkeermeister.models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Parkeermeister.classes
{
    class API {

        //{
        //    public static async Task<JObject> TaskApi(string url)
        //    {

        //        using (HttpClient client = new HttpClient())
        //        {
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //            var response = await client.GetAsync(url);

        //            string content = await response.Content.ReadAsStringAsync();

        //            return JObject.Parse(content);

        //        }
        //    }

        public string callApi(string url)
        {
            string response;
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");

                try {
                    response = client.DownloadString(url);
                }
                catch (WebException ex)
                {
                     response = "";
                     
                }

                return response;

            }
        }
    }
}
