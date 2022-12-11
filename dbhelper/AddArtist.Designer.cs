
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
            this.tb_city_id = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_artist = new System.Windows.Forms.DataGridView();
            this.dgv_city = new System.Windows.Forms.DataGridView();
            this.dgv_movement = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.abouttextbox = new System.Windows.Forms.RichTextBox();
            this.abouturlbox = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_artist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_city)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_movement)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "artist name";
            // 
            // tb_artist_name
            // 
            this.tb_artist_name.Location = new System.Drawing.Point(16, 69);
            this.tb_artist_name.Name = "tb_artist_name";
            this.tb_artist_name.Size = new System.Drawing.Size(252, 22);
            this.tb_artist_name.TabIndex = 1;
            this.tb_artist_name.TextChanged += new System.EventHandler(this.tb_artist_name_TextChanged);
            // 
            // tb_movement_id
            // 
            this.tb_movement_id.Location = new System.Drawing.Point(16, 114);
            this.tb_movement_id.Name = "tb_movement_id";
            this.tb_movement_id.Size = new System.Drawing.Size(252, 22);
            this.tb_movement_id.TabIndex = 3;
            this.tb_movement_id.TextChanged += new System.EventHandler(this.tb_movement_id_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "movement id";
            // 
            // tb_city_id
            // 
            this.tb_city_id.Location = new System.Drawing.Point(16, 160);
            this.tb_city_id.Name = "tb_city_id";
            this.tb_city_id.Size = new System.Drawing.Size(252, 22);
            this.tb_city_id.TabIndex = 9;
            this.tb_city_id.TextChanged += new System.EventHandler(this.tb_city_id_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "city id";
            // 
            // dgv_artist
            // 
            this.dgv_artist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_artist.Location = new System.Drawing.Point(274, 384);
            this.dgv_artist.Name = "dgv_artist";
            this.dgv_artist.RowHeadersWidth = 51;
            this.dgv_artist.RowTemplate.Height = 24;
            this.dgv_artist.Size = new System.Drawing.Size(788, 222);
            this.dgv_artist.TabIndex = 10;
            // 
            // dgv_city
            // 
            this.dgv_city.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_city.Location = new System.Drawing.Point(274, 32);
            this.dgv_city.Name = "dgv_city";
            this.dgv_city.RowHeadersWidth = 51;
            this.dgv_city.RowTemplate.Height = 24;
            this.dgv_city.Size = new System.Drawing.Size(391, 329);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(668, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "movement";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(271, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "city id";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(274, 364);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "artist id";
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.Moccasin;
            this.Add.Location = new System.Drawing.Point(18, 491);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(146, 115);
            this.Add.TabIndex = 20;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.Moccasin;
            this.Delete.Location = new System.Drawing.Point(170, 491);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(87, 115);
            this.Delete.TabIndex = 21;
            this.Delete.Text = "Delete Last";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(15, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 39);
            this.label4.TabIndex = 22;
            this.label4.Text = "Add Artist";
            // 
            // abouttextbox
            // 
            this.abouttextbox.Location = new System.Drawing.Point(16, 304);
            this.abouttextbox.Name = "abouttextbox";
            this.abouttextbox.Size = new System.Drawing.Size(252, 181);
            this.abouttextbox.TabIndex = 34;
            this.abouttextbox.Text = "";
            this.abouttextbox.TextChanged += new System.EventHandler(this.abouttextbox_TextChanged);
            // 
            // abouturlbox
            // 
            this.abouturlbox.Location = new System.Drawing.Point(16, 208);
            this.abouturlbox.Name = "abouturlbox";
            this.abouturlbox.Size = new System.Drawing.Size(252, 73);
            this.abouturlbox.TabIndex = 33;
            this.abouturlbox.Text = "";
            this.abouturlbox.TextChanged += new System.EventHandler(this.abouturlbox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 32;
            this.label6.Text = "image url";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 284);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 17);
            this.label8.TabIndex = 31;
            this.label8.Text = "about artist text";
            // 
            // AddArtist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1069, 622);
            this.Controls.Add(this.abouttextbox);
            this.Controls.Add(this.abouturlbox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgv_movement);
            this.Controls.Add(this.dgv_city);
            this.Controls.Add(this.dgv_artist);
            this.Controls.Add(this.tb_city_id);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_movement_id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_artist_name);
            this.Controls.Add(this.label1);
            this.Name = "AddArtist";
            this.Text = "AddArtist";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_artist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_city)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_movement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_artist_name;
        private System.Windows.Forms.TextBox tb_movement_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_city_id;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_artist;
        private System.Windows.Forms.DataGridView dgv_city;
        private System.Windows.Forms.DataGridView dgv_movement;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox abouttextbox;
        private System.Windows.Forms.RichTextBox abouturlbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
    }
}