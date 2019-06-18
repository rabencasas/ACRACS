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
    public partial class form_Unload : Form
    {
        public form_Unload()
        {
            InitializeComponent();
        }

        private void form_Unload_Shown(object sender, EventArgs e)
        {
            Program.mainForm.lblDepartment.Text = string.Empty;
            Program.mainForm.lblDocTitle.Text = string.Empty;
            Program.mainForm.cborooms.Items.Clear();
            Program.mainForm.ClearListView_wRoom();
            Program.mainForm.cmdSection.Text = "[ No Class ]";
            Program.mainForm.lblyear_level.Text = ".";
            Program.mainForm.lbltotal_courses.Text = ".";
            Program.mainForm.lblclass_density.Text = ".";

            Program.index_current_Section = 0;
            Program.schoolschedule.Programs.Clear();
            Program.schoolschedule.Rooms.Clear();
            Program.schoolschedule.Instructors.Clear();
            Program.schoolschedule.Sections.Clear();
            Program.schoolschedule.Courses.Clear();
            Program.schoolschedule.Classes.Clear();

            Close();
        }
    }
}
