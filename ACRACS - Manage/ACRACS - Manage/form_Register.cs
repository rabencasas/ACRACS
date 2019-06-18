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

namespace ACRACS___Manage
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void cmdContinue_Click(object sender, EventArgs e)
        {
            pnlWelcome.Dock = DockStyle.None;
            pnlRegistrationForm.Dock = DockStyle.Fill;
            this.Text = "Registration form";
            pnlRegistrationForm.BringToFront();
            txtFirstName.Focus();
        }

        private void cmdRegister_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;

            if (txtFirstName.Text == "" || txtLastName.Text == "" || txtEmail.Text == "" || txtUserName.Text == "" || txtPassWord.Text == "" || txtRetype.Text == "")
            {
                lblMessage.Text = "Please provide all the necessary datas.";
                lblMessage.Visible = true;
            }
            else
            {
                if (txtRetype.Text == txtPassWord.Text)
                {
                    if (MessageBox.Show("Continue to register?", "Registration confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        lblMessage.Visible = false;

                        // register user
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = Program.dbConnection;
                            cmd.CommandText = "INSERT INTO tbl_User VALUES(@1,@2,@3,@4,@5,@6)";
                            cmd.Parameters.AddWithValue("@1", txtFirstName.Text);
                            cmd.Parameters.AddWithValue("@2", txtLastName.Text);
                            cmd.Parameters.AddWithValue("@3", txtEmail.Text);
                            cmd.Parameters.AddWithValue("@4", "Administrator");
                            cmd.Parameters.AddWithValue("@5", txtUserName.Text);
                            cmd.Parameters.AddWithValue("@6", txtPassWord.Text);

                            try
                            {
                                cmd.Connection.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("You are successfully registered! You will be redirected to the main page.", "User registered successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cmd.Connection.Close();

                                this.Hide();
                                Program.currentUser_userName = txtUserName.Text;
                                Program.currentuser_firstName = txtFirstName.Text;
                                Program.currentuser_lastName = txtLastName.Text;
                                new frmStartGuide().ShowDialog();
                                Program.mainForm.Show();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
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

        private void txtEmail_Leave(object sender, EventArgs e)
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
    }
}
