using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using acschedule;

namespace ACRACS___Schedule
{
    public partial class frmMain : Form
    {
        // variables ============================================
        internal ListView active_Day = new ListView();


        // user defined methods =================================

        internal ListView GetCurrentDay_listview()
        {
            if (tabDays.SelectedTab.Text == "Monday")
            {
                return viewMonday;
            }
            if (tabDays.SelectedTab.Text == "Tuesday")
            {
                return viewTuesday;
            }
            if (tabDays.SelectedTab.Text == "Wednesday")
            {
                return viewWednesday;
            }
            if (tabDays.SelectedTab.Text == "Thursday")
            {
                return viewThursday;
            }
            if (tabDays.SelectedTab.Text == "Friday")
            {
                return viewFriday;
            }
            if (tabDays.SelectedTab.Text == "Saturday")
            {
                return viewSaturday;
            }
            if (tabDays.SelectedTab.Text == "Sunday")
            {
                return viewSunday;
            }

            return null;
        }
        internal void ClearListView()
        {
            for (int i = 0; i < viewMonday.Items.Count; i++)
            {
                //Monday
                viewMonday.Items[i].BackColor = Color.White;
                viewMonday.Items[i].SubItems[1].Text = " ";
                viewMonday.Items[i].SubItems[2].Text = " ";
                viewMonday.Items[i].SubItems[3].Text = " ";
                viewMonday.Items[i].SubItems[4].Text = " ";
                viewMonday.Items[i].SubItems[5].Text = " ";

                //Tuesday
                viewTuesday.Items[i].BackColor = Color.White;
                viewTuesday.Items[i].SubItems[1].Text = " ";
                viewTuesday.Items[i].SubItems[2].Text = " ";
                viewTuesday.Items[i].SubItems[3].Text = " ";
                viewTuesday.Items[i].SubItems[4].Text = " ";
                viewTuesday.Items[i].SubItems[5].Text = " ";

                //Wednesday
                viewWednesday.Items[i].BackColor = Color.White;
                viewWednesday.Items[i].SubItems[1].Text = " ";
                viewWednesday.Items[i].SubItems[2].Text = " ";
                viewWednesday.Items[i].SubItems[3].Text = " ";
                viewWednesday.Items[i].SubItems[4].Text = " ";
                viewWednesday.Items[i].SubItems[5].Text = " ";

                //Thursday
                viewThursday.Items[i].BackColor = Color.White;
                viewThursday.Items[i].SubItems[1].Text = " ";
                viewThursday.Items[i].SubItems[2].Text = " ";
                viewThursday.Items[i].SubItems[3].Text = " ";
                viewThursday.Items[i].SubItems[4].Text = " ";
                viewThursday.Items[i].SubItems[5].Text = " ";

                //Friday
                viewFriday.Items[i].BackColor = Color.White;
                viewFriday.Items[i].SubItems[1].Text = " ";
                viewFriday.Items[i].SubItems[2].Text = " ";
                viewFriday.Items[i].SubItems[3].Text = " ";
                viewFriday.Items[i].SubItems[4].Text = " ";
                viewFriday.Items[i].SubItems[5].Text = " ";

                //Saturday
                viewSaturday.Items[i].BackColor = Color.White;
                viewSaturday.Items[i].SubItems[1].Text = " ";
                viewSaturday.Items[i].SubItems[2].Text = " ";
                viewSaturday.Items[i].SubItems[3].Text = " ";
                viewSaturday.Items[i].SubItems[4].Text = " ";
                viewSaturday.Items[i].SubItems[5].Text = " ";

                //Sunday
                viewSunday.Items[i].BackColor = Color.White;
                viewSunday.Items[i].SubItems[1].Text = " ";
                viewSunday.Items[i].SubItems[2].Text = " ";
                viewSunday.Items[i].SubItems[3].Text = " ";
                viewSunday.Items[i].SubItems[4].Text = " ";
                viewSunday.Items[i].SubItems[5].Text = " ";
            }
        }
        internal void ClearListView_wRoom()
        {
            for (int i = 0; i < viewMonday.Items.Count; i++)
            {
                //Monday
                viewMonday.Items[i].BackColor = Color.White;
                viewMonday.Items[i].SubItems[1].Text = " ";
                viewMonday.Items[i].SubItems[2].Text = " ";
                viewMonday.Items[i].SubItems[3].Text = " ";
                viewMonday.Items[i].SubItems[4].Text = " ";
                viewMonday.Items[i].SubItems[5].Text = " ";

                //Tuesday
                viewTuesday.Items[i].BackColor = Color.White;
                viewTuesday.Items[i].SubItems[1].Text = " ";
                viewTuesday.Items[i].SubItems[2].Text = " ";
                viewTuesday.Items[i].SubItems[3].Text = " ";
                viewTuesday.Items[i].SubItems[4].Text = " ";
                viewTuesday.Items[i].SubItems[5].Text = " ";

                //Wednesday
                viewWednesday.Items[i].BackColor = Color.White;
                viewWednesday.Items[i].SubItems[1].Text = " ";
                viewWednesday.Items[i].SubItems[2].Text = " ";
                viewWednesday.Items[i].SubItems[3].Text = " ";
                viewWednesday.Items[i].SubItems[4].Text = " ";
                viewWednesday.Items[i].SubItems[5].Text = " ";

                //Thursday
                viewThursday.Items[i].BackColor = Color.White;
                viewThursday.Items[i].SubItems[1].Text = " ";
                viewThursday.Items[i].SubItems[2].Text = " ";
                viewThursday.Items[i].SubItems[3].Text = " ";
                viewThursday.Items[i].SubItems[4].Text = " ";
                viewThursday.Items[i].SubItems[5].Text = " ";

                //Friday
                viewFriday.Items[i].BackColor = Color.White;
                viewFriday.Items[i].SubItems[1].Text = " ";
                viewFriday.Items[i].SubItems[2].Text = " ";
                viewFriday.Items[i].SubItems[3].Text = " ";
                viewFriday.Items[i].SubItems[4].Text = " ";
                viewFriday.Items[i].SubItems[5].Text = " ";

                //Saturday
                viewSaturday.Items[i].BackColor = Color.White;
                viewSaturday.Items[i].SubItems[1].Text = " ";
                viewSaturday.Items[i].SubItems[2].Text = " ";
                viewSaturday.Items[i].SubItems[3].Text = " ";
                viewSaturday.Items[i].SubItems[4].Text = " ";
                viewSaturday.Items[i].SubItems[5].Text = " ";

                //Sunday
                viewSunday.Items[i].BackColor = Color.White;
                viewSunday.Items[i].SubItems[1].Text = " ";
                viewSunday.Items[i].SubItems[2].Text = " ";
                viewSunday.Items[i].SubItems[3].Text = " ";
                viewSunday.Items[i].SubItems[4].Text = " ";
                viewSunday.Items[i].SubItems[5].Text = " ";
            }
        }

