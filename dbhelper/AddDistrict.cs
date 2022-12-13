using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace dbhelper
{
    public partial class AddDistrict : Form, Iconnection
    {

        string district;
        string cityId;
        NpgsqlConnection conn;
        NpgsqlCommand comm;
        NpgsqlDataReader dr;

        public AddDistrict()
        {
            InitializeComponent();
            load();
            updateTable();
        }


        private void tbdistrict_TextChanged(object sender, EventArgs e)
        {
            district = tbdistrict.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cityId = textBox1.Text;
        }

        private void add_Click(object sender, EventArgs e)
        {
            TextFormatter.formater(ref district);
            addRowToTable();
            updateTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deleteLastRow();
            updateTable();
        }

        //inteface methods
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
                comm.CommandText = "(select max(district_id) from adresses.districts);";
                int id = Convert.ToInt32(comm.ExecuteScalar());
                //MessageBox.Show(id.ToString());
                conn.Close();

                conn.Open();
                // delete last row from about.about
                comm.CommandText = "delete from adresses.districts where district_id= " + id + ";";
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
            comm.CommandText = "select * from adresses.districts;";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.dgvdistricts.DataSource = dt;
            }
            comm.CommandText = "select * from adresses.cities; ";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.dgvcities.DataSource = dt;
            }
            conn.Close();
        }

        public void addRowToTable()
        {

            bool succesful = true;
            try
            {
                // insert into adresses.districts
                conn.Open();
                comm.CommandText = "insert into adresses.districts (city_id,district) values ('" + cityId + "','" + district + "');";
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

    }
}
