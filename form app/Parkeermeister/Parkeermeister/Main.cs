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
            // make instance of object API
            API api = new API();
            IList<JToken> parkingGaragesRaw;
            // dynamic url 
            JObject DynamicUrl = JObject.Parse(api.callApi("http://opendata.technolution.nl/opendata/parkingdata/v1/dynamic/0c9bc6de-95be-4803-8fb9-483b2291338d"));
            // static url
            JObject StaticUrl = JObject.Parse(api.callApi("http://opendata.technolution.nl/opendata/parkingdata/v1/static/650bc16f-d210-49f3-992b-530f9360b251"));
            JObject allData = JObject.Parse(api.callApi("http://opendata.technolution.nl/opendata/parkingdata/v1"));
           
            parkingGaragesRaw = allData["parkingFacilities"].Children().ToList();
            // dynamic information
            var pFDI = DynamicUrl["parkingFacilityDynamicInformation"];
            // static information
            var pFSI     = StaticUrl["parkingFacilityStaticInformation"];

            var PFAlldata = allData["parkingFacilities"];
            // static second array 
            var facStatus = pFDI["facilityActualStatus"];
            // indentiefier of parking url
            string indentifier = (string)pFDI["identifier"];
            // available spots output of json static object
            int available_spots = (int)facStatus["vacantSpaces"];
            // unix last updated timestamp ouput of json static object
            double UnixTimeStamp = (int)facStatus["lastUpdated"];
            // function to convert unix time stamp to datetime
            DateTime unixTimestamp = UnixTimeStampToDateTime(UnixTimeStamp);

            // location required for Google maps API
            string latitude =   pFSI["locationForDisplay"]  != null ? latitude =  (string) pFSI["locationForDisplay"]["latitude"]  : latitude = "";
            string longitude =  pFSI["locationForDisplay"]  != null ? longitude = (string) pFSI["locationForDisplay"]["longitude"] : longitude = "";
            // check available spots and return an color
            if (available_spots > 50)
            {
                placeholderbeschikbaar.BackColor = Color.Green;
            }
            else if (available_spots < 50)
            {

                placeholderbeschikbaar.BackColor = Color.Orange;
            }
            else if (available_spots == 0)
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
            contant.Text = pFSI["paymentMethods"] != null ? contant.Text = (string)pFSI["paymentMethods"].ToString() : contant.Text = "Geen betaalmethodes aangegeven";

            // progress bar 
            int total_spaces = (int)facStatus["parkingCapacity"];
            int free_spaces = (int)facStatus["vacantSpaces"];
            float total = ((float)free_spaces / (float)total_spaces) * 100;
            progressBar1.Value = 100 - (int)total;

            // showing all parking garages
            foreach (JToken jt in parkingGaragesRaw)
            {
                ListBoxParking.Items.Add((string)jt["name"]);
                // ListBoxParking.MouseDoubleClick += new MouseEventHandler(ListBoxOnClick(jt["identiefier"]));

            }
            try
            {
                // A queryadress must be properly
                StringBuilder queryadress = new StringBuilder();
                queryadress.Append("https://www.google.nl/maps/@" + latitude + ","+ longitude + ",15z");
           
                webBrowser1.Navigate(queryadress.ToString());
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }


        private void ListBoxOnClick(object sender, EventArgs e , string identiefer)
        {
            if (ListBoxParking.SelectedItem != null)
            {
                
            }
        }
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp converter to datetime 
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}

