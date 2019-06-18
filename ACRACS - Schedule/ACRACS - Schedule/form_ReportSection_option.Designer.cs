namespace ACRACS___Schedule
{
    partial class form_ReportSection_option
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
            this.cmdAll = new System.Windows.Forms.Button();
            this.cmdOne = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cboSections = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdAll
            // 
            this.cmdAll.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.cmdAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAll.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmdAll.Location = new System.Drawing.Point(14, 71);
            this.cmdAll.Name = "cmdAll";
            this.cmdAll.Size = new System.Drawing.Size(321, 38);
            this.cmdAll.TabIndex = 2;
            this.cmdAll.Text = "Select all sections.";
            this.cmdAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAll.UseVisualStyleBackColor = true;
            this.cmdAll.Click += new System.EventHandler(this.cmdAll_Click);
            // 
            // cmdOne
            // 
            this.cmdOne.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.cmdOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOne.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOne.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmdOne.Location = new System.Drawing.Point(14, 112);
            this.cmdOne.Name = "cmdOne";
            this.cmdOne.Size = new System.Drawing.Size(321, 38);
            this.cmdOne.TabIndex = 3;
            this.cmdOne.Text = "Select a section.";
            this.cmdOne.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdOne.UseVisualStyleBackColor = true;
            this.cmdOne.Click += new System.EventHandler(this.cmdOne_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select an option for generating reports.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select option.";
            // 
            // cmdSelect
            // 
            this.cmdSelect.Location = new System.Drawing.Point(8, 64);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(75, 23);
            this.cmdSelect.TabIndex = 6;
            this.cmdSelect.Text = "&Select";
            this.cmdSelect.UseVisualStyleBackColor = true;
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdCancel);
            this.groupBox1.Controls.Add(this.cboSections);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmdSelect);
            this.groupBox1.Location = new System.Drawing.Point(17, 199);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 95);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(233, 64);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cboSections
            // 
            this.cboSections.FormattingEnabled = true;
            this.cboSections.Location = new System.Drawing.Point(8, 37);
            this.cboSections.Name = "cboSections";
            this.cboSections.Size = new System.Drawing.Size(300, 21);
            this.cboSections.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sections:";
            // 
            // form_ReportSection_option
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(355, 163);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdOne);
            this.Controls.Add(this.cmdAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "form_ReportSection_option";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.form_ReportSection_option_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdAll;
        private System.Windows.Forms.Button cmdOne;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSelect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboSections;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdCancel;
    }
}