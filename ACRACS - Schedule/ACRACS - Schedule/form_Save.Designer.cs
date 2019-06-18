namespace ACRACS___Schedule
{
    partial class form_Save
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
            this.prgSaveProgress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // prgSaveProgress
            // 
            this.prgSaveProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prgSaveProgress.Location = new System.Drawing.Point(0, 0);
            this.prgSaveProgress.Maximum = 5;
            this.prgSaveProgress.Name = "prgSaveProgress";
            this.prgSaveProgress.Size = new System.Drawing.Size(353, 33);
            this.prgSaveProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.prgSaveProgress.TabIndex = 1;
            // 
            // form_Save
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 33);
            this.ControlBox = false;
            this.Controls.Add(this.prgSaveProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "form_Save";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saving to database";
            this.Shown += new System.EventHandler(this.form_Save_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar prgSaveProgress;
    }
}