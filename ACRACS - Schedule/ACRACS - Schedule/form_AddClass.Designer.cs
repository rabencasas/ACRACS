namespace ACRACS___Schedule
{
    partial class frmAddClass
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
            this.lblSection = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMergedSections = new System.Windows.Forms.Label();
            this.cmdMerge = new System.Windows.Forms.Button();
            this.cboRoom = new System.Windows.Forms.ComboBox();
            this.cboDay = new System.Windows.Forms.ComboBox();
            this.cboInstructor = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoLaboratory = new System.Windows.Forms.RadioButton();
            this.rdoLecture = new System.Windows.Forms.RadioButton();
            this.cboToTime = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboFromTime = new System.Windows.Forms.ComboBox();
            this.cboCourse = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdAddClass = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.BackColor = System.Drawing.Color.Transparent;
            this.lblSection.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSection.Location = new System.Drawing.Point(12, 9);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(85, 19);
            this.lblSection.TabIndex = 7;
            this.lblSection.Text = "BSIT-111";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMergedSections);
            this.groupBox1.Controls.Add(this.cmdMerge);
            this.groupBox1.Controls.Add(this.cboRoom);
            this.groupBox1.Controls.Add(this.cboDay);
            this.groupBox1.Controls.Add(this.cboInstructor);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cboToTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboFromTime);
            this.groupBox1.Controls.Add(this.cboCourse);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 250);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblMergedSections
            // 
            this.lblMergedSections.AutoSize = true;
            this.lblMergedSections.Location = new System.Drawing.Point(90, 192);
            this.lblMergedSections.Name = "lblMergedSections";
            this.lblMergedSections.Size = new System.Drawing.Size(10, 13);
            this.lblMergedSections.TabIndex = 25;
            this.lblMergedSections.Text = ".";
            // 
            // cmdMerge
            // 
            this.cmdMerge.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMerge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdMerge.Location = new System.Drawing.Point(87, 211);
            this.cmdMerge.Name = "cmdMerge";
            this.cmdMerge.Size = new System.Drawing.Size(105, 23);
            this.cmdMerge.TabIndex = 11;
            this.cmdMerge.Text = "Merge...";
            this.cmdMerge.UseVisualStyleBackColor = true;
            this.cmdMerge.Click += new System.EventHandler(this.cmdMerge1_Click);
            // 
            // cboRoom
            // 
            this.cboRoom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboRoom.FormattingEnabled = true;
            this.cboRoom.Location = new System.Drawing.Point(87, 149);
            this.cboRoom.Name = "cboRoom";
            this.cboRoom.Size = new System.Drawing.Size(340, 21);
            this.cboRoom.TabIndex = 10;
            // 
            // cboDay
            // 
            this.cboDay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboDay.FormattingEnabled = true;
            this.cboDay.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.cboDay.Location = new System.Drawing.Point(87, 123);
            this.cboDay.Name = "cboDay";
            this.cboDay.Size = new System.Drawing.Size(340, 21);
            this.cboDay.TabIndex = 9;
            // 
            // cboInstructor
            // 
            this.cboInstructor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboInstructor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboInstructor.FormattingEnabled = true;
            this.cboInstructor.Location = new System.Drawing.Point(87, 97);
            this.cboInstructor.Name = "cboInstructor";
            this.cboInstructor.Size = new System.Drawing.Size(340, 21);
            this.cboInstructor.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Room:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoLaboratory);
            this.groupBox2.Controls.Add(this.rdoLecture);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox2.Location = new System.Drawing.Point(87, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 30);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // rdoLaboratory
            // 
            this.rdoLaboratory.AutoSize = true;
            this.rdoLaboratory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoLaboratory.Location = new System.Drawing.Point(103, 10);
            this.rdoLaboratory.Name = "rdoLaboratory";
            this.rdoLaboratory.Size = new System.Drawing.Size(88, 17);
            this.rdoLaboratory.TabIndex = 7;
            this.rdoLaboratory.TabStop = true;
            this.rdoLaboratory.Text = "Laboratory";
            this.rdoLaboratory.UseVisualStyleBackColor = true;
            // 
            // rdoLecture
            // 
            this.rdoLecture.AutoSize = true;
            this.rdoLecture.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoLecture.Location = new System.Drawing.Point(6, 10);
            this.rdoLecture.Name = "rdoLecture";
            this.rdoLecture.Size = new System.Drawing.Size(68, 17);
            this.rdoLecture.TabIndex = 6;
            this.rdoLecture.TabStop = true;
            this.rdoLecture.Text = "Lecture";
            this.rdoLecture.UseVisualStyleBackColor = true;
            // 
            // cboToTime
            // 
            this.cboToTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboToTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboToTime.FormattingEnabled = true;
            this.cboToTime.Location = new System.Drawing.Point(190, 38);
            this.cboToTime.Name = "cboToTime";
            this.cboToTime.Size = new System.Drawing.Size(84, 21);
            this.cboToTime.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Instructor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Day:";
            // 
            // cboFromTime
            // 
            this.cboFromTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboFromTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboFromTime.FormattingEnabled = true;
            this.cboFromTime.Location = new System.Drawing.Point(87, 38);
            this.cboFromTime.Name = "cboFromTime";
            this.cboFromTime.Size = new System.Drawing.Size(84, 21);
            this.cboFromTime.TabIndex = 3;
            // 
            // cboCourse
            // 
            this.cboCourse.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboCourse.FormattingEnabled = true;
            this.cboCourse.Location = new System.Drawing.Point(87, 13);
            this.cboCourse.Name = "cboCourse";
            this.cboCourse.Size = new System.Drawing.Size(340, 21);
            this.cboCourse.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Class type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Time:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Course:";
            // 
            // cmdAddClass
            // 
            this.cmdAddClass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdAddClass.Location = new System.Drawing.Point(103, 301);
            this.cmdAddClass.Name = "cmdAddClass";
            this.cmdAddClass.Size = new System.Drawing.Size(105, 23);
            this.cmdAddClass.TabIndex = 22;
            this.cmdAddClass.Text = "Add Class";
            this.cmdAddClass.UseVisualStyleBackColor = true;
            this.cmdAddClass.Click += new System.EventHandler(this.cmdAddClass_Click);
            // 
            // frmAddClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 329);
            this.Controls.Add(this.cmdAddClass);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblSection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddClass_FormClosed);
            this.Load += new System.EventHandler(this.frmAddClass_Load);
            this.Shown += new System.EventHandler(this.frmAddClass_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboDay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoLaboratory;
        private System.Windows.Forms.RadioButton rdoLecture;
        private System.Windows.Forms.ComboBox cboToTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboFromTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdAddClass;
        private System.Windows.Forms.Button cmdMerge;
        internal System.Windows.Forms.ComboBox cboCourse;
        internal System.Windows.Forms.Label lblMergedSections;
        internal System.Windows.Forms.ComboBox cboInstructor;
        internal System.Windows.Forms.ComboBox cboRoom;
    }
}