﻿
namespace dbhelper
{
    partial class UserPanel
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
            this.changePassword = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.deleteMySelf = new System.Windows.Forms.Button();
            this.post = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // changePassword
            // 
            this.changePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.changePassword.Location = new System.Drawing.Point(18, 153);
            this.changePassword.Name = "changePassword";
            this.changePassword.Size = new System.Drawing.Size(416, 134);
            this.changePassword.TabIndex = 0;
            this.changePassword.Text = "change my password";
            this.changePassword.UseVisualStyleBackColor = true;
            this.changePassword.Click += new System.EventHandler(this.changePassword_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(18, 293);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(416, 134);
            this.button2.TabIndex = 1;
            this.button2.Text = "change my username";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // deleteMySelf
            // 
            this.deleteMySelf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.deleteMySelf.Location = new System.Drawing.Point(18, 433);
            this.deleteMySelf.Name = "deleteMySelf";
            this.deleteMySelf.Size = new System.Drawing.Size(416, 134);
            this.deleteMySelf.TabIndex = 2;
            this.deleteMySelf.Text = "delete me";
            this.deleteMySelf.UseVisualStyleBackColor = true;
            this.deleteMySelf.Click += new System.EventHandler(this.deleteMySelf_Click);
            // 
            // post
            // 
            this.post.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.post.Location = new System.Drawing.Point(18, 12);
            this.post.Name = "post";
            this.post.Size = new System.Drawing.Size(416, 134);
            this.post.TabIndex = 3;
            this.post.Text = "post something";
            this.post.UseVisualStyleBackColor = true;
            this.post.Click += new System.EventHandler(this.post_Click);
            // 
            // UserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(446, 688);
            this.Controls.Add(this.post);
            this.Controls.Add(this.deleteMySelf);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.changePassword);
            this.Name = "UserPanel";
            this.Text = "UserPanel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button changePassword;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button deleteMySelf;
        private System.Windows.Forms.Button post;
    }
}