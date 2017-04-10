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


namespace Parkeermeister.classes
{
    class API

    {
        public static async Task<JObject> TaskApi(string url)
        {
           
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(url);

                string content = await response.Content.ReadAsStringAsync();

                return JObject.Parse(content);

            }
        }

    }
}
