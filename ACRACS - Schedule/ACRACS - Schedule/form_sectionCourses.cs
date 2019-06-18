using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ACRACS___Schedule
{
    public partial class form_sectionCourses : Form
    {
        public form_sectionCourses()
        {
            InitializeComponent();
        }

        private void form_sectionCourses_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Program.schoolschedule.Sections[Program.index_current_Section].Courses.Count; i++)
            {
                lstCourses.Items.Add(Program.schoolschedule.Sections[Program.index_current_Section].Courses[i].Coursecode);
            }
        }
    }
}
