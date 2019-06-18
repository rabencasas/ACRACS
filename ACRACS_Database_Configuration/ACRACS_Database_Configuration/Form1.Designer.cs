namespace ACRACS_Database_Configuration
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmd_delete = new System.Windows.Forms.Button();
            this.cmd_create = new System.Windows.Forms.Button();
            this.cmd_Cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cbo_app = new System.Windows.Forms.ComboBox();
            this.cmd_save = new System.Windows.Forms.Button();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_instanceName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chk_NamedInstance = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmd_Cancel1 = new System.Windows.Forms.Button();
            this.cmd_Save1 = new System.Windows.Forms.Button();
            this.cmd_Close = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cbo_app1 = new System.Windows.Forms.ComboBox();
            this.cmd_removeInstance = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cmd_Cancel);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbo_app);
            this.groupBox1.Controls.Add(this.cmd_save);
            this.groupBox1.Controls.Add(this.txt_password);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_id);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 238);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Authentication details";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmd_delete);
            this.groupBox2.Controls.Add(this.cmd_create);
            this.groupBox2.Location = new System.Drawing.Point(43, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(221, 80);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // cmd_delete
            // 
            this.cmd_delete.Location = new System.Drawing.Point(38, 46);
            this.cmd_delete.Name = "cmd_delete";
            this.cmd_delete.Size = new System.Drawing.Size(144, 23);
            this.cmd_delete.TabIndex = 2;
            this.cmd_delete.Text = "Use &default authentication";
            this.cmd_delete.UseVisualStyleBackColor = true;
            this.cmd_delete.Click += new System.EventHandler(this.cmd_delete_Click);
            // 
            // cmd_create
            // 
            this.cmd_create.Location = new System.Drawing.Point(38, 17);
            this.cmd_create.Name = "cmd_create";
            this.cmd_create.Size = new System.Drawing.Size(144, 23);
            this.cmd_create.TabIndex = 1;
            this.cmd_create.Text = "&Add authentication details";
            this.cmd_create.UseVisualStyleBackColor = true;
            this.cmd_create.Click += new System.EventHandler(this.cmd_create_Click);
            // 
            // cmd_Cancel
            // 
            this.cmd_Cancel.Enabled = false;
            this.cmd_Cancel.Location = new System.Drawing.Point(339, 206);
            this.cmd_Cancel.Name = "cmd_Cancel";
            this.cmd_Cancel.Size = new System.Drawing.Size(82, 23);
            this.cmd_Cancel.TabIndex = 5;
            this.cmd_Cancel.Text = "&Cancel";
            this.cmd_Cancel.UseVisualStyleBackColor = true;
            this.cmd_Cancel.Click += new System.EventHandler(this.cmd_Cancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(43, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 1);
            this.panel1.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(303, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "For application:";
            // 
            // cbo_app
            // 
            this.cbo_app.Enabled = false;
            this.cbo_app.FormattingEnabled = true;
            this.cbo_app.Items.AddRange(new object[] {
            "ACRACS-Manage",
            "ACRACS-Schedule",
            "ACRACS-Client"});
            this.cbo_app.Location = new System.Drawing.Point(306, 39);
            this.cbo_app.Name = "cbo_app";
            this.cbo_app.Size = new System.Drawing.Size(203, 21);
            this.cbo_app.TabIndex = 2;
            this.cbo_app.SelectedIndexChanged += new System.EventHandler(this.cbo_app_SelectedIndexChanged);
            // 
            // cmd_save
            // 
            this.cmd_save.Enabled = false;
            this.cmd_save.Location = new System.Drawing.Point(427, 206);
            this.cmd_save.Name = "cmd_save";
            this.cmd_save.Size = new System.Drawing.Size(82, 23);
            this.cmd_save.TabIndex = 6;
            this.cmd_save.Text = "&Save";
            this.cmd_save.UseVisualStyleBackColor = true;
            this.cmd_save.Click += new System.EventHandler(this.cmd_save_Click);
            // 
            // txt_password
            // 
            this.txt_password.Enabled = false;
            this.txt_password.Location = new System.Drawing.Point(305, 155);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(204, 20);
            this.txt_password.TabIndex = 4;
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(302, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Authentication password:";
            // 
            // txt_id
            // 
            this.txt_id.Enabled = false;
            this.txt_id.Location = new System.Drawing.Point(79, 155);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(204, 20);
            this.txt_id.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Authentication ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(7, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(478, 29);
            this.label4.TabIndex = 5;
            this.label4.Text = "SQL Server Database Connection Configuration";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(12, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(432, 52);
            this.label5.TabIndex = 7;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(9, 583);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(305, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Note: Please do no use \'tab key\' in your User ID and password.";
            // 
            // txt_instanceName
            // 
            this.txt_instanceName.Enabled = false;
            this.txt_instanceName.Location = new System.Drawing.Point(43, 57);
            this.txt_instanceName.Name = "txt_instanceName";
            this.txt_instanceName.Size = new System.Drawing.Size(240, 20);
            this.txt_instanceName.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(40, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(213, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Instance name: (e.g. NEW_SQLEXPRESS)";
            // 
            // chk_NamedInstance
            // 
            this.chk_NamedInstance.AutoSize = true;
            this.chk_NamedInstance.Location = new System.Drawing.Point(10, 0);
            this.chk_NamedInstance.Name = "chk_NamedInstance";
            this.chk_NamedInstance.Size = new System.Drawing.Size(155, 17);
            this.chk_NamedInstance.TabIndex = 1;
            this.chk_NamedInstance.Text = "Use named instance server";
            this.chk_NamedInstance.UseVisualStyleBackColor = true;
            this.chk_NamedInstance.CheckedChanged += new System.EventHandler(this.chk_NamedInstance_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox3.Controls.Add(this.cmd_removeInstance);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.cbo_app1);
            this.groupBox3.Controls.Add(this.cmd_Cancel1);
            this.groupBox3.Controls.Add(this.cmd_Save1);
            this.groupBox3.Controls.Add(this.txt_instanceName);
            this.groupBox3.Controls.Add(this.chk_NamedInstance);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(12, 372);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(560, 179);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // cmd_Cancel1
            // 
            this.cmd_Cancel1.Enabled = false;
            this.cmd_Cancel1.Location = new System.Drawing.Point(339, 101);
            this.cmd_Cancel1.Name = "cmd_Cancel1";
            this.cmd_Cancel1.Size = new System.Drawing.Size(82, 23);
            this.cmd_Cancel1.TabIndex = 4;
            this.cmd_Cancel1.Text = "&Cancel";
            this.cmd_Cancel1.UseVisualStyleBackColor = true;
            this.cmd_Cancel1.Click += new System.EventHandler(this.cmd_Cancel1_Click);
            // 
            // cmd_Save1
            // 
            this.cmd_Save1.Enabled = false;
            this.cmd_Save1.Location = new System.Drawing.Point(427, 101);
            this.cmd_Save1.Name = "cmd_Save1";
            this.cmd_Save1.Size = new System.Drawing.Size(82, 23);
            this.cmd_Save1.TabIndex = 5;
            this.cmd_Save1.Text = "&Save";
            this.cmd_Save1.UseVisualStyleBackColor = true;
            this.cmd_Save1.Click += new System.EventHandler(this.cmd_Save1_Click);
            // 
            // cmd_Close
            // 
            this.cmd_Close.Location = new System.Drawing.Point(439, 578);
            this.cmd_Close.Name = "cmd_Close";
            this.cmd_Close.Size = new System.Drawing.Size(82, 23);
            this.cmd_Close.TabIndex = 2;
            this.cmd_Close.Text = "Cl&ose";
            this.cmd_Close.UseVisualStyleBackColor = true;
            this.cmd_Close.Click += new System.EventHandler(this.cmd_Close_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(302, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "For application:";
            // 
            // cbo_app1
            // 
            this.cbo_app1.Enabled = false;
            this.cbo_app1.FormattingEnabled = true;
            this.cbo_app1.Items.AddRange(new object[] {
            "ACRACS-Manage",
            "ACRACS-Schedule",
            "ACRACS-Client"});
            this.cbo_app1.Location = new System.Drawing.Point(305, 57);
            this.cbo_app1.Name = "cbo_app1";
            this.cbo_app1.Size = new System.Drawing.Size(203, 21);
            this.cbo_app1.TabIndex = 3;
            // 
            // cmd_removeInstance
            // 
            this.cmd_removeInstance.Location = new System.Drawing.Point(339, 130);
            this.cmd_removeInstance.Name = "cmd_removeInstance";
            this.cmd_removeInstance.Size = new System.Drawing.Size(169, 23);
            this.cmd_removeInstance.TabIndex = 6;
            this.cmd_removeInstance.Text = "&Remove named instance";
            this.cmd_removeInstance.UseVisualStyleBackColor = true;
            this.cmd_removeInstance.Click += new System.EventHandler(this.cmd_removeInstance_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(584, 611);
            this.Controls.Add(this.cmd_Close);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmd_save;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbo_app;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmd_Cancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmd_delete;
        private System.Windows.Forms.Button cmd_create;
        private System.Windows.Forms.TextBox txt_instanceName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chk_NamedInstance;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button cmd_Cancel1;
        private System.Windows.Forms.Button cmd_Save1;
        private System.Windows.Forms.Button cmd_Close;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbo_app1;
        private System.Windows.Forms.Button cmd_removeInstance;

    }
}

