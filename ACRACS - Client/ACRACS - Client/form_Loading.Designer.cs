﻿namespace ACRACS___Client
{
    partial class form_Loading
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
            this.prgSaveProgress.Enabled = false;
            this.prgSaveProgress.Location = new System.Drawing.Point(0, 0);
            this.prgSaveProgress.Name = "prgSaveProgress";
            this.prgSaveProgress.Size = new System.Drawing.Size(353, 33);
            this.prgSaveProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.prgSaveProgress.TabIndex = 3;
            // 
            // form_Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 33);
            this.ControlBox = false;
            this.Controls.Add(this.prgSaveProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "form_Loading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading Report";
            this.Shown += new System.EventHandler(this.form_Loading_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar prgSaveProgress;
    }
}