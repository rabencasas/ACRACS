using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.IO;

namespace ACRACS___Client
{
    public partial class form_dbconfiguration : Form
    {
        //
        // fields
        //
        internal bool isControlForm = false;
        //
        // custom methods
        //
        private void TestIP()
        {
            if (txt_IPAddress.Text.Length != 0)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        // Check whether user has custom sql server authentication details (userid and password).
                        // If true, use the custom user id and password.
                        if (File.Exists(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config.dbc")))
                        {
                            // Create a new sqlConnection object with the specified instance name.
                            if (File.Exists(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config_instance.dbc")))
                            {
                                Program.dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Client.Properties.Settings.Default.ip_address, @"\", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config_instance.dbc")), ",1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config.dbc")).Split('\t')[0], ";Password=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config.dbc")).Split('\t')[1]));
                            }
                            // Create a new sqlConnection object with the default sql server name.
                            else
                            {
                                Program.dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Client.Properties.Settings.Default.ip_address, @",1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config.dbc")).Split('\t')[0], ";Password=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config.dbc")).Split('\t')[1]));
                            }
                        }
                        // If false, use the default user id and password (userId: sa, password: pass).
                        else
                        {
                            // Create a new sqlConnection object with the specified instance name & with the default user id and password.
                            if (File.Exists(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config_instance.dbc")))
                            {
                                Program.dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Client.Properties.Settings.Default.ip_address, @"\", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config_instance.dbc")), ",1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=sa;Password=admin"));
                            }
                            // Create a new sqlConnection object with the default sql server name & with the default user id and password.
                            else
                            {
                                Program.dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Client.Properties.Settings.Default.ip_address, ",1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=sa;Password=admin"));
                            }
                        }

                        cmd.CommandText = "SELECT * FROM tbl_Department";
                        cmd.Connection = Program.dbConnection;
                        cmd.Connection.Open();
                        Program.dr = cmd.ExecuteReader();

                        if (Program.dr.Read())
                        {
                            MessageBox.Show("The application succesfully established a connection to the system database server", "Connection established", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmdSave.Enabled = true;
                        }
                        else
                        {
                            cmdSave.Enabled = false;
                        }

                        Program.dr.Close();
                        Program.dr.Dispose();
                        cmd.Connection.Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("The application was not successful in connecting to the system database server using the IP address provided.", "Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Please input the IP address first.", "No IP address", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveIP()
        {
            try
            {
                Properties.Settings.Default.ip_address = txt_IPAddress.Text;
                Properties.Settings.Default.Save();

                // Check whether user has custom sql server authentication details (userid and password).
                // If true, use the custom user id and password.
                if (File.Exists(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config.dbc")))
                {
                    // Create a new sqlConnection object with the specified instance name.
                    if (File.Exists(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config_instance.dbc")))
                    {
                        Program.dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Client.Properties.Settings.Default.ip_address, @"\", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config_instance.dbc")), ",1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config.dbc")).Split('\t')[0], ";Password=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config.dbc")).Split('\t')[1]));
                    }
                    // Create a new sqlConnection object with the default sql server name.
                    else
                    {
                        Program.dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Client.Properties.Settings.Default.ip_address, @",1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config.dbc")).Split('\t')[0], ";Password=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config.dbc")).Split('\t')[1]));
                    }
                }
                // If false, use the default user id and password (userId: sa, password: pass).
                else
                {
                    // Create a new sqlConnection object with the specified instance name & with the default user id and password.
                    if (File.Exists(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config_instance.dbc")))
                    {
                        Program.dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Client.Properties.Settings.Default.ip_address, @"\", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config_instance.dbc")), ",1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=sa;Password=admin"));
                    }
                    // Create a new sqlConnection object with the default sql server name & with the default user id and password.
                    else
                    {
                        Program.dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Client.Properties.Settings.Default.ip_address, ",1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=sa;Password=admin"));
                    }
                }

                MessageBox.Show("Ip address is succesfully saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (isControlForm)
                {
                    // retrieve resource information
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = Program.dbConnection;
                        cmd.CommandText = "SELECT * FROM setting_Schedule_Description WHERE Status = 'Released'";
                        cmd.Connection.Open();

                        Program.dr = cmd.ExecuteReader();

                        while (Program.dr.Read())
                        {
                            Program.doc_Title = Program.dr["Description"].ToString();
                            Program.doc_SYFrom = int.Parse(Program.dr["SY_From"].ToString());
                            Program.doc_SYTo = int.Parse(Program.dr["SY_To"].ToString());
                            Program.doc_SemLevel = Program.dr["SemesterLevel"].ToString();

                            Program.mainForm.lblDocTitle.Text = Program.doc_Title;
                            Program.mainForm.lblDocInfo.Text = string.Concat("SCHOOL YEAR: ", Program.doc_SYFrom, " - ", Program.doc_SYTo, ", ", Program.doc_SemLevel);
                            Program.isReleased = true;
                        }

                        Program.dr.Close();
                        Program.dr.Dispose();
                        cmd.Connection.Close();
                    }

                    this.Hide();
                    Program.splash.Show();
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("An error occured while saving the IP address:\n\n", ex.Message, "\n\nPlease recheck your database configuration."), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public form_dbconfiguration()
        {
            InitializeComponent();
        }

        private void form_dbconfiguration_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.icon_database;

            if (Properties.Settings.Default.ip_address != ".")
            {
                txt_IPAddress.Text = Properties.Settings.Default.ip_address;
            }
        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            TestIP();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveIP();
        }
    }
}
