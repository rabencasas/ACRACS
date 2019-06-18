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
    public partial class frm_Sections : Form
    {
        public frm_Sections()
        {
            InitializeComponent();
        }

        private void frm_Sections_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Program.schoolschedule.Sections.Count; i++)
            {
                ListViewItem li = lstSections.Items.Add(Program.schoolschedule.Sections[i].SectionName);
                li.SubItems.Add(Program.schoolschedule.Sections[i].ProgramCode);
                li.SubItems.Add(Program.schoolschedule.Sections[i].YearLevel.ToString());
                li.SubItems.Add(Program.schoolschedule.Sections[i].Class_Density.ToString());
            }
        }

        private void lstSections_DoubleClick(object sender, EventArgs e)
        {
            if (lstSections.SelectedItems.Count != 0)
            {
                Program.mainForm.cmdSection.Text = Program.schoolschedule.Sections[lstSections.SelectedIndices[0]].SectionName;
                Program.mainForm.lblyear_level.Text = string.Concat("Yr-level: ", Program.schoolschedule.Sections[lstSections.SelectedIndices[0]].YearLevel);
                Program.mainForm.lbltotal_courses.Text = string.Concat("Courses: ", Program.schoolschedule.Sections[lstSections.SelectedIndices[0]].Courses.Count);
                Program.mainForm.lblclass_density.Text = string.Concat("Class density: ", Program.schoolschedule.Sections[lstSections.SelectedIndices[0]].Class_Density);

                Program.index_current_Section = lstSections.SelectedIndices[0];
                Program.mainForm.optViewSectionClassOnly.Checked = false;

                Program.mainForm.pnlTopRight.Visible = true;
                Program.mainForm.ClearListView();

                // hide classroom column in tabDays
                Program.mainForm.viewMonday.Columns[5].Width = 0;
                Program.mainForm.viewTuesday.Columns[5].Width = 0;
                Program.mainForm.viewWednesday.Columns[5].Width = 0;
                Program.mainForm.viewThursday.Columns[5].Width = 0;
                Program.mainForm.viewFriday.Columns[5].Width = 0;
                Program.mainForm.viewSaturday.Columns[5].Width = 0;
                Program.mainForm.viewSunday.Columns[5].Width = 0;

                Program.mainForm.cborooms.SelectedIndex = 0;
                Program.mainForm.OnChangeOfRoom();

                Close();
            }
        }
    }
}
