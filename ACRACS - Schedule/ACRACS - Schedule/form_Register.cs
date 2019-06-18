using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using acschedule;
using System.Net.Mail;

namespace ACRACS___Schedule
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        //
        // custom methods
        //
        private void CheckEmail()
        {
            try
            {
                lblMessage.Visible = false;
                new MailAddress(txtEmail.Text);
                lblMessage.Text = "...";
            }
            catch (Exception)
            {
                lblMessage.Text = "Inputted data is not a valid email address.";
                txtEmail.SelectAll();
                txtEmail.Focus();
                lblMessage.Visible = true;
            }
        }
        private void Register()
        {
            lblMessage.Visible = false;

            if (txtFirstName.Text == "" || txtLastName.Text == "" || txtEmail.Text == "" || txtUserName.Text == "" || txtPassWord.Text == "" || txtRetype.Text == "" || cboPosition.Text == "")
            {
                lblMessage.Text = "Please complete all the fields.";
                lblMessage.Visible = true;
            }
            else
            {
                if (txtRetype.Text == txtPassWord.Text)
                {
                    if (MessageBox.Show("Continue to register?", "Registration confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            // check the position for duplication avoidance
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.Connection = Program.dbConnection;
                                cmd.CommandText = "SELECT COUNT(*) FROM tbl_Department RIGHT JOIN tbl_Dpd ON tbl_Department.deptId = tbl_Dpd.dpdDepartment WHERE deptId = @1";
                                cmd.Parameters.AddWithValue("@1", Program.departments[cboPosition.SelectedIndex].DepartmentId);
                                cmd.Connection.Open();

                                if (int.Parse(cmd.ExecuteScalar().ToString()) == 0)
                                {
                                    lblMessage.Visible = false;

                                    cmd.Parameters.Clear();
                                    cmd.Connection = Program.dbConnection;
                                    cmd.CommandText = "INSERT INTO tbl_User VALUES(@1,@2,@3,@4,@5,@6)";
                                    cmd.Parameters.AddWithValue("@1", txtFirstName.Text);
                                    cmd.Parameters.AddWithValue("@2", txtLastName.Text);
                                    cmd.Parameters.AddWithValue("@3", txtEmail.Text);
                                    cmd.Parameters.AddWithValue("@4", "DPD");
                                    cmd.Parameters.AddWithValue("@5", txtUserName.Text);
                                    cmd.Parameters.AddWithValue("@6", txtPassWord.Text);

                                    cmd.ExecuteNonQuery();

                                    cmd.Parameters.Clear();

                                    cmd.CommandText = "SELECT MAX(dpdId) FROM tbl_Dpd";
                                    string max_dpdId = cmd.ExecuteScalar().ToString();
                                    int maxInt;

                                    if (max_dpdId == "")
                                    {
                                        maxInt = 10010001;
                                    }
                                    else
                                    {
                                        maxInt = int.Parse(max_dpdId) + 1;
                                    }

                                    cmd.CommandText = "INSERT INTO tbl_Dpd VALUES(@1,@2,@3)";
                                    cmd.Parameters.AddWithValue("@1", maxInt);
                                    cmd.Parameters.AddWithValue("@2", txtUserName.Text);
                                    cmd.Parameters.AddWithValue("@3", Program.departments[cboPosition.SelectedIndex].DepartmentId);
                                    cmd.ExecuteNonQuery();

                                    cmd.Parameters.Clear();
                                    cmd.CommandText = "UPDATE setting_DPDSchedulingStatus SET dpd = @dpdId WHERE department = @deptId";
                                    cmd.Parameters.AddWithValue("@dpdId", maxInt);
                                    cmd.Parameters.AddWithValue("@deptId", Program.departments[cboPosition.SelectedIndex].DepartmentId);
                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("You are successfully registered!", "User registered successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    cmd.Connection.Close();

                                    Close();
                                }
                                else
                                {
                                    lblMessage.Visible = true;
                                    lblMessage.Text = "There is already a DPD registered with the chosen position.\nPlease contact the administrator.";
                                    cmd.Connection.Close();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(string.Concat("An error has occured while validating inputted data:\n\n", ex.Message), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            
                            Program.dbConnection.Close();
                        }
                    }
                }
                else
                {
                    lblMessage.Text = "Retyped password didn't match.";
                    txtRetype.Text = "";
                    txtRetype.Focus();
                    lblMessage.Visible = true;
                }
            }
        }

        private void cmdRegister_Click(object sender, EventArgs e)
        {
            Register();
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            CheckEmail();
        }
    }
}
