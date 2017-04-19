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
