using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace ACRACS___Manage
{
    public partial class form_ActivateSchedule : Form
    {
        public form_ActivateSchedule()
        {
            InitializeComponent();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            try
            {
                Program.ActivateResource();
                Program.mainForm.pnlToolBox.Visible = false;
                Program.mainForm.cmdSave.Visible = false;
                Program.mainForm.optDocument_Description.Enabled = false;
                Program.mainForm.optFile_Save.Enabled = false;
                Program.mainForm.optSections.Enabled = false;
                Program.mainForm.optView_SchedulingStatus.Enabled = true;
                Program.mainForm.mnuReports.Visible = false;
                Program.mainForm.mnuReports.Enabled = true;

                //hide panels
                Program.mainForm.pnlClassRooms.Dock = DockStyle.None;
                Program.mainForm.pnlClassRooms.Visible = false;
                Program.mainForm.pnlCourses.Dock = DockStyle.None;
                Program.mainForm.pnlCourses.Visible = false;
                Program.mainForm.pnlInstructors.Dock = DockStyle.None;
                Program.mainForm.pnlInstructors.Visible = false;
                Program.mainForm.pnlDept1.Dock = DockStyle.None;
                Program.mainForm.pnlDept2.Dock = DockStyle.None;
                Program.mainForm.pnlDept3.Dock = DockStyle.None;
                Program.mainForm.pnlDept4.Dock = DockStyle.None;
                Program.mainForm.pnlDept1.Visible = false;
                Program.mainForm.pnlDept2.Visible = false;
                Program.mainForm.pnlDept3.Visible = false;
                Program.mainForm.pnlDept4.Visible = false;
                Program.mainForm.cmdActivate.Text = "Release";
                Program.mainForm.lblDocTitle.Text = string.Concat(Program.docDescription, " (Activated)");
                this.Close();
                new form_DPDSchedulingStatus().ShowDialog();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("An error has occured:\n\n",ex.Message,"\n\nPlease contact the developer."),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
