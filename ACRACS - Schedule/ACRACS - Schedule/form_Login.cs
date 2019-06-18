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

namespace ACRACS___Schedule
{
    public partial class frmLogin : Form
    {
        //
        // variables
        //
        private bool isRegistered = false;

        //
        // custom methods
        //
        private void LoginUser()
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
                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = Program.dbConnection;
                        cmd.CommandText = "SELECT * FROM tbl_User RIGHT JOIN tbl_Dpd ON tbl_User.userName = tbl_Dpd.dpdUserName WHERE userName = @1 AND passWord = @2";
                        cmd.Parameters.AddWithValue("@1", txtuserName.Text);
                        cmd.Parameters.AddWithValue("@2", txtpassWord.Text);
                        cmd.Connection.Open();

                        Program.dr = cmd.ExecuteReader();

                        while (Program.dr.Read())
                        {
                            Program.currentUser_firstName = Program.dr["firstName"].ToString();
                            Program.currentUser_lastName = Program.dr["lastName"].ToString();

                            for (int i = 0; i < Program.departments.Count; i++)
                            {
                                if (Program.dr["dpdDepartment"].ToString() == Program.departments[i].DepartmentId)
                                {
                                    Program.currentuser_deptId = Program.departments[i].DepartmentId;
                                    Program.currentuser_deptDesc = Program.departments[i].DepartmentDescription;
                                    break;
                                }
                            }

                            isRegistered = true;
                        }

                        if (isRegistered == true)
                        {
                            cmd.Connection.Close();
                            Program.currentUser_userName = txtuserName.Text;

                            Program.UpdateSchedulingStatus(1);

                            txtpassWord.Text = "";
                            Program.dr.Close();
                            Program.dr.Dispose();
                            cmd.Connection.Close();

                            Program.splashForm.tmrUpdate.Stop();
                            Program.splashForm.Hide();
                            new form_Load().ShowDialog();
                            this.Close(); 
                            Program.mainForm.Show();
                        }
                        else
                        {
                            MessageBox.Show(this, "Unable to continue. Either the username was not found on the database or the password was incorrect. Please try again.", "Unable to log-in", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                            txtpassWord.Text = null;
                            txtuserName.SelectAll(); ;
                            txtuserName.Focus();

                            Program.dr.Close();
                            Program.dr.Dispose();
                            cmd.Connection.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Concat("An error has occured:\n\n", ex.Message), "Error occured during user log-in", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Program.LogError(ex, this);

                    Program.dr.Close();
                    Program.dbConnection.Close();
                }
            }
        }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            LoginUser();
        }
    }
}
