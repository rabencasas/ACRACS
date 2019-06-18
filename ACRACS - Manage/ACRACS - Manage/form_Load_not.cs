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
    public partial class form_Load_not : Form
    {
        public form_Load_not()
        {
            InitializeComponent();
        }

        //custom method
        private void UnloadResource()
        {
            // remove resource description
            Program.docDescription = string.Empty;
            Program.docSemLevel = string.Empty;
            Program.docSyFrom = 0;
            Program.docSyTo = 0;
            Program.docStatus = string.Empty;

            // remove all stored datas
            Program.courses.Clear();
            Program.instructors.Clear();
            Program.classRooms.Clear();
            Program.programs.Clear();
            Program.sections.Clear();

            // remove datas from user-view
            Program.mainForm.lstCourses.Items.Clear();
            Program.mainForm.lstInstructors.Items.Clear();
            Program.mainForm.lstClassRooms.Items.Clear();

            // remove all programs
            Program.mainForm.lstProgDept1.Items.Clear();
            Program.mainForm.lstProgDept2.Items.Clear();
            Program.mainForm.lstProgDept3.Items.Clear();
            Program.mainForm.lstProgDept4.Items.Clear();

            // remove all sections
            Program.mainForm.lstSect_Dept1.Items.Clear();
            Program.mainForm.lstSect_Dept2.Items.Clear();
            Program.mainForm.lstSect_Dept3.Items.Clear();
            Program.mainForm.lstSect_Dept4.Items.Clear();

            Program.mainForm.lblSectTotal_Dept1.Text = "0";
            Program.mainForm.lblSectTotal_Dept2.Text = "0";
            Program.mainForm.lblSectTotal_Dept3.Text = "0";
            Program.mainForm.lblSectTotal_Dept4.Text = "0";

            Program.mainForm.lbltotal_course.Text = "Total: 0";
            Program.mainForm.lbltotal_instructor.Text = "Total: 0";
            Program.mainForm.lbltotal_classroom.Text = "Total: 0";

            this.Close();
        }

        private void form_Load_not_Shown(object sender, EventArgs e)
        {
            UnloadResource();
        }
    }
}
