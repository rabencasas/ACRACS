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

namespace ACRACS___Manage
{
    public partial class form_Load : Form
    {
        public form_Load()
        {
            InitializeComponent();
        }

        private void form_Load_Shown(object sender, EventArgs e)
        {
            try
            {
                // close first the database connection
                Program.dbConnection.Close();

                //
                // Get stored resources information from the database
                //
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "SELECT * FROM setting_Schedule_Description";
                    cmd.Connection.Open();

                    Program.dr = cmd.ExecuteReader();

                    // get stored resource description/information and display to mainform
                    while (Program.dr.Read())
                    {
                        Program.docDescription = Program.dr["Description"].ToString();
                        Program.docSyFrom = int.Parse(Program.dr["SY_From"].ToString());
                        Program.docSyTo = int.Parse(Program.dr["SY_To"].ToString());
                        Program.docSemLevel = Program.dr["SemesterLevel"].ToString();
                        Program.docStatus = Program.dr["Status"].ToString();

                        Program.mainForm.lblDocTitle.Text = Program.docDescription;
                        Program.mainForm.lblDocInfo.Text = string.Concat("SCHOOL YEAR: ", Program.docSyFrom, " - ", Program.docSyTo, ", ", Program.docSemLevel);
                    }

                    Program.dr.Close();
                    cmd.Connection.Close();
                }

                //
                // Check the status and load based on conditions
                //
                if (Program.docStatus == "Not Activated" || Program.docStatus == "Deactivated")
                {
                    ListViewItem li;

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = Program.dbConnection;
                        cmd.CommandText = "SELECT * FROM setting_Schedule_Description";
                        cmd.Connection.Open();

                        Program.dr = cmd.ExecuteReader();

                        // get stored resource description/information and display to mainform
                        while (Program.dr.Read())
                        {
                            Program.docDescription = Program.dr["Description"].ToString();
                            Program.docSyFrom = int.Parse(Program.dr["SY_From"].ToString());
                            Program.docSyTo = int.Parse(Program.dr["SY_To"].ToString());
                            Program.docSemLevel = Program.dr["SemesterLevel"].ToString();
                            Program.docStatus = Program.dr["Status"].ToString();

                            Program.mainForm.lblDocTitle.Text = Program.docDescription;

                            if (Program.docStatus == "Deactivated")
                            {
                                Program.mainForm.lblDocTitle.Text = string.Concat(Program.docDescription," (Deactivated)");
                            }

                            Program.mainForm.lblDocInfo.Text = string.Concat("SCHOOL YEAR: ", Program.docSyFrom, " - ", Program.docSyTo, ", ", Program.docSemLevel);
                        }

                        Program.dr.Close();

                        // retrieve resources
                        // 1. retrieve courses
                        cmd.CommandText = "SELECT * FROM tbl_Course";

                        Program.dr = cmd.ExecuteReader();

                        while (Program.dr.Read())
                        {
                            Program.courses.Add(new Course(Program.dr["corsCode"].ToString(), Program.dr["corsDescription"].ToString(), int.Parse(Program.dr["corsUnit"].ToString())));
                            li = Program.mainForm.lstCourses.Items.Add(Program.dr["corsCode"].ToString());
                            li.SubItems.Add(Program.dr["corsDescription"].ToString());
                            li.SubItems.Add(Program.dr["corsUnit"].ToString());
                        }

                        Program.dr.Close();

                        // 2. retrieve classrooms
                        cmd.CommandText = "SELECT * FROM tbl_Room";
                        Program.dr = cmd.ExecuteReader();

                        while (Program.dr.Read())
                        {
                            Program.classRooms.Add(new Room(Program.dr[0].ToString(), Program.dr[1].ToString()));
                            li = Program.mainForm.lstClassRooms.Items.Add(Program.dr[0].ToString());
                            li.SubItems.Add(Program.dr[1].ToString());
                        }

                        Program.dr.Close();

                        // 3. retrieve programs
                        cmd.CommandText = "SELECT * FROM tbl_Program";

                        Program.dr = cmd.ExecuteReader();

                        while (Program.dr.Read())
                        {
                            Program.programs.Add(new acschedule.Program(Program.dr[0].ToString(), Program.dr[1].ToString(), Program.dr[2].ToString()));

                            if (Program.dr[2].ToString() == "Dpt-1")
                            {
                                Program.mainForm.lstProgDept1.Items.Add(string.Concat(Program.dr[0].ToString(), "  -\t", Program.dr[1].ToString()));
                            }
                            else if (Program.dr[2].ToString() == "Dpt-2")
                            {
                                Program.mainForm.lstProgDept2.Items.Add(string.Concat(Program.dr[0].ToString(), "  -\t", Program.dr[1].ToString()));
                            }
                            else if (Program.dr[2].ToString() == "Dpt-3")
                            {
                                Program.mainForm.lstProgDept3.Items.Add(string.Concat(Program.dr[0].ToString(), "  -\t", Program.dr[1].ToString()));
                            }
                            else
                            {
                                Program.mainForm.lstProgDept4.Items.Add(string.Concat(Program.dr[0].ToString(), "  -\t", Program.dr[1].ToString()));
                            }
                        }

                        Program.dr.Close();

                        // 4. retrieve sections
                        cmd.CommandText = "SELECT * FROM tbl_Section";

                        Program.dr = cmd.ExecuteReader();

                        while (Program.dr.Read())
                        {
                            Program.sections.Add(new Section(Program.dr[0].ToString(), int.Parse(Program.dr[1].ToString()), Program.dr[2].ToString(), int.Parse(Program.dr[3].ToString())));
                        }

                        for (int i = 0; i < Program.sections.Count; i++)
                        {
                            for (int x = 0; x < Program.programs.Count; x++)
                            {
                                if (Program.sections[i].ProgramCode == Program.programs[x].ProgramCode)
                                {
                                    if (Program.programs[x].DepartmentId == "Dpt-1")
                                    {
                                        li = Program.mainForm.lstSect_Dept1.Items.Add(Program.sections[i].SectionName);
                                        li.SubItems.Add(Program.sections[i].YearLevel.ToString());
                                        li.SubItems.Add(Program.sections[i].Class_Density.ToString());
                                        li.SubItems.Add(Program.sections[i].ProgramCode);
                                    }
                                    else if (Program.programs[x].DepartmentId == "Dpt-2")
                                    {
                                        li = Program.mainForm.lstSect_Dept2.Items.Add(Program.sections[i].SectionName);
                                        li.SubItems.Add(Program.sections[i].YearLevel.ToString());
                                        li.SubItems.Add(Program.sections[i].Class_Density.ToString());
                                        li.SubItems.Add(Program.sections[i].ProgramCode);

                                    }
                                    else if (Program.programs[x].DepartmentId == "Dpt-3")
                                    {
                                        li = Program.mainForm.lstSect_Dept3.Items.Add(Program.sections[i].SectionName);
                                        li.SubItems.Add(Program.sections[i].YearLevel.ToString());
                                        li.SubItems.Add(Program.sections[i].Class_Density.ToString());
                                        li.SubItems.Add(Program.sections[i].ProgramCode);

                                    }
                                    else
                                    {
                                        li = Program.mainForm.lstSect_Dept4.Items.Add(Program.sections[i].SectionName);
                                        li.SubItems.Add(Program.sections[i].YearLevel.ToString());
                                        li.SubItems.Add(Program.sections[i].Class_Density.ToString());
                                        li.SubItems.Add(Program.sections[i].ProgramCode);

                                    }
                                }
                            }
                        }
                        Program.dr.Close();

                        // 5. retrieve sections courses from table tbl_SectionCourses
                        cmd.CommandText = "SELECT * FROM tbl_SectionCourses LEFT JOIN tbl_Course ON tbl_SectionCourses.course = tbl_Course.corsCode";

                        Program.dr = cmd.ExecuteReader();

                        while (Program.dr.Read())
                        {
                            for (int i = 0; i < Program.sections.Count; i++)
                            {
                                if (Program.dr["section"].ToString() == Program.sections[i].SectionName)
                                {
                                    Program.sections[i].Courses.Add(new Course(Program.dr["course"].ToString(),Program.dr[3].ToString(),int.Parse(Program.dr[4].ToString())));
                                }
                            }
                        }
                        Program.dr.Close();

                        // load instructors
                        cmd.CommandText = cmd.CommandText = "SELECT * FROM tbl_Instructor LEFT JOIN tbl_User ON tbl_Instructor.instrUserName = tbl_User.userName LEFT JOIN tbl_Department ON tbl_Instructor.instrDepartment = tbl_Department.deptId";

                        Program.dr.Close();

                        Program.dr = cmd.ExecuteReader();

                        while (Program.dr.Read())
                        {
                            Program.instructors.Add(new Instructor(Program.dr[0].ToString(), Program.dr[3].ToString(), Program.dr[4].ToString(), Program.dr[5].ToString(), Program.dr[2].ToString(), Program.dr[10].ToString(), Program.dr[1].ToString(), Program.dr[8].ToString()));
                        }

                        // display instructors to listbox
                        for (int i = 0; i < Program.instructors.Count; i++)
                        {
                            Program.mainForm.lstInstructors.Items.Add(string.Concat(Program.instructors[i].FirstName, " ", Program.instructors[i].LastName));
                        }

                        // get total sections per program;
                        Program.mainForm.lblSectTotal_Dept1.Text = Program.mainForm.lstSect_Dept1.Items.Count.ToString();
                        Program.mainForm.lblSectTotal_Dept2.Text = Program.mainForm.lstSect_Dept2.Items.Count.ToString();
                        Program.mainForm.lblSectTotal_Dept3.Text = Program.mainForm.lstSect_Dept3.Items.Count.ToString();
                        Program.mainForm.lblSectTotal_Dept4.Text = Program.mainForm.lstSect_Dept4.Items.Count.ToString();

                        Program.dr.Close();
                        Program.dr.Dispose();
                        cmd.Connection.Close();

                        Program.mainForm.optView_SchedulingStatus.Enabled = false;
                        Program.mainForm.menuStrip1.Visible = true;
                        Program.mainForm.pnlTopHeader.Visible = true;
                        Program.mainForm.pnlToolBox.Visible = true;
                    }
                }
                else if (Program.docStatus == "Activated")
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        // load instructors
                        cmd.Connection = Program.dbConnection;
                        cmd.CommandText = "SELECT * FROM tbl_Instructor LEFT JOIN tbl_User ON tbl_Instructor.instrUserName = tbl_User.userName LEFT JOIN tbl_Department ON tbl_Instructor.instrDepartment = tbl_Department.deptId";
                        cmd.Connection.Open();
                        Program.dr = cmd.ExecuteReader();

                        while (Program.dr.Read())
                        {
                            Program.instructors.Add(new Instructor(Program.dr[0].ToString(), Program.dr[3].ToString(), Program.dr[4].ToString(), Program.dr[5].ToString(), Program.dr[2].ToString(), Program.dr[10].ToString(), Program.dr[1].ToString(), Program.dr[8].ToString()));
                        }

                        Program.dr.Close();
                        Program.dr.Dispose();
                        cmd.Connection.Close();
                    }

                    Program.dr.Dispose();
                    Program.dbConnection.Close();   

                    Program.mainForm.menuStrip1.Visible = true;
                    Program.mainForm.pnlTopHeader.Visible = true;
                    Program.mainForm.optFile_Save.Enabled = false;
                    Program.mainForm.optDocument_Description.Enabled = false;
                    Program.mainForm.optSections.Enabled = false;
                    Program.mainForm.pnlToolBox.Visible = false;
                    Program.mainForm.cmdSave.Visible = false;
                    Program.mainForm.cmdActivate.Text = "Release";
                    Program.mainForm.optDocument_Description.Enabled = false;
                    Program.mainForm.lblDocTitle.Text = string.Concat(Program.docDescription," (Activated)");
                    new form_DPDSchedulingStatus().ShowDialog();
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        // load instructors
                        cmd.Connection = Program.dbConnection;
                        cmd.CommandText = "SELECT * FROM tbl_Instructor LEFT JOIN tbl_User ON tbl_Instructor.instrUserName = tbl_User.userName LEFT JOIN tbl_Department ON tbl_Instructor.instrDepartment = tbl_Department.deptId";
                        cmd.Connection.Open();
                        Program.dr = cmd.ExecuteReader();

