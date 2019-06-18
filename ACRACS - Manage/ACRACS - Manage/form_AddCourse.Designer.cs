namespace ACRACS___Manage
{
    partial class form_AddCourse
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
            this.lstAddedCourses = new System.Windows.Forms.ListBox();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSection = new System.Windows.Forms.Label();
            this.cmddone = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstCourses
            // 
            this.lstCourses.FormattingEnabled = true;
            this.lstCourses.Location = new System.Drawing.Point(335, 61);
            this.lstCourses.Name = "lstCourses";
            this.lstCourses.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstCourses.Size = new System.Drawing.Size(276, 316);
            this.lstCourses.TabIndex = 0;
            // 
            // lstAddedCourses
            // 
            this.lstAddedCourses.FormattingEnabled = true;
            this.lstAddedCourses.Location = new System.Drawing.Point(12, 61);
            this.lstAddedCourses.Name = "lstAddedCourses";
            this.lstAddedCourses.Size = new System.Drawing.Size(276, 316);
            this.lstAddedCourses.TabIndex = 1;
            // 
            // cmdRemove
            // 
            this.cmdRemove.Location = new System.Drawing.Point(294, 61);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(35, 23);
            this.cmdRemove.TabIndex = 2;
            this.cmdRemove.Text = ">>";
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(294, 90);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(35, 23);
            this.cmdAdd.TabIndex = 3;
            this.cmdAdd.Text = "<<";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lblSection);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 37);
            this.panel1.TabIndex = 5;
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.BackColor = System.Drawing.Color.Transparent;
            this.lblSection.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSection.Location = new System.Drawing.Point(12, 10);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(76, 19);
            this.lblSection.TabIndex = 11;
            this.lblSection.Text = "BSIT-111";
            // 
            // cmddone
            // 
            this.cmddone.Location = new System.Drawing.Point(536, 383);
            this.cmddone.Name = "cmddone";
            this.cmddone.Size = new System.Drawing.Size(75, 23);
            this.cmddone.TabIndex = 6;
            this.cmddone.Text = "Done";
            this.cmddone.UseVisualStyleBackColor = true;
            this.cmddone.Click += new System.EventHandler(this.cmddone_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMessage.Location = new System.Drawing.Point(12, 388);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(337, 26);
            this.lblMessage.TabIndex = 19;
            this.lblMessage.Text = "Note: Use << button to add the selected courses to current section.\r\n          Us" +
    "e >> button to remove the current selected courses.";
            this.lblMessage.Visible = false;
            // 
            // form_AddCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(632, 423);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.cmddone);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.lstAddedCourses);
            this.Controls.Add(this.lstCourses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "form_AddCourse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add courses to section";
            this.Load += new System.EventHandler(this.form_AddCourse_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstCourses;
        private System.Windows.Forms.ListBox lstAddedCourses;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.Button cmddone;
        private System.Windows.Forms.Label lblMessage;
    }
}