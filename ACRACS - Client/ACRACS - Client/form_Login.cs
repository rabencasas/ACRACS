using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace ACRACS___Client
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void form_Login_Shown(object sender, EventArgs e)
        {
            txtuserName.Focus();
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            if (txtuserName.Text == "" || txtpassWord.Text == "")
            {
                if (txtuserName.Text == "")
                {
                    MessageBox.Show(this, "Please enter your username.", "No username", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show(this, "Please enter your password.", "No password", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                }
            }
            else
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    bool isRegistered = false;

                    cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "SELECT * FROM tbl_Instructor LEFT JOIN tbl_User ON tbl_Instructor.instrUserName = tbl_User.userName LEFT JOIN tbl_Department ON tbl_Instructor.instrDepartment = tbl_Department.deptId WHERE userName = @1 AND passWord = @2";
                    cmd.Parameters.AddWithValue("@1", txtuserName.Text);
                    cmd.Parameters.AddWithValue("@2", txtpassWord.Text);
                    cmd.Connection.Open();

                    Program.dr = cmd.ExecuteReader();

                    while (Program.dr.Read())
                    {
                        Program.user_id = int.Parse(Program.dr["instrId"].ToString());
                        Program.user_firstName = Program.dr["firstName"].ToString();
                        Program.user_lastName = Program.dr["lastName"].ToString();
                        Program.user_userName = Program.dr["instrUserName"].ToString();
                        Program.user_emailAdd = Program.dr["emailAddr"].ToString();
                        Program.user_department = Program.dr["deptDescription"].ToString();

                        isRegistered = true;
                    }

                    Program.dr.Close();
                    Program.dr.Dispose();
                    cmd.Parameters.Clear();

                    if (isRegistered == true)
                    {
                        //get instructor department and 
                        cmd.Connection.Close();
                        Program.dr.Close();
                        Program.dr.Dispose();

                        if (Program.isReleased)
                        {
                            // display controls
                            Program.mainForm.menuStrip1.Visible = true;
                            Program.mainForm.pnlTopHeader.Visible = true;
                            Program.mainForm.pnlContainer.Visible = true;
                            Program.mainForm.statusStrip1.Visible = true;
                        }

                        //display user information to mainform
                        Program.mainForm.lblUser.Text = string.Concat(Program.user_firstName, " ", Program.user_lastName, " - ", Program.user_department);

                        txtpassWord.Text = "";

                        Program.splash.Hide();
                        Program.splash.tmrUpdate.Stop();
                        new form_Loading().ShowDialog();
                        Close();
                        Program.mainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show(this, "Unable to continue. Either the username was not found on the database or the password was incorrect or the registrar was not yet able to assign you to a department (please contact your registrar prior to this). Please try again.", "Unable to log-in", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        txtpassWord.Text = null;
                        txtuserName.SelectAll(); ;
                        txtuserName.Focus();
                    }

                    Program.dr.Close();
                    Program.dr.Dispose();
                    cmd.Connection.Close();
                }
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.splash.tmrUpdate.Start();
        }
    }
}