                        while (Program.dr.Read())
                        {
                            Program.instructors.Add(new Instructor(Program.dr[0].ToString(), Program.dr[3].ToString(), Program.dr[4].ToString(), Program.dr[5].ToString(), Program.dr[2].ToString(), Program.dr[10].ToString(), Program.dr[1].ToString(), Program.dr[8].ToString()));
                        }

                        Program.dr.Close();
                        Program.dr.Dispose();
                        cmd.Connection.Close();
                    }

                    Program.dr.Dispose();
                    Program.dbConnection.Close();

                    Program.mainForm.menuStrip1.Visible = true;
                    Program.mainForm.pnlTopHeader.Visible = true;
                    Program.mainForm.mnuReports.Visible = true;
                    Program.mainForm.pnlToolBox.Visible = false;
                    Program.mainForm.cmdActivate.Text = "Deactivate";
                    Program.mainForm.cmdSave.Visible = false;
                    Program.mainForm.optDocument_Description.Enabled = false;
                    Program.mainForm.optView_SchedulingStatus.Enabled = false;
                    Program.mainForm.optFile_Save.Enabled = false;
                    Program.mainForm.optSections.Enabled = false;
                    Program.mainForm.lblDocTitle.Text = string.Concat(Program.docDescription, " (Released)");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("An error has occured while saving the datas:\n\n", ex.Message, "\n\nPlease contact the developer."), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Program.dr.Close();
                Program.dr.Dispose();
                Program.dbConnection.Close();

                this.Close();
            }
        }
    }
}
