    using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.IO;
using acschedule;

namespace ACRACS___Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        // application objects (forms, connectionstrings, user details)
        internal static SqlConnection dbConnection;
        internal static SqlDataReader dr;
        internal static int user_id;
        internal static string user_firstName;
        internal static string user_lastName;
        internal static string user_userName;
        internal static string user_emailAdd;
        internal static string user_department;

        internal static List<School_Class> _classes;

    
        // forms
        internal static Form _CONTROL_form;

        internal static frmSplash splash;
        internal static frmLogin loginForm;
        internal static frmRegister registrationForm;
        internal static frmMain mainForm;
        internal static form_dbconfiguration configurationForm;

        // resources status
        internal static string doc_Title;
        internal static string doc_SemLevel;
        internal static int doc_SYFrom;
        internal static int doc_SYTo;
        internal static bool isReleased;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            splash = new frmSplash();
            loginForm = new frmLogin();
            registrationForm = new frmRegister();
            mainForm = new frmMain();
            configurationForm = new form_dbconfiguration();
            isReleased = false;

            _classes = new List<School_Class>();

            // Run program based on decision
            if (Properties.Settings.Default.ip_address != ".")
            {
                _CONTROL_form = splash;

                try
                {
                    // Instantiate other objects

                    // Check whether user has custom sql server authentication details (userid and password).
                    // If true, use the custom user id and password.
                    if (File.Exists(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config.dbc")))
                    {
                        // Create a new sqlConnection object with the specified instance name.
                        if (File.Exists(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config_instance.dbc")))
                        {
                            dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Client.Properties.Settings.Default.ip_address, @"\", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config_instance.dbc")), ",1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config.dbc")).Split('\t')[0], ";Password=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config.dbc")).Split('\t')[1]));
                        }
                        // Create a new sqlConnection object with the default sql server name.
                        else
                        {
                            dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Client.Properties.Settings.Default.ip_address, @",1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config.dbc")).Split('\t')[0], ";Password=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config.dbc")).Split('\t')[1]));
                        }
                    }
                    // If false, use the default user id and password (userId: sa, password: pass).
                    else
                    {
                        // Create a new sqlConnection object with the specified instance name & with the default user id and password.
                        if (File.Exists(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config_instance.dbc")))
                        {
                            dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Client.Properties.Settings.Default.ip_address, @"\", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\config_instance.dbc")), ",1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=sa;Password=admin"));
                        }
                        // Create a new sqlConnection object with the default sql server name & with the default user id and password.
                        else
                        {
                            dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Client.Properties.Settings.Default.ip_address, ",1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=sa;Password=admin"));
                        }
                    }


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

                            mainForm.lblDocTitle.Text = Program.doc_Title;
                            mainForm.lblDocInfo.Text = string.Concat("SCHOOL YEAR: ", Program.doc_SYFrom, " - ", Program.doc_SYTo, ", ", Program.doc_SemLevel);
                            isReleased = true;
                        }

                        Program.dr.Close();
                        Program.dr.Dispose();
                        cmd.Connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Concat("An unexpected error has occured:\n\n", ex.Message,"\n\nPlease recheck your database configuration."), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    _CONTROL_form = configurationForm;
                    configurationForm.isControlForm = true;

                    if (dr != null)
                    {
                        if (!dr.IsClosed)
                        {
                            dr.Close();
                        }
                    }
                    
                    dbConnection.Close();
                }
            }
            else
            {
                _CONTROL_form = configurationForm;
                configurationForm.isControlForm = true;
            }

            Application.Run(_CONTROL_form);
        }

        //user-defined methods
        public static void DisplayResourceInformation()
        {
            mainForm.lblDocTitle.Text = doc_Title;
            mainForm.lblDocInfo.Text = string.Concat("SCHOOL YEAR: ", doc_SYFrom, " - ", doc_SYTo, ", ", doc_SemLevel);
        }
    }
}
    