using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace dbhelper
{
    public partial class LogIn : Form
    {

        NpgsqlConnection conn;
        NpgsqlCommand comm;
        NpgsqlDataReader dr;
        String _username;
        String _password;
        public LogIn()
        {
            InitializeComponent();
            conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;User Id=dbhelper; Password=123456;");
            conn.Open();
            comm = new NpgsqlCommand();
            comm.Connection = conn;
            conn.Close();
        }
        public LogIn(String username,String password)
        {
            InitializeComponent();
            conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;User Id=dbhelper; Password=123456;");
            conn.Open();
            comm = new NpgsqlCommand();
            comm.Connection = conn;
            conn.Close();
            _username = username;
            _password = password;
            login();
        }


        private void username_TextChanged(object sender, EventArgs e)
        {
            _username = username.Text;
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            _password = password.Text;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            login();
        }

        private void login()
        {
            conn.Open();
            comm.CommandType = CommandType.Text;
            comm.CommandText = " SELECT users.auth('" + _username + "','" + _password + "');";
            dr = comm.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0].ToString() == "True")
                {
                    MessageBox.Show("user found, welcome");
                    result.Text = "succesfully logged in";
                    this.Hide();
                    Form form = new UserPanel(_username, _password);
                    form.Show();
                }
                else
                    result.Text = "wrong username or password";
            }
            conn.Close();
        }

    }
}
