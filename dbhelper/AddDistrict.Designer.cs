
namespace dbhelper
{
    partial class AddDistrict
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
            this.dgvcities = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvdistricts = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbdistrict = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdistricts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvcities
            // 
            this.dgvcities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcities.Location = new System.Drawing.Point(19, 454);
            this.dgvcities.Name = "dgvcities";
            this.dgvcities.RowHeadersWidth = 51;
            this.dgvcities.RowTemplate.Height = 24;
            this.dgvcities.Size = new System.Drawing.Size(389, 150);
            this.dgvcities.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(16, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "city id";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 147);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(389, 22);
            this.textBox1.TabIndex = 21;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dgvdistricts
            // 
            this.dgvdistricts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdistricts.Location = new System.Drawing.Point(19, 294);
            this.dgvdistricts.Name = "dgvdistricts";
            this.dgvdistricts.RowHeadersWidth = 51;
            this.dgvdistricts.RowTemplate.Height = 24;
            this.dgvdistricts.Size = new System.Drawing.Size(389, 150);
            this.dgvdistricts.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(243, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 82);
            this.button1.TabIndex = 19;
            this.button1.Text = "Delete Lastly Added";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(30, 194);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(207, 82);
            this.add.TabIndex = 18;
            this.add.Text = "Add !";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(16, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "district name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 36);
            this.label1.TabIndex = 16;
            this.label1.Text = "Add New District";
            // 
            // tbdistrict
            // 
            this.tbdistrict.Location = new System.Drawing.Point(19, 86);
            this.tbdistrict.Name = "tbdistrict";
            this.tbdistrict.Size = new System.Drawing.Size(389, 22);
            this.tbdistrict.TabIndex = 15;
            this.tbdistrict.TextChanged += new System.EventHandler(this.tbdistrict_TextChanged);
            // 
            // AddDistrict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(427, 623);
            this.Controls.Add(this.dgvcities);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgvdistricts);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbdistrict);
            this.Name = "AddDistrict";
            this.Text = "AddDistrict";
            ((System.ComponentModel.ISupportInitialize)(this.dgvcities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdistricts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvcities;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgvdistricts;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbdistrict;
    }
}