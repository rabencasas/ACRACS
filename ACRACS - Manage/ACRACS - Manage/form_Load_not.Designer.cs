namespace ACRACS___Manage
{
    partial class form_Load_not
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
            this.prgUnloadProgress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // prgUnloadProgress
            // 
            this.prgUnloadProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prgUnloadProgress.Enabled = false;
            this.prgUnloadProgress.Location = new System.Drawing.Point(0, 0);
            this.prgUnloadProgress.Name = "prgUnloadProgress";
            this.prgUnloadProgress.Size = new System.Drawing.Size(353, 33);
            this.prgUnloadProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.prgUnloadProgress.TabIndex = 2;
            // 
            // form_Load_not
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 33);
            this.ControlBox = false;
            this.Controls.Add(this.prgUnloadProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "form_Load_not";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unloading";
            this.Shown += new System.EventHandler(this.form_Load_not_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar prgUnloadProgress;
    }
}