using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace dbhelper
{
    public partial class AddArtTotally : Form, Iconnection
    {
        //fields
        NpgsqlConnection conn;
        NpgsqlCommand comm;
        NpgsqlDataReader dr;
        string artname;
        string artistID;
        string movementID;
        string materialID;
        string abouttext;
        string aboutimg;
        string year;
        string catagoryname;
        char catagory;

        public AddArtTotally(char catagory, string catagoryname)
        {
            InitializeComponent();
            load();
            updateTable();
            this.catagoryname = catagoryname;
            this.catagory = catagory;
        }

        //form controll actions.
        private void txbname_TextChanged(object sender, EventArgs e)
        {
            artname = txbname.Text;
        }

        private void txbyear_TextChanged(object sender, EventArgs e)
        {
            year = txbyear.Text;
        }

        private void txbartistId_TextChanged(object sender, EventArgs e)
        {
            artistID = txbartistId.Text;
        }

        private void txbmovementId_TextChanged(object sender, EventArgs e)
        {
            movementID = txbmovementId.Text;
        }

        private void txbmaterialId_TextChanged(object sender, EventArgs e)
        {
            materialID = txbmaterialId.Text;
        }

        private void rtba_TextChanged(object sender, EventArgs e)
        {
            abouttext = rtba.Text;
        }

        private void rtburl_TextChanged(object sender, EventArgs e)
        {
            aboutimg = rtburl.Text;
        }

        private void add_Click(object sender, EventArgs e)
        {
            addRowToTable();
            updateTable();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            deleteLastRow();
            updateTable();
        }



        //interface
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
                //obtaining lastly added input id from about.about
                comm.CommandText = "(select max(about_id) from about.about);";
                int aboutid = Convert.ToInt32(comm.ExecuteScalar());

                //obtaining lastly added input id from arts.art
                comm.CommandText = "(select max(art_id) from arts.art);";
                int artid = Convert.ToInt32(comm.ExecuteScalar());

                //delete lastly added row from about.about and about.about_art
                comm.CommandText = "delete from about.about where about.about.about_id="+aboutid+";";
                comm.ExecuteNonQuery();

                //delete lastly added row from arts.art and arts.art_$catagory
                comm.CommandText = "delete from arts.art where arts.art_id=" + artid + ";";
                comm.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                succesful = !succesful;
                MessageBox.Show(e.Message.ToString());
            }
            MessageBox.Show((succesful) ? "deletion succesfull" : "unsuccesfull");
        }

        public void updateTable()
        {
            conn.Open();
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from arts.art;";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.dgvart.DataSource = dt;
            }
            conn.Close();

            conn.Open();

            comm.CommandText = "select * from artists.artists;";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.dgvartist.DataSource = dt;
            }
            conn.Close();
            conn.Open();


            comm.CommandText = "select * from movements.movement";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.dgvmovement.DataSource = dt;
            }
            conn.Close();
            conn.Open();


            //about tablosundaki david silinecek about art tablosu cascade değil !!!
            comm.CommandText = "select * from  material.material";
            dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                this.dgvmaterial.DataSource = dt;
            }
            conn.Close();
        }

        public void addRowToTable()
        {
            bool succesful = true;
            try
            {
                conn.Open();
                // insert into about.about
                comm.CommandText = "insert into about.about (about_name,about_who) values ('" + artname + "','a');";
                comm.ExecuteNonQuery();

                //obtaining lastly added input id from about.about
                comm.CommandText = "(select max(about_id) from about.about);";
                int aboutid = Convert.ToInt32(comm.ExecuteScalar());

                //insert into about.about_art
                comm.CommandText = "insert into about.about_art (about_id,about_text,about_img) values (" + aboutid + ",'" + abouttext + "','" + aboutimg + "');";
                comm.ExecuteNonQuery();

                // insert into arts.art with catagory
                comm.CommandText = "insert into arts.art (art_name,art_type) values ('" + artname + "'," + catagory + ");";
                comm.ExecuteNonQuery();


                //obtaining lastly added input id from arts.art
                comm.CommandText = "(select max(art_id) from arts.art);";
                int artid = Convert.ToInt32(comm.ExecuteScalar());

                //insert into related catagory art table.
                comm.CommandText = "insert into arts." + catagoryname + " (art_id,art_artist_id,art_material_id,art_movement_id,art_about_id,art_date) values (" + artid + "," + artistID + "," + materialID + "," + movementID + "," + aboutid + "," + year + ");";
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
