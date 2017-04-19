namespace Parkeermeister
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.placeholdertarief = new System.Windows.Forms.Label();
            this.laatstbijgewerkt = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.adressplaceholder = new System.Windows.Forms.Label();
            this.adress = new System.Windows.Forms.Label();
            this.placeholderbeschikbaar = new System.Windows.Forms.Label();
            this.tarief = new System.Windows.Forms.Label();
            this.datum_placeholder = new System.Windows.Forms.Label();
            this.ListBoxParking = new System.Windows.Forms.ListBox();
            this.webControl1 = new Awesomium.Windows.Forms.WebControl(this.components);
            this.aantal_parkeerplekken = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label3.Location = new System.Drawing.Point(699, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Details:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(700, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Beschikbaar:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(703, 86);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(220, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // placeholdertarief
            // 
            this.placeholdertarief.AutoSize = true;
            this.placeholdertarief.Location = new System.Drawing.Point(700, 168);
            this.placeholdertarief.Name = "placeholdertarief";
            this.placeholdertarief.Size = new System.Drawing.Size(128, 17);
            this.placeholdertarief.TabIndex = 10;
            this.placeholdertarief.Text = "(tarief placeholder)";
            // 
            // laatstbijgewerkt
            // 
            this.laatstbijgewerkt.AutoSize = true;
            this.laatstbijgewerkt.Location = new System.Drawing.Point(700, 205);
            this.laatstbijgewerkt.Name = "laatstbijgewerkt";
            this.laatstbijgewerkt.Size = new System.Drawing.Size(133, 17);
            this.laatstbijgewerkt.TabIndex = 11;
            this.laatstbijgewerkt.Text = "laatst bijgewerkt op:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label8.Location = new System.Drawing.Point(699, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(196, 22);
            this.label8.TabIndex = 13;
            this.label8.Text = "Activiteit afgelopen dag";
            // 
            // adressplaceholder
            // 
            this.adressplaceholder.AutoSize = true;
            this.adressplaceholder.Location = new System.Drawing.Point(24, 622);
            this.adressplaceholder.Name = "adressplaceholder";
            this.adressplaceholder.Size = new System.Drawing.Size(148, 17);
            this.adressplaceholder.TabIndex = 14;
            this.adressplaceholder.Text = "- (adress placeholder)";
            // 
            // adress
            // 
            this.adress.AutoSize = true;
            this.adress.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.adress.Location = new System.Drawing.Point(23, 600);
            this.adress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.adress.Name = "adress";
            this.adress.Size = new System.Drawing.Size(62, 22);
            this.adress.TabIndex = 16;
            this.adress.Text = "Adres:";
            // 
            // placeholderbeschikbaar
            // 
            this.placeholderbeschikbaar.AutoSize = true;
            this.placeholderbeschikbaar.Location = new System.Drawing.Point(796, 56);
            this.placeholderbeschikbaar.Name = "placeholderbeschikbaar";
            this.placeholderbeschikbaar.Size = new System.Drawing.Size(231, 17);
            this.placeholderbeschikbaar.TabIndex = 9;
            this.placeholderbeschikbaar.Text = "(beschikbare plaatsen placeholder)";
            // 
            // tarief
            // 
            this.tarief.AutoSize = true;
            this.tarief.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.tarief.Location = new System.Drawing.Point(699, 136);
            this.tarief.Name = "tarief";
            this.tarief.Size = new System.Drawing.Size(62, 22);
            this.tarief.TabIndex = 6;
            this.tarief.Text = "Tarief:";
            // 
            // datum_placeholder
            // 
            this.datum_placeholder.AutoSize = true;
            this.datum_placeholder.Location = new System.Drawing.Point(828, 205);
            this.datum_placeholder.Name = "datum_placeholder";
            this.datum_placeholder.Size = new System.Drawing.Size(135, 17);
            this.datum_placeholder.TabIndex = 17;
            this.datum_placeholder.Text = "(datum placeholder)";
            // 
            // ListBoxParking
            // 
            this.ListBoxParking.FormattingEnabled = true;
            this.ListBoxParking.ItemHeight = 16;
            this.ListBoxParking.Location = new System.Drawing.Point(10, 4);
            this.ListBoxParking.Name = "ListBoxParking";
            this.ListBoxParking.ScrollAlwaysVisible = true;
            this.ListBoxParking.Size = new System.Drawing.Size(248, 532);
            this.ListBoxParking.TabIndex = 18;
            this.ListBoxParking.SelectedIndexChanged += new System.EventHandler(this.ListBoxParking_SelectedIndexChanged);
            // 
            // webControl1
            // 
            this.webControl1.Location = new System.Drawing.Point(274, 4);
            this.webControl1.Size = new System.Drawing.Size(394, 496);
            this.webControl1.TabIndex = 20;
            // 
            // aantal_parkeerplekken
            // 
            this.aantal_parkeerplekken.AutoSize = true;
            this.aantal_parkeerplekken.Location = new System.Drawing.Point(24, 554);
            this.aantal_parkeerplekken.Name = "aantal_parkeerplekken";
            this.aantal_parkeerplekken.Size = new System.Drawing.Size(46, 17);
            this.aantal_parkeerplekken.TabIndex = 21;
            this.aantal_parkeerplekken.Text = "label1";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(693, 285);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "plaatsen";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(433, 328);
            this.chart1.TabIndex = 22;
            this.chart1.Text = "chart1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1139, 733);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.aantal_parkeerplekken);
            this.Controls.Add(this.webControl1);
            this.Controls.Add(this.ListBoxParking);
            this.Controls.Add(this.datum_placeholder);
            this.Controls.Add(this.adress);
            this.Controls.Add(this.adressplaceholder);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.laatstbijgewerkt);
            this.Controls.Add(this.placeholdertarief);
            this.Controls.Add(this.placeholderbeschikbaar);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tarief);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ParkeerMeister ™";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label placeholdertarief;
        private System.Windows.Forms.Label laatstbijgewerkt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label adressplaceholder;
        private System.Windows.Forms.Label adress;
        private System.Windows.Forms.Label placeholderbeschikbaar;
        private System.Windows.Forms.Label tarief;
        private System.Windows.Forms.Label datum_placeholder;
        private System.Windows.Forms.ListBox ListBoxParking;
        private Awesomium.Windows.Forms.WebControl webControl1;
        private System.Windows.Forms.Label aantal_parkeerplekken;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

