using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace dbhelper
{
    public partial class SignIn : Form
    {
        NpgsqlConnection conn;
        NpgsqlCommand comm;
        NpgsqlDataReader dr;
        String _username;
        String _password;
        String _countryID;
        String _cityID;
        public SignIn()
        {
            InitializeComponent();
            conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;User Id=dbhelper; Password=123456;");
            conn.Open();
            comm = new NpgsqlCommand();
            comm.Connection = conn;
            conn.Close();
            update();
        }

        private void update()
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

            comm.CommandText = "select city from adresses.cities;";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.dgvcity.DataSource = dt;
            }
            conn.Close();
        }

        private void user_TextChanged(object sender, EventArgs e)
        {
            _username = user.Text;
        }

        private void pass_TextChanged(object sender, EventArgs e)
        {
            _password = pass.Text;
        }

        private void sign_Click(object sender, EventArgs e)
        {
            conn.Open();
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select users.signUpFromForm('"+_username+"','"+_password+"',"+_countryID+","+_cityID+");";
            dr = comm.ExecuteReader();
            if (dr.HasRows) { MessageBox.Show("sign up succesfull");Form form = new LogIn(_username,_password); this.Hide();  }
            conn.Close();
        }

        private void countrybox_TextChanged(object sender, EventArgs e)
        {
            _countryID = countrybox.Text;
        }

        private void citybox_TextChanged(object sender, EventArgs e)
        {
            _cityID = citybox.Text;
        }
    }
}
