using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbhelper
{
    public partial class AddAdress : Form
    {
        public AddAdress()
        {
            InitializeComponent();
        }





        private void addNewCountry_Click(object sender, EventArgs e)
        {
            //go to add country form.
            Form form = new AddCountry();
            form.Show();
            this.Close();
        }

        private void addNewCity_Click(object sender, EventArgs e)
        {
            //go to add city form.
            Form form = new AddCity();
            form.Show();
            this.Close();
        }

        private void addNewDistrict_Click(object sender, EventArgs e)
        {
            //go to add district form.
            Form form = new AddDistrict();
            form.Show();
            this.Close();
        }





    }
}
