﻿using System;
using System.Windows.Forms;
namespace dbhelper
{
    public partial class AddArtRoute : Form
    {
        public AddArtRoute()
        {
            InitializeComponent();
        }


        private void AddPaint_Click(object sender, EventArgs e)
        {
            Form form = new AddArtTotally('p', "art_paints");
            form.Show();
            this.Close();

        }

        private void AddStatues_Click(object sender, EventArgs e)
        {
            Form form = new AddArtTotally('s', "art_statues");
            form.Show();
            this.Close();

        }

        private void AddDecorativeArt_Click(object sender, EventArgs e)
        {
            Form form = new AddArtTotally('d', "art_decorative");
            form.Show();
            this.Close();
        }

        private void AddArchitecture_Click(object sender, EventArgs e)
        {
            Form form = new AddArtTotally('r', "art_architecture");
            form.Show();
            this.Close();

        }
    }
}
