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
    public partial class form_DPDSchedulingStatus : Form
    {
        //
        // Custom methods.
        //

        private void Track()
        {
            // Track DPD scheduling status thru database table 'setting_DPDSchedulingStatus' every 3s
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "SELECT * FROM setting_DPDSchedulingStatus FULL JOIN tbl_Department ON setting_DPDSchedulingStatus.department = tbl_Department.deptId FULL JOIN tbl_Dpd ON setting_DPDSchedulingStatus.dpd = tbl_Dpd.dpdId LEFT JOIN tbl_User ON tbl_Dpd.dpdUserName = tbl_User.userName";
                    cmd.Connection.Open();
                    Program.dr = cmd.ExecuteReader();

                    // Display updates to listview
                    while (Program.dr.Read())
                    {
                        // Determine the department.
                        if (Program.dr[0].ToString() == "Dpt-1")
                        {
                            // Display the status together with the DPD name
                            lst_DPD_Stat.Items[0].SubItems[1].Text = string.Concat(Program.dr["firstName"].ToString()," ",Program.dr["lastName"].ToString());
                            lst_DPD_Stat.Items[0].SubItems[2].Text = Program.dr["schedulingStatus"].ToString();

                            //  Check whether the scheduling is done. IF yes,
                            //  a green background-color is set for visual guidance.
                            if (Program.dr["schedulingStatus"].ToString() == "Done")
                            {
                                lst_DPD_Stat.Items[0].BackColor = Color.FromArgb(111, 255, 157);
                            }
                            else
                            {
                                lst_DPD_Stat.Items[0].BackColor = Color.Transparent;
                            }
                        }
                        else if (Program.dr[0].ToString() == "Dpt-2")
                        {
                            lst_DPD_Stat.Items[1].SubItems[1].Text = string.Concat(Program.dr["firstName"].ToString(), " ", Program.dr["lastName"].ToString());
                            lst_DPD_Stat.Items[1].SubItems[2].Text = Program.dr["schedulingStatus"].ToString();

                            if (Program.dr["schedulingStatus"].ToString() == "Done")
                            {
                                lst_DPD_Stat.Items[1].BackColor = Color.FromArgb(111, 255, 157);
                            }
                            else
                            {
                                lst_DPD_Stat.Items[1].BackColor = Color.Transparent;
                            }
                        }
                        else if (Program.dr[0].ToString() == "Dpt-3")
                        {
                            lst_DPD_Stat.Items[2].SubItems[1].Text = string.Concat(Program.dr["firstName"].ToString(), " ", Program.dr["lastName"].ToString());
                            lst_DPD_Stat.Items[2].SubItems[2].Text = Program.dr["schedulingStatus"].ToString();

                            if (Program.dr["schedulingStatus"].ToString() == "Done")
                            {
                                lst_DPD_Stat.Items[2].BackColor = Color.FromArgb(111, 255, 157);
                            }
                            else
                            {
                                lst_DPD_Stat.Items[2].BackColor = Color.Transparent;
                            }
                        }
                        else
                        {
                            lst_DPD_Stat.Items[3].SubItems[1].Text = string.Concat(Program.dr["firstName"].ToString(), " ", Program.dr["lastName"].ToString());
                            lst_DPD_Stat.Items[3].SubItems[2].Text = Program.dr["schedulingStatus"].ToString();

                            if (Program.dr["schedulingStatus"].ToString() == "Done")
                            {
                                lst_DPD_Stat.Items[3].BackColor = Color.FromArgb(111, 255, 157);
                            }
                            else
                            {
                                lst_DPD_Stat.Items[3].BackColor = Color.Transparent;
                            }
                        }
                    }

                    Program.dr.Close();
                    Program.dr.Dispose();
                    cmd.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("An internal error occred while running the system:\n\n", ex.ToString(), "\n\nPlease contact the developer."), "Internal error occured", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                Close();
            }
        }

        public form_DPDSchedulingStatus()
        {
            InitializeComponent();
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            new form_StatusUpdate().ShowDialog();
        }

        private void form_DPDSchedulingStatus_Shown(object sender, EventArgs e)
        {
            cmdClose.Focus();
            tmrRealtime.Start();
        }

        private void form_DPDSchedulingStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrRealtime.Stop();
        }

        private void tmrRealtime_Tick(object sender, EventArgs e)
        {
            Track();
        }

        private void form_DPDSchedulingStatus_Load(object sender, EventArgs e)
        {
            Track();
        }
    }
}
