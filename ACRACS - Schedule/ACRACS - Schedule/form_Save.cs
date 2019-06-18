using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace ACRACS___Schedule
{
    public partial class form_Save : Form
    {
        public form_Save()
        {
            InitializeComponent();
        }

        private void form_Save_Shown(object sender, EventArgs e)
        {
            try
            {
                // temp. storage
                List<string> fromtable_SectionClasses = new List<string>();

                using (SqlCommand cmd = new SqlCommand())
                {
                    // Set the cmd properties: connection, sql query
                    cmd.Connection = Program.dbConnection;

                    // 1. Retrieve all records from table 'tbl_SectionClasses'. This is to avoid errors in referencing records in table 'tbl_Class'
                    
                    cmd.CommandText = "SELECT * FROM tbl_SectionClasses";
                    cmd.Connection.Open();

                    Program.dr = cmd.ExecuteReader();

                    while (Program.dr.Read())
                    {
                        fromtable_SectionClasses.Add(string.Concat(Program.dr[0].ToString(),' ',Program.dr[1].ToString()));
                    }
                    Program.dr.Close();

                    // 2. Remove all records from table 'tbl_SectionClasses'
                    cmd.CommandText = "DELETE FROM tbl_SectionClasses";
                    cmd.ExecuteNonQuery();

                    // 3. Remove all records from table 'tbl_Class'
                    cmd.CommandText = "DELETE FROM tbl_Class";
                    cmd.ExecuteNonQuery();

                    // 4. Store all classes old & new to table 'tbl_Class'
                    for (int i = 0; i < Program.schoolschedule.Classes.Count; i++)
                    {
                        cmd.CommandText = "INSERT INTO tbl_Class VALUES(@id, @timeStart, @timeEnd, @course, @type, @instructor, @day, @room)";
                        cmd.Parameters.AddWithValue("@id", Program.schoolschedule.Classes[i].Id);
                        cmd.Parameters.AddWithValue("@timeStart", Program.schoolschedule.Classes[i].Class_TimeStart);
                        cmd.Parameters.AddWithValue("@timeEnd", Program.schoolschedule.Classes[i].Class_TimeEnd);
                        cmd.Parameters.AddWithValue("@course", Program.schoolschedule.Classes[i].Course.Coursecode);
                        cmd.Parameters.AddWithValue("@type", Program.schoolschedule.Classes[i].Class_Type);
                        cmd.Parameters.AddWithValue("@instructor", Program.schoolschedule.Classes[i].Instructor.Identification);
                        cmd.Parameters.AddWithValue("@day", Program.schoolschedule.Classes[i].Day);
                        cmd.Parameters.AddWithValue("@room", Program.schoolschedule.Classes[i].Room.Name);

                        cmd.ExecuteNonQuery();
                        // remove all recently added parameters per loop
                        cmd.Parameters.Clear();
                    }

                    // 5. save all section with classes into table 'tbl_SectionClasses'
                    for (int i = 0; i < Program.schoolschedule.Classes.Count; i++)
                    {
                        for (int y = 0; y < Program.schoolschedule.Classes[i].Sections.Count; y++)
                        {
                            cmd.CommandText = "INSERT INTO tbl_SectionClasses VALUES(@section, @class)";
                            cmd.Parameters.AddWithValue("@section", Program.schoolschedule.Classes[i].Sections[y].SectionName);
                            cmd.Parameters.AddWithValue("@class", Program.schoolschedule.Classes[i].Id);

                            cmd.ExecuteNonQuery();
                            // remove all recently added parameters per loop
                            cmd.Parameters.Clear();
                        }
                    }

                    // close & dispose resources
                    Program.dr.Close();
                    Program.dr.Dispose();
                    cmd.Connection.Close();

                    MessageBox.Show("All datas have been successfully saved to the database", "All datas saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("An error has occured while saving the datas:\n\n", ex.Message, "\n\nPlease contact the developer."), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Program.dbConnection.Close();
                Close();
            }
        }
    }
}
