namespace ACRACS___Manage
{
    partial class form_securityAccess
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
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_message = new System.Windows.Forms.TextBox();
            this.txt_instrPassword = new System.Windows.Forms.TextBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_password
            // 
            this.txt_password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_password.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.Location = new System.Drawing.Point(0, 0);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(388, 29);
            this.txt_password.TabIndex = 1;
            this.txt_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // txt_message
            // 
            this.txt_message.BackColor = System.Drawing.SystemColors.Control;
            this.txt_message.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_message.Location = new System.Drawing.Point(-7, 44);
            this.txt_message.Name = "txt_message";
            this.txt_message.ReadOnly = true;
            this.txt_message.Size = new System.Drawing.Size(395, 13);
            this.txt_message.TabIndex = 2;
            this.txt_message.Text = "Jerome Pueblo\'s password is:";
            this.txt_message.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_instrPassword
            // 
            this.txt_instrPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txt_instrPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_instrPassword.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.txt_instrPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_instrPassword.Location = new System.Drawing.Point(-7, 60);
            this.txt_instrPassword.Name = "txt_instrPassword";
            this.txt_instrPassword.ReadOnly = true;
            this.txt_instrPassword.Size = new System.Drawing.Size(395, 30);
            this.txt_instrPassword.TabIndex = 3;
            this.txt_instrPassword.Text = "98472349";
            this.txt_instrPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(120, 108);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(137, 23);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "&Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // form_securityAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 27);
            this.ControlBox = false;
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.txt_instrPassword);
            this.Controls.Add(this.txt_message);
            this.Controls.Add(this.txt_password);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "form_securityAccess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter your log-in password.";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.form_securityAccess_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_message;
        private System.Windows.Forms.TextBox txt_instrPassword;
        private System.Windows.Forms.Button cmdClose;
    }
}