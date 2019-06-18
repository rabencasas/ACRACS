using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;
using acracs.ReportEngine;
using acschedule;

namespace ACRACS___Client
{
    public partial class frmMain : Form
    {
        // fields/report objects/etc.
        internal InstructorReport instructorReport;


        /**** METHODS ****/
        public frmMain()
        {
            InitializeComponent();
        }

        private void Logout()
        {
            if (MessageBox.Show(this, "Are you sure you want to log-out?", "Log-out confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                // hide controls
                menuStrip1.Visible = false;
                pnlTopHeader.Visible = false;
                pnlContainer.Visible = false;
                statusStrip1.Visible = false;

                // clear current_user
                Program.user_department = string.Empty;
                Program.user_firstName = string.Empty;
                Program.user_lastName = string.Empty;
                Program.user_userName = string.Empty;

                Close();
                Program.splash.ShowDialog();
            }

        }
        private void ExitApplication()
        {
            if (MessageBox.Show(this, "Are you sure you want to close the application?", "Exit confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }
        //================================================

        /**** Form events ****/
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void aboutTheDeveloperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new form_Developer().ShowDialog();
        }

        private void aboutSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new form_System().ShowDialog();
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new form_UserAccount().ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*if (MessageBox.Show("Are you sure you want to close the application?","Confirm application close",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }*/
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            File.Copy(string.Concat(Environment.CurrentDirectory, "/reports/", Program.user_userName, ".pdf"), saveFileDialog1.FileName);
            MessageBox.Show("Report successfully saved as pdf file.","Report saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void saveAsPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }
    }
}
