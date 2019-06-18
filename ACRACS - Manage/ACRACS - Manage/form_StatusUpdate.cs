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
    public partial class form_StatusUpdate : Form
    {
        public form_StatusUpdate()
        {
            InitializeComponent();
        }

        private void cboOpt_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOpt_Status.Text == "Activate")
            {
                lbOptDescription.Text = "Resource activating.\n\nThe resources will be visible to the DPDs.\nThis will allow the DPDs to start working on creating class schedules.\n\nOnce this option is chosen, you can no longer add or update the datas\nyou have inputted and saved.\n\nIt is therefore, recommended that you review the datas first.";
            }
            else if (cboOpt_Status.Text == "Release")
            {
                lbOptDescription.Text = "Releasing the schedules.\n\nIf this option is chosen, the reports will be available and acquirable to\nthe instructors as well as to the DPDs.\n\nThis status can be updated only when all the class schedules\nare complete.";
            }
            else if (cboOpt_Status.Text == "Deactivate")
            {
                lbOptDescription.Text = "Deactivating the resources.\n\nIf this option is chosen. Resources will be disabled to the DPDs as well as the reports.";
            }
            else
            {
                lbOptDescription.Text = "";
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            if (cboOpt_Status.Text == "Activate")
            {
                new form_ActivateSchedule().ShowDialog();
            }
            else if (cboOpt_Status.Text == "Release")
            {
                // update status in database
                using(SqlCommand cmd = new SqlCommand())
	            {
		            cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "UPDATE setting_Schedule_Description SET Status = 'Released'";
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
	            }

                // modify controls
                Program.mainForm.mnuReports.Visible = true;
                Program.mainForm.mnuReports.Enabled = true;
                Program.mainForm.pnlToolBox.Visible = false;
                Program.mainForm.cmdSave.Visible = false;
                Program.mainForm.optDocument_Description.Enabled = false;
                Program.mainForm.optView_SchedulingStatus.Enabled = false;
                Program.mainForm.optFile_Save.Enabled = false;

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
                Program.mainForm.optSections.Enabled = false;

                Program.mainForm.cmdActivate.Text = "Deactivate";
                Program.mainForm.lblDocTitle.Text = string.Concat(Program.docDescription, " (Released)");

                this.Close();
            }
            else if (cboOpt_Status.Text == "Deactivate")
            {
                // update status in database
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "UPDATE setting_Schedule_Description SET Status = 'Deactivated'";
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }

                // modify controls
                Program.mainForm.mnuReports.Visible = true;
                Program.mainForm.mnuReports.Enabled = true;
                Program.mainForm.pnlToolBox.Visible = true;
                Program.mainForm.cmdSave.Visible = true;
                Program.mainForm.optDocument_Description.Enabled = false;
                Program.mainForm.optSections.Enabled = true;
                Program.mainForm.optFile_Save.Enabled = true;

                Program.mainForm.cmdActivate.Text = "Activate";
                Program.mainForm.lblDocTitle.Text = string.Concat(Program.docDescription, " (Deactivated)");

                new form_Load_not().ShowDialog();
                new form_Load().ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid status.", "Invalid status", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void form_StatusUpdate_Load(object sender, EventArgs e)
        {
            if (Program.docStatus == "Activated")
            {
                cboOpt_Status.Items.RemoveAt(0);
            }
            else
            {
                cboOpt_Status.Items.RemoveAt(1);
            }
        }
    }
}
