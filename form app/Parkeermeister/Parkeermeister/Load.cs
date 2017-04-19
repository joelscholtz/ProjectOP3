using Parkeermeister.classes;
using Parkeermeister.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            string path = Directory.GetCurrentDirectory();
            string audiofile1 = "1.wav";
            SoundPlayer sp = new SoundPlayer(Path.Combine(path, audiofile1));
            sp.Play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            progressBar1.Increment(25);
            
           
            if (progressBar1.Value == 10000)
            {
                timer1.Stop();
               
            }
        }
    }
}
