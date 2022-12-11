
namespace dbhelper
{
    partial class AddArtist
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tb_artist_name = new System.Windows.Forms.TextBox();
            this.tb_movement_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_about_id = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_country_id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_city_id = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_artist = new System.Windows.Forms.DataGridView();
            this.dgv_country = new System.Windows.Forms.DataGridView();
            this.dgv_city = new System.Windows.Forms.DataGridView();
            this.dgv_movement = new System.Windows.Forms.DataGridView();
            this.dgv_about = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_artist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_country)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_city)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_movement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_about)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "artist name";
            // 
            // tb_artist_name
            // 
            this.tb_artist_name.Location = new System.Drawing.Point(12, 52);
            this.tb_artist_name.Name = "tb_artist_name";
            this.tb_artist_name.Size = new System.Drawing.Size(252, 22);
            this.tb_artist_name.TabIndex = 1;
            this.tb_artist_name.TextChanged += new System.EventHandler(this.tb_artist_name_TextChanged);
            // 
            // tb_movement_id
            // 
            this.tb_movement_id.Location = new System.Drawing.Point(12, 97);
            this.tb_movement_id.Name = "tb_movement_id";
            this.tb_movement_id.Size = new System.Drawing.Size(252, 22);
            this.tb_movement_id.TabIndex = 3;
            this.tb_movement_id.TextChanged += new System.EventHandler(this.tb_movement_id_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "movement id";
            // 
            // tb_about_id
            // 
            this.tb_about_id.Location = new System.Drawing.Point(12, 142);
            this.tb_about_id.Name = "tb_about_id";
            this.tb_about_id.Size = new System.Drawing.Size(252, 22);
            this.tb_about_id.TabIndex = 5;
            this.tb_about_id.TextChanged += new System.EventHandler(this.tb_about_id_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "about id";
            // 
            // tb_country_id
            // 
            this.tb_country_id.Location = new System.Drawing.Point(12, 187);
            this.tb_country_id.Name = "tb_country_id";
            this.tb_country_id.Size = new System.Drawing.Size(252, 22);
            this.tb_country_id.TabIndex = 7;
            this.tb_country_id.TextChanged += new System.EventHandler(this.tb_country_id_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "country id";
            // 
            // tb_city_id
            // 
            this.tb_city_id.Location = new System.Drawing.Point(12, 232);
            this.tb_city_id.Name = "tb_city_id";
            this.tb_city_id.Size = new System.Drawing.Size(252, 22);
            this.tb_city_id.TabIndex = 9;
            this.tb_city_id.TextChanged += new System.EventHandler(this.tb_city_id_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "city id";
            // 
            // dgv_artist
            // 
            this.dgv_artist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_artist.Location = new System.Drawing.Point(16, 406);
            this.dgv_artist.Name = "dgv_artist";
            this.dgv_artist.RowHeadersWidth = 51;
            this.dgv_artist.RowTemplate.Height = 24;
            this.dgv_artist.Size = new System.Drawing.Size(252, 200);
            this.dgv_artist.TabIndex = 10;
            // 
            // dgv_country
            // 
            this.dgv_country.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_country.Location = new System.Drawing.Point(671, 406);
            this.dgv_country.Name = "dgv_country";
            this.dgv_country.RowHeadersWidth = 51;
            this.dgv_country.RowTemplate.Height = 24;
            this.dgv_country.Size = new System.Drawing.Size(391, 200);
            this.dgv_country.TabIndex = 11;
            // 
            // dgv_city
            // 
            this.dgv_city.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_city.Location = new System.Drawing.Point(274, 406);
            this.dgv_city.Name = "dgv_city";
            this.dgv_city.RowHeadersWidth = 51;
            this.dgv_city.RowTemplate.Height = 24;
            this.dgv_city.Size = new System.Drawing.Size(391, 200);
            this.dgv_city.TabIndex = 12;
            // 
            // dgv_movement
            // 
            this.dgv_movement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_movement.Location = new System.Drawing.Point(671, 32);
            this.dgv_movement.Name = "dgv_movement";
            this.dgv_movement.RowHeadersWidth = 51;
            this.dgv_movement.RowTemplate.Height = 24;
            this.dgv_movement.Size = new System.Drawing.Size(391, 329);
            this.dgv_movement.TabIndex = 13;
            // 
            // dgv_about
            // 
            this.dgv_about.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_about.Location = new System.Drawing.Point(274, 32);
            this.dgv_about.Name = "dgv_about";
            this.dgv_about.RowHeadersWidth = 51;
            this.dgv_about.RowTemplate.Height = 24;
            this.dgv_about.Size = new System.Drawing.Size(391, 329);
            this.dgv_about.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(271, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "about";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(668, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "movement";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(668, 386);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "country";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(271, 386);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "city id";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 386);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "artist id";
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.Moccasin;
            this.Add.Location = new System.Drawing.Point(16, 278);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(146, 83);
            this.Add.TabIndex = 20;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.Moccasin;
            this.Delete.Location = new System.Drawing.Point(168, 278);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(87, 83);
            this.Delete.TabIndex = 21;
            this.Delete.Text = "Delete Last";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // AddArtist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1069, 622);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgv_about);
            this.Controls.Add(this.dgv_movement);
            this.Controls.Add(this.dgv_city);
            this.Controls.Add(this.dgv_country);
            this.Controls.Add(this.dgv_artist);
            this.Controls.Add(this.tb_city_id);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_country_id);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_about_id);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_movement_id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_artist_name);
            this.Controls.Add(this.label1);
            this.Name = "AddArtist";
            this.Text = "AddArtist";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_artist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_country)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_city)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_movement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_about)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_artist_name;
        private System.Windows.Forms.TextBox tb_movement_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_about_id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_country_id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_city_id;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_artist;
        private System.Windows.Forms.DataGridView dgv_country;
        private System.Windows.Forms.DataGridView dgv_city;
        private System.Windows.Forms.DataGridView dgv_movement;
        private System.Windows.Forms.DataGridView dgv_about;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Delete;
    }
}