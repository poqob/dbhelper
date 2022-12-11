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
    public partial class AddMovement : Form, Iconnection
    {
        string aboutname;
        string abouttext;
        string aboutimg;
        NpgsqlConnection conn;
        NpgsqlCommand comm;
        NpgsqlDataReader dr;
        public AddMovement()
        {
            InitializeComponent();
            load();
        }

        //interface
        public void addRowToTable()
        {
            bool succesful = true;
            try
            {
                // insert into about.about
                conn.Open();
                comm.CommandText = "insert into about.about (about_name,about_who) values ('" + aboutname + "','o');";
                comm.ExecuteNonQuery();
                conn.Close();
                // insert into about.about_movement

                conn.Open();
                comm.CommandText = "(select max(about_id) from about.about);";
                int id = Convert.ToInt32(comm.ExecuteScalar());
                //MessageBox.Show(id.ToString());
                conn.Close();

                conn.Open();
                comm.CommandText = "insert into about.about_movement (about_id,about_text,about_img) values (" + id + ",'" + abouttext + "','" + aboutimg + "');";
                comm.ExecuteNonQuery();
                conn.Close();

                // insert into movements.movement
                conn.Open();
                comm.CommandText = "insert into movements.movement (movement_name,movement_about_id) values ('" + aboutname + "'," + id + ");";
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
                comm.CommandText = "delete from about.about_movement where about_id= " + id + ";";
                comm.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                // delete last row from movements.movement 
                comm.CommandText = "delete from movements.movement where movement_about_id= " + id + ";";
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
            comm.CommandText = "select * from about.about where about_who='o';";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.dataGridView1.DataSource = dt;
            }
            conn.Close();

            conn.Open();
            comm.CommandText = "select * from about.about_movement";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.dataGridView2.DataSource = dt;
            }
            conn.Close();

            conn.Open();
            comm.CommandText = "select * from movements.movement";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.dataGridView3.DataSource = dt;
            }
            conn.Close();
        }



        //form
        private void AddMovement_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //insert into movement.movement table the text
            formater(ref aboutname);
            formater(ref abouttext);
            addRowToTable();
            updateTable();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            deleteLastRow();
            updateTable();
        }



        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void aboutnamebox_TextChanged(object sender, EventArgs e)
        {
            aboutname = aboutnamebox.Text;
        }

        private void abouturlbox_TextChanged(object sender, EventArgs e)
        {
            aboutimg = abouturlbox.Text;
        }

        private void abouttextbox_TextChanged(object sender, EventArgs e)
        {
            abouttext = abouttextbox.Text;
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
    }
}
