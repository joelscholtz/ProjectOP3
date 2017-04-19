using Parkeermeister.classes;
using Parkeermeister.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parkeermeister
{
    public partial class Load : Form
    {
        public Load()
        {
            InitializeComponent();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SoundPlayer my_wave_file = new SoundPlayer("C:/1.wav");
            my_wave_file.Play();
            progressBar1.Increment(1);
            
            if (progressBar1.Value == 100)
            {
                timer1.Stop();


               
            }
        }
    }
}
