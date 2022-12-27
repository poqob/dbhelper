
namespace dbhelper
{
    partial class SignIn
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
            this.user = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pass = new System.Windows.Forms.RichTextBox();
            this.dgvcountry = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvcity = new System.Windows.Forms.DataGridView();
            this.sign = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.citybox = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.countrybox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcity)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sign Up";
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(20, 104);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(313, 37);
            this.user.TabIndex = 1;
            this.user.Text = "";
            this.user.TextChanged += new System.EventHandler(this.user_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "password";
            // 
            // pass
            // 
            this.pass.Location = new System.Drawing.Point(20, 191);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(313, 37);
            this.pass.TabIndex = 3;
            this.pass.Text = "";
            this.pass.TextChanged += new System.EventHandler(this.pass_TextChanged);
            // 
            // dgvcountry
            // 
            this.dgvcountry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcountry.Location = new System.Drawing.Point(20, 428);
            this.dgvcountry.Name = "dgvcountry";
            this.dgvcountry.RowHeadersWidth = 51;
            this.dgvcountry.RowTemplate.Height = 24;
            this.dgvcountry.Size = new System.Drawing.Size(313, 124);
            this.dgvcountry.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 408);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "country";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 560);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "city";
            // 
            // dgvcity
            // 
            this.dgvcity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcity.Location = new System.Drawing.Point(20, 580);
            this.dgvcity.Name = "dgvcity";
            this.dgvcity.RowHeadersWidth = 51;
            this.dgvcity.RowTemplate.Height = 24;
            this.dgvcity.Size = new System.Drawing.Size(313, 156);
            this.dgvcity.TabIndex = 7;
            // 
            // sign
            // 
            this.sign.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sign.Location = new System.Drawing.Point(47, 751);
            this.sign.Name = "sign";
            this.sign.Size = new System.Drawing.Size(248, 106);
            this.sign.TabIndex = 9;
            this.sign.Text = "Sign Up!!";
            this.sign.UseVisualStyleBackColor = true;
            this.sign.Click += new System.EventHandler(this.sign_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "city id";
            // 
            // citybox
            // 
            this.citybox.Location = new System.Drawing.Point(20, 357);
            this.citybox.Name = "citybox";
            this.citybox.Size = new System.Drawing.Size(313, 37);
            this.citybox.TabIndex = 12;
            this.citybox.Text = "";
            this.citybox.TextChanged += new System.EventHandler(this.citybox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "country id";
            // 
            // countrybox
            // 
            this.countrybox.Location = new System.Drawing.Point(20, 270);
            this.countrybox.Name = "countrybox";
            this.countrybox.Size = new System.Drawing.Size(313, 37);
            this.countrybox.TabIndex = 10;
            this.countrybox.Text = "";
            this.countrybox.TextChanged += new System.EventHandler(this.countrybox_TextChanged);
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(357, 894);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.citybox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.countrybox);
            this.Controls.Add(this.sign);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvcity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvcountry);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.user);
            this.Controls.Add(this.label1);
            this.Name = "SignIn";
            this.Text = "SignIn";
            ((System.ComponentModel.ISupportInitialize)(this.dgvcountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox user;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox pass;
        private System.Windows.Forms.DataGridView dgvcountry;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvcity;
        private System.Windows.Forms.Button sign;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox citybox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox countrybox;
    }
}