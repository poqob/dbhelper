
namespace dbhelper
{
    partial class AddAdress
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
            this.addNewCountry = new System.Windows.Forms.Button();
            this.addNewCity = new System.Windows.Forms.Button();
            this.addNewDistrict = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addNewCountry
            // 
            this.addNewCountry.BackColor = System.Drawing.Color.Crimson;
            this.addNewCountry.Location = new System.Drawing.Point(12, 12);
            this.addNewCountry.Name = "addNewCountry";
            this.addNewCountry.Size = new System.Drawing.Size(105, 209);
            this.addNewCountry.TabIndex = 0;
            this.addNewCountry.Text = "Add new country";
            this.addNewCountry.UseVisualStyleBackColor = false;
            this.addNewCountry.Click += new System.EventHandler(this.addNewCountry_Click);
            // 
            // addNewCity
            // 
            this.addNewCity.BackColor = System.Drawing.Color.Crimson;
            this.addNewCity.Location = new System.Drawing.Point(132, 12);
            this.addNewCity.Name = "addNewCity";
            this.addNewCity.Size = new System.Drawing.Size(105, 209);
            this.addNewCity.TabIndex = 1;
            this.addNewCity.Text = "Add new city";
            this.addNewCity.UseVisualStyleBackColor = false;
            this.addNewCity.Click += new System.EventHandler(this.addNewCity_Click);
            // 
            // addNewDistrict
            // 
            this.addNewDistrict.BackColor = System.Drawing.Color.Crimson;
            this.addNewDistrict.Location = new System.Drawing.Point(252, 12);
            this.addNewDistrict.Name = "addNewDistrict";
            this.addNewDistrict.Size = new System.Drawing.Size(105, 209);
            this.addNewDistrict.TabIndex = 2;
            this.addNewDistrict.Text = "Add new district";
            this.addNewDistrict.UseVisualStyleBackColor = false;
            this.addNewDistrict.Click += new System.EventHandler(this.addNewDistrict_Click);
            // 
            // AddAdress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Firebrick;
            this.ClientSize = new System.Drawing.Size(377, 237);
            this.Controls.Add(this.addNewDistrict);
            this.Controls.Add(this.addNewCity);
            this.Controls.Add(this.addNewCountry);
            this.Name = "AddAdress";
            this.Text = "AddAdress";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addNewCountry;
        private System.Windows.Forms.Button addNewCity;
        private System.Windows.Forms.Button addNewDistrict;
    }
}