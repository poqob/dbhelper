
namespace dbhelper
{
    partial class AddCity
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
            this.dgvcity = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbcity = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvcountry = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcountry)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvcity
            // 
            this.dgvcity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcity.Location = new System.Drawing.Point(19, 294);
            this.dgvcity.Name = "dgvcity";
            this.dgvcity.RowHeadersWidth = 51;
            this.dgvcity.RowTemplate.Height = 24;
            this.dgvcity.Size = new System.Drawing.Size(298, 150);
            this.dgvcity.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(194, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 82);
            this.button1.TabIndex = 10;
            this.button1.Text = "Delete Lastly Added";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(30, 194);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(158, 82);
            this.add.TabIndex = 9;
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
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "city name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 36);
            this.label1.TabIndex = 7;
            this.label1.Text = "Add New City";
            // 
            // tbcity
            // 
            this.tbcity.Location = new System.Drawing.Point(19, 86);
            this.tbcity.Name = "tbcity";
            this.tbcity.Size = new System.Drawing.Size(298, 22);
            this.tbcity.TabIndex = 6;
            this.tbcity.TextChanged += new System.EventHandler(this.tbcity_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 147);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(298, 22);
            this.textBox1.TabIndex = 12;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(16, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "country id";
            // 
            // dgvcountry
            // 
            this.dgvcountry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcountry.Location = new System.Drawing.Point(19, 454);
            this.dgvcountry.Name = "dgvcountry";
            this.dgvcountry.RowHeadersWidth = 51;
            this.dgvcountry.RowTemplate.Height = 24;
            this.dgvcountry.Size = new System.Drawing.Size(298, 150);
            this.dgvcountry.TabIndex = 14;
            // 
            // AddCity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Firebrick;
            this.ClientSize = new System.Drawing.Size(332, 616);
            this.Controls.Add(this.dgvcountry);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgvcity);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbcity);
            this.Name = "AddCity";
            this.Text = "AddCity";
            ((System.ComponentModel.ISupportInitialize)(this.dgvcity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcountry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvcity;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbcity;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvcountry;
    }
}