
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.Data.SqlClient;
using acschedule;
using System.IO;
using System.Drawing;


namespace ACRACS___Schedule
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        // forms
        internal static Form _CONTROL_form;

        public static frmSplash splashForm;
        public static frmMain mainForm;
        public static frmAddClass AddClassForm;
        public static form_UpdateClass UpdateClassForm;
        public static form_ConfigureConnection configurationForm;

        // datas, connectionstrings, schedule datas
        internal static SqlConnection dbConnection;
        internal static SqlDataReader dr;

        internal static ScheduleResource schoolschedule;
        internal static List<Department> departments;

        // current user information
        internal static string currentUser_userName;
        internal static string currentUser_firstName;
        internal static string currentUser_lastName;
        internal static string currentuser_deptId;
        internal static string currentuser_deptDesc;  

        //
        // data storage variables =================================================
        //

        // essentail variables @ run-time
        internal static int index_current_Section;

        // schedulinResourceDescription
        internal static string doc_Title;
        internal static int doc_SYFrom;
        internal static int doc_SYTo;
        internal static string doc_SemLevel;
        internal static string doc_Status;

        // subjectColorList for storing constant colors for assigning to current section courses
        internal static readonly Color[] subjectColors = new Color[]
        { 
            // light yellow
            Color.FromArgb(251, 255, 174),
            // light green
            Color.FromArgb(192, 255, 174),
            // light green-blue
            Color.FromArgb(174, 249, 255),
            // light blue
            Color.FromArgb(174, 176, 255),
            // light violet
            Color.FromArgb(249, 174, 255),
            // cape
            Color.FromArgb(255, 186, 111),
            // light yellow-green
            Color.FromArgb(204, 254, 112),
            // light green
            Color.FromArgb(111, 255, 157),
            // lighter blue
            Color.FromArgb(111, 201, 255),
            // darker violet
            Color.FromArgb(204, 111, 255),
            // light violet
            Color.FromArgb(255, 111, 193),
            // light gray (for non-section current subjects, default)
            Color.FromArgb(230, 230, 230),
        };

        //
        // end data storage variables =================================================
        //

        [STAThread]
        static void Main()  
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // instantiate storage objects
            schoolschedule = new ScheduleResource();
            departments = new List<Department>(4);

            // instantiate forms
            mainForm = new frmMain();
            splashForm = new frmSplash();
            AddClassForm = new frmAddClass();
            UpdateClassForm = new form_UpdateClass();
            configurationForm = new form_ConfigureConnection();

            // Run program based on decision
            if (Properties.Settings.Default.ip_address != ".")
            {
                _CONTROL_form = splashForm;

                try
                {
                    // Instantiate other objects.

                    // Check whether user has custom sql server authentication details (userid and password).
                    // If true, use the custom user id and password.
                    if (File.Exists(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config.dbc")))
                    {
                        // Create a new sqlConnection object with the specified instance name.
                        if (File.Exists(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"),@"\config_instance.dbc")))
                        {
                            dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Schedule.Properties.Settings.Default.ip_address, @"\", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config_instance.dbc")), ",1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config.dbc")).Split('\t')[0], ";Password=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config.dbc")).Split('\t')[1]));                            
                        }
                        // Create a new sqlConnection object with the default sql server name.
                        else
                        {
                            dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Schedule.Properties.Settings.Default.ip_address, @",1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config.dbc")).Split('\t')[0], ";Password=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config.dbc")).Split('\t')[1]));
                        }
                    }
                    // If false, use the default user id and password (userId: sa, password: pass).
                    else
                    {
                        // Create a new sqlConnection object with the specified instance name & with the default user id and password.
                        if (File.Exists(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config_instance.dbc")))
                        {
                            dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Schedule.Properties.Settings.Default.ip_address, @"\", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\config_instance.dbc")), ",1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=sa;Password=admin"));
                        }
                        // Create a new sqlConnection object with the default sql server name & with the default user id and password.
                        else
                        {
                            dbConnection = new SqlConnection(string.Concat(@"Data Source=", ACRACS___Schedule.Properties.Settings.Default.ip_address,",1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=sa;Password=admin"));
                        }
                    }


                    //
                    // Retrieve departments
                    //
                    departments.Clear();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = dbConnection;
                        cmd.CommandText = "SELECT * FROM tbl_Department";
                        cmd.Connection.Open();
                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            departments.Add(new Department(dr[0].ToString(), dr[1].ToString()));
                        }

                        dr.Close();
                        dr.Dispose();
                        cmd.Connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Concat("An unexpected error has occured:\n\n", ex.Message,"\n\nPlease recheck your database configuration."), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogError(ex, new Form());

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

        internal static void DisplayDescriptionToMainForm()
        {
            // load current user info, position, document information
            Program.mainForm.lblDepartment.Text = Program.currentuser_deptDesc;
            Program.mainForm.lblDocTitle.Text = string.Concat(Program.doc_Title, " (", Program.doc_Status, ")");
            Program.mainForm.lblDocInfo.Text = string.Concat("SCHOOL YEAR: ", Program.doc_SYFrom, " - ", Program.doc_SYTo, ", ", Program.doc_SemLevel);
            Program.mainForm.sttsCurentUser.Text = string.Concat("Current user: ", Program.currentUser_firstName, " ", Program.currentUser_lastName, "(", Program.currentUser_userName, ")");
        }
        internal static void UpdateSchedulingStatus(int Status)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = dbConnection;
                    cmd.CommandText = "DELETE setting_Actives";
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO setting_Actives VALUES(@stat)";
                    cmd.Parameters.AddWithValue("@stat", Status);
                    cmd.ExecuteNonQuery();

                    cmd.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("An unexpected error has occured while updating the log-in status :\n\n",ex.Message),"Error occured",MessageBoxButtons.OK,MessageBoxIcon.Error);
                LogError(ex, new Form());
                dbConnection.Close();
            }
        }

        public static void LogError(Exception Ex, Form xForm)
        {
            File.AppendAllText(string.Concat(Environment.CurrentDirectory, "/log.txt"), string.Concat(Ex.ToString(), "\t", xForm.Name, "\n", DateTime.Now.ToShortTimeString(), "\t", DateTime.Now.ToShortDateString(), "\n\n"));
        }
    }
}
