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

        public class Vector2
        {
            double x, y;
            public Vector2( double x , double y )
            {
                this.x = x;
                this.y = y;
            }
        }

        public void StartForm()
        {
            API api = new API();

            // dynamic url 
            JObject DynamicUrl = JObject.Parse(api.callApi("http://opendata.technolution.nl/opendata/parkingdata/v1/dynamic/0c9bc6de-95be-4803-8fb9-483b2291338d"));
            // static url
            JObject StaticUrl = JObject.Parse(api.callApi("http://opendata.technolution.nl/opendata/parkingdata/v1/static/650bc16f-d210-49f3-992b-530f9360b251"));

            var jLabels = DynamicUrl.ToObject<Parking>();
            // dynamic information
            var pFDI = DynamicUrl["parkingFacilityDynamicInformation"];
            // static information
            var pFSI = DynamicUrl["parkingFacilityDynamicInformation"];

            var facStatus = pFDI["facilityActualStatus"];
            string indentifier = (string)pFDI["identifier"];
            int available_spots = (int)facStatus["vacantSpaces"];
            double UnixTimeStamp = (int)facStatus["lastUpdated"];
            DateTime unixTimestamp = UnixTimeStampToDateTime(UnixTimeStamp);


            // location required for Google maps API
            Vector2 locationForDisplay = (string)pFSI["locationForDisplay"] != null ? locationForDisplay = new Vector2((double)pFSI["locationForDisplay"]["latitude"], (double)pFSI["locationForDisplay"]["longitude"]) : locationForDisplay = null;

            // check available spots and return an color
            if (available_spots > 50)
            {
                placeholderbeschikbaar.BackColor = Color.Green;
            }else if (available_spots < 50)   {

                placeholderbeschikbaar.BackColor = Color.Orange;
            }else if(available_spots == 0)
            {
                placeholderbeschikbaar.BackColor = Color.Red;
            }
            // bind variable available_spots to label
            placeholderbeschikbaar.Text = available_spots.ToString();

            // bind variable name to label address
            adressplaceholder.Text = (string)pFDI["name"];
            // bind variable last updated to label 
            datum_placeholder.Text = unixTimestamp.ToString();

            // tarrifs
            tarief.Text = (string)pFDI["tariff"] != null ? tarief.Text = (string)pFDI["tariff"].ToString() : tarief.Text = "Geen tarief beschikbaar";
            if (tarief.Text == "Geen tarief beschikbaar")
            {
                placeholdertarief.Visible = false;
            }
            // Payment methods 
            contant.Text = (string)pFSI["paymentMethods"] != null ? contant.Text = (string)pFSI["paymentMethods"].ToString() : contant.Text = "Geen betaalmethodes aangegeven";
           


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

