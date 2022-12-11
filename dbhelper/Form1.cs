using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace dbhelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
           

        }

        private void add__Click(object sender, EventArgs e)
        {

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
            Form form = new AddMaterialPage();
            form.Show();
        }

       

        private void add_adress_click(object sender, EventArgs e)
        {
            Form form = new AddAdress();
            form.Show();
        }
    }
}
