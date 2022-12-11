
namespace dbhelper
{
    partial class Form1
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
            this.add_material = new System.Windows.Forms.Button();
            this.add_movement = new System.Windows.Forms.Button();
            this.add_adress = new System.Windows.Forms.Button();
            this.add_art = new System.Windows.Forms.Button();
            this.add_artist = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // add_material
            // 
            this.add_material.AllowDrop = true;
            this.add_material.BackColor = System.Drawing.Color.SpringGreen;
            this.add_material.ForeColor = System.Drawing.Color.Black;
            this.add_material.Location = new System.Drawing.Point(10, 11);
            this.add_material.Name = "add_material";
            this.add_material.Size = new System.Drawing.Size(329, 241);
            this.add_material.TabIndex = 0;
            this.add_material.Text = "add material";
            this.add_material.UseCompatibleTextRendering = true;
            this.add_material.UseVisualStyleBackColor = false;
            this.add_material.Click += new System.EventHandler(this.add_material_Click);
            // 
            // add_movement
            // 
            this.add_movement.AllowDrop = true;
            this.add_movement.BackColor = System.Drawing.Color.SpringGreen;
            this.add_movement.ForeColor = System.Drawing.Color.Black;
            this.add_movement.Location = new System.Drawing.Point(345, 11);
            this.add_movement.Name = "add_movement";
            this.add_movement.Size = new System.Drawing.Size(329, 241);
            this.add_movement.TabIndex = 5;
            this.add_movement.Text = "add movement";
            this.add_movement.UseCompatibleTextRendering = true;
            this.add_movement.UseVisualStyleBackColor = false;
            this.add_movement.Click += new System.EventHandler(this.add_movement_Click);
            // 
            // add_adress
            // 
            this.add_adress.AllowDrop = true;
            this.add_adress.BackColor = System.Drawing.Color.SpringGreen;
            this.add_adress.ForeColor = System.Drawing.Color.Black;
            this.add_adress.Location = new System.Drawing.Point(680, 12);
            this.add_adress.Name = "add_adress";
            this.add_adress.Size = new System.Drawing.Size(329, 241);
            this.add_adress.TabIndex = 6;
            this.add_adress.Text = "add adress";
            this.add_adress.UseCompatibleTextRendering = true;
            this.add_adress.UseVisualStyleBackColor = false;
            this.add_adress.Click += new System.EventHandler(this.add_adress_click);
            // 
            // add_art
            // 
            this.add_art.AllowDrop = true;
            this.add_art.BackColor = System.Drawing.Color.SpringGreen;
            this.add_art.ForeColor = System.Drawing.Color.Black;
            this.add_art.Location = new System.Drawing.Point(345, 268);
            this.add_art.Name = "add_art";
            this.add_art.Size = new System.Drawing.Size(329, 241);
            this.add_art.TabIndex = 7;
            this.add_art.Text = "Add Art";
            this.add_art.UseCompatibleTextRendering = true;
            this.add_art.UseVisualStyleBackColor = false;
            this.add_art.Click += new System.EventHandler(this.add__Click);
            // 
            // add_artist
            // 
            this.add_artist.AllowDrop = true;
            this.add_artist.BackColor = System.Drawing.Color.SpringGreen;
            this.add_artist.ForeColor = System.Drawing.Color.Black;
            this.add_artist.Location = new System.Drawing.Point(10, 268);
            this.add_artist.Name = "add_artist";
            this.add_artist.Size = new System.Drawing.Size(329, 241);
            this.add_artist.TabIndex = 8;
            this.add_artist.Text = "Add artist";
            this.add_artist.UseCompatibleTextRendering = true;
            this.add_artist.UseVisualStyleBackColor = false;
            this.add_artist.Click += new System.EventHandler(this.add_artist_click);
            // 
            // button2
            // 
            this.button2.AllowDrop = true;
            this.button2.BackColor = System.Drawing.Color.SpringGreen;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(680, 268);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(329, 241);
            this.button2.TabIndex = 9;
            this.button2.Text = "add museum";
            this.button2.UseCompatibleTextRendering = true;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(1017, 526);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.add_artist);
            this.Controls.Add(this.add_art);
            this.Controls.Add(this.add_adress);
            this.Controls.Add(this.add_movement);
            this.Controls.Add(this.add_material);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button add_material;
        private System.Windows.Forms.Button add_movement;
        private System.Windows.Forms.Button add_adress;
        private System.Windows.Forms.Button add_art;
        private System.Windows.Forms.Button add_artist;
        private System.Windows.Forms.Button button2;
    }
}

