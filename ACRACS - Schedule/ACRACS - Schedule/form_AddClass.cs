using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using acschedule;

namespace ACRACS___Schedule
{
    public partial class frmAddClass : Form
    {
        //
        // fields
        //
        internal int index_ConflictedClass;
        internal List<int> indices_SectionsToBeMerged;

        public frmAddClass()
        {
            InitializeComponent();
            indices_SectionsToBeMerged = new List<int>();
        }

        private void DisplayTime()
        {
            DateTime timeloader = DateTime.Parse("6:00 AM");
            int ctr = 0;
            ListViewItem itmtime = new ListViewItem(timeloader.ToShortTimeString());

            do
            {
                cboFromTime.Items.Add(timeloader.AddMinutes(ctr).ToShortTimeString());
                cboToTime.Items.Add(timeloader.AddMinutes(ctr).ToShortTimeString());


                ctr += 30;

            } while (timeloader.AddMinutes(ctr).Hour < DateTime.Parse("11:00 PM").Hour);

            cboFromTime.Items.Add("11:00 PM");
            cboToTime.Items.Add("11:00 PM");

            itmtime = null;
        }


        private void frmAddClass_Load(object sender, EventArgs e)
        {
            try
            {
            // clear all fields first
            cboCourse.SelectedItem = null;
            cboCourse.Text = string.Empty;
            cboFromTime.SelectedItem = null;
            cboFromTime.Text = string.Empty;
            cboToTime.SelectedItem = null;
            cboToTime.Text = string.Empty;
            rdoLaboratory.Checked = false;
            rdoLecture.Checked = false;
            cboInstructor.SelectedItem = null;
            cboInstructor.Text = string.Empty;
            cboDay.SelectedItem = null;
            cboDay.Text = string.Empty;
            cboRoom.SelectedItem = null;
            cboRoom.Text = string.Empty;
            lblMergedSections.Text = string.Empty;

            // remove all items list from controls
            cboCourse.Items.Clear();
            cboFromTime.Items.Clear();
            cboToTime.Items.Clear();
            cboInstructor.Items.Clear();
            //cboDay1.Items.Clear();
            cboRoom.Items.Clear();
            
            lblSection.Text = Program.schoolschedule.Sections[Program.index_current_Section].SectionName;

            // display courses in a section
            for (int i = 0; i < Program.schoolschedule.Sections[Program.index_current_Section].Courses.Count; i++)
            {
                cboCourse.Items.Add(string.Concat(Program.schoolschedule.Sections[Program.index_current_Section].Courses[i].Coursecode, " (", Program.schoolschedule.Sections[Program.index_current_Section].Courses[i].Units, ")"));
            }

            // display time
            DisplayTime();

            // get current dayView & selected start-time
            if (Program.mainForm.tabDays.SelectedTab.Text == "Monday")
            {
                cboDay.SelectedIndex = 0;
                cboFromTime.SelectedIndex = Program.mainForm.viewMonday.SelectedIndices[0];
            }
            if (Program.mainForm.tabDays.SelectedTab.Text == "Tuesday")
            {
                cboDay.SelectedIndex = 1;
                cboFromTime.SelectedIndex = Program.mainForm.viewTuesday.SelectedIndices[0];
            }
            if (Program.mainForm.tabDays.SelectedTab.Text == "Wednesday")
            {
                cboDay.SelectedIndex = 2;
                cboFromTime.SelectedIndex = Program.mainForm.viewWednesday.SelectedIndices[0];
            }
            if (Program.mainForm.tabDays.SelectedTab.Text == "Thursday")
            {
                cboDay.SelectedIndex = 3;
                cboFromTime.SelectedIndex = Program.mainForm.viewThursday.SelectedIndices[0];
            }
            if (Program.mainForm.tabDays.SelectedTab.Text == "Friday")
            {
                cboDay.SelectedIndex = 4;
                cboFromTime.SelectedIndex = Program.mainForm.viewFriday.SelectedIndices[0];
            }
            if (Program.mainForm.tabDays.SelectedTab.Text == "Saturday")
            {
                cboDay.SelectedIndex = 5;
                cboFromTime.SelectedIndex = Program.mainForm.viewSaturday.SelectedIndices[0];
            }
            if (Program.mainForm.tabDays.SelectedTab.Text == "Sunday")
            {
                cboDay.SelectedIndex = 6;
                cboFromTime.SelectedIndex = Program.mainForm.viewSunday.SelectedIndices[0];
            }

            // display instructors
            for (int i = 0; i < Program.schoolschedule.Instructors.Count; i++)
            {
                cboInstructor.Items.Add(string.Concat(Program.schoolschedule.Instructors[i].FirstName," ",Program.schoolschedule.Instructors[i].LastName));
            }

            // display classrooms
            for (int i = 0; i < Program.schoolschedule.Rooms.Count; i++)
            {
                cboRoom.Items.Add(string.Concat(Program.schoolschedule.Rooms[i].Name, " (", Program.schoolschedule.Rooms[i].RoomType, ")"));
            }

            // select classroom based on recent selected
            if (Program.mainForm.cborooms.Text != "" || Program.mainForm.cborooms.Text != string.Empty)
            {
                cboRoom.Text = cboRoom.Items[Program.mainForm.cborooms.SelectedIndex].ToString();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmdMerge1_Click(object sender, EventArgs e)
        {
            if (cboCourse.Text != "" || cboCourse.Text != string.Empty || cboCourse.SelectedItem != null)
            {
                new form_Merger().ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select first a course.", "No course selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboCourse.Focus();
            }
        }

        private void frmAddClass_FormClosed(object sender, FormClosedEventArgs e)
        {
            indices_SectionsToBeMerged.Clear();
        }

        private void frmAddClass_Shown(object sender, EventArgs e)
        {
            cboCourse.Focus();
        }

        private void cmdAddClass_Click(object sender, EventArgs e)
        {
            try
            {
                if ((cboCourse.Text != "" || cboCourse.SelectedItem != null) && (cboFromTime.Text != "" || cboFromTime.SelectedItem != null) && (cboToTime.Text != "" || cboToTime.SelectedItem != null) && (cboInstructor.Text != "" || cboInstructor.SelectedItem != null) && (cboDay.Text != "" || cboDay.SelectedItem != null) && (cboRoom.Text != "" || cboRoom.SelectedItem != null))
                {
                    if (DateTime.Compare(DateTime.Parse(cboFromTime.Text), DateTime.Parse(cboToTime.Text)) < 0)
                    {
                        if (!rdoLecture.Checked && !rdoLaboratory.Checked)
                        {
                            MessageBox.Show("Cannot create a class. The class type is not specified.", "Class type not specified", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // Validate/Add class here:
                            List<Section> sections = new List<Section>();

                            sections.Add(Program.schoolschedule.Sections[Program.index_current_Section]);
                            for (int i = 0; i < indices_SectionsToBeMerged.Count; i++)
                            {
                                sections.Add(Program.schoolschedule.Sections[indices_SectionsToBeMerged[i]]);
                            }

                            if (Program.schoolschedule.AddClass(sections, Program.schoolschedule.Sections[Program.index_current_Section].Courses[cboCourse.SelectedIndex], Program.schoolschedule.Instructors[cboInstructor.SelectedIndex], Program.schoolschedule.Rooms[cboRoom.SelectedIndex], DateTime.Parse(cboFromTime.Text), DateTime.Parse(cboToTime.Text), cboDay.Text, rdoLaboratory.Checked ? "Laboratory" : "Lecture", out index_ConflictedClass))
                            {
                                MessageBox.Show("A new class is successfully added.", "New class added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Program.mainForm.DisplayVisual(Program.schoolschedule.Classes[Program.schoolschedule.Classes.Count - 1], Program.mainForm.GetCurrentDay_listview(), Program.subjectColors[cboCourse.SelectedIndex]);
                                Program.mainForm.cborooms.SelectedIndex = cboRoom.SelectedIndex;
                                Program.mainForm.OnChangeOfRoom();
                                Close();
                            }
                            else
                            {
                                new form_Conflictclass().ShowDialog();
                            }
                        }
                    }
                    else
                    {
                        if (DateTime.Compare(DateTime.Parse(cboFromTime.Text), DateTime.Parse(cboToTime.Text)) == 0)
                        {
                            MessageBox.Show("Cannot create a class where the start-time is equal to end-time.", "Incorrect class time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Cannot create a class where the end-time is earlier than start-time.", "Incorrect class time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Cannot create a class. Please complete all the necessary datas provided.", "Incomplete data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("An unexpected error has occured: ", ex.Message), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.LogError(ex, this);
            }
        }
    }
}
