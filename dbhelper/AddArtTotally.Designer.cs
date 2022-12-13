
namespace dbhelper
{
    partial class AddArtTotally
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
            this.dgvart = new System.Windows.Forms.DataGridView();
            this.txbname = new System.Windows.Forms.TextBox();
            this.rtba = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.add = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbartistId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rtburl = new System.Windows.Forms.RichTextBox();
            this.dgvartist = new System.Windows.Forms.DataGridView();
            this.dgvmovement = new System.Windows.Forms.DataGridView();
            this.delete = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvmaterial = new System.Windows.Forms.DataGridView();
            this.txbmovementId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txbmaterialId = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txbyear = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvartist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmovement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmaterial)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvart
            // 
            this.dgvart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvart.Location = new System.Drawing.Point(269, 34);
            this.dgvart.Name = "dgvart";
            this.dgvart.RowHeadersWidth = 51;
            this.dgvart.RowTemplate.Height = 24;
            this.dgvart.Size = new System.Drawing.Size(444, 205);
            this.dgvart.TabIndex = 0;
            // 
            // txbname
            // 
            this.txbname.Location = new System.Drawing.Point(12, 94);
            this.txbname.Name = "txbname";
            this.txbname.Size = new System.Drawing.Size(228, 22);
            this.txbname.TabIndex = 1;
            this.txbname.TextChanged += new System.EventHandler(this.txbname_TextChanged);
            // 
            // rtba
            // 
            this.rtba.Location = new System.Drawing.Point(12, 394);
            this.rtba.Name = "rtba";
            this.rtba.Size = new System.Drawing.Size(228, 174);
            this.rtba.TabIndex = 2;
            this.rtba.Text = "";
            this.rtba.TextChanged += new System.EventHandler(this.rtba_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 42);
            this.label1.TabIndex = 3;
            this.label1.Text = "Add Art";
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(16, 709);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(110, 89);
            this.add.TabIndex = 4;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Art name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Artist ID";
            // 
            // txbartistId
            // 
            this.txbartistId.Location = new System.Drawing.Point(16, 197);
            this.txbartistId.Name = "txbartistId";
            this.txbartistId.Size = new System.Drawing.Size(228, 22);
            this.txbartistId.TabIndex = 7;
            this.txbartistId.TextChanged += new System.EventHandler(this.txbartistId_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 373);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "About The Art";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 581);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Art Image Url";
            // 
            // rtburl
            // 
            this.rtburl.Location = new System.Drawing.Point(12, 601);
            this.rtburl.Name = "rtburl";
            this.rtburl.Size = new System.Drawing.Size(228, 75);
            this.rtburl.TabIndex = 9;
            this.rtburl.Text = "";
            this.rtburl.TextChanged += new System.EventHandler(this.rtburl_TextChanged);
            // 
            // dgvartist
            // 
            this.dgvartist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvartist.Location = new System.Drawing.Point(269, 272);
            this.dgvartist.Name = "dgvartist";
            this.dgvartist.RowHeadersWidth = 51;
            this.dgvartist.RowTemplate.Height = 24;
            this.dgvartist.Size = new System.Drawing.Size(444, 170);
            this.dgvartist.TabIndex = 11;
            // 
            // dgvmovement
            // 
            this.dgvmovement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvmovement.Location = new System.Drawing.Point(269, 473);
            this.dgvmovement.Name = "dgvmovement";
            this.dgvmovement.RowHeadersWidth = 51;
            this.dgvmovement.RowTemplate.Height = 24;
            this.dgvmovement.Size = new System.Drawing.Size(444, 150);
            this.dgvmovement.TabIndex = 12;
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(132, 709);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(108, 89);
            this.delete.TabIndex = 13;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(266, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Arts";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(266, 252);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Artists";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(266, 453);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "movements";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(266, 635);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "materials";
            // 
            // dgvmaterial
            // 
            this.dgvmaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvmaterial.Location = new System.Drawing.Point(269, 655);
            this.dgvmaterial.Name = "dgvmaterial";
            this.dgvmaterial.RowHeadersWidth = 51;
            this.dgvmaterial.RowTemplate.Height = 24;
            this.dgvmaterial.Size = new System.Drawing.Size(444, 150);
            this.dgvmaterial.TabIndex = 17;
            // 
            // txbmovementId
            // 
            this.txbmovementId.Location = new System.Drawing.Point(16, 254);
            this.txbmovementId.Name = "txbmovementId";
            this.txbmovementId.Size = new System.Drawing.Size(228, 22);
            this.txbmovementId.TabIndex = 20;
            this.txbmovementId.TextChanged += new System.EventHandler(this.txbmovementId_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 234);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "Movement ID";
            // 
            // txbmaterialId
            // 
            this.txbmaterialId.Location = new System.Drawing.Point(16, 309);
            this.txbmaterialId.Name = "txbmaterialId";
            this.txbmaterialId.Size = new System.Drawing.Size(228, 22);
            this.txbmaterialId.TabIndex = 22;
            this.txbmaterialId.TextChanged += new System.EventHandler(this.txbmaterialId_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 289);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 17);
            this.label11.TabIndex = 21;
            this.label11.Text = "Material ID";
            // 
            // txbyear
            // 
            this.txbyear.Location = new System.Drawing.Point(12, 142);
            this.txbyear.Name = "txbyear";
            this.txbyear.Size = new System.Drawing.Size(228, 22);
            this.txbyear.TabIndex = 24;
            this.txbyear.TextChanged += new System.EventHandler(this.txbyear_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 122);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 17);
            this.label12.TabIndex = 23;
            this.label12.Text = "Year";
            // 
            // AddArtTotally
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(744, 834);
            this.Controls.Add(this.txbyear);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txbmaterialId);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txbmovementId);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgvmaterial);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.dgvmovement);
            this.Controls.Add(this.dgvartist);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rtburl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbartistId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtba);
            this.Controls.Add(this.txbname);
            this.Controls.Add(this.dgvart);
            this.Name = "AddArtTotally";
            this.Text = "AddArtTotally";
            ((System.ComponentModel.ISupportInitialize)(this.dgvart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvartist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmovement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmaterial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvart;
        private System.Windows.Forms.TextBox txbname;
        private System.Windows.Forms.RichTextBox rtba;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbartistId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtburl;
        private System.Windows.Forms.DataGridView dgvartist;
        private System.Windows.Forms.DataGridView dgvmovement;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvmaterial;
        private System.Windows.Forms.TextBox txbmovementId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbmaterialId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txbyear;
        private System.Windows.Forms.Label label12;
    }
}