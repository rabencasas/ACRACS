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
    public partial class form_Conflictclass : Form
    {
        public form_Conflictclass()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void form_Conflictclass_Load(object sender, EventArgs e)
        {
            try
            {
                ListViewItem li;

            // display time:
            // 1: start-time
            li = lstClass_conflicted.Items.Add("START-TIME");
            li.SubItems.Add(Program.schoolschedule.Classes[Program.AddClassForm.index_ConflictedClass].Class_TimeStart.ToShortTimeString());

            // 2: end-time
            li = lstClass_conflicted.Items.Add("END-TIME");
            li.SubItems.Add(Program.schoolschedule.Classes[Program.AddClassForm.index_ConflictedClass].Class_TimeEnd.ToShortTimeString());

            // display course (2)
            li = lstClass_conflicted.Items.Add("COURSE");
            li.SubItems.Add(Program.schoolschedule.Classes[Program.AddClassForm.index_ConflictedClass].Course.Coursecode);

            // display section(s) (3)
            li = lstClass_conflicted.Items.Add("SECTION(S)");
            for (int i = 0; i < Program.schoolschedule.Classes[Program.AddClassForm.index_ConflictedClass].Sections.Count; i++)
            {
                if (i == 0)
                {
                    li.SubItems.Add(Program.schoolschedule.Classes[Program.AddClassForm.index_ConflictedClass].Sections[i].SectionName);
                }
                else
                {
                    li.SubItems.Add(string.Concat(", ", Program.schoolschedule.Classes[Program.AddClassForm.index_ConflictedClass].Sections[i].SectionName));
                }
            }

            // class type (4)
            li = lstClass_conflicted.Items.Add("CLASS TYPE");
            li.SubItems.Add(Program.schoolschedule.Classes[Program.AddClassForm.index_ConflictedClass].Class_Type);

            // display instructor (5)
            li = lstClass_conflicted.Items.Add("INSTRUCTOR");
            li.SubItems.Add(string.Concat(Program.schoolschedule.Classes[Program.AddClassForm.index_ConflictedClass].Instructor.FirstName," ",Program.schoolschedule.Classes[Program.AddClassForm.index_ConflictedClass].Instructor.LastName));
        
            // display room (6)
            li = lstClass_conflicted.Items.Add("ROOM");
            li.SubItems.Add(Program.schoolschedule.Classes[Program.AddClassForm.index_ConflictedClass].Room.Name);

            // determine the part of conflict in class & display in 'RED TEXT'
            // instructor conflict
            if (Program.schoolschedule.Instructors[Program.AddClassForm.cboInstructor.SelectedIndex].Identification == Program.schoolschedule.Classes[Program.AddClassForm.index_ConflictedClass].Instructor.Identification)
            {
                lstClass_conflicted.Items[5].ForeColor = Color.Red;
            }
            // room conflict
            else if (Program.schoolschedule.Rooms[Program.AddClassForm.cboRoom.SelectedIndex].Name == Program.schoolschedule.Classes[Program.AddClassForm.index_ConflictedClass].Room.Name)
            {
                lstClass_conflicted.Items[6].ForeColor = Color.Red;
            }
            // time conflict
            else
            {
                lstClass_conflicted.Items[0].ForeColor = Color.Red;
                lstClass_conflicted.Items[1].ForeColor = Color.Red;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void form_Conflictclass_Shown(object sender, EventArgs e)
        {
            cmdClose.Focus();
        }
    }
}
