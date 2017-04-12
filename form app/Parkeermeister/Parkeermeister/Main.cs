using Newtonsoft.Json.Linq;
using Parkeermeister.classes;
using Parkeermeister.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parkeermeister
{
    public partial class Main : Form
    {
        public Main()
        {
            // Thread t = new Thread(new ThreadStart(StartForm));
            // t.Start();
            // Thread.Sleep(1000);

            // Application.Run(new Load());
            //  t.Abort();
            InitializeComponent();
            StartForm();
        }



        public void StartForm()
        {
            API api = new API();

            JObject DynamicUrl = JObject.Parse(api.callApi("http://opendata.technolution.nl/opendata/parkingdata/v1/dynamic/0c9bc6de-95be-4803-8fb9-483b2291338d"));
            JObject StaticUrl = JObject.Parse(api.callApi("http://opendata.technolution.nl/opendata/parkingdata/v1/static/650bc16f-d210-49f3-992b-530f9360b251"));

            var jLabels = DynamicUrl.ToObject<Parking>();
            var pFDI = DynamicUrl["parkingFacilityDynamicInformation"];
            var facStatus = pFDI["facilityActualStatus"];
            string indentifier = (string)pFDI["identifier"];
            int available_spots = (int)facStatus["vacantSpaces"];
            double UnixTimeStamp = (int)facStatus["lastUpdated"];
            DateTime unixTimestamp = UnixTimeStampToDateTime(UnixTimeStamp);

            if (available_spots > 50)
            {
                placeholderbeschikbaar.BackColor = Color.Green;
            }else if (available_spots < 50)   {

                placeholderbeschikbaar.BackColor = Color.Orange;
            }else if(available_spots == 0)
            {
                placeholderbeschikbaar.BackColor = Color.Red;
            }

            adressplaceholder.Text = (string)pFDI["name"];
            placeholderbeschikbaar.Text = available_spots.ToString();
            datum_placeholder.Text = unixTimestamp.ToString();

            // tarieven
            tarief.Text = (string)pFDI["tariff"] != null ? tarief.Text = (string)pFDI["tariff"].ToString() : tarief.Text = "Geen tarief beschikbaar";
            if (tarief.Text == "Geen tarief beschikbaar")
            {
                placeholdertarief.Visible = false;
            }


            // progress bar 
            int total_spaces = (int)facStatus["parkingCapacity"];
            int free_spaces =  (int)facStatus["vacantSpaces"];
            float  total = ((float)free_spaces / (float)total_spaces) * 100;
            progressBar1.Value = 100 - (int) total;
        }
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}

