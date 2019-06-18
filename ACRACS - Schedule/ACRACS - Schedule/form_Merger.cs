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
    public partial class form_Merger : Form
    {
        public form_Merger()
        {
            InitializeComponent();
        }

        private void form_Merger_Load(object sender, EventArgs e)
        {
            // clear items first
            lstSections.Items.Clear();

            try
            {
                ListViewItem li;

                for (int i = 0; i < Program.schoolschedule.Sections.Count; i++)
                {
                    for (int j = 0; j < Program.schoolschedule.Sections[i].Courses.Count; j++)
                    {
                        if (Program.schoolschedule.Sections[i].Courses[j].Coursecode == Program.schoolschedule.Sections[Program.index_current_Section].Courses[Program.AddClassForm.cboCourse.SelectedIndex].Coursecode && Program.schoolschedule.Sections[i].SectionName != Program.schoolschedule.Sections[Program.index_current_Section].SectionName)
                        {
                            li = lstSections.Items.Add(Program.schoolschedule.Sections[i].SectionName);
                            li.SubItems.Add(Program.schoolschedule.Sections[i].Class_Density.ToString());
                            li.SubItems.Add(Program.schoolschedule.Sections[i].ProgramCode);
                            li.SubItems.Add(Program.schoolschedule.Sections[i].YearLevel.ToString());
                            li.SubItems.Add(i.ToString());

                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("An error occured while running the application:\n\n", ex.ToString(), "\n\nPlease contact the developer."), "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstSections_DoubleClick(object sender, EventArgs e)
        {
            if (lstSections.SelectedIndices.Count != 0)
            {
                // clear stored values from indices_SectionsToBeMerged and replace by new selected
                Program.AddClassForm.indices_SectionsToBeMerged.Clear();

                // add to indices_SectionsToBeMerged list variable
                for (int i = 0; i < lstSections.SelectedIndices.Count; i++)
                {
                    Program.AddClassForm.indices_SectionsToBeMerged.Add(int.Parse(lstSections.SelectedItems[i].SubItems[4].Text.ToString()));
                }

                // display merged sections to AddClassForm
                for (int i = 0; i < Program.AddClassForm.indices_SectionsToBeMerged.Count; i++)
                {
                    if (i == 0)
                    {
                        Program.AddClassForm.lblMergedSections.Text = Program.schoolschedule.Sections[Program.AddClassForm.indices_SectionsToBeMerged[0]].SectionName;
                    }
                    else
                    {
                        Program.AddClassForm.lblMergedSections.Text += string.Concat(", ",Program.schoolschedule.Sections[Program.AddClassForm.indices_SectionsToBeMerged[0]].SectionName);
                    }
                }

                Close();
            }
        }

        private void form_Merger_Shown(object sender, EventArgs e)
        {
            if (Program.AddClassForm.indices_SectionsToBeMerged.Count != 0)
            {
                for (int i = 0; i < Program.AddClassForm.indices_SectionsToBeMerged.Count; i++)
                {
                    for (int j = 0; j < lstSections.Items.Count; j++)
                    {
                        if (lstSections.Items[j].Text == Program.schoolschedule.Sections[Program.AddClassForm.indices_SectionsToBeMerged[i]].SectionName)
                        {
                            lstSections.Items[j].Selected = true;
                        }
                    }
                }
            }
        }
    }
}
