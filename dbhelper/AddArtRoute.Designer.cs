
namespace dbhelper
{
    partial class AddArtRoute
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
            this.AddPaint = new System.Windows.Forms.Button();
            this.AddStatues = new System.Windows.Forms.Button();
            this.AddDecorativeArt = new System.Windows.Forms.Button();
            this.AddArchitecture = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddPaint
            // 
            this.AddPaint.BackColor = System.Drawing.Color.LimeGreen;
            this.AddPaint.Location = new System.Drawing.Point(12, 12);
            this.AddPaint.Name = "AddPaint";
            this.AddPaint.Size = new System.Drawing.Size(117, 250);
            this.AddPaint.TabIndex = 0;
            this.AddPaint.Text = "Add Paint";
            this.AddPaint.UseVisualStyleBackColor = false;
            this.AddPaint.Click += new System.EventHandler(this.AddPaint_Click);
            // 
            // AddStatues
            // 
            this.AddStatues.BackColor = System.Drawing.Color.Lime;
            this.AddStatues.Location = new System.Drawing.Point(135, 12);
            this.AddStatues.Name = "AddStatues";
            this.AddStatues.Size = new System.Drawing.Size(117, 250);
            this.AddStatues.TabIndex = 1;
            this.AddStatues.Text = "Add  Statues";
            this.AddStatues.UseVisualStyleBackColor = false;
            this.AddStatues.Click += new System.EventHandler(this.AddStatues_Click);
            // 
            // AddDecorativeArt
            // 
            this.AddDecorativeArt.BackColor = System.Drawing.Color.LawnGreen;
            this.AddDecorativeArt.Location = new System.Drawing.Point(258, 11);
            this.AddDecorativeArt.Name = "AddDecorativeArt";
            this.AddDecorativeArt.Size = new System.Drawing.Size(117, 250);
            this.AddDecorativeArt.TabIndex = 2;
            this.AddDecorativeArt.Text = "Add DecorativeArt";
            this.AddDecorativeArt.UseVisualStyleBackColor = false;
            this.AddDecorativeArt.Click += new System.EventHandler(this.AddDecorativeArt_Click);
            // 
            // AddArchitecture
            // 
            this.AddArchitecture.BackColor = System.Drawing.Color.YellowGreen;
            this.AddArchitecture.Location = new System.Drawing.Point(381, 11);
            this.AddArchitecture.Name = "AddArchitecture";
            this.AddArchitecture.Size = new System.Drawing.Size(117, 250);
            this.AddArchitecture.TabIndex = 3;
            this.AddArchitecture.Text = "Add Arthitecture";
            this.AddArchitecture.UseVisualStyleBackColor = false;
            this.AddArchitecture.Click += new System.EventHandler(this.AddArchitecture_Click);
            // 
            // AddArtRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(511, 273);
            this.Controls.Add(this.AddArchitecture);
            this.Controls.Add(this.AddDecorativeArt);
            this.Controls.Add(this.AddStatues);
            this.Controls.Add(this.AddPaint);
            this.Name = "AddArtRoute";
            this.Text = "AddArtTotally";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddPaint;
        private System.Windows.Forms.Button AddStatues;
        private System.Windows.Forms.Button AddDecorativeArt;
        private System.Windows.Forms.Button AddArchitecture;
    }
}