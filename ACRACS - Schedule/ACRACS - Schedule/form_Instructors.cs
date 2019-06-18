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
    public partial class form_Instructors : Form
    {
        public form_Instructors()
        {
            InitializeComponent();
        }

        private void form_Instructors_Load(object sender, EventArgs e)
        {
            ListViewItem li;
            lstInstructors.Items.Add(" ");

            if (Program.doc_Status == "Released")
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = Program.dbConnection;
                    cmd.CommandText = "SELECT * FROM tbl_Instructor LEFT JOIN tbl_User ON tbl_Instructor.instrUserName = tbl_User.userName LEFT JOIN tbl_Department ON tbl_Instructor.instrDepartment = tbl_Department.deptId";
                    cmd.Connection.Open();

                    Program.dr = cmd.ExecuteReader();

                    while (Program.dr.Read())
                    {
                        li = lstInstructors.Items.Add(Program.dr["instrUserName"].ToString());
                        li.SubItems.Add(Program.dr["firstName"].ToString());
                        li.SubItems.Add(Program.dr["lastName"].ToString());
                        li.SubItems.Add(Program.dr["emailAddr"].ToString());
                        li.SubItems.Add(Program.dr["deptDescription"].ToString());
                    }

                    Program.dr.Close();
                    Program.dr.Dispose();
                    cmd.Connection.Close();
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                try
                {
                    for (int i = 0; i < Program.schoolschedule.Instructors.Count; i++)
                    {
                        li = lstInstructors.Items.Add(Program.schoolschedule.Instructors[i].UserName);
                        li.SubItems.Add(Program.schoolschedule.Instructors[i].FirstName);
                        li.SubItems.Add(Program.schoolschedule.Instructors[i].LastName);
                        li.SubItems.Add(Program.schoolschedule.Instructors[i].Email_Address);
                        li.SubItems.Add(Program.schoolschedule.Instructors[i].Department_Description);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
