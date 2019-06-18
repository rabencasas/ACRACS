using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ACRACS___Manage
{
    public partial class form_AddCourse : Form
    {
        public form_AddCourse()
        {
            InitializeComponent();
        }

        private void form_AddCourse_Load(object sender, EventArgs e)
        {
            // set header title
            lblSection.Text = Program.sections[Program.selectedSection].SectionName;

            lstCourses.Items.Clear();
            lstAddedCourses.Items.Clear();

            // add recently added courses from section
            for (int i = 0; i < Program.sections[Program.selectedSection].Courses.Count; i++)
            {
                lstAddedCourses.Items.Add(Program.sections[Program.selectedSection].Courses[i].Coursecode);
            }

            // add all courses except those already added in the selected section
            bool isAdded = false;
            for (int i = 0; i < Program.courses.Count; i++)
            {
                for (int y = 0; y < lstAddedCourses.Items.Count; y++)
                {
                    if (lstAddedCourses.Items[y].ToString() == Program.courses[i].Coursecode)
                    {
                        isAdded = true;
                        break;
                    }
                    else
                    {
                        isAdded = false;
                        continue;
                    }
                }

                if (!isAdded)
                {
                    lstCourses.Items.Add(Program.courses[i].Coursecode);
                }
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstCourses.SelectedItems.Count; i++)
            {
                lstAddedCourses.Items.Add(lstCourses.SelectedItems[i].ToString());
                lstCourses.Items.Remove(lstCourses.SelectedItems[i]);
            }
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstAddedCourses.SelectedItems.Count; i++)
            {
                lstCourses.Items.Add(lstAddedCourses.SelectedItems[i].ToString());
                lstAddedCourses.Items.Remove(lstAddedCourses.SelectedItems[i]);
            }
        }

        private void cmddone_Click(object sender, EventArgs e)
        {
            if (lstAddedCourses.Items.Count == 0)
            {
                MessageBox.Show("No courses added.","No courses added",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                // remove all recently added courses from the section
                Program.sections[Program.selectedSection].Courses.Clear();

                // add courses to current section
                for (int i = 0; i < lstAddedCourses.Items.Count; i++)
                {
                    Program.sections[Program.selectedSection].Courses.Add(new acschedule.Course(lstAddedCourses.Items[i].ToString(),"",0));
                }

                for (int i = 0; i < Program.sections[Program.selectedSection].Courses.Count; i++)
                {
                    for (int x = 0; x < Program.courses.Count; x++)
                    {
                        if (Program.sections[Program.selectedSection].Courses[i].Coursecode == Program.courses[x].Coursecode)
                        {
                            Program.sections[Program.selectedSection].Courses[i].CourseDescription = Program.courses[x].CourseDescription;
                            Program.sections[Program.selectedSection].Courses[i].Units = Program.courses[x].Units;
                            break;
                        }
                    }
                }

                this.Close();
            }
        }
    }
}
