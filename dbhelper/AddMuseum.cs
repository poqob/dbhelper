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
    public partial class AddMuseum : Form, Iconnection
    {

        //fields
        NpgsqlConnection conn;
        NpgsqlCommand comm;
        NpgsqlDataReader dr;
        string museum;
        string museumtext;
        string museumurl;
        string adressID;
        string countryID;
        string cityID;
        string districtID;

        public AddMuseum()
        {
            InitializeComponent();
            load();
            updateTable();
        }

        //form controlls-actions

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            museum = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            adressID = textBox2.Text;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            museumtext = richTextBox1.Text;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            museumurl = richTextBox2.Text;
        }

        private void add_Click(object sender, EventArgs e)
        {
            formater(ref museum);
            addRowToTable();
            updateTable();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            deleteLastRow();
            updateTable();
        }





        //interface methods
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
                comm.CommandText = "(select max(museum_id) from museums.museums);";
                int id = Convert.ToInt32(comm.ExecuteScalar());

                //delete lastly added row from about.about and about.about_museum
                comm.CommandText = "delete from about.about where about.about_id=(max(about_id) from about.about);";
                comm.ExecuteNonQuery();

                // delete last row from museums.museums
                comm.CommandText = "delete from museums.museums where museum_id= " + id + ";";
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
            comm.CommandText = "select * from museums.museums;";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.dataGridView1.DataSource = dt;
            }

            comm.CommandType = CommandType.Text;
            comm.CommandText = "drop table if exists newtable ;drop table if exists newtable2; create temp table newtable2(adress_id serial); create temp table newtable(country_id, country, city_id, city) as (select adresses.countries.country_id, country, adresses.cities.city_id, city,district from adresses.countries inner join adresses.cities on adresses.cities.country_id = adresses.countries.country_id inner join adresses.districts on adresses.districts.city_id = adresses.cities.city_id order by country_id); alter table newtable add column adress_id serial; select adress_id, country, city,district from newtable; ";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.dataGridView2.DataSource = dt;
            }


            conn.Close();
        }

        //TODO: how to acces temp tables, learn structure of temp tables.
        public void addRowToTable()
        {

            bool succesful = true;
            try
            {
                conn.Open();
                // insert into about.about
                comm.CommandText = "insert into about.about (about_name,about_who) values ('" + museum + "','m');";
                comm.ExecuteNonQuery();

                //obtaining lastly added input id from about.about
                comm.CommandText = "(select max(about_id) from about.about);";
                int id = Convert.ToInt32(comm.ExecuteScalar());

                //obtaining country id
                comm.CommandText = "select country_id from newtable where adress_id=" + adressID + ";";
                countryID = comm.ExecuteScalar().ToString();

                //obtaining city id
                comm.CommandText = "select city_id from newtable where adress_id=" + adressID + ";";
                cityID = comm.ExecuteScalar().ToString();

                //obtaining district id
                comm.CommandText = "select district_id from newtable where adress_id=" + adressID + ";";
                districtID = comm.ExecuteScalar().ToString();

                //insert into about.about_museum
                comm.CommandText = "insert into about.about_museum (about_id,about_text,about_img) values (" + id + ",'" + museumtext + "','" + museumurl + "');";
                comm.ExecuteNonQuery();

                // insert into museums.museums
                comm.CommandText = "insert into museums.museums (museum,country_id,city_id,district_id,about_id) values ('" + museum + "'," + countryID + ","+cityID+ "," +districtID+ "," +id+");";
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
