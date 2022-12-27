using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace dbhelper
{
    public partial class UserPanel : Form
    {
        NpgsqlConnection conn;
        NpgsqlCommand comm;
        NpgsqlDataReader dr;
        String _username;
        String _password;
        String _userID;
        public UserPanel(String _username,String _password)
        {
            InitializeComponent();
            conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;User Id=dbhelper; Password=123456;");
            conn.Open();
            comm = new NpgsqlCommand();
            comm.Connection = conn;
            conn.Close();

            this._username = _username;
            this._password = _password;
            userID();
        }
        private void userID()
        {

            conn.Open();
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select user_id from users.users where user_name='"+_username+"' and user_password='"+_password+"';";
            dr = comm.ExecuteReader();
            while (dr.Read())
            {
                _userID = dr[0].ToString();
            }
            conn.Close();
        }

        private void changePassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new ChangeUsernameOrPasswordTemplateForm("C Password",_userID,'p');
            form.Show();
            if (form.IsDisposed) this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new ChangeUsernameOrPasswordTemplateForm("C Username",_userID,'u');
            form.Show();
            if (form.IsDisposed) this.Show();
        }

        private void deleteMySelf_Click(object sender, EventArgs e)
        {
            conn.Open();
            comm.CommandType = CommandType.Text;
            comm.CommandText = "delete from users.users where user_id= "+_userID+";";
            dr = comm.ExecuteReader();
            conn.Close();
            MessageBox.Show("deletion succesfull");
            this.Dispose();

        }

        private void post_Click(object sender, EventArgs e)
        {

        }
    }
}
