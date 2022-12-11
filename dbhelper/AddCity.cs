using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
namespace dbhelper
{
    public partial class AddCity : Form,Iconnection
    {
        string city;
        string countryId;
        NpgsqlConnection conn;
        NpgsqlCommand comm;
        NpgsqlDataReader dr;

        public AddCity()
        {
            InitializeComponent();
            load();
            updateTable();
        }

        //form actions
        private void tbcity_TextChanged(object sender, EventArgs e)
        {
            city = tbcity.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            countryId = textBox1.Text;
        }

        private void add_Click(object sender, EventArgs e)
        {
            //add row to db
            formater(ref city);
            addRowToTable();
            updateTable();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //delete last row
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
                comm.CommandText = "(select max(city_id) from adresses.cities);";
                int id = Convert.ToInt32(comm.ExecuteScalar());
                //MessageBox.Show(id.ToString());
                conn.Close();

                conn.Open();
                // delete last row from about.about
                comm.CommandText = "delete from adresses.cities where city_id= " + id + ";";
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
            comm.CommandText = "select * from adresses.cities;";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.dgvcity.DataSource = dt;
            }
            comm.CommandText = "select * from adresses.countries; ";
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
                // insert into adresses.cities
                conn.Open();
                comm.CommandText = "insert into adresses.cities (city,country_id) values ('" + city + "','"+countryId+"');";
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
