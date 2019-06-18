namespace ACRACS___Schedule
{
    partial class form_sectionCourses
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
            this.lstCourses = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstCourses
            // 
            this.lstCourses.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCourses.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCourses.FormattingEnabled = true;
            this.lstCourses.ItemHeight = 18;
            this.lstCourses.Location = new System.Drawing.Point(0, 0);
            this.lstCourses.Name = "lstCourses";
            this.lstCourses.Size = new System.Drawing.Size(232, 371);
            this.lstCourses.TabIndex = 0;
            // 
            // form_sectionCourses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 371);
            this.Controls.Add(this.lstCourses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "form_sectionCourses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.form_sectionCourses_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstCourses;
    }
}