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
    public partial class frmLogin : Form
    {
        // fields
        private bool isRegistered = false;

        public frmLogin()
        {
            InitializeComponent();
        }

        //custom method
        private void LoadResources()
        {
            new form_Load().ShowDialog();
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            //
            // validate first the inputted datas
            //
            if(txtuserName.Text == "" || txtpassWord.Text == "")
            {
                if(txtuserName.Text == "")
                {
                    MessageBox.Show(this, "Please enter your username.", "No username", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(this, "Please enter your password.", "No password", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (Program.dbConnection.State == ConnectionState.Open)
                    {
                        Program.dbConnection.Close();
                    }

                    cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "SELECT * FROM tbl_User WHERE userName = @1 AND passWord = @2 AND userPosition = 'Administrator'";
                    cmd.Parameters.AddWithValue("@1", txtuserName.Text);
                    cmd.Parameters.AddWithValue("@2", txtpassWord.Text);
                    cmd.Connection.Open();

                    Program.dr = cmd.ExecuteReader();

                    while (Program.dr.Read())
                    {
                        Program.currentuser_firstName = Program.dr["firstName"].ToString();
                        Program.currentuser_lastName = Program.dr["lastName"].ToString();

                        isRegistered = true;
                    }

                    if (isRegistered == true)
                    {
                        cmd.Connection.Close();
                        Program.currentUser_userName = txtuserName.Text;

                        txtpassWord.Text = "";
                        Program.dr.Close();
                        Program.dr.Dispose();
                        cmd.Connection.Close();

                        //
                        //display user info to mainform statusbar
                        //
                        Program.mainForm.sttsUser.Text = string.Concat(Program.currentuser_firstName, " ", Program.currentuser_lastName, " (", Program.currentUser_userName, ")");

                        this.Hide();

                        // resource initiation based on conditions
                        cmd.Connection = Program.dbConnection;
                        cmd.CommandText = "SELECT COUNT(*) FROM setting_Schedule_Description";
                        cmd.Connection.Open();

                        if (int.Parse(cmd.ExecuteScalar().ToString()) == 1)
                        {
                            cmd.Connection.Close();
                            LoadResources();
                        }
                        else
                        {
                            cmd.Connection.Close();
                            new frmStartGuide().ShowDialog();
                        }

                        Program.mainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show(this, "Unable to log you in. Either the username is not registered or the password was incorrect. Please try again.", "Unable to log-in", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        txtpassWord.Text = null;
                        txtuserName.SelectAll(); ;
                        txtuserName.Focus();

                        Program.dr.Close();
                        Program.dr.Dispose();
                        cmd.Connection.Close();
                    }
                }
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isRegistered)
            {
                Application.ExitThread();
            }
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            txtuserName.Focus();
        }
    }
}
