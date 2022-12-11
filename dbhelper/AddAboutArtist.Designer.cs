
namespace dbhelper
{
    partial class AddAboutArtist
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
            this.abouttextbox = new System.Windows.Forms.RichTextBox();
            this.abouturlbox = new System.Windows.Forms.RichTextBox();
            this.aboutnamebox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvaboutartist = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.delete = new System.Windows.Forms.Button();
            this.dgvabout = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvaboutartist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvabout)).BeginInit();
            this.SuspendLayout();
            // 
            // abouttextbox
            // 
            this.abouttextbox.Location = new System.Drawing.Point(12, 171);
            this.abouttextbox.Name = "abouttextbox";
            this.abouttextbox.Size = new System.Drawing.Size(388, 80);
            this.abouttextbox.TabIndex = 30;
            this.abouttextbox.Text = "";
            this.abouttextbox.TextChanged += new System.EventHandler(this.abouttextbox_TextChanged_1);
            // 
            // abouturlbox
            // 
            this.abouturlbox.Location = new System.Drawing.Point(12, 97);
            this.abouturlbox.Name = "abouturlbox";
            this.abouturlbox.Size = new System.Drawing.Size(388, 51);
            this.abouturlbox.TabIndex = 29;
            this.abouturlbox.Text = "";
            this.abouturlbox.TextChanged += new System.EventHandler(this.abouturlbox_TextChanged);
            // 
            // aboutnamebox
            // 
            this.aboutnamebox.Location = new System.Drawing.Point(12, 31);
            this.aboutnamebox.Name = "aboutnamebox";
            this.aboutnamebox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedHorizontal;
            this.aboutnamebox.Size = new System.Drawing.Size(388, 42);
            this.aboutnamebox.TabIndex = 28;
            this.aboutnamebox.Text = "";
            this.aboutnamebox.TextChanged += new System.EventHandler(this.aboutnamebox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 17);
            this.label5.TabIndex = 25;
            this.label5.Text = "image url";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 582);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "about artist";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "about";
            // 
            // dgvaboutartist
            // 
            this.dgvaboutartist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvaboutartist.Location = new System.Drawing.Point(12, 602);
            this.dgvaboutartist.Name = "dgvaboutartist";
            this.dgvaboutartist.RowHeadersWidth = 51;
            this.dgvaboutartist.RowTemplate.Height = 24;
            this.dgvaboutartist.Size = new System.Drawing.Size(388, 173);
            this.dgvaboutartist.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "artist name";
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.Bisque;
            this.delete.Location = new System.Drawing.Point(205, 257);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(195, 99);
            this.delete.TabIndex = 20;
            this.delete.Text = "delete lastly added";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // dgvabout
            // 
            this.dgvabout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvabout.Location = new System.Drawing.Point(12, 380);
            this.dgvabout.Name = "dgvabout";
            this.dgvabout.RowHeadersWidth = 51;
            this.dgvabout.RowTemplate.Height = 24;
            this.dgvabout.Size = new System.Drawing.Size(388, 186);
            this.dgvabout.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "about artist text";
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.Color.Bisque;
            this.add.Location = new System.Drawing.Point(12, 257);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(187, 99);
            this.add.TabIndex = 17;
            this.add.Text = "Add Artist !!";
            this.add.UseVisualStyleBackColor = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // AddAboutArtist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(420, 788);
            this.Controls.Add(this.abouttextbox);
            this.Controls.Add(this.abouturlbox);
            this.Controls.Add(this.aboutnamebox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvaboutartist);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.dgvabout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.add);
            this.Name = "AddAboutArtist";
            this.Text = "AddAboutArtist";
            ((System.ComponentModel.ISupportInitialize)(this.dgvaboutartist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvabout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox abouttextbox;
        private System.Windows.Forms.RichTextBox abouturlbox;
        private System.Windows.Forms.RichTextBox aboutnamebox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvaboutartist;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.DataGridView dgvabout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button add;
    }
}