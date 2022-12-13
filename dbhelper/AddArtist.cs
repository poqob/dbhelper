using System;
using System.Data;
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
        string cityId;

        string abouttext;
        string abouturl;
        NpgsqlConnection conn;
        NpgsqlCommand comm;
        NpgsqlDataReader dr;
        public AddArtist()
        {
            InitializeComponent();
            load();
        }

        //Interface methods

        //psql connection 
        public void load()
        {
            conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;User Id=dbhelper; Password=123456;");
            conn.Open();
            comm = new NpgsqlCommand();
            comm.Connection = conn;
            conn.Close();
            updateTable();
        }

        //insert  relevant data to related tables.
        public void addRowToTable()
        {
            bool succesful = true;
            try
            {
                //obtaining country id
                conn.Open();
                comm.CommandText = "(select country_id from adresses.cities where city_id=" + cityId + ");";
                countryId = comm.ExecuteScalar().ToString();
                conn.Close();

                // insert into about.about
                conn.Open();
                comm.CommandText = "insert into about.about (about_name,about_who) values ('" + artistName + "','i');";
                comm.ExecuteNonQuery();
                conn.Close();

                //obttaining about id
                conn.Open();
                comm.CommandText = "(select max(about_id) from about.about);";
                aboutId = comm.ExecuteScalar().ToString();
                conn.Close();

                //insert into about_artist
                conn.Open();
                comm.CommandText = "insert into about.about_artist (about_id,about_text,about_img) values (" + aboutId + ",'" + abouttext + "','" + abouturl + "');";
                comm.ExecuteNonQuery();
                conn.Close();

                //obtaining country id
                conn.Open();
                comm.CommandText = "(select country_id from adresses.cities where city_id=" + cityId + ");";
                countryId = comm.ExecuteScalar().ToString();
                conn.Close();

                // insert into artists.artists
                conn.Open();
                comm.CommandText = "insert into artists.artists (artist_name,artist_movement_id,artist_about_id,artist_country_id,artist_city_id) values ('" + artistName + "','" + movementId + "','" + aboutId + "','" + countryId + "','" + cityId + "');";
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

        //delete related rows from related tables.
        public void deleteLastRow()
        {
            bool succesful = true;
            try
            {
                conn.Open();
                comm.CommandText = "delete from artists.artists where artist_id=(select max(artist_id) from artists.artists); delete from about.about where about_id=(select max(about_id) from about.about);";
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

        //update tables
        public void updateTable()
        {
            conn.Open();
            comm.CommandText = "select city_id,city from adresses.cities";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.dgv_city.DataSource = dt;
            }
            conn.Close();

            conn.Open();
            comm.CommandText = "select movement_id,movement_name from movements.movement";
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
            //TODO:formater will be added.
            addRowToTable();
            updateTable();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            deleteLastRow();
            updateTable();
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

        private void tb_city_id_TextChanged(object sender, EventArgs e)
        {
            cityId = tb_city_id.Text;
        }

        private void abouturlbox_TextChanged(object sender, EventArgs e)
        {
            abouturl = abouturlbox.Text;
        }

        private void abouttextbox_TextChanged(object sender, EventArgs e)
        {
            abouttext = abouttextbox.Text;
        }
    }
}
