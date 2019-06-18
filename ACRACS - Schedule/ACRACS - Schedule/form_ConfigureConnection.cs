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
using System.IO;

namespace ACRACS___Schedule
{
    public partial class form_ConfigureConnection : Form
    {
        //
        // fields
        //
        internal bool isControlForm = false;

        public form_ConfigureConnection()
        {
            InitializeComponent();
        }

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
                        if (File.Exists(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config.dbc")))
                        {
                            // Create a new sqlConnection object with the specified instance name.
                            if (File.Exists(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config_instance.dbc")))
                            {
                                Program.dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Schedule.Properties.Settings.Default.ip_address, @"\", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config_instance.dbc")), "1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config.dbc")).Split('\t')[0], ";Password=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config.dbc")).Split('\t')[1]));
                            }
                            // Create a new sqlConnection object with the default sql server name.
                            else
                            {
                                Program.dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Schedule.Properties.Settings.Default.ip_address, @",1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config.dbc")).Split('\t')[0], ";Password=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config.dbc")).Split('\t')[1]));
                            }
                        }
                        // If false, use the default user id and password (userId: sa, password: pass).
                        else
                        {
                            // Create a new sqlConnection object with the specified instance name & with the default user id and password.
                            if (File.Exists(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config_instance.dbc")))
                            {
                                Program.dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Schedule.Properties.Settings.Default.ip_address, @"\", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config_instance.dbc")), "1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=sa;Password=admin"));
                            }
                            // Create a new sqlConnection object with the default sql server name & with the default user id and password.
                            else
                            {
                                Program.dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Schedule.Properties.Settings.Default.ip_address, ",1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=sa;Password=admin"));
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
                catch (Exception ex)
                {
                    MessageBox.Show(string.Concat("The application was not successful in connecting to the system database server using the IP address provided.\n\n",ex.Message,"\n\nPlease recheck your database configuration"), "Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (File.Exists(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config.dbc")))
                {
                    // Create a new sqlConnection object with the specified instance name.
                    if (File.Exists(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config_instance.dbc")))
                    {
                        Program.dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Schedule.Properties.Settings.Default.ip_address, @"\", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config_instance.dbc")), ",1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config.dbc")).Split('\t')[0], ";Password=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config.dbc")).Split('\t')[1]));
                    }
                    // Create a new sqlConnection object with the default sql server name.
                    else
                    {
                        Program.dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Schedule.Properties.Settings.Default.ip_address, @",1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config.dbc")).Split('\t')[0], ";Password=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config.dbc")).Split('\t')[1]));
                    }
                }
                // If false, use the default user id and password (userId: sa, password: pass).
                else
                {
                    // Create a new sqlConnection object with the specified instance name & with the default user id and password.
                    if (File.Exists(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config_instance.dbc")))
                    {
                        Program.dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Schedule.Properties.Settings.Default.ip_address, @"\", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config_instance.dbc")), ",1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=sa;Password=admin"));
                    }
                    // Create a new sqlConnection object with the default sql server name & with the default user id and password.
                    else
                    {
                        Program.dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Schedule.Properties.Settings.Default.ip_address, ",1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=sa;Password=admin"));
                    }
                }

                MessageBox.Show("Ip address is succesfully saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (isControlForm)
                {
                    //
                    // Retrieve departments
                    //
                    Program.departments.Clear();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = Program.dbConnection;
                        cmd.CommandText = "SELECT * FROM tbl_Department";
                        cmd.Connection.Open();
                        Program.dr = cmd.ExecuteReader();

                        while (Program.dr.Read())
                        {
                            Program.departments.Add(new Department(Program.dr[0].ToString(), Program.dr[1].ToString()));
                        }

                        Program.dr.Close();
                        Program.dr.Dispose();
                        cmd.Connection.Close();
                    }

                    this.Hide();
                    Program.splashForm.Show();
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("An error occured while saving the IP address:\n\n",ex.Message,"\n\nPlease recheck your database configuration."),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            TestIP();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveIP();

            try
            {
                //
                // Retrieve departments
                //
                Program.departments.Clear();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "SELECT * FROM tbl_Department";
                    cmd.Connection.Open();
                    Program.dr = cmd.ExecuteReader();

                    while (Program.dr.Read())
                    {
                        Program.departments.Add(new Department(Program.dr[0].ToString(), Program.dr[1].ToString()));
                    }

                    Program.dr.Close();
                    Program.dr.Dispose();
                    cmd.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("An unexpected error has occured:\n\n", ex.Message), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.LogError(ex, new Form());

                Program.dr.Close();
                Program.dbConnection.Close();
            }
        }

        private void form_ConfigureConnection_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ip_address != ".")
            {
                txt_IPAddress.Text = Properties.Settings.Default.ip_address;    
            }
        }
    }
}
