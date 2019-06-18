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
    public partial class form_Instructors : Form
    {
        // fields
        internal int selectedInstructor_index;

        public form_Instructors()
        {
            InitializeComponent();
        }

        private void form_Instructors_Load(object sender, EventArgs e)
        {
            ListViewItem li;
            lstInstructors.Items.Clear();

            for (int i = 0; i < Program.instructors.Count; i++)
            {
                li = lstInstructors.Items.Add(Program.instructors[i].UserName);
                li.SubItems.Add(Program.instructors[i].FirstName);
                li.SubItems.Add(Program.instructors[i].LastName);
                li.SubItems.Add(Program.instructors[i].Email_Address);
                li.SubItems.Add(Program.instructors[i].Department_Description);
            }
        }

        private void cmdGet_Click(object sender, EventArgs e)
        {
            if (lstInstructors.SelectedItems.Count != 0)
            {
                using (form_securityAccess frmGetPassword = new form_securityAccess())
                {
                    frmGetPassword.username = Program.currentUser_userName;
                    frmGetPassword.selectedInstrID = Program.instructors[lstInstructors.SelectedItems[0].Index].Identification;

                    frmGetPassword.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("No instructor selected. Please an instructor first.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