        internal void InitiateTabDays()
        {

            DateTime timeloader = DateTime.Parse("6:00 AM");
            int ctr = 0;
            ListViewItem itmtime = new ListViewItem(timeloader.ToShortTimeString());

            do
            {
                viewMonday.Items.Add(timeloader.AddMinutes(ctr).ToShortTimeString());
                viewTuesday.Items.Add(timeloader.AddMinutes(ctr).ToShortTimeString());
                viewWednesday.Items.Add(timeloader.AddMinutes(ctr).ToShortTimeString());
                viewThursday.Items.Add(timeloader.AddMinutes(ctr).ToShortTimeString());
                viewFriday.Items.Add(timeloader.AddMinutes(ctr).ToShortTimeString());
                viewSaturday.Items.Add(timeloader.AddMinutes(ctr).ToShortTimeString());
                viewSunday.Items.Add(timeloader.AddMinutes(ctr).ToShortTimeString());


                ctr += 30;

            } while (timeloader.AddMinutes(ctr).Hour < DateTime.Parse("11:00 PM").Hour);

            viewMonday.Items.Add("11:00 PM");
            viewTuesday.Items.Add("11:00 PM");
            viewWednesday.Items.Add("11:00 PM");
            viewThursday.Items.Add("11:00 PM");
            viewFriday.Items.Add("11:00 PM");
            viewSaturday.Items.Add("11:00 PM");
            viewSunday.Items.Add("11:00 PM");

            itmtime = null;


            for (int i = 0; i < viewMonday.Items.Count; i++)
            {
                //Monday
                viewMonday.Items[i].SubItems.Add(" ");
                viewMonday.Items[i].SubItems.Add(" ");
                viewMonday.Items[i].SubItems.Add(" ");
                viewMonday.Items[i].SubItems.Add(" ");
                viewMonday.Items[i].SubItems.Add(" ");

                //Tuesday
                viewTuesday.Items[i].SubItems.Add(" ");
                viewTuesday.Items[i].SubItems.Add(" ");
                viewTuesday.Items[i].SubItems.Add(" ");
                viewTuesday.Items[i].SubItems.Add(" ");
                viewTuesday.Items[i].SubItems.Add(" ");

                //Wednesday
                viewWednesday.Items[i].SubItems.Add(" ");
                viewWednesday.Items[i].SubItems.Add(" ");
                viewWednesday.Items[i].SubItems.Add(" ");
                viewWednesday.Items[i].SubItems.Add(" ");
                viewWednesday.Items[i].SubItems.Add(" ");

                //Thursday
                viewThursday.Items[i].SubItems.Add(" ");
                viewThursday.Items[i].SubItems.Add(" ");
                viewThursday.Items[i].SubItems.Add(" ");
                viewThursday.Items[i].SubItems.Add(" ");
                viewThursday.Items[i].SubItems.Add(" ");

                //Friday
                viewFriday.Items[i].SubItems.Add(" ");
                viewFriday.Items[i].SubItems.Add(" ");
                viewFriday.Items[i].SubItems.Add(" ");
                viewFriday.Items[i].SubItems.Add(" ");
                viewFriday.Items[i].SubItems.Add(" ");

                //Saturday
                viewSaturday.Items[i].SubItems.Add(" ");
                viewSaturday.Items[i].SubItems.Add(" ");
                viewSaturday.Items[i].SubItems.Add(" ");
                viewSaturday.Items[i].SubItems.Add(" ");
                viewSaturday.Items[i].SubItems.Add(" ");

                //Sunday
                viewSunday.Items[i].SubItems.Add(" ");
                viewSunday.Items[i].SubItems.Add(" ");
                viewSunday.Items[i].SubItems.Add(" ");
                viewSunday.Items[i].SubItems.Add(" ");
                viewSunday.Items[i].SubItems.Add(" ");
            }
        }
        internal void DisplayVisual(School_Class Class, ListView Day_listview, Color course_Color)
        {
            for (int x = 0; x < Day_listview.Items.Count; x++)
            {
                if (Day_listview.Items[x].Text == Class.Class_TimeStart.ToShortTimeString())
                {
                    // 
                    // display class info to listview
                    //
                    Day_listview.Items[x].SubItems[1].Text = Class.Course.Coursecode;
                    // display section(s)
                    for (int y = 0; y < Class.Sections.Count; y++)
                    {
                        if (y == 0)
                        {
                            Day_listview.Items[x].SubItems[2].Text = Class.Sections[0].SectionName;
                        }
                        else
                        {
                            Day_listview.Items[x].SubItems[2].Text += string.Concat(", ",Class.Sections[y].SectionName);
                        }
                    }
                    Day_listview.Items[x].SubItems[3].Text = Class.Class_Type;
                    Day_listview.Items[x].SubItems[4].Text = string.Concat(Class.Instructor.FirstName, " ", Class.Instructor.LastName);

                    int z = x;
                    do
	                {
	                    Day_listview.Items[z].BackColor = course_Color;
                        z += 1;
	                } while (DateTime.Compare(DateTime.Parse(Day_listview.Items[z].Text), DateTime.Parse(Class.Class_TimeEnd.ToShortTimeString())) < 0);
                }
                else if (DateTime.Parse(Day_listview.Items[x].Text) == DateTime.Parse(Class.Class_TimeEnd.ToShortTimeString()))
	            {
		            Day_listview.Items[x].BackColor = course_Color;
	            }
            }

            Day_listview.SelectedItems.Clear();
        }
        internal void DisplayVisual_wRoom(School_Class Class, ListView Day_listview, Color course_Color)
        {
            for (int x = 0; x < Day_listview.Items.Count; x++)
            {
                if (Day_listview.Items[x].Text == Class.Class_TimeStart.ToShortTimeString())
                {
                    // 
                    // display class info to listview
                    //
                    Day_listview.Items[x].SubItems[1].Text = Class.Course.Coursecode;
                    // display section(s)
                    for (int y = 0; y < Class.Sections.Count; y++)
                    {
                        if (y == 0)
                        {
                            Day_listview.Items[x].SubItems[2].Text = Class.Sections[0].SectionName;
                        }
                        else
                        {
                            Day_listview.Items[x].SubItems[2].Text += string.Concat(", ", Class.Sections[y].SectionName);
                        }
                    }
                    Day_listview.Items[x].SubItems[3].Text = Class.Class_Type;
                    Day_listview.Items[x].SubItems[4].Text = string.Concat(Class.Instructor.FirstName, " ", Class.Instructor.LastName);
                    Day_listview.Items[x].SubItems[5].Text = Class.Room.Name;

                    int z = x;
                    do
                    {
                        Day_listview.Items[z].BackColor = course_Color;
                        z += 1;
                    } while (DateTime.Compare(DateTime.Parse(Day_listview.Items[z].Text), DateTime.Parse(Class.Class_TimeEnd.ToShortTimeString())) < 0);
                }
                else if (DateTime.Parse(Day_listview.Items[x].Text) == DateTime.Parse(Class.Class_TimeEnd.ToShortTimeString()))
                {
                    Day_listview.Items[x].BackColor = course_Color;
                }
            }

            Day_listview.SelectedItems.Clear();
        }
        internal void Display_SectionClasses()
        {
            //clear listview first
            ClearListView();

            // display the Classroom column by setting the width with 200
            viewMonday.Columns[5].Width = 200;
            viewTuesday.Columns[5].Width = 200;
            viewWednesday.Columns[5].Width = 200;
            viewThursday.Columns[5].Width = 200;
            viewFriday.Columns[5].Width = 200;
            viewSaturday.Columns[5].Width = 200;

            // index of subject color to be used
            int color_index = 11;

            // Display all sessions to listview
            for (int i = 0; i < Program.schoolschedule.Classes.Count; i++)
            {
                // Determine whether its part of the current section
                for (int y = 0; y < Program.schoolschedule.Classes[i].Sections.Count; y++)
                {
                    if (Program.schoolschedule.Classes[i].Sections[y].SectionName == Program.schoolschedule.Sections[Program.index_current_Section].SectionName)
                    {
                        // 
                        for (int x = 0; x < Program.schoolschedule.Sections[Program.index_current_Section].Courses.Count; x++)
                        {
                            if (Program.schoolschedule.Classes[i].Course.Coursecode == Program.schoolschedule.Sections[Program.index_current_Section].Courses[x].Coursecode)
                            {
                                color_index = x;
                            }
                        }

                        //display to listivew
                        if (Program.schoolschedule.Classes[i].Day == "Monday")
                        {
                            DisplayVisual_wRoom(Program.schoolschedule.Classes[i], viewMonday, Program.subjectColors[color_index]);
                        }
                        else if (Program.schoolschedule.Classes[i].Day == "Tuesday")
                        {
                            DisplayVisual_wRoom(Program.schoolschedule.Classes[i], viewTuesday, Program.subjectColors[color_index]);
                        }
                        else if (Program.schoolschedule.Classes[i].Day == "Wednesday")
                        {
                            DisplayVisual_wRoom(Program.schoolschedule.Classes[i], viewWednesday, Program.subjectColors[color_index]);
                        }
                        else if (Program.schoolschedule.Classes[i].Day == "Thursday")
                        {
                            DisplayVisual_wRoom(Program.schoolschedule.Classes[i], viewThursday, Program.subjectColors[color_index]);
                        }
                        else if (Program.schoolschedule.Classes[i].Day == "Friday")
                        {
                            DisplayVisual_wRoom(Program.schoolschedule.Classes[i], viewFriday, Program.subjectColors[color_index]);
                        }
                        else if (Program.schoolschedule.Classes[i].Day == "Saturday")
                        {
                            DisplayVisual_wRoom(Program.schoolschedule.Classes[i], viewSaturday, Program.subjectColors[color_index]);
                        }
                        else
                        {
                            DisplayVisual_wRoom(Program.schoolschedule.Classes[i], viewSunday, Program.subjectColors[color_index]);
                        }
                    }
                }
            }
        }
        internal void OnChangeOfRoom()
        {
            try
            {
                // index of subject color to be used
                int color_index = 11;

                //clear listview first
                ClearListView();

                //display all classes to listview
                for (int i = 0; i < Program.schoolschedule.Classes.Count; i++)
                {
                    if (Program.schoolschedule.Classes[i].Room.Name == Program.schoolschedule.Rooms[cborooms.SelectedIndex].Name)
                    {
                        //determine whether its part of the current section
                        for (int y = 0; y < Program.schoolschedule.Classes[i].Sections.Count; y++)
                        {
                            if (Program.schoolschedule.Classes[i].Sections[y].SectionName == Program.schoolschedule.Sections[Program.index_current_Section].SectionName)
                            {
                                for (int x = 0; x < Program.schoolschedule.Sections[Program.index_current_Section].Courses.Count; x++)
                                {
                                    if (Program.schoolschedule.Classes[i].Course.Coursecode == Program.schoolschedule.Sections[Program.index_current_Section].Courses[x].Coursecode)
                                    {
                                        color_index = x;
                                    }
                                }
                            }
                        }

                        //display to listivew
                        if (Program.schoolschedule.Classes[i].Day == "Monday")
                        {
                            DisplayVisual(Program.schoolschedule.Classes[i], viewMonday, Program.subjectColors[color_index]);
                        }
                        else if (Program.schoolschedule.Classes[i].Day == "Tuesday")
                        {
                            DisplayVisual(Program.schoolschedule.Classes[i], viewTuesday, Program.subjectColors[color_index]);
                        }
                        else if (Program.schoolschedule.Classes[i].Day == "Wednesday")
                        {
                            DisplayVisual(Program.schoolschedule.Classes[i], viewWednesday, Program.subjectColors[color_index]);
                        }
                        else if (Program.schoolschedule.Classes[i].Day == "Thursday")
                        {
                            DisplayVisual(Program.schoolschedule.Classes[i], viewThursday, Program.subjectColors[color_index]);
                        }
                        else if (Program.schoolschedule.Classes[i].Day == "Friday")
                        {
                            DisplayVisual(Program.schoolschedule.Classes[i], viewFriday, Program.subjectColors[color_index]);
                        }
                        else if (Program.schoolschedule.Classes[i].Day == "Saturday")
                        {
                            DisplayVisual(Program.schoolschedule.Classes[i], viewSaturday, Program.subjectColors[color_index]);
                        }
                        else
                        {
                            DisplayVisual(Program.schoolschedule.Classes[i], viewSunday, Program.subjectColors[color_index]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("An unexpected error has occured: ", ex.Message), "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.LogError(ex, this);
            }
        }

        // ======================================================

        public frmMain()
        {
            InitializeComponent();
            active_Day = viewMonday;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close the application?","Confirmation",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = false;
                Program.UpdateSchedulingStatus(0);
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.schoolschedule.Classes.Count != 0 || cmdSection.Text != "[ No Class ]")
            {
                DialogResult dialogAnswer = MessageBox.Show("Do you want to save the classes?","Save classes",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
                
                if (dialogAnswer == System.Windows.Forms.DialogResult.Yes)
                {
                    Program.UpdateSchedulingStatus(0);
                    new form_Save().ShowDialog();
                    new form_Unload().ShowDialog();
                    Program.splashForm.tmrUpdate.Start();
                    this.Hide();
                    Program.splashForm.Show();
                }
                else if(dialogAnswer == System.Windows.Forms.DialogResult.No)
                {
                    Program.UpdateSchedulingStatus(0);
                    new form_Unload().ShowDialog();
                    Program.splashForm.tmrUpdate.Start();
                    this.Hide();
                    Program.splashForm.Show();
                }
            }
            else
            {
                Program.UpdateSchedulingStatus(0);
                new form_Unload().ShowDialog();
                Program.splashForm.tmrUpdate.Start();
                this.Hide();
                Program.splashForm.Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close the application?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Program.UpdateSchedulingStatus(0);
                Application.ExitThread();
            }
        }

        private void cmdSection_Click(object sender, EventArgs e)
        {
            new frm_Sections().ShowDialog();
        }

        private void cmdAddClass_Click(object sender, EventArgs e)
        {
            new frmAddClass().ShowDialog();
        }

        private void lbltotal_courses_DoubleClick(object sender, EventArgs e)
        {
            using (form_sectionCourses frm = new form_sectionCourses())
            {
                frm.Location = Cursor.Position;
                frm.ShowDialog();
            }
        }

        private void aDDCLASSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (active_Day.SelectedItems[0].BackColor != Color.Transparent && active_Day.SelectedItems[0].SubItems[1].Text != " " && active_Day.SelectedItems[0].SubItems[2].Text != " " && active_Day.SelectedItems[0].SubItems[3].Text != " " && active_Day.SelectedItems[0].SubItems[4].Text != " ")
                {
                    MessageBox.Show("You cannot add in the selected time. There is already a class added.", "Cannot add class", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else
                {
                    Program.AddClassForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cborooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnChangeOfRoom();
        }

        private void mnuActions_Opening(object sender, CancelEventArgs e)
        {
            if (optViewSectionClassOnly.Checked || cmdSection.Text == "[ No Class ]")
            {
                e.Cancel = true;
            }
            if (cmdSection.Text == "[ No Class ]")
            {
                MessageBox.Show("To add class, select a section first by clicking the button located at bottom left.", "No section", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void aboutTheDeveloperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new form_Developer().ShowDialog();
        }

        private void sectionClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (optViewSectionClassOnly.Checked)
            {
                pnlTopRight.Visible = false;
                Display_SectionClasses();
            }
            else
            {
                pnlTopRight.Visible = true;
                ClearListView();

                // remove classroom column in tabDays
                viewMonday.Columns[5].Width = 0;
                viewTuesday.Columns[5].Width = 0;
                viewWednesday.Columns[5].Width = 0;
                viewThursday.Columns[5].Width = 0;
                viewFriday.Columns[5].Width = 0;
                viewSaturday.Columns[5].Width = 0;
                viewSunday.Columns[5].Width = 0;

                cborooms.SelectedIndex = 0;
                OnChangeOfRoom();
            }
        }

        private void finishUpSchedulingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new form_StatusUpdate().ShowDialog();
        }

        private void tabDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabDays.SelectedIndex)
            {
                case 0:
                    active_Day = viewMonday;
                    break;
                case 1:
                    active_Day = viewTuesday;
                    break;
                case 2:
                    active_Day = viewWednesday;
                    break;
                case 3:
                    active_Day = viewThursday;
                    break;
                case 4:
                    active_Day = viewFriday;
                    break;
                case 5:
                    active_Day = viewSaturday;
                    break;
                case 6:
                    active_Day = viewSunday;
                    break;
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (active_Day.SelectedItems[0].SubItems[1].Text != " " && active_Day.SelectedItems[0].SubItems[1].Text != " " && active_Day.SelectedItems[0].SubItems[2].Text != " " && active_Day.SelectedItems[0].SubItems[3].Text != " " && active_Day.SelectedItems[0].SubItems[4].Text != " ")
            {
                if (MessageBox.Show("Are you sure you want to remove the selected class?","Delete confirmation",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    for (int i = 0; i < Program.schoolschedule.Classes.Count; i++)
                    {
                        if (Program.schoolschedule.Classes[i].Course.Coursecode == active_Day.SelectedItems[0].SubItems[1].Text && Program.schoolschedule.Classes[i].Sections[0].SectionName == active_Day.SelectedItems[0].SubItems[2].Text.Split(',',' ')[0] && Program.schoolschedule.Classes[i].Class_Type == active_Day.SelectedItems[0].SubItems[3].Text && string.Concat(Program.schoolschedule.Classes[i].Instructor.FirstName, " ", Program.schoolschedule.Classes[i].Instructor.LastName) == active_Day.SelectedItems[0].SubItems[4].Text)
                        {
                            Program.schoolschedule.Classes.RemoveAt(i);
                            break;
                        }
                    }

                    ClearListView();
                    OnChangeOfRoom();
                }
            }
            else
            {
                MessageBox.Show("Selected time does not contain any class.","No class selected",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
        }

        private void opt_Save_Click(object sender, EventArgs e)
        {
            new form_Save().ShowDialog();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            new form_Save().ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (active_Day.SelectedItems[0].BackColor != Color.Transparent && active_Day.SelectedItems[0].SubItems[1].Text != " " && active_Day.SelectedItems[0].SubItems[2].Text != " " && active_Day.SelectedItems[0].SubItems[3].Text != " " && active_Day.SelectedItems[0].SubItems[4].Text != " ")
                {
                    Program.UpdateClassForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No class selected.", "Cannot add class", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void optMe_Click(object sender, EventArgs e)
        {
            new form_UserAccount().ShowDialog();
        }

        private void optInstructors_Click(object sender, EventArgs e)
        {
            new form_Instructors().ShowDialog();
        }

        private void optDpds_Click(object sender, EventArgs e)
        {
            new form_dpd().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Program.schoolschedule.Classes.Count; i++)
            {
                MessageBox.Show(string.Concat(Program.schoolschedule.Classes[i].Id," ",Program.schoolschedule.Classes[i].Day," ",Program.schoolschedule.Classes[i].Course.Coursecode," ",Program.schoolschedule.Classes[i].Instructor.FirstName));
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < Program.schoolschedule.Classes.Count; i++)
            {
                MessageBox.Show(string.Concat(Program.schoolschedule.Classes[i].Class_TimeStart.ToShortTimeString(), " - ", Program.schoolschedule.Classes[i].Class_TimeEnd.ToShortTimeString(), " - ", Program.schoolschedule.Classes[i].Course.Coursecode, " - ", Program.schoolschedule.Classes[i].Class_Type, " - ", Program.schoolschedule.Classes[i].Id, " - ", Program.schoolschedule.Classes[i].Instructor.FirstName, " - ", Program.schoolschedule.Classes[i].Room.Name));
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = Program.dbConnection;
                cmd.CommandText = "SELECT * FROM setting_Actives";
                cmd.Connection.Open();

                MessageBox.Show(cmd.ExecuteScalar().ToString());
            }
        }
        private void sectionReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new form_ReportSection_option().ShowDialog();
        }
    }
}