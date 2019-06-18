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
    public partial class form_Load : Form
    {
        public form_Load()
        {
            InitializeComponent();
        }

        // method: Load resources from the database.
        private void LoadResources()
        {
            try
            {
                // load programs (e.g. BSIT, BSCS) [conditioned based on department]
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT progCode, progDescription FROM tbl_Program WHERE progDepartment = @1";
                    cmd.Parameters.AddWithValue("@1", Program.currentuser_deptId);
                    cmd.Connection = Program.dbConnection;
                    cmd.Connection.Open();

                    Program.dr = cmd.ExecuteReader();

                    while (Program.dr.Read())
                    {
                        Program.schoolschedule.Programs.Add(new acschedule.Program(Program.dr[0].ToString(), Program.dr[1].ToString(), Program.currentuser_deptId));
                    }

                    Program.dr.Close();
                }

                // load rooms
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM tbl_Room ORDER BY rmType";
                    cmd.Connection = Program.dbConnection;

                    Program.dr = cmd.ExecuteReader();

                    while (Program.dr.Read())
                    {
                        Program.schoolschedule.Rooms.Add(new acschedule.Room(Program.dr["rmName"].ToString(), Program.dr["rmType"].ToString()));
                        Program.mainForm.cborooms.Items.Add(string.Concat(Program.dr["rmName"].ToString(), " (", Program.dr["rmType"].ToString(), ")"));
                    }

                    Program.dr.Close();
                    cmd.Connection.Close();
                }

                // load sections
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;
                    cmd.Connection.Open();

                    for (int i = 0; i < Program.schoolschedule.Programs.Count; i++)
                    {
                        // remove recently stored parameters first to avoid bug
                        cmd.Parameters.Clear();

                        cmd.CommandText = "SELECT * FROM tbl_Section WHERE sectProgram = @1";
                        cmd.Parameters.AddWithValue("@1", Program.schoolschedule.Programs[i].ProgramCode);

                        Program.dr = cmd.ExecuteReader();

                        while (Program.dr.Read())
                        {
                            Program.schoolschedule.Sections.Add(new acschedule.Section(Program.dr[0].ToString(), int.Parse(Program.dr[1].ToString()), Program.dr[2].ToString(), int.Parse(Program.dr[3].ToString())));
                        }

                        Program.dr.Close();
                    }

                    Program.dr.Close();
                    Program.dr.Dispose();
                    cmd.Connection.Close();
                }

                // courses per section
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;
                    cmd.Connection.Open();

                    for (int i = 0; i < Program.schoolschedule.Sections.Count; i++)
                    {
                        // clear recently added parameters in the loop
                        cmd.Parameters.Clear();

                        cmd.CommandText = "SELECT * FROM tbl_SectionCourses FULL JOIN tbl_Course ON tbl_SectionCourses.course = tbl_Course.corsCode WHERE section = @1";
                        cmd.Parameters.AddWithValue("@1", Program.schoolschedule.Sections[i].SectionName);

                        Program.dr = cmd.ExecuteReader();

                        while (Program.dr.Read())
                        {
                            Program.schoolschedule.Sections[i].Courses.Add(new Course(Program.dr[1].ToString(), Program.dr[3].ToString(), int.Parse(Program.dr[4].ToString())));
                        }

                        Program.dr.Close();
                    }

                    cmd.Connection.Close();
                }

                // load instructors
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM tbl_Instructor LEFT JOIN tbl_User ON tbl_Instructor.instrUserName = tbl_User.userName LEFT JOIN tbl_Department ON tbl_Instructor.instrDepartment = tbl_Department.deptId";
                    cmd.Connection = Program.dbConnection;
                    cmd.Connection.Open();

                    Program.dr = cmd.ExecuteReader();

                    while (Program.dr.Read())
                    {
                        Program.schoolschedule.Instructors.Add(new Instructor(Program.dr[0].ToString(), Program.dr[3].ToString(), Program.dr[4].ToString(), Program.dr[5].ToString(), Program.dr[8].ToString(), Program.dr[9].ToString(), Program.dr[1].ToString(), Program.dr[7].ToString()));
                    }

                    Program.dr.Close();
                    Program.dr.Dispose();
                    cmd.Connection.Close();
                }

                // load all classes
                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlDataReader dr2;

                    cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "SELECT * FROM tbl_Class";
                    cmd.Connection.Open();

                    Program.dr = cmd.ExecuteReader();

                    while (Program.dr.Read())
                    {
                        Program.schoolschedule.Classes.Add(new School_Class(int.Parse(Program.dr["clsId"].ToString()), new List<Section>(), new Course(), new Instructor(), new Room(), DateTime.Parse(Program.dr["clsTime_Start"].ToString()), DateTime.Parse(Program.dr["clsTime_End"].ToString()), Program.dr["clsDay"].ToString(), Program.dr["clsType"].ToString()));

                        Program.schoolschedule.Classes[Program.schoolschedule.Classes.Count - 1].Course.Coursecode = Program.dr["clsCourse"].ToString();
                        Program.schoolschedule.Classes[Program.schoolschedule.Classes.Count - 1].Instructor.Identification = Program.dr["clsInstructor"].ToString();
                        Program.schoolschedule.Classes[Program.schoolschedule.Classes.Count - 1].Room.Name = Program.dr["clsRoom"].ToString();
                    }
                    Program.dr.Close();

                    // retrieve class 'COURSE' information
                    for (int i = 0; i < Program.schoolschedule.Classes.Count; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "SELECT * FROM tbl_Course WHERE corsCode = @code";
                        cmd.Parameters.AddWithValue("@code", Program.schoolschedule.Classes[i].Course.Coursecode);

                        dr2 = cmd.ExecuteReader();

                        while (dr2.Read())
                        {
                            Program.schoolschedule.Classes[i].Course.Coursecode = dr2["corsCode"].ToString();
                            Program.schoolschedule.Classes[i].Course.CourseDescription = dr2["corsDescription"].ToString();
                            Program.schoolschedule.Classes[i].Course.Units = int.Parse(dr2["corsUnit"].ToString());
                        }
                        dr2.Close();
                    }

                    // retrieve instructor information
                    for (int i = 0; i < Program.schoolschedule.Classes.Count; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "SELECT * FROM tbl_Instructor LEFT JOIN tbl_User ON tbl_Instructor.instrUserName = tbl_User.userName LEFT JOIN tbl_Department ON tbl_Instructor.instrDepartment = tbl_Department.deptId WHERE instrId = @id";
                        cmd.Parameters.AddWithValue("@id", Program.schoolschedule.Classes[i].Instructor.Identification);
                        dr2 = cmd.ExecuteReader();

                        while (dr2.Read())
                        {
                            Program.schoolschedule.Classes[i].Instructor.Identification = dr2["instrId"].ToString();
                            Program.schoolschedule.Classes[i].Instructor.FirstName = dr2["firstName"].ToString();
                            Program.schoolschedule.Classes[i].Instructor.LastName = dr2["lastName"].ToString();
                            Program.schoolschedule.Classes[i].Instructor.Email_Address = dr2["emailAddr"].ToString();
                            Program.schoolschedule.Classes[i].Instructor.UserName = dr2["instrUserName"].ToString();
                            Program.schoolschedule.Classes[i].Instructor.Department_Id = dr2["instrDepartment"].ToString();
                            Program.schoolschedule.Classes[i].Instructor.Department_Description = dr2["deptDescription"].ToString();
                        }
                        dr2.Close();
                    }

                    // retrieve classroom information
                    for (int i = 0; i < Program.schoolschedule.Classes.Count; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "SELECT * FROM tbl_Room WHERE rmName = @name";
                        cmd.Parameters.AddWithValue("@name", Program.schoolschedule.Classes[i].Room.Name);
                        dr2 = cmd.ExecuteReader();

                        while (dr2.Read())
                        {
                            Program.schoolschedule.Classes[i].Room.Name = dr2[0].ToString();
                            Program.schoolschedule.Classes[i].Room.RoomType = dr2[1].ToString();
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

                    for (int i = 0; i < Program.schoolschedule.Classes.Count; i++)
                    {
                        cmd.CommandText = "SELECT * FROM tbl_SectionClasses LEFT JOIN tbl_Section ON tbl_SectionClasses.section = tbl_Section.sectName WHERE class = @classId";
                        cmd.Parameters.AddWithValue("@classId", Program.schoolschedule.Classes[i].Id);

                        Program.dr = cmd.ExecuteReader();

                        while (Program.dr.Read())
                        {
                            Program.schoolschedule.Classes[i].Sections.Add(new Section(Program.dr["sectName"].ToString(), int.Parse(Program.dr["sectYrLevel"].ToString()), Program.dr["sectProgram"].ToString(), int.Parse(Program.dr["sectClassDensity"].ToString())));
                        }

                        Program.dr.Close();
                        cmd.Parameters.Clear();

                    }

                    cmd.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("An error has occured while saving the datas:\n\n", ex.Message, "\n\nPlease contact the developer."), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void form_Load_Shown(object sender, EventArgs e)
        {
            if (Program.doc_Status == "Activated")
            {
                Program.DisplayDescriptionToMainForm();
                LoadResources();

                Program.mainForm.pnlTopRight.Visible = true;
                Program.mainForm.pnlInfo.Visible = true;
                Program.mainForm.mnuReports.Visible = false;
                Program.mainForm.mnuSchedule.Visible = true;
                Program.mainForm.mnuView.Visible = true;

                Program.mainForm.pnlMainContainer.Controls.Clear();

                Program.mainForm.pnlMainContainer.Controls.Add(Program.mainForm.pnlInfo);
                Program.mainForm.pnlInfo.Dock = DockStyle.Bottom;
                Program.mainForm.pnlInfo.Height = 38;
                Program.mainForm.pnlMainContainer.Controls.Add(Program.mainForm.tabDays);
                Program.mainForm.tabDays.Dock = DockStyle.Fill;
                Program.mainForm.tabDays.BringToFront();
                Program.mainForm.cborooms.SelectedIndex = 0;

                if (Program.doc_Status == "Activated")
                {
                    new frm_Sections().ShowDialog();
                    Program.mainForm.cborooms.SelectedIndex = 0;

                    Program.mainForm.InitiateTabDays();
                    Program.DisplayDescriptionToMainForm();
                }

                Close();
            }
            else
            {
                try
                {
                    // prepare the report logo (save as file)
                    if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule")))
                    {
                        Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"));
                        Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule","reports"));
                    }
                    if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule","reports")))
                    {
                        Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule", "reports"));
                    }
                    if (!File.Exists(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\reports\logo.png")))
                    {
                        Properties.Resources.logo.Save(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ACRACS-Schedule"), @"\reports\logo.png"));
                    }

                    Program.DisplayDescriptionToMainForm();

                    Program.mainForm.pnlTopRight.Visible = false;
                    Program.mainForm.pnlInfo.Visible = false;
                    Program.mainForm.mnuReports.Visible = true;
                    Program.mainForm.mnuSchedule.Visible = false;
                    Program.mainForm.mnuView.Visible = false;

                    Program.mainForm.pnlMainContainer.Controls.Clear();

                    Program.mainForm.pnlMainContainer.Controls.Add(Program.mainForm.pdfViewer);
                    Program.mainForm.pdfViewer.Dock = DockStyle.Fill;
                
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw;
                }
            }
        }
    }
}
