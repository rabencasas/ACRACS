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
    public partial class form_Sections : Form
    {
        public form_Sections()
        {
            InitializeComponent();
        }

        private void form_Sections_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Program.sections.Count; i++)
            {
                lstSections.Items.Add(Program.sections[i].SectionName);
            }
        }

        private void lstSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstCourses.Items.Clear();

            for (int i = 0; i < Program.sections[lstSections.SelectedIndex].Courses.Count; i++)
            {
                ListViewItem li;
                li = lstCourses.Items.Add(Program.sections[lstSections.SelectedIndex].Courses[i].Coursecode);
                li.SubItems.Add(Program.sections[lstSections.SelectedIndex].Courses[i].CourseDescription);
                li.SubItems.Add(Program.sections[lstSections.SelectedIndex].Courses[i].Units.ToString());

            }

            lblTotal.Text = Program.sections[lstSections.SelectedIndex].Courses.Count.ToString();
        }
    }
}
