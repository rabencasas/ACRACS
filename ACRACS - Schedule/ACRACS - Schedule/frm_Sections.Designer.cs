namespace ACRACS___Schedule
{
    partial class frm_Sections
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
            this.lstSections = new System.Windows.Forms.ListView();
            this.clmName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmProgram = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmYrLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDensity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lstSections
            // 
            this.lstSections.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstSections.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstSections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName,
            this.clmProgram,
            this.clmYrLevel,
            this.clmDensity});
            this.lstSections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSections.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSections.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lstSections.FullRowSelect = true;
            this.lstSections.Location = new System.Drawing.Point(0, 0);
            this.lstSections.Name = "lstSections";
            this.lstSections.Size = new System.Drawing.Size(399, 542);
            this.lstSections.TabIndex = 0;
            this.lstSections.UseCompatibleStateImageBehavior = false;
            this.lstSections.View = System.Windows.Forms.View.Details;
            this.lstSections.DoubleClick += new System.EventHandler(this.lstSections_DoubleClick);
            // 
            // clmName
            // 
            this.clmName.Text = "Name";
            this.clmName.Width = 100;
            // 
            // clmProgram
            // 
            this.clmProgram.Text = "Program";
            this.clmProgram.Width = 100;
            // 
            // clmYrLevel
            // 
            this.clmYrLevel.Text = "Year Level";
            this.clmYrLevel.Width = 100;
            // 
            // clmDensity
            // 
            this.clmDensity.Text = "Class Density";
            this.clmDensity.Width = 100;
            // 
            // frm_Sections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 542);
            this.Controls.Add(this.lstSections);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Sections";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frm_Sections_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstSections;
        private System.Windows.Forms.ColumnHeader clmName;
        private System.Windows.Forms.ColumnHeader clmProgram;
        private System.Windows.Forms.ColumnHeader clmYrLevel;
        private System.Windows.Forms.ColumnHeader clmDensity;
    }
}