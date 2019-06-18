using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using MigraDoc.DocumentObjectModel;
using acschedule;
using System.IO;
using acracs.ReportEngine;

namespace ACRACS___Schedule
{
    public partial class form_ReportSection_option : Form
    {
        //
        // Private fields.
        //
        string partialQuery = string.Empty;
        bool hasweekend = false;
        string msections = string.Empty;

        private List<acschedule.Program> programs;
        private List<acschedule.Section> sections;
        private List<School_Class> classes;
        private List<Course> courses;
        private SectionReport report;
        private ACRACS_Report acracsReport;

        int index_ClassCourse = 0;

        //
        // Custom method(s).

        // Methods for one-section report.
        private void GetClasses()
        {
            try
            {
                // load section classes
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = Program.dbConnection;
                cmd.CommandText = "SELECT * FROM tbl_SectionClasses LEFT JOIN tbl_Class ON tbl_SectionClasses.class = tbl_Class.clsId WHERE section = @sectionName";
                cmd.Parameters.AddWithValue("@sectionName", sections[cboSections.SelectedIndex].SectionName);
                cmd.Connection.Open();

                Program.dr = cmd.ExecuteReader();

                while (Program.dr.Read())
                {
                    classes.Add(new School_Class(int.Parse(Program.dr["clsId"].ToString()), new List<acschedule.Section>(), new Course(), new Instructor(), new Room(), DateTime.Parse(Program.dr["clsTime_Start"].ToString()), DateTime.Parse(Program.dr["clsTime_End"].ToString()), Program.dr["clsDay"].ToString(), Program.dr["clsType"].ToString()));

                    classes[classes.Count - 1].Course.Coursecode = Program.dr["clsCourse"].ToString();
                    classes[classes.Count - 1].Instructor.Identification = Program.dr["clsInstructor"].ToString();
                    classes[classes.Count - 1].Room.Name = Program.dr["clsRoom"].ToString();
                }
                Program.dr.Close();

                // retrieve class 'COURSE' information
                for (int i = 0; i < classes.Count; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT * FROM tbl_Course WHERE corsCode = @code";
                    cmd.Parameters.AddWithValue("@code", classes[i].Course.Coursecode);

                    Program.dr = cmd.ExecuteReader();

                    while (Program.dr.Read())
                    {
                        classes[i].Course.Coursecode = Program.dr["corsCode"].ToString();
                        classes[i].Course.CourseDescription = Program.dr["corsDescription"].ToString();
                        classes[i].Course.Units = int.Parse(Program.dr["corsUnit"].ToString());
                    }
                    Program.dr.Close();
                }

                // retrieve instructor information
                for (int i = 0; i < classes.Count; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT * FROM tbl_Instructor LEFT JOIN tbl_User ON tbl_Instructor.instrUserName = tbl_User.userName LEFT JOIN tbl_Department ON tbl_Instructor.instrDepartment = tbl_Department.deptId WHERE instrId = @id";
                    cmd.Parameters.AddWithValue("@id", classes[i].Instructor.Identification);
                    Program.dr = cmd.ExecuteReader();

                    while (Program.dr.Read())
                    {
                        classes[i].Instructor.Identification = Program.dr["instrId"].ToString();
                        classes[i].Instructor.FirstName = Program.dr["firstName"].ToString();
                        classes[i].Instructor.LastName = Program.dr["lastName"].ToString();
                        classes[i].Instructor.Email_Address = Program.dr["emailAddr"].ToString();
                        classes[i].Instructor.UserName = Program.dr["instrUserName"].ToString();
                        classes[i].Instructor.Department_Id = Program.dr["instrDepartment"].ToString();
                        classes[i].Instructor.Department_Description = Program.dr["deptDescription"].ToString();
                    }
                    Program.dr.Close();
                }

                // retrieve classroom information
                for (int i = 0; i < classes.Count; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT * FROM tbl_Room WHERE rmName = @name";
                    cmd.Parameters.AddWithValue("@name", classes[i].Room.Name);
                    Program.dr = cmd.ExecuteReader();

                    while (Program.dr.Read())
                    {
                        classes[i].Room.Name = Program.dr[0].ToString();
                        classes[i].Room.RoomType = Program.dr[1].ToString();
                    }
                    Program.dr.Close();
                }

                Program.dr.Dispose();
                cmd.Connection.Close();
            }

            // retrieve all sections
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = Program.dbConnection;
                cmd.Connection.Open();

                for (int i = 0; i < classes.Count; i++)
                {
                    cmd.CommandText = "SELECT * FROM tbl_SectionClasses LEFT JOIN tbl_Section ON tbl_SectionClasses.section = tbl_Section.sectName WHERE class = @classId";
                    cmd.Parameters.AddWithValue("@classId", classes[i].Id);

                    Program.dr = cmd.ExecuteReader();

                    while (Program.dr.Read())
                    {
                        classes[i].Sections.Add(new acschedule.Section(Program.dr["sectName"].ToString(), int.Parse(Program.dr["sectYrLevel"].ToString()), Program.dr["sectProgram"].ToString(), int.Parse(Program.dr["sectClassDensity"].ToString())));
                    }

                    Program.dr.Close();
                    cmd.Parameters.Clear();

                }

                cmd.Connection.Close();
            }
            }
            catch (Exception ex)
            {
                Program.dbConnection.Close();
                MessageBox.Show(ex.ToString());
            }
        }
        private void GetCourses()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "SELECT * FROM tbl_SectionCourses LEFT JOIN tbl_Course ON tbl_SectionCourses.course = tbl_Course.corsCode WHERE section = @section";
                    cmd.Parameters.AddWithValue("@section", sections[cboSections.SelectedIndex].SectionName);
                    cmd.Connection.Open();

                    Program.dr = cmd.ExecuteReader();

                    while (Program.dr.Read())
                    {
                        courses.Add(new Course(Program.dr["corsCode"].ToString(), Program.dr["corsDescription"].ToString(), int.Parse(Program.dr["corsUnit"].ToString())));
                    }

                    Program.dr.Close();

                    cmd.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Methods for all-section report.
        private void GetClasses(acschedule.Section SchoolSection)
        {
            try
            {
                classes.Clear();

                // load section classes
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "SELECT * FROM tbl_SectionClasses LEFT JOIN tbl_Class ON tbl_SectionClasses.class = tbl_Class.clsId WHERE section = @sectionName";
                    cmd.Parameters.AddWithValue("@sectionName", SchoolSection.SectionName);
                    cmd.Connection.Open();

                    Program.dr = cmd.ExecuteReader();

                    while (Program.dr.Read())
                    {
                        classes.Add(new School_Class(int.Parse(Program.dr["clsId"].ToString()), new List<acschedule.Section>(), new Course(), new Instructor(), new Room(), DateTime.Parse(Program.dr["clsTime_Start"].ToString()), DateTime.Parse(Program.dr["clsTime_End"].ToString()), Program.dr["clsDay"].ToString(), Program.dr["clsType"].ToString()));

                        classes[classes.Count - 1].Course.Coursecode = Program.dr["clsCourse"].ToString();
                        classes[classes.Count - 1].Instructor.Identification = Program.dr["clsInstructor"].ToString();
                        classes[classes.Count - 1].Room.Name = Program.dr["clsRoom"].ToString();
                    }
                    Program.dr.Close();

                    // retrieve class 'COURSE' information
                    for (int i = 0; i < classes.Count; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "SELECT * FROM tbl_Course WHERE corsCode = @code";
                        cmd.Parameters.AddWithValue("@code", classes[i].Course.Coursecode);

                        Program.dr = cmd.ExecuteReader();

                        while (Program.dr.Read())
                        {
                            classes[i].Course.Coursecode = Program.dr["corsCode"].ToString();
                            classes[i].Course.CourseDescription = Program.dr["corsDescription"].ToString();
                            classes[i].Course.Units = int.Parse(Program.dr["corsUnit"].ToString());
                        }
                        Program.dr.Close();
                    }

                    // retrieve instructor information
                    for (int i = 0; i < classes.Count; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "SELECT * FROM tbl_Instructor LEFT JOIN tbl_User ON tbl_Instructor.instrUserName = tbl_User.userName LEFT JOIN tbl_Department ON tbl_Instructor.instrDepartment = tbl_Department.deptId WHERE instrId = @id";
                        cmd.Parameters.AddWithValue("@id", classes[i].Instructor.Identification);
                        Program.dr = cmd.ExecuteReader();

                        while (Program.dr.Read())
                        {
                            classes[i].Instructor.Identification = Program.dr["instrId"].ToString();
                            classes[i].Instructor.FirstName = Program.dr["firstName"].ToString();
                            classes[i].Instructor.LastName = Program.dr["lastName"].ToString();
                            classes[i].Instructor.Email_Address = Program.dr["emailAddr"].ToString();
                            classes[i].Instructor.UserName = Program.dr["instrUserName"].ToString();
                            classes[i].Instructor.Department_Id = Program.dr["instrDepartment"].ToString();
                            classes[i].Instructor.Department_Description = Program.dr["deptDescription"].ToString();
                        }
                        Program.dr.Close();
                    }

                    // retrieve classroom information
                    for (int i = 0; i < classes.Count; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "SELECT * FROM tbl_Room WHERE rmName = @name";
                        cmd.Parameters.AddWithValue("@name", classes[i].Room.Name);
                        Program.dr = cmd.ExecuteReader();

                        while (Program.dr.Read())
                        {
                            classes[i].Room.Name = Program.dr[0].ToString();
                            classes[i].Room.RoomType = Program.dr[1].ToString();
                        }
                        Program.dr.Close();
                    }

                    Program.dr.Dispose();
                    cmd.Connection.Close();
                }

                // retrieve all sections
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;
                    cmd.Connection.Open();

                    for (int i = 0; i < classes.Count; i++)
                    {
                        cmd.CommandText = "SELECT * FROM tbl_SectionClasses LEFT JOIN tbl_Section ON tbl_SectionClasses.section = tbl_Section.sectName WHERE class = @classId";
                        cmd.Parameters.AddWithValue("@classId", classes[i].Id);

                        Program.dr = cmd.ExecuteReader();

                        while (Program.dr.Read())
                        {
                            classes[i].Sections.Add(new acschedule.Section(Program.dr["sectName"].ToString(), int.Parse(Program.dr["sectYrLevel"].ToString()), Program.dr["sectProgram"].ToString(), int.Parse(Program.dr["sectClassDensity"].ToString())));
                        }

                        Program.dr.Close();
                        cmd.Parameters.Clear();

                    }

                    cmd.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                Program.dbConnection.Close();
                MessageBox.Show(ex.ToString());
            }
        }
        private void GetCourses(acschedule.Section SchoolSection)
        {
            try
            {
                courses.Clear();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "SELECT * FROM tbl_SectionCourses LEFT JOIN tbl_Course ON tbl_SectionCourses.course = tbl_Course.corsCode WHERE section = @section";
                    cmd.Parameters.AddWithValue("@section", SchoolSection.SectionName);
                    cmd.Connection.Open();

                    Program.dr = cmd.ExecuteReader();

                    while (Program.dr.Read())
                    {
                        courses.Add(new Course(Program.dr["corsCode"].ToString(), Program.dr["corsDescription"].ToString(), int.Parse(Program.dr["corsUnit"].ToString())));
                    }

                    Program.dr.Close();

                    cmd.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                Program.dbConnection.Close();
                MessageBox.Show(ex.ToString());
            }
        }

        // Other methods.
        private void GetSections()
        {
            try
            {
                // Get programs under the current dpd/user department.
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "SELECT * FROM tbl_Program WHERE progDepartment = @dept";
                    cmd.Parameters.AddWithValue("@dept", Program.currentuser_deptId);
                    cmd.Connection.Open();

                    Program.dr = cmd.ExecuteReader();

                    while (Program.dr.Read())
                    {
                        programs.Add(new acschedule.Program(Program.dr["progCode"].ToString(), Program.dr["progDescription"].ToString(), Program.currentuser_deptId));
                    }
                    Program.dr.Close();

                    if (programs.Count == 1)
                    {
                        partialQuery = string.Concat("sectProgram = '", programs[0].ProgramCode, "'");
                    }
                    else
                    {
                        for (int i = 0; i < programs.Count; i++)
                        {
                            if (i == 0)
                            {
                                partialQuery = string.Concat("sectProgram = '", programs[0].ProgramCode, "'");
                            }
                            else
                            {
                                partialQuery += string.Concat(" OR sectProgram = '", programs[i].ProgramCode, "'");
                            }
                        }
                    }

                    // Select all sections [conditioned with the programs]
                    cmd.CommandText = string.Concat("SELECT * FROM tbl_Section WHERE ", partialQuery);

                    Program.dr = cmd.ExecuteReader();

                    while (Program.dr.Read())
                    {
                        sections.Add(new acschedule.Section(Program.dr["sectName"].ToString(), int.Parse(Program.dr["sectYrLevel"].ToString()), Program.dr["sectProgram"].ToString(), int.Parse(Program.dr["sectClassDensity"].ToString())));
                    }
                    Program.dr.Close();

                    Program.dr.Dispose();
                    cmd.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                Program.dbConnection.Close();
                MessageBox.Show(ex.ToString());
            }
        }


        private void GetIndexClassCourse(School_Class Class)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (Class.Course.Coursecode == courses[i].Coursecode)
                {
                    index_ClassCourse = i;
                    break;
                }
            }
        }

        public form_ReportSection_option()
        {
            InitializeComponent();
        }

        private void cmdOne_Click(object sender, EventArgs e)
        {
            this.Height = 342;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Height = 202;
            cboSections.SelectedItem = null;
        }

        private void form_ReportSection_option_Load(object sender, EventArgs e)
        {
            programs = new List<acschedule.Program>();
            sections = new List<acschedule.Section>();
            classes = new List<School_Class>();
            courses = new List<Course>();

            GetSections();

            // Show all sections to the combobox control
            for (int i = 0; i < sections.Count; i++)
            {
                cboSections.Items.Add(sections[i].SectionName);
            }
        }

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            if (cboSections.SelectedItem != null)
            {
                Cursor = Cursors.WaitCursor;

                try
                {
                // Get classes and courses of the section.
                GetClasses();
                GetCourses();

                // determine if classes has saturday or sunday
                for (int i = 0; i < classes.Count; i++)
                {
                    if (classes[i].Day == "Saturday" || classes[i].Day == "Sunday")
                    {
                        hasweekend = true;
                        break;
                    }
                }

                // Create a new report.
                report = new SectionReport(sections[cboSections.SelectedIndex].SectionName, sections[cboSections.SelectedIndex].YearLevel, hasweekend);
                report.AddNewPage();
                report.AddLogo(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"),"/reports/logo.png"));
                report.AddHeaderText_SchoolName("Asian College", "Dumaguete");
                report.AddHeaderText_Department(Program.currentuser_deptDesc);
                report.AddHeaderText_Section(sections[cboSections.SelectedIndex].SectionName);
                report.Create_ReportTable();

                for (int i = 0; i < classes.Count; i++)
                {
                    // concatenate all sections
                    for (int x = 0; x < classes[i].Sections.Count; x++)
                    {
                        if (x==0)
                        {
                            msections = classes[i].Sections[0].SectionName;
                        }
                        else
                        {
                            msections += string.Concat(", ", classes[i].Sections[x].SectionName);
                        }
                    }

                    GetIndexClassCourse(classes[i]);
                    report.AddClass(classes[i], classes[i].Course.Coursecode, classes[i].Room.Name, msections, new MigraDoc.DocumentObjectModel.Color(Program.subjectColors[index_ClassCourse].R,Program.subjectColors[index_ClassCourse].G,Program.subjectColors[index_ClassCourse].B));

                    msections = string.Empty;
                }
                    report.Render();
                    report.Save(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule", "reports"),"/", sections[cboSections.SelectedIndex].SectionName, ".pdf"));
                    Program.mainForm.pdfViewer.Document = new Apitron.PDF.Rasterizer.Document(new FileStream(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), "/reports/", sections[cboSections.SelectedIndex].SectionName, ".pdf"), FileMode.Open));

                    hasweekend = false;
                    Cursor = Cursors.Default;
                    Close();
                }
                catch (Exception ex)
                {
                    Program.dbConnection.Close();
                    MessageBox.Show(ex.ToString());
                }

            }
            else
            {
                MessageBox.Show("Please select a section first.", "No section selected", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void cmdAll_Click(object sender, EventArgs e)
        {
            try
            {
                acracsReport = new ACRACS_Report();
                SectionReport _tmpSectionReport;
                
                // For every section, generate a report.
                for (int i = 0; i < sections.Count; i++)
                {
                    // Get classes and courses of the section.
                    GetClasses(sections[i]);
                    GetCourses(sections[i]);

                    // determine if classes has saturday or sunday
                    for (int y = 0; y < classes.Count; y++)
                    {
                        if (classes[y].Day == "Saturday" || classes[y].Day == "Sunday")
                        {
                            hasweekend = true;
                            break;
                        }
                    }


                    _tmpSectionReport = new SectionReport(sections[i].SectionName, sections[i].YearLevel, hasweekend);
                    _tmpSectionReport.AddNewPage();
                    _tmpSectionReport.AddLogo(string.Concat(Environment.CurrentDirectory, "/reports/logo.png"));
                    _tmpSectionReport.AddHeaderText_SchoolName("Asian College", "Dumaguete");
                    _tmpSectionReport.AddHeaderText_Department(Program.currentuser_deptDesc);
                    _tmpSectionReport.AddHeaderText_Section(sections[i].SectionName);
                    _tmpSectionReport.Create_ReportTable();

                    for (int y = 0; y < classes.Count; y++)
                    {
                        // concatenate all sections
                        for (int z = 0; z < classes[y].Sections.Count; z++)
                        {
                            if (z == 0)
                            {
                                msections = classes[y].Sections[0].SectionName;
                            }
                            else
                            {
                                msections += string.Concat(", ", classes[y].Sections[z].SectionName);
                            }
                        }

                        GetIndexClassCourse(classes[y]);
                        _tmpSectionReport.AddClass(classes[y], classes[y].Course.Coursecode, classes[y].Room.Name, msections, new MigraDoc.DocumentObjectModel.Color(Program.subjectColors[index_ClassCourse].R, Program.subjectColors[index_ClassCourse].G, Program.subjectColors[index_ClassCourse].B));

                        msections = string.Empty;
                    }

                    acracsReport.Reports_Sections.Add(_tmpSectionReport);
                }

                // Merge all reports & save as pdf file.
                acracsReport.MergeAllReport_Section();
                acracsReport.SaveAllReport_Section(string.Concat(Environment.CurrentDirectory, "/reports/", Program.currentuser_deptId, ".pdf"));
                Program.mainForm.pdfViewer.Document = new Apitron.PDF.Rasterizer.Document(new FileStream(string.Concat(Environment.CurrentDirectory, "/reports/", Program.currentuser_deptId, ".pdf"), FileMode.Open));

                Close();
            }
            catch (Exception ex)
            {  
                Program.dbConnection.Close();
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
