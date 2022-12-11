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
    public partial class AddArtist : Form, Iconnection
    {
        string artistName;
        string movementId;
        string aboutId;
        string countryId;
        string CityId;
        NpgsqlConnection conn;
        NpgsqlCommand comm;
        NpgsqlDataReader dr;
        public AddArtist()
        {
            InitializeComponent();
            load();
        }




        //Interface
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
            throw new NotImplementedException();
        }



        public void addRowToTable()
        {
            throw new NotImplementedException();
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
                this.dgv_about.DataSource = dt;
            }
            conn.Close();

            conn.Open();
            comm.CommandText = "select * from adresses.countries";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.dgv_country.DataSource = dt;
            }
            conn.Close();

            conn.Open();
            comm.CommandText = "select * from adresses.cities";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.dgv_city.DataSource = dt;
            }
            conn.Close();

            conn.Open();
            comm.CommandText = "select * from movements.movement";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.dgv_movement.DataSource = dt;
            }
            conn.Close();

            conn.Open();
            comm.CommandText = "select * from artists.artists";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.dgv_artist.DataSource = dt;
            }
            conn.Close();
        }

        //buttons
        private void Add_Click(object sender, EventArgs e)
        {

        }

        private void Delete_Click(object sender, EventArgs e)
        {

        }

        //Input textfields
        private void tb_artist_name_TextChanged(object sender, EventArgs e)
        {
            artistName = tb_artist_name.Text;
        }

        private void tb_movement_id_TextChanged(object sender, EventArgs e)
        {
            movementId = tb_movement_id.Text;
        }

        private void tb_about_id_TextChanged(object sender, EventArgs e)
        {
            aboutId = tb_about_id.Text;
        }

        private void tb_country_id_TextChanged(object sender, EventArgs e)
        {
            countryId = tb_country_id.Text;
        }

        private void tb_city_id_TextChanged(object sender, EventArgs e)
        {
            CityId = tb_city_id.Text;
        }


    }
}
