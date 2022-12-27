using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace dbhelper
{
    public partial class ChangeUsernameOrPasswordTemplateForm : Form
    {
        String userID;
        string temp0;
        string temp1;
        char who;
        NpgsqlConnection conn;
        NpgsqlCommand comm;
        NpgsqlDataReader dr;
        public ChangeUsernameOrPasswordTemplateForm(String header,String userID,char who)
        {
            InitializeComponent();
            this.userID = userID;
            this.header.Text = header;
            this.who = who;
            conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;User Id=dbhelper; Password=123456;");
            conn.Open();
            comm = new NpgsqlCommand();
            comm.Connection = conn;
            conn.Close();
           

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            temp0 = richTextBox1.Text;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            temp1 = richTextBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string field=
            who == 'u' ? "user_name" : "user_password";
            if (temp0 == temp1)
            {
                string quary1 = "update users.users set "+field+"='" + temp0 + "' where user_id=" + userID + ";";
                conn.Open();
                comm.CommandType = CommandType.Text;
                comm.CommandText = quary1;
                dr = comm.ExecuteReader();
                result.Text = "change succcesful";
                conn.Close();
            }
            else
            {
                result.Text = "please fill areas correctly";
            }
        }
    }
}
