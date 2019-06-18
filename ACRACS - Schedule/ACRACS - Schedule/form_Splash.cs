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
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        //
        // methods
        //
        #region Custom Methods
        public void CheckUpdate()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "SELECT * FROM setting_Schedule_Description";
                    cmd.Connection.Open();

                    Program.dr = cmd.ExecuteReader();

                    if (Program.dr.Read())
                    {
                        //get resource information
                        Program.doc_Title = Program.dr["Description"].ToString();
                        Program.doc_SYFrom = int.Parse(Program.dr["SY_From"].ToString());
                        Program.doc_SYTo = int.Parse(Program.dr["SY_To"].ToString());
                        Program.doc_SemLevel = Program.dr["SemesterLevel"].ToString();
                        Program.doc_Status = Program.dr["Status"].ToString();
                    }

                    if (Program.doc_Status == "Not Activated")
                    {
                        txtNotifier.Text = "The resources are not yet activated.";
                    }
                    else if (Program.doc_Status == "Activated")
                    {
                        txtNotifier.Text = "The resources are now activated. Please login.";
                    }
                    else if (Program.doc_Status == "Deactivated")
                    {
                        cmdLogin.Visible = false;
                        txtNotifier.Text = "The resources has been deactivated.";
                    }
                    else if (Program.doc_Status == "Released")
                    {
                        cmdLogin.Visible = true;
                        txtNotifier.Text = "The schedules are now released. Please login.";
                    }
                    else
                    {
                        txtNotifier.Text = "The resources has not been created yet.";
                    }

                    Program.dr.Close();
                    Program.dr.Dispose();

                    cmd.CommandText = "SELECT * FROM setting_Actives";
                    if (int.Parse(cmd.ExecuteScalar().ToString()) == 1)
                    {
                        if (Program.doc_Status == "Activated" || Program.doc_Status == "Released")
                        {
                            lblMessage.Visible = true;
                            cmdLogin.Visible = false;
                        }
                    }
                    else
                    {
                        lblMessage.Visible = false;
                        cmdLogin.Visible = true;
                    }

                    cmd.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                tmrUpdate.Stop();

                MessageBox.Show(string.Concat("A real-time function error has occured:\n\n",ex.ToString()),"Real-time function error occured",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Program.LogError(ex, this);

                Program.dr.Close();
                Program.dbConnection.Close();
            }
        }

        #endregion


        //
        // Events
        //
        private void cmdLogin_Click(object sender, EventArgs e)
        {
            tmrUpdate.Stop();
            new frmLogin().ShowDialog();
        }

        private void cmdRegister_Click(object sender, EventArgs e)
        {
            tmrUpdate.Stop();
            new frmRegister().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void cmdCoonfigureDB_Click(object sender, EventArgs e)
        {
            if (Program.configurationForm.isControlForm)
            {
                new form_ConfigureConnection().ShowDialog();
            }
            else
            {
                Program.configurationForm.ShowDialog();
            }
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            CheckUpdate();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            CheckUpdate();
            cmdCoonfigureDB.BackgroundImage = Properties.Resources.icon_database.ToBitmap();
        }

        private void frmSplash_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Exit application?","Confirm Exit",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = false;
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void frmSplash_Shown(object sender, EventArgs e)
        {
            tmrUpdate.Start();
        }
    }
}
