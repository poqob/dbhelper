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
    public partial class AddAboutArtist : Form, Iconnection
    {
        string aboutname = "";
        string abouttext = "";
        string aboutimg = "";
        NpgsqlConnection conn;
        NpgsqlCommand comm;
        NpgsqlDataReader dr;
        public AddAboutArtist()
        {
            InitializeComponent();
            load();
        }

        //interface
        public void addRowToTable()
        {


            // insert into about.about
            conn.Open();
            comm.CommandText = "insert into about.about (about_name,about_who) values ('" + aboutname + "','i');";
            comm.ExecuteNonQuery();
            conn.Close();
            // insert into about.about_movement

            conn.Open();
            comm.CommandText = "(select max(about_id) from about.about);";
            int id = Convert.ToInt32(comm.ExecuteScalar());
            //MessageBox.Show(id.ToString());
            conn.Close();

            conn.Open();
            comm.CommandText = "insert into about.about_artist (about_id,about_text,about_img) values (" + id + ",'" + abouttext + "','" + aboutimg + "');";
            comm.ExecuteNonQuery();
            conn.Close();


            //if inserting was succesful then show a message dialog.
            MessageBox.Show(aboutname + " added");
        }

        public void deleteLastRow()
        {
            bool succesful = true;
            try
            {

                conn.Open();
                comm.CommandText = "(select max(about_id) from about.about);";
                int id = Convert.ToInt32(comm.ExecuteScalar());
                //MessageBox.Show(id.ToString());
                conn.Close();

                conn.Open();
                // delete last row from about.about
                comm.CommandText = "delete from about.about where about_id= " + id + ";";
                comm.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                // delete last row from about.about_movement
                comm.CommandText = "delete from about.about_artist where about_id= " + id + ";";
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

        public void load()
        {
            conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;User Id=dbhelper; Password=123456;");
            conn.Open();
            comm = new NpgsqlCommand();
            comm.Connection = conn;
            conn.Close();
            updateTable();
        }

        public void updateTable()
        {
            conn.Open();
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from about.about where about_who='i';";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.dgvabout.DataSource = dt;
            }
            conn.Close();

            conn.Open();
            comm.CommandText = "select * from about.about_artist";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.dgvaboutartist.DataSource = dt;
            }
            conn.Close();


        }

        private void aboutnamebox_TextChanged(object sender, EventArgs e)
        {
            aboutname = aboutnamebox.Text;
        }
        private void abouttextbox_TextChanged_1(object sender, EventArgs e)
        {
            abouttext = abouttextbox.Text;
        }

        private void abouturlbox_TextChanged(object sender, EventArgs e)
        {
            aboutimg = abouturlbox.Text;
        }



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

        private void add_Click(object sender, EventArgs e)
        {
            //inserting.
            formater(ref aboutname);
            formater(ref abouttext);
            addRowToTable();
            updateTable();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            //deleting
            deleteLastRow();
            updateTable();
        }

       
    }
}
