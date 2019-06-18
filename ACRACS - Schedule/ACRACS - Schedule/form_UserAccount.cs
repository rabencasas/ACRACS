using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net.Mail;
using System.Data.SqlClient;

namespace ACRACS___Schedule
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

        private void form_UserAccount_Load(object sender, EventArgs e)
        {
            txtFirstName.Text = Program.currentUser_firstName;
            txtLastName.Text = Program.currentUser_lastName;
            txtUsername.Text = Program.currentUser_userName;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = Program.dbConnection;
                cmd.CommandText = "SELECT emailAddr,passWord FROM tbl_User WHERE userName = @uname";
                cmd.Parameters.AddWithValue("@uname", Program.currentUser_userName);
                cmd.Connection.Open();

                Program.dr = cmd.ExecuteReader();

                while (Program.dr.Read())
                {
                    txtEmail.Text = Program.dr["emailAddr"].ToString();
                    txtPassword.Text = Program.dr["passWord"].ToString();
                }

                Program.dr.Close();
                cmd.Parameters.Clear();
                cmd.Connection.Close();
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            CheckEmail();
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

                                Program.currentUser_firstName = txtFirstName.Text;
                                Program.currentUser_lastName = txtLastName.Text;
                                Program.mainForm.sttsCurentUser.Text = string.Concat("Current user: ", Program.currentUser_firstName, " ", Program.currentUser_lastName, "(", Program.currentUser_userName, ")");

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
                            MessageBox.Show(string.Concat("The update was not succesfull:\n\n", ex.Message),"Account not updated",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
