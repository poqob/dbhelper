using Npgsql;
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
    public partial class AddCountry : Form, Iconnection
    {
        NpgsqlConnection conn;
        NpgsqlCommand comm;
        NpgsqlDataReader dr;
        string country;
        public AddCountry()
        {
            InitializeComponent();
            load();
            updateTable();
        }


        //component actions
        private void tbcountry_TextChanged(object sender, EventArgs e)
        {
            country = tbcountry.Text;
        }

        private void add_Click(object sender, EventArgs e)
        {
            formater(ref country);
            addRowToTable();
            updateTable();
        }
        private void delete_click(object sender, EventArgs e)
        {
            deleteLastRow();
            updateTable();
        }



        //interface
        public void load()
        {
            conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;User Id=dbhelper; Password=123456;");
            conn.Open();
            comm = new NpgsqlCommand();
            comm.Connection = conn;
            conn.Close();
            updateTable();
        }

        public void deleteLastRow()
        {
            bool succesful = true;
            try
            {
                conn.Open();
                comm.CommandText = "(select max(country_id) from adresses.countries);";
                int id = Convert.ToInt32(comm.ExecuteScalar());
                //MessageBox.Show(id.ToString());
                conn.Close();

                conn.Open();
                // delete last row from about.about
                comm.CommandText = "delete from adresses.countries where country_id= " + id + ";";
                comm.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                succesful = !succesful;
                MessageBox.Show(e.Message.ToString());
            }
            MessageBox.Show((succesful) ? "deletion succesfull" : "unsuccesfull");
        }

        public void updateTable()
        {
            conn.Open();
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select country from adresses.countries;";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.dgvcountry.DataSource = dt;
            }
            conn.Close();
        }

        public void addRowToTable()
        {
            bool succesful = true;
            try
            {
                // insert into adresses.countries
                conn.Open();
            comm.CommandText = "insert into adresses.countries (country) values ('" + country + "');";
            comm.ExecuteNonQuery();
            conn.Close();
            }
            catch (Exception e)
            {
                succesful = !succesful;
                MessageBox.Show(e.Message.ToString());
                conn.Close();
            }
            MessageBox.Show((succesful) ? "addition succesfull" : "unsuccesfull");
        }

        //format method
        private void formater(ref string a)
        {
            //we will write a string formatter here to avoid ' character error for sql solver.
            //example: john's villa. if we send it to sql engine the engine will fall in a conflict.
            int loc = 0;
            int counter = 0;


            if (a.Contains("'"))
            {
                while (loc != -1 || counter != a.Length)
                {
                    loc = a.IndexOf("'", loc);
                    a.Insert(loc, "'");
                    loc++;
                    counter++;
                }
            }
        }


    }
}
