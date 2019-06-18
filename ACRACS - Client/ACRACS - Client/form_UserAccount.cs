using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Net.Mail;

namespace ACRACS___Client
{
    public partial class form_UserAccount : Form
    {
        public form_UserAccount()
        {
            InitializeComponent();
        }

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

        private void GetPassword()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = Program.dbConnection;
                cmd.CommandText = "SELECT passWord FROM tbl_User WHERE userName = @uname";
                cmd.Parameters.AddWithValue("@uname", Program.user_userName);
                cmd.Connection.Open();

                txtPassword.Text = cmd.ExecuteScalar().ToString();

                cmd.Connection.Close();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (cmdCancel.Text == "Update")
            {
                txtFirstName.Enabled = true;
                txtLastName.Enabled = true;
                txtEmail.Enabled = true;
                txtPassword.Enabled = true;
                lblConfirm.Visible = true;
                txtConfirm.Visible = true;
                cmdCancel.Text = "Cancel";
                cmdUpdate.Visible = true;
            }
            else
            {
                txtFirstName.Enabled = false;
                txtLastName.Enabled = false;
                txtEmail.Enabled = false;
                txtPassword.Enabled = false;
                lblConfirm.Visible = false;
                txtConfirm.Visible = false;
                cmdCancel.Text = "Update";
                cmdUpdate.Visible = false;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            CheckEmail();
        }

        private void form_UserAccount_Load(object sender, EventArgs e)
        {
            txtFirstName.Text = Program.user_firstName;
            txtLastName.Text = Program.user_lastName;
            txtUsername.Text = Program.user_userName;
            txtEmail.Text = Program.user_emailAdd;
            GetPassword();
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;

            if (txtFirstName.Text == "" || txtLastName.Text == "" || txtEmail.Text == "" || txtPassword.Text == "" || txtConfirm.Text == "")
            {
                lblMessage.Text = "Please complete all the fields.";
                lblMessage.Visible = true;
            }
            else
            {
                if (txtConfirm.Text == txtPassword.Text)
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = Program.dbConnection;
                        cmd.CommandText = "UPDATE tbl_User SET firstName = @fname, lastName = @lname, emailAddr = @email, passWord = @pwd WHERE userName = @uname";
                        cmd.Parameters.AddWithValue("@fname", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@lname", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@pwd", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@uname", txtUsername.Text);

                        cmd.Connection.Open();

                        try
                        {
                            if (cmd.ExecuteNonQuery() != 0)
                            {
                                MessageBox.Show("Your account information is successfully updated", "Account updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cmd.Connection.Close();

                                Program.user_firstName = txtFirstName.Text;
                                Program.user_lastName = txtLastName.Text;
                                Program.user_emailAdd = txtEmail.Text;
                                Program.mainForm.lblUser.Text = string.Concat("Current user: ", Program.user_firstName, " ", Program.user_lastName, "(", Program.user_userName, ")");

                                Close();
                            }
                            else
                            {
                                MessageBox.Show("The update was not succesfull:\n\n", "Account not updated", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cmd.Connection.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(string.Concat("The update was not succesfull:\n\n", ex.Message), "Account not updated", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            cmd.Connection.Close();
                        }
                    }
                }
                else
                {
                    lblMessage.Text = "Retyped password didn't match.";
                    txtConfirm.Text = "";
                    txtConfirm.Focus();
                    lblMessage.Visible = true;
                }
            }
        }

    }
}
