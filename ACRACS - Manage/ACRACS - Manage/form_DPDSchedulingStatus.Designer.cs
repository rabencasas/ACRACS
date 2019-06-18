namespace ACRACS___Manage
{
    partial class form_DPDSchedulingStatus
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "Business Department",
            " ",
            " "}, -1);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "Gen. Ed. and Health Care Services Department",
            " ",
            " "}, -1);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "Technology Department",
            " ",
            " "}, -1);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            "Tourism and Hopitality Management Department",
            " ",
            " "}, -1);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lst_DPD_Stat = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.icon_Dept1 = new System.Windows.Forms.Button();
            this.icon_Dept2 = new System.Windows.Forms.Button();
            this.icon_Dept3 = new System.Windows.Forms.Button();
            this.icon_Dept4 = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tmrRealtime = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lblDescription);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 37);
            this.panel1.TabIndex = 12;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDescription.Location = new System.Drawing.Point(21, 9);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(170, 19);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.Text = "DPD Scheduling Status";
            // 
            // lst_DPD_Stat
            // 
            this.lst_DPD_Stat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lst_DPD_Stat.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_DPD_Stat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lst_DPD_Stat.FullRowSelect = true;
            this.lst_DPD_Stat.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8});
            this.lst_DPD_Stat.Location = new System.Drawing.Point(49, 69);
            this.lst_DPD_Stat.Name = "lst_DPD_Stat";
            this.lst_DPD_Stat.Size = new System.Drawing.Size(726, 224);
            this.lst_DPD_Stat.TabIndex = 13;
            this.lst_DPD_Stat.UseCompatibleStateImageBehavior = false;
            this.lst_DPD_Stat.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Department";
            this.columnHeader1.Width = 360;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "DPD (Deputy Program Director)";
            this.columnHeader2.Width = 219;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Scheduling Status";
            this.columnHeader3.Width = 130;
            // 
            // icon_Dept1
            // 
            this.icon_Dept1.Location = new System.Drawing.Point(25, 97);
            this.icon_Dept1.Name = "icon_Dept1";
            this.icon_Dept1.Size = new System.Drawing.Size(18, 18);
            this.icon_Dept1.TabIndex = 14;
            this.icon_Dept1.UseVisualStyleBackColor = true;
            // 
            // icon_Dept2
            // 
            this.icon_Dept2.Location = new System.Drawing.Point(25, 118);
            this.icon_Dept2.Name = "icon_Dept2";
            this.icon_Dept2.Size = new System.Drawing.Size(18, 18);
            this.icon_Dept2.TabIndex = 15;
            this.icon_Dept2.UseVisualStyleBackColor = true;
            // 
            // icon_Dept3
            // 
            this.icon_Dept3.Location = new System.Drawing.Point(25, 138);
            this.icon_Dept3.Name = "icon_Dept3";
            this.icon_Dept3.Size = new System.Drawing.Size(18, 18);
            this.icon_Dept3.TabIndex = 16;
            this.icon_Dept3.UseVisualStyleBackColor = true;
            // 
            // icon_Dept4
            // 
            this.icon_Dept4.Location = new System.Drawing.Point(25, 158);
            this.icon_Dept4.Name = "icon_Dept4";
            this.icon_Dept4.Size = new System.Drawing.Size(18, 18);
            this.icon_Dept4.TabIndex = 17;
            this.icon_Dept4.UseVisualStyleBackColor = true;
            // 
            // cmdClose
            // 
            this.cmdClose.ForeColor = System.Drawing.Color.Black;
            this.cmdClose.Location = new System.Drawing.Point(49, 313);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(110, 23);
            this.cmdClose.TabIndex = 22;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkLabel1.Location = new System.Drawing.Point(432, 318);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(29, 13);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "here";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(214, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "If all the DPDs completed the schedules, click";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(457, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "to update the overall scheduling status.";
            // 
            // tmrRealtime
            // 
            this.tmrRealtime.Interval = 3000;
            this.tmrRealtime.Tick += new System.EventHandler(this.tmrRealtime_Tick);
            // 
            // form_DPDSchedulingStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(794, 348);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.icon_Dept4);
            this.Controls.Add(this.icon_Dept3);
            this.Controls.Add(this.icon_Dept2);
            this.Controls.Add(this.icon_Dept1);
            this.Controls.Add(this.lst_DPD_Stat);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "form_DPDSchedulingStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_DPDSchedulingStatus_FormClosing);
            this.Load += new System.EventHandler(this.form_DPDSchedulingStatus_Load);
            this.Shown += new System.EventHandler(this.form_DPDSchedulingStatus_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ListView lst_DPD_Stat;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button icon_Dept1;
        private System.Windows.Forms.Button icon_Dept2;
        private System.Windows.Forms.Button icon_Dept3;
        private System.Windows.Forms.Button icon_Dept4;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer tmrRealtime;
    }
}