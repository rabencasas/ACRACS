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

namespace ACRACS___Client
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
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
                lblMessage.Text = "You email address is invalid.";
                txtEmail.SelectAll();
                txtEmail.Focus();
                lblMessage.Visible = true;
            }
        }

        private void cmdRegister_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;

            if (txtFirstName.Text == "" || txtLastName.Text == "" || txtEmail.Text == "" || txtUserName.Text == "" || txtPassWord.Text == "" || txtRetype.Text == "")
            {
                lblMessage.Text = "Please complete all the fields.";
                lblMessage.Visible = true;
            }
            else
            {
                if (txtRetype.Text == txtPassWord.Text)
                {
                    if (MessageBox.Show("Are you sure you want to register?", "Registration confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        lblMessage.Visible = false;

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = Program.dbConnection;
                            cmd.CommandText = "SELECT COUNT(*) FROM tbl_User WHERE firstName = @1 AND lastName = @2 AND userPosition = 'Instructor'";
                            cmd.Parameters.AddWithValue("@1", txtFirstName.Text);
                            cmd.Parameters.AddWithValue("@2", txtLastName.Text);
                            cmd.Connection.Open();

                            if (int.Parse(cmd.ExecuteScalar().ToString()) != 0)
                            {
                                MessageBox.Show(string.Concat("There is already a registered user named ",txtFirstName.Text," ",txtLastName.Text,". Is this your current account?"),"Current user existing",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                                cmd.Connection.Close();
                            }
                            else
                            {
                                cmd.Parameters.Clear();
                                cmd.Connection = Program.dbConnection;
                                cmd.CommandText = "INSERT INTO tbl_User VALUES(@1,@2,@3,@4,@5,@6)";
                                cmd.Parameters.AddWithValue("@1", txtFirstName.Text);
                                cmd.Parameters.AddWithValue("@2", txtLastName.Text);
                                cmd.Parameters.AddWithValue("@3", txtEmail.Text);
                                cmd.Parameters.AddWithValue("@4", "Instructor");
                                cmd.Parameters.AddWithValue("@5", txtUserName.Text);
                                cmd.Parameters.AddWithValue("@6", txtPassWord.Text);

                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("You are successfully registered! You will be redirected to the main page.", "User registered successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // clear control values
                                    txtFirstName.Text = "";
                                    txtLastName.Text = "";
                                    txtEmail.Text = "";
                                    txtUserName.Text = "";
                                    txtPassWord.Text = "";
                                    txtRetype.Text = "";

                                    cmd.Connection.Close();
                                    this.Hide();

                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Cannot register your username. The username may already registered in the database, please change your username.", "Cannot insert duplicate username", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                                    txtUserName.Focus();
                                }
                                finally
                                {
                                    cmd.Connection.Close();
                                }

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

        private void frmRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.splash.tmrUpdate.Start();
        }
    }
}
