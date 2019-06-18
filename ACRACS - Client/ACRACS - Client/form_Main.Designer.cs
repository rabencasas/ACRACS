namespace ACRACS___Client
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutTheDeveloperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pdfViewer1 = new Apitron.PDF.Controls.PDFViewer();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlTopHeader = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmdActivate = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.pnlDocInfo_container = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDocInfo = new System.Windows.Forms.Label();
            this.lblDocTitle = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.pnlTopHeader.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlDocInfo_container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.accountToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1240, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.saveAsPDFToolStripMenuItem,
            this.toolStripSeparator2,
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(142, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // saveAsPDFToolStripMenuItem
            // 
            this.saveAsPDFToolStripMenuItem.Name = "saveAsPDFToolStripMenuItem";
            this.saveAsPDFToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.saveAsPDFToolStripMenuItem.Text = "&Save as PDF...";
            this.saveAsPDFToolStripMenuItem.Click += new System.EventHandler(this.saveAsPDFToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(142, 6);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.logoutToolStripMenuItem.Text = "&Log-out";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.accountToolStripMenuItem.Text = "&Account";
            this.accountToolStripMenuItem.Click += new System.EventHandler(this.accountToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutSystemToolStripMenuItem,
            this.aboutTheDeveloperToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutSystemToolStripMenuItem
            // 
            this.aboutSystemToolStripMenuItem.Name = "aboutSystemToolStripMenuItem";
            this.aboutSystemToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.aboutSystemToolStripMenuItem.Text = "&About System...";
            this.aboutSystemToolStripMenuItem.Click += new System.EventHandler(this.aboutSystemToolStripMenuItem_Click);
            // 
            // aboutTheDeveloperToolStripMenuItem
            // 
            this.aboutTheDeveloperToolStripMenuItem.Name = "aboutTheDeveloperToolStripMenuItem";
            this.aboutTheDeveloperToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.aboutTheDeveloperToolStripMenuItem.Text = "&About the Developer...";
            this.aboutTheDeveloperToolStripMenuItem.Click += new System.EventHandler(this.aboutTheDeveloperToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 567);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1240, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // lblUser
            // 
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(220, 17);
            this.lblUser.Text = "Jerome Pueblos - Technology Department";
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.pdfViewer1);
            this.pnlContainer.Controls.Add(this.panel5);
            this.pnlContainer.Controls.Add(this.panel3);
            this.pnlContainer.Controls.Add(this.panel2);
            this.pnlContainer.Controls.Add(this.panel1);
            this.pnlContainer.Controls.Add(this.pnlTopHeader);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1240, 589);
            this.pnlContainer.TabIndex = 2;
            this.pnlContainer.Visible = false;
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.BackColor = System.Drawing.SystemColors.Control;
            this.pdfViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer1.Document = null;
            this.pdfViewer1.EnableSearch = true;
            this.pdfViewer1.Location = new System.Drawing.Point(22, 90);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.PageViewMode = Apitron.PDF.Controls.PageViewMode.PageByPage;
            this.pdfViewer1.SearchHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.pdfViewer1.Size = new System.Drawing.Size(1196, 469);
            this.pdfViewer1.TabIndex = 15;
            this.pdfViewer1.Zoom = 1.5F;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(22, 559);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1196, 30);
            this.panel5.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(22, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1196, 30);
            this.panel3.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1218, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(22, 529);
            this.panel2.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(22, 529);
            this.panel1.TabIndex = 11;
            // 
            // pnlTopHeader
            // 
            this.pnlTopHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTopHeader.BackgroundImage")));
            this.pnlTopHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTopHeader.Controls.Add(this.panel4);
            this.pnlTopHeader.Controls.Add(this.pnlDocInfo_container);
            this.pnlTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlTopHeader.Name = "pnlTopHeader";
            this.pnlTopHeader.Size = new System.Drawing.Size(1240, 60);
            this.pnlTopHeader.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.cmdActivate);
            this.panel4.Controls.Add(this.cmdSave);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(957, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(281, 58);
            this.panel4.TabIndex = 9;
            // 
            // cmdActivate
            // 
            this.cmdActivate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.cmdActivate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdActivate.Location = new System.Drawing.Point(140, 17);
            this.cmdActivate.Name = "cmdActivate";
            this.cmdActivate.Size = new System.Drawing.Size(123, 31);
            this.cmdActivate.TabIndex = 9;
            this.cmdActivate.Text = "Print";
            this.cmdActivate.UseVisualStyleBackColor = true;
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.cmdSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdSave.Location = new System.Drawing.Point(11, 17);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(123, 31);
            this.cmdSave.TabIndex = 8;
            this.cmdSave.Text = "Save as PDF";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // pnlDocInfo_container
            // 
            this.pnlDocInfo_container.BackColor = System.Drawing.Color.Transparent;
            this.pnlDocInfo_container.Controls.Add(this.pictureBox1);
            this.pnlDocInfo_container.Controls.Add(this.lblDocInfo);
            this.pnlDocInfo_container.Controls.Add(this.lblDocTitle);
            this.pnlDocInfo_container.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDocInfo_container.Location = new System.Drawing.Point(0, 0);
            this.pnlDocInfo_container.Name = "pnlDocInfo_container";
            this.pnlDocInfo_container.Size = new System.Drawing.Size(698, 58);
            this.pnlDocInfo_container.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // lblDocInfo
            // 
            this.lblDocInfo.AutoSize = true;
            this.lblDocInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblDocInfo.Location = new System.Drawing.Point(62, 35);
            this.lblDocInfo.Name = "lblDocInfo";
            this.lblDocInfo.Size = new System.Drawing.Size(121, 13);
            this.lblDocInfo.TabIndex = 7;
            this.lblDocInfo.Text = "Technology Department";
            // 
            // lblDocTitle
            // 
            this.lblDocTitle.AutoSize = true;
            this.lblDocTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDocTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocTitle.Location = new System.Drawing.Point(61, 11);
            this.lblDocTitle.Name = "lblDocTitle";
            this.lblDocTitle.Size = new System.Drawing.Size(138, 19);
            this.lblDocTitle.TabIndex = 6;
            this.lblDocTitle.Text = "Jerome Pueblos";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "\"Pdf file (*.pdf)|*.pdf|All files (*.*)|*.*\"";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1240, 589);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACRACS - Client";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            this.pnlTopHeader.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnlDocInfo_container.ResumeLayout(false);
            this.pnlDocInfo_container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel pnlTopHeader;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Button cmdActivate;
        public System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Panel pnlDocInfo_container;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label lblDocInfo;
        public System.Windows.Forms.Label lblDocTitle;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutTheDeveloperToolStripMenuItem;
        public System.Windows.Forms.ToolStripStatusLabel lblUser;
        internal Apitron.PDF.Controls.PDFViewer pdfViewer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;


    }
}

