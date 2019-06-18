using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using System.Data.SqlClient;
using acschedule;

namespace ACRACS___Manage
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        /**** Database connection coniguration ****/
        internal static SqlConnection dbConnection;
        internal static SqlDataReader dr;

        /**** forms ****/
        internal static frmLogin loginForm;
        internal static frmMain mainForm;
        internal static frmRegister registrationForm;
        internal static form_AddCourse form_AddCoursetoSection;
        internal static form_Instructors instructors_form;

        // Currentuser information
        internal static string currentUser_userName;
        internal static string currentuser_firstName;
        internal static string currentuser_lastName;

        // Schedule documents description
        internal static string docDescription;
        internal static string docSemLevel;
        internal static int docSyFrom;
        internal static int docSyTo;
        internal static string docStatus;

        // Resources storage variables/objects
        internal static List<Department> departments = new List<Department>();
        internal static List<Instructor> instructors = new List<Instructor>();
        internal static List<Room> classRooms = new List<Room>();
        internal static List<acschedule.Program> programs = new List<acschedule.Program>();
        internal static List<Course> courses = new List<Course>();
        internal static List<Section> sections = new List<Section>();

        internal static int selectedSection;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 
            // Instantiate forms
            // 
            mainForm = new frmMain();
            loginForm = new frmLogin();
            registrationForm = new frmRegister();
            form_AddCoursetoSection = new form_AddCourse();
            instructors_form = new form_Instructors();

            // Instantiate other objects
            if (File.Exists(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Manage"), @"\config.dbc")))
            {
                dbConnection = new SqlConnection(string.Concat(@"Data Source=.,1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Manage"), @"\config.dbc")).Split('\t')[0], ";Password=", File.ReadAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Manage"), @"\config.dbc")).Split('\t')[1]));               
            }
            else
            {
                dbConnection = new SqlConnection(@"Data Source=.,1433;Network Library=DBMSSOCN;Initial Catalog=db_ACRACS;User ID=sa;Password=admin");
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //
                    // Retrieve Departments First.
                    // 
                    cmd.Connection = dbConnection;
                    cmd.CommandText = "SELECT * FROM tbl_Department";
                    cmd.Connection.Open();
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        departments.Add(new Department(Program.dr[0].ToString(), Program.dr[1].ToString()));
                    }

                    //
                    // Copy retrieved departments to cboDepartments.
                    //

                    for (int i = 0; i < departments.Count; i++)
                    {
                        mainForm.cboDepartments.Items.Add(string.Concat(Program.departments[i].DepartmentId, " - ", Program.departments[i].DepartmentDescription));
                    }

                    dr.Close();
                    dr.Dispose();

                    cmd.CommandText = "SELECT COUNT(*) FROM tbl_User WHERE userPosition = 'Administrator'";

                    if (int.Parse(cmd.ExecuteScalar().ToString()) >= 1)
                    {
                        cmd.Connection.Close();
                        Application.Run(loginForm);
                    }
                    else
                    {
                        cmd.Connection.Close();
                        Application.Run(registrationForm);
                    }
                }
            }
            catch (Exception ex)
            {
                if (dr != null)
                {
                    Program.dr.Close();
                }
                if (Program.dbConnection.State != System.Data.ConnectionState.Closed)
                {
                    Program.dbConnection.Close();
                }
                MessageBox.Show(string.Concat("An error has occured: \n\n", ex.Message, "\n\nPlease recheck your database configuration."), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool ActivateResource()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = dbConnection;
                cmd.CommandText = "UPDATE setting_Schedule_Description SET Status = 'Activated'";
                cmd.Connection.Open();

                if (cmd.ExecuteNonQuery() == 1)
                {
                    cmd.Connection.Close();
                    docStatus = "Activated";
                    return true;
                }
                else
                {
                    cmd.Connection.Close();
                    return false;
                }
            }
        }
    }
}
