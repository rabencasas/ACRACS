namespace ACRACS___Schedule
{
    partial class frmSplash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplash));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNotifier = new System.Windows.Forms.TextBox();
            this.cmdCoonfigureDB = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdRegister = new System.Windows.Forms.Button();
            this.cmdLogin = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDocInfo = new System.Windows.Forms.Label();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.lblMessage = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Controls.Add(this.txtNotifier);
            this.panel1.Controls.Add(this.cmdCoonfigureDB);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.cmdRegister);
            this.panel1.Controls.Add(this.cmdLogin);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblDocInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(689, 356);
            this.panel1.TabIndex = 13;
            // 
            // txtNotifier
            // 
            this.txtNotifier.BackColor = System.Drawing.SystemColors.Control;
            this.txtNotifier.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNotifier.Enabled = false;
            this.txtNotifier.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtNotifier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNotifier.Location = new System.Drawing.Point(12, 163);
            this.txtNotifier.Name = "txtNotifier";
            this.txtNotifier.Size = new System.Drawing.Size(665, 23);
            this.txtNotifier.TabIndex = 14;
            this.txtNotifier.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdCoonfigureDB
            // 
            this.cmdCoonfigureDB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdCoonfigureDB.BackgroundImage")));
            this.cmdCoonfigureDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdCoonfigureDB.Location = new System.Drawing.Point(10, 9);
            this.cmdCoonfigureDB.Name = "cmdCoonfigureDB";
            this.cmdCoonfigureDB.Size = new System.Drawing.Size(35, 33);
            this.cmdCoonfigureDB.TabIndex = 22;
            this.cmdCoonfigureDB.UseVisualStyleBackColor = true;
            this.cmdCoonfigureDB.Click += new System.EventHandler(this.cmdCoonfigureDB_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(244, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "E&xit Application";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdRegister
            // 
            this.cmdRegister.Location = new System.Drawing.Point(244, 255);
            this.cmdRegister.Name = "cmdRegister";
            this.cmdRegister.Size = new System.Drawing.Size(159, 23);
            this.cmdRegister.TabIndex = 19;
            this.cmdRegister.Text = "&Register";
            this.cmdRegister.UseVisualStyleBackColor = true;
            this.cmdRegister.Click += new System.EventHandler(this.cmdRegister_Click);
            // 
            // cmdLogin
            // 
            this.cmdLogin.Location = new System.Drawing.Point(244, 231);
            this.cmdLogin.Name = "cmdLogin";
            this.cmdLogin.Size = new System.Drawing.Size(159, 23);
            this.cmdLogin.TabIndex = 18;
            this.cmdLogin.Text = "Log-&in";
            this.cmdLogin.UseVisualStyleBackColor = true;
            this.cmdLogin.Visible = false;
            this.cmdLogin.Click += new System.EventHandler(this.cmdLogin_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(173, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(318, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Developer: Raben V. Casas   |   Contact: casasraben@gmail.com";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(293, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 16;
            this.label2.Text = "ACRACS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(312, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // lblDocInfo
            // 
            this.lblDocInfo.AutoSize = true;
            this.lblDocInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblDocInfo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocInfo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblDocInfo.Location = new System.Drawing.Point(174, 89);
            this.lblDocInfo.Name = "lblDocInfo";
            this.lblDocInfo.Size = new System.Drawing.Size(324, 16);
            this.lblDocInfo.TabIndex = 13;
            this.lblDocInfo.Text = "Asian College Room and Class Scheduling System";
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 1000;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(243, 200);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(161, 13);
            this.lblMessage.TabIndex = 19;
            this.lblMessage.Text = "Another DPD is currently active.";
            this.lblMessage.Visible = false;
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(689, 356);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSplash_FormClosing);
            this.Load += new System.EventHandler(this.frmSplash_Load);
            this.Shown += new System.EventHandler(this.frmSplash_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdRegister;
        private System.Windows.Forms.Button cmdLogin;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label lblDocInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdCoonfigureDB;
        internal System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.TextBox txtNotifier;
        private System.Windows.Forms.Label lblMessage;


    }
}

