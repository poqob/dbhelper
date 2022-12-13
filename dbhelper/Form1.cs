using System;
using System.Windows.Forms;

namespace dbhelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void add_movement_Click(object sender, EventArgs e)
        {
            //open add movement page.
            Form form = new AddMovement();
            form.Show();

        }

        private void add_artist_click(object sender, EventArgs e)
        {
            //open adding artist page.
            Form form = new AddArtist();
            form.Show();
        }

        private void add_material_Click(object sender, EventArgs e)
        {
            //adding material page
            Form form = new AddMaterialPage();
            form.Show();
        }

        private void add_adress_click(object sender, EventArgs e)
        {
            //add adress page
            Form form = new AddAdress();
            form.Show();
        }

        private void add_museum_click(object sender, EventArgs e)
        {
            //add museum page
            Form form = new AddMuseum();
            form.Show();
        }

        private void add_art_Click(object sender, EventArgs e)
        {
            //add museum page
            Form form = new AddArtRoute();
            form.Show();
        }
    }
}
