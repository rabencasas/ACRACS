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
    public partial class form_StatusUpdate : Form
    {
        public form_StatusUpdate()
        {
            InitializeComponent();
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            if (cboOptions.Text == "Done" || cboOptions.Text == "On-going")
            {
                if (cboOptions.Text == "Done" && MessageBox.Show("Are you sure you are done creating class schedules?", "Status confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = Program.dbConnection;
                            cmd.CommandText = "UPDATE setting_DPDSchedulingStatus SET schedulingStatus = @status WHERE department = @dept";
                            cmd.Parameters.AddWithValue("@status", cboOptions.Text);
                            cmd.Parameters.AddWithValue("@dept", Program.currentuser_deptId);

                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Your status is successfully updated", "Status updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, string.Concat("An error occured while updating the status:\n\n", ex.Message, "\n\nPlease contact the developer"), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Program.dbConnection.Close();
                    }
                }
                else
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = Program.dbConnection;
                            cmd.CommandText = "UPDATE setting_DPDSchedulingStatus SET schedulingStatus = @status WHERE department = @dept";
                            cmd.Parameters.AddWithValue("@status", cboOptions.Text);
                            cmd.Parameters.AddWithValue("@dept", Program.currentuser_deptId);

                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Your status is successfully updated", "Status updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, string.Concat("An error occured while updating the status:\n\n", ex.Message, "\n\nPlease contact the developer"), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Program.dbConnection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Your status is not updated. Please review your option.","Status not updated",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Concat(Program.currentuser_deptId," ",Program.currentuser_deptId.Length.ToString()));
        }
    }
}
