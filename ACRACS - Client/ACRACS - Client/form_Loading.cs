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
using acracs.ReportEngine;
using System.IO;
using MigraDoc.DocumentObjectModel;

namespace ACRACS___Client
{
    public partial class form_Loading : Form
    {

        public form_Loading()
        {
            InitializeComponent();
        }

        //
        // Custom methods.
        //
        private void GetClasses()
        {
            // load instructor classes
            using (SqlCommand cmd = new SqlCommand())
            {
                SqlDataReader dr2;

                cmd.Connection = Program.dbConnection;
                cmd.CommandText = "SELECT * FROM tbl_Class LEFT JOIN tbl_SectionClasses ON tbl_Class.clsId = tbl_SectionClasses.class WHERE clsInstructor = @instructorId";
                cmd.Parameters.AddWithValue("@instructorId", Program.user_id);
                cmd.Connection.Open();

                Program.dr = cmd.ExecuteReader();

                while (Program.dr.Read())
                {
                    Program._classes.Add(new School_Class(int.Parse(Program.dr["clsId"].ToString()), new List<acschedule.Section>(), new Course(), new Instructor(), new Room(), DateTime.Parse(Program.dr["clsTime_Start"].ToString()), DateTime.Parse(Program.dr["clsTime_End"].ToString()), Program.dr["clsDay"].ToString(), Program.dr["clsType"].ToString()));

                    Program._classes[Program._classes.Count - 1].Course.Coursecode = Program.dr["clsCourse"].ToString();
                    Program._classes[Program._classes.Count - 1].Instructor.Identification = Program.dr["clsInstructor"].ToString();
                    Program._classes[Program._classes.Count - 1].Room.Name = Program.dr["clsRoom"].ToString();
                }
                Program.dr.Close();

                // retrieve class 'COURSE' information
                for (int i = 0; i < Program._classes.Count; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT * FROM tbl_Course WHERE corsCode = @code";
                    cmd.Parameters.AddWithValue("@code", Program._classes[i].Course.Coursecode);

                    dr2 = cmd.ExecuteReader();

                    while (dr2.Read())
                    {
                        Program._classes[i].Course.Coursecode = dr2["corsCode"].ToString();
                        Program._classes[i].Course.CourseDescription = dr2["corsDescription"].ToString();
                        Program._classes[i].Course.Units = int.Parse(dr2["corsUnit"].ToString());
                    }
                    dr2.Close();
                }

                // retrieve instructor information
                for (int i = 0; i < Program._classes.Count; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT * FROM tbl_Instructor LEFT JOIN tbl_User ON tbl_Instructor.instrUserName = tbl_User.userName LEFT JOIN tbl_Department ON tbl_Instructor.instrDepartment = tbl_Department.deptId WHERE instrId = @id";
                    cmd.Parameters.AddWithValue("@id", Program._classes[i].Instructor.Identification);
                    dr2 = cmd.ExecuteReader();

                    while (dr2.Read())
                    {
                        Program._classes[i].Instructor.Identification = dr2["instrId"].ToString();
                        Program._classes[i].Instructor.FirstName = dr2["firstName"].ToString();
                        Program._classes[i].Instructor.LastName = dr2["lastName"].ToString();
                        Program._classes[i].Instructor.Email_Address = dr2["emailAddr"].ToString();
                        Program._classes[i].Instructor.UserName = dr2["instrUserName"].ToString();
                        Program._classes[i].Instructor.Department_Id = dr2["instrDepartment"].ToString();
                        Program._classes[i].Instructor.Department_Description = dr2["deptDescription"].ToString();
                    }
                    dr2.Close();
                }

                // retrieve classroom information
                for (int i = 0; i < Program._classes.Count; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT * FROM tbl_Room WHERE rmName = @name";
                    cmd.Parameters.AddWithValue("@name", Program._classes[i].Room.Name);
                    dr2 = cmd.ExecuteReader();

                    while (dr2.Read())
                    {
                        Program._classes[i].Room.Name = dr2[0].ToString();
                        Program._classes[i].Room.RoomType = dr2[1].ToString();
                    }
                    dr2.Close();
                }

                Program.dr.Dispose();
                cmd.Connection.Close();
            }

            // retrieve all sections
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = Program.dbConnection;
                cmd.Connection.Open();

                for (int i = 0; i < Program._classes.Count; i++)
                {
                    cmd.CommandText = "SELECT * FROM tbl_SectionClasses LEFT JOIN tbl_Section ON tbl_SectionClasses.section = tbl_Section.sectName WHERE class = @classId";
                    cmd.Parameters.AddWithValue("@classId", Program._classes[i].Id);

                    Program.dr = cmd.ExecuteReader();

                    while (Program.dr.Read())
                    {
                        Program._classes[i].Sections.Add(new acschedule.Section(Program.dr["sectName"].ToString(), int.Parse(Program.dr["sectYrLevel"].ToString()), Program.dr["sectProgram"].ToString(), int.Parse(Program.dr["sectClassDensity"].ToString())));
                    }

                    Program.dr.Close();
                    cmd.Parameters.Clear();

                }

                cmd.Connection.Close();
            }
        }

        private void form_Loading_Load(object sender, EventArgs e)
        {
            
        }

        private void form_Loading_Shown(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;

            // Get classes first.
            GetClasses();

            bool hasWeekEnd = false;

            for (int i = 0; i < Program._classes.Count; i++)
            {
                if (Program._classes[i].Day == "Saturday" || Program._classes[i].Day == "Sunday")
                {
                    hasWeekEnd = true;
                    break;
                }
            }

            // prepare the report logo (save as file)
            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client")))
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"));
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client", "reports"));
            }
            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client", "reports")))
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client", "reports"));
            }
            if (!File.Exists(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\reports\logo.png")))
            {
                Properties.Resources.image_reportLogo.Save(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\reports\logo.png"));
            }

            // initialize report
            Program.mainForm.instructorReport = new InstructorReport(Program.user_firstName, Program.user_lastName, hasWeekEnd);
            Program.mainForm.instructorReport.AddNewPage();
            Program.mainForm.instructorReport.AddLogo(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), @"\reports\logo.png"));
            Program.mainForm.instructorReport.AddHeaderText_SchoolName("Asian College", "Dumaguete");
            Program.mainForm.instructorReport.AddHeaderText_Department(Program.user_department);
            Program.mainForm.instructorReport.AddHeaderText_Instructor();
            Program.mainForm.instructorReport.Create_ReportTable();

            // start displaying class in report table
            string sections = string.Empty;
            for (int i = 0; i < Program._classes.Count; i++)
            {
                for (int x = 0; x < Program._classes[i].Sections.Count; x++)
                {
                    if (x == 0)
                    {
                        sections = Program._classes[i].Sections[x].SectionName;
                    }
                    else
                    {
                        sections += string.Concat(", ", Program._classes[i].Sections[x].SectionName);
                    }
                }

                Program.mainForm.instructorReport.AddClass(Program._classes[i], Program._classes[i].Course.Coursecode, Program._classes[i].Room.Name, sections, Colors.LightBlue);

                sections = string.Empty;
            }

            // save report as pdf file.
            Program.mainForm.instructorReport.Render();
            Program.mainForm.instructorReport.Save(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), "/reports/", Program.user_userName, ".pdf"));
            Program.mainForm.pdfViewer1.Document = new Apitron.PDF.Rasterizer.Document(new FileStream(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Client"), "/reports/", Program.user_userName, ".pdf"), FileMode.Open));

            Cursor = Cursors.Default;
            Close();
        }
    }
}
