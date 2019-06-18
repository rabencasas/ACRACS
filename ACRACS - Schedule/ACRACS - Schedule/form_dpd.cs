using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace ACRACS___Schedule
{
    public partial class form_dpd : Form
    {
        public form_dpd()
        {
            InitializeComponent();
        }

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
                            lstdpds.Items[1].Text = string.Concat(Program.dr["firstName"].ToString(), " ", Program.dr["lastName"].ToString());
                            lstdpds.Items[1].SubItems[2].Text = Program.dr["schedulingStatus"].ToString();

                            //  Check whether the scheduling is done. IF yes,
                            //  a green background-color is set for visual guidance.
                            if (Program.dr["schedulingStatus"].ToString() == "Done")
                            {
                                lstdpds.Items[1].BackColor = Color.FromArgb(217, 255, 230);
                            }
                            else if (Program.dr["schedulingStatus"].ToString() == "Active")
                            {
                                lstdpds.Items[1].BackColor = Color.FromArgb(255, 191, 191);
                            }
                            else
                            {
                                lstdpds.Items[1].BackColor = Color.Transparent;
                            }
                        }
                        else if (Program.dr[0].ToString() == "Dpt-2")
                        {
                            lstdpds.Items[2].Text = string.Concat(Program.dr["firstName"].ToString(), " ", Program.dr["lastName"].ToString());
                            lstdpds.Items[2].SubItems[2].Text = Program.dr["schedulingStatus"].ToString();

                            if (Program.dr["schedulingStatus"].ToString() == "Done")
                            {
                                lstdpds.Items[2].BackColor = Color.FromArgb(217, 255, 230);
                            }
                            else if (Program.dr["schedulingStatus"].ToString() == "Active")
                            {
                                lstdpds.Items[2].BackColor = Color.FromArgb(255, 191, 191);
                            }
                            else
                            {
                                lstdpds.Items[2].BackColor = Color.Transparent;
                            }
                        }
                        else if (Program.dr[0].ToString() == "Dpt-3")
                        {
                            lstdpds.Items[3].Text = string.Concat(Program.dr["firstName"].ToString(), " ", Program.dr["lastName"].ToString());
                            lstdpds.Items[3].SubItems[2].Text = Program.dr["schedulingStatus"].ToString();

                            if (Program.dr["schedulingStatus"].ToString() == "Done")
                            {
                                lstdpds.Items[3].BackColor = Color.FromArgb(217, 255, 230);
                            }
                            else if (Program.dr["schedulingStatus"].ToString() == "Active")
                            {
                                lstdpds.Items[3].BackColor = Color.FromArgb(255, 191, 191);
                            }
                            else
                            {
                                lstdpds.Items[3].BackColor = Color.Transparent;
                            }
                        }
                        else
                        {
                            lstdpds.Items[4].Text = string.Concat(Program.dr["firstName"].ToString(), " ", Program.dr["lastName"].ToString());
                            lstdpds.Items[4].SubItems[2].Text = Program.dr["schedulingStatus"].ToString();

                            if (Program.dr["schedulingStatus"].ToString() == "Done")
                            {
                                lstdpds.Items[4].BackColor = Color.FromArgb(217, 255, 230);
                            }
                            else if (Program.dr["schedulingStatus"].ToString() == "Active")
                            {
                                lstdpds.Items[4].BackColor = Color.FromArgb(255, 191, 191);
                            }
                            else
                            {
                                lstdpds.Items[4].BackColor = Color.Transparent;
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


        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tmrRealtime_Tick(object sender, EventArgs e)
        {
            Track();
        }

        private void form_dpd_Shown(object sender, EventArgs e)
        {
            cmdClose.Focus();
            tmrRealtime.Start();
        }

        private void form_dpd_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrRealtime.Stop();
        }

        private void form_dpd_Load(object sender, EventArgs e)
        {
            Track();
        }
    }
}
