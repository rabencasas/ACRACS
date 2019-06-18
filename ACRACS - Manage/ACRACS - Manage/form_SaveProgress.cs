using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace ACRACS___Manage
{
    public partial class form_SaveProgress : Form
    {
        public form_SaveProgress()
        {
            InitializeComponent();
        }

        private void form_SaveProgress_Shown(object sender, EventArgs e)
        {
            try
            {
                prgSaveProgress.Maximum += Program.courses.Count;
                prgSaveProgress.Maximum += Program.instructors.Count;
                prgSaveProgress.Maximum += Program.classRooms.Count;
                prgSaveProgress.Maximum += Program.programs.Count;
                prgSaveProgress.Maximum += Program.sections.Count;

                if (Program.dbConnection.State == ConnectionState.Open)
                {
                    Program.dbConnection.Close();
                }

                // clear setting_Schedule_Description table from database
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "DELETE FROM setting_Schedule_Description";
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                // save Data description
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "INSERT INTO setting_Schedule_Description VALUES(@1,@2,@3,@4,@5)";
                    cmd.Parameters.AddWithValue("@1", Program.docDescription);
                    cmd.Parameters.AddWithValue("@2", Program.docSyFrom);
                    cmd.Parameters.AddWithValue("@3", Program.docSyTo);
                    cmd.Parameters.AddWithValue("@4", Program.docSemLevel);
                    cmd.Parameters.AddWithValue("@5", Program.docStatus);

                    cmd.ExecuteNonQuery();

                    for (int i = 0; i < 5; i++)
                    {
                        prgSaveProgress.Value += 1;
                    }
                }

                // clear tbl_Room
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "DELETE FROM tbl_Room";
                    cmd.ExecuteNonQuery();
                }

                //  save Classrooms
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = Program.dbConnection;

                    for (int i = 0; i < Program.classRooms.Count; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO tbl_Room VALUES(@1, @2)";
                        cmd.Parameters.AddWithValue("@1", Program.classRooms[i].Name);
                        cmd.Parameters.AddWithValue("@2", Program.classRooms[i].RoomType);

                        cmd.ExecuteNonQuery();

                        prgSaveProgress.Value += 1;
                    }
                }

                // clear Instructor records
                // first: remove from tbl_Instructor
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "DELETE FROM tbl_Instructor";
                    cmd.ExecuteNonQuery();
                }

                // second: remove from tbl_User
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "DELETE FROM tbl_User WHERE userPosition = 'Instructor'";
                    cmd.ExecuteNonQuery();
                }

                // save Instructors
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = Program.dbConnection;

                    for (int i = 0; i < Program.instructors.Count; i++)
                    {
                        // first: save to table tbl_User
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO tbl_User VALUES(@1, @2, @3, @4, @5, @6)";
                        cmd.Parameters.AddWithValue("@1", Program.instructors[i].FirstName);
                        cmd.Parameters.AddWithValue("@2", Program.instructors[i].LastName);
                        cmd.Parameters.AddWithValue("@3", Program.instructors[i].Email_Address);
                        cmd.Parameters.AddWithValue("@4", "Instructor");
                        cmd.Parameters.AddWithValue("@5", Program.instructors[i].UserName);
                        cmd.Parameters.AddWithValue("@6", Program.instructors[i].GetPassword());

                        cmd.ExecuteNonQuery();

                        // second: save to table tbl_Insructor
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO tbl_Instructor VALUES(@1, @2, @3)";
                        cmd.Parameters.AddWithValue("@1", int.Parse(Program.instructors[i].Identification));
                        cmd.Parameters.AddWithValue("@2", Program.instructors[i].UserName);
                        cmd.Parameters.AddWithValue("@3", Program.instructors[i].Department_Id);

                        cmd.ExecuteNonQuery();

                        prgSaveProgress.Value += 1;
                    }
                }

                // clear tbl_SectionCourses table
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "DELETE FROM tbl_SectionCourses";
                    cmd.ExecuteNonQuery();
                }

                // clear tbl_Course
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "DELETE FROM tbl_Course";
                    cmd.ExecuteNonQuery();
                }

                //  save Courses
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;

                    for (int i = 0; i < Program.courses.Count; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO tbl_Course VALUES(@1, @2, @3)";
                        cmd.Parameters.AddWithValue("@1", Program.courses[i].Coursecode);
                        cmd.Parameters.AddWithValue("@2", Program.courses[i].CourseDescription);
                        cmd.Parameters.AddWithValue("@3", Program.courses[i].Units);

                        cmd.ExecuteNonQuery();

                        prgSaveProgress.Value += 1;
                    }
                }

                // clear tbl_Section
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "DELETE FROM tbl_Section";
                    cmd.ExecuteNonQuery();
                }

                // clear tbl_Program
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "DELETE FROM tbl_Program";
                    cmd.ExecuteNonQuery();
                }

                //  save Programs
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;

                    for (int i = 0; i < Program.programs.Count; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO tbl_Program VALUES(@1, @2, @3)";
                        cmd.Parameters.AddWithValue("@1", Program.programs[i].ProgramCode);
                        cmd.Parameters.AddWithValue("@2", Program.programs[i].ProgramDescription);
                        cmd.Parameters.AddWithValue("@3", Program.programs[i].DepartmentId);

                        cmd.ExecuteNonQuery();

                        prgSaveProgress.Value += 1;
                    }
                }

                //  save Sections
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = Program.dbConnection;

                    for (int i = 0; i < Program.sections.Count; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO tbl_Section   VALUES(@1, @2, @3, @4)";
                        cmd.Parameters.AddWithValue("@1", Program.sections[i].SectionName);
                        cmd.Parameters.AddWithValue("@2", Program.sections[i].YearLevel);
                        cmd.Parameters.AddWithValue("@3", Program.sections[i].ProgramCode);
                        cmd.Parameters.AddWithValue("@4", Program.sections[i].Class_Density);

                        cmd.ExecuteNonQuery();

                        prgSaveProgress.Value += 1;
                    }

                }

                // save section courses
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;

                    for (int i = 0; i < Program.sections.Count; i++)
                    {
                        for (int j = 0; j < Program.sections[i].Courses.Count; j++)
                        {
                            cmd.CommandText = "INSERT INTO tbl_SectionCourses VALUES(@1, @2)";
                            cmd.Parameters.AddWithValue("@1", Program.sections[i].SectionName);
                            cmd.Parameters.AddWithValue("@2", Program.sections[i].Courses[j].Coursecode);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                    }
                }

                Program.dbConnection.Close();
                MessageBox.Show("All datas have been successfully saved to the database", "All datas saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("An error has occured while saving the datas:\n\n", ex.Message, "\n\nPlease contact the developer."), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }
    }
}
