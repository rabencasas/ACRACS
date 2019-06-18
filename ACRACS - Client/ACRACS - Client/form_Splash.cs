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
    public partial class frmSplash : Form
    {
        /**** METHODS ****/
        public frmSplash()
        {
            InitializeComponent();
        }
        public void CheckUpdate()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "SELECT * FROM setting_Schedule_Description WHERE Status = 'Released'";
                    cmd.Connection.Open();

                    Program.dr = cmd.ExecuteReader();

                    if (Program.dr.Read())
                    {
                        //get resource information
                        Program.doc_Title = Program.dr["Description"].ToString();
                        Program.doc_SYFrom = int.Parse(Program.dr["SY_From"].ToString());
                        Program.doc_SYTo = int.Parse(Program.dr["SY_To"].ToString());
                        Program.doc_SemLevel = Program.dr["SemesterLevel"].ToString();
                        Program.isReleased = true;

                        Program.mainForm.lblDocTitle.Text = Program.doc_Title;
                        Program.mainForm.lblDocInfo.Text = string.Concat("SCHOOL YEAR: ", Program.doc_SYFrom, " - ", Program.doc_SYTo, ", ", Program.doc_SemLevel);

                        cmdLogin.Visible = true;
                        lblMessage.Text = "The schedules are now released. Please login.";
                    }
                    else
                    {
                        lblMessage.Text = "The schedules has not been released yet.";
                        cmdLogin.Visible = false;
                    }

                    Program.dr.Close();
                    Program.dr.Dispose();
                    cmd.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /**** EVENTS ****/
        private void button2_Click(object sender, EventArgs e)
        {
            tmrUpdate.Stop();
            Program.registrationForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tmrUpdate.Stop();
            Program.loginForm.ShowDialog();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            if (Program.isReleased)
            {
                cmdLogin.Visible = true;
                lblMessage.Text = "The schedules are now released. Please login.";
                Program.isReleased = true;
            }
            else
            {
                lblMessage.Text = "The schedules has not been released yet.";
                cmdLogin.Visible = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void frmSplash_Shown(object sender, EventArgs e)
        {
            tmrUpdate.Start();
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            CheckUpdate();
        }

        private void cmdCoonfigureDB_Click(object sender, EventArgs e)
        {
            if (Program.configurationForm.isControlForm)
            {
                new form_dbconfiguration().ShowDialog();
            }
            else
            {
                Program.configurationForm.ShowDialog();
            }

        }
    }
}
