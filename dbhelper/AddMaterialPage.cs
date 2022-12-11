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
    public partial class AddMaterialPage :Form,Iconnection
    {
        string material;
        NpgsqlConnection conn;
        NpgsqlCommand comm;
        NpgsqlDataReader dr;

        public AddMaterialPage()
        {
            InitializeComponent();
            load();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            material =richTextBox1.Text;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            addRowToTable();
            updateTable();
        }

        private void deleteLastAdded(object sender, EventArgs e)
        {
            deleteLastRow();
            updateTable();
        }

        //Iconnection
        public void load()
        {
            conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;User Id=dbhelper; Password=123456;");
            conn.Open();
            comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from material.material";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.dataGridView1.DataSource = dt;
            }
            conn.Close();
        }



        //Iconnection
        public void deleteLastRow()
        {
            conn.Open();
            // delete last row from material.material
            comm.CommandText = "delete from material.material where material_id= (select max(material_id) from material.material);";
            comm.ExecuteNonQuery();
            conn.Close();

            //if inserting was succesful then show a message dialog.
            MessageBox.Show("deleted");
        }

        //Iconnection
        public void updateTable()
        {
            conn.Open();
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from material.material";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.dataGridView1.DataSource = dt;
            }
            conn.Close();
        }
        //Iconnection
        public void addRowToTable()
        {
            conn.Open();
            // insert into material.material
            comm.CommandText = "insert into material.material (material_name) values ('" + material + "');";
            string command = "insert into material.material (material_name) values '" + material + "';";
            comm.ExecuteNonQuery();

            conn.Close();
            //if inserting was succesful then show a message dialog.
            MessageBox.Show(material + " added");
        }
    }
}
