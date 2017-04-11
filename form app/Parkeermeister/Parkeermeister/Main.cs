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

            JObject ding = JObject.Parse(api.callApi("http://opendata.technolution.nl/opendata/parkingdata/v1/static/8d85bbdb-8bbd-4a24-b35f-85f21186ec04"));


            var jLabels = ding.ToObject<Parking>();

            adressplaceholder.Text = (string)ding["parkingFacilityStaticInformation"]["name"];
            label4.Text = (string)ding["parkingFacilityStaticInformation"]["identifier"];
        }
      }
}

