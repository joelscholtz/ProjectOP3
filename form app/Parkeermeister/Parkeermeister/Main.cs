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
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }

        private void fgf_Load(object sender, EventArgs e)
        {

        }

        public void StartForm()
        {
            Application.Run(new Load());
            var url = API.TaskApi("http://opendata.technolution.nl/opendata/parkingdata/v1/static/8d85bbdb-8bbd-4a24-b35f-85f21186ec04");
            var jsondata = url.Result.ToObject<Parking>();
            Betaalmethode.Text = jsondata.name;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       
        

        }
    }

