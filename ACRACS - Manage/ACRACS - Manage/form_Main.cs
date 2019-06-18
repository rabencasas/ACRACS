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

namespace ACRACS___Manage
{
    public partial class frmMain : Form
    {
        // form variables
        #region form variables
        //================================
        ListViewItem li;
        private string current_departmentId;
        string tmpString;
        Button currentMenu;
        //================================
        #endregion


        // default constructor - system generated
        public frmMain()
        {
            InitializeComponent();
        }

        // form added methods
        #region methods
        //================================
        private void ChangeMenu(Panel Panel_to_view, Button Button_menu, Control Textbox_to_Focus)
        {
            //onfocus first other menu buttons
            cmdDept1.BackColor = Color.WhiteSmoke;
            cmdDept4.BackColor = Color.WhiteSmoke;
            cmdDept2.BackColor = Color.WhiteSmoke;
            cmdDept3.BackColor = Color.WhiteSmoke;

            cmdCourses.BackColor = Color.WhiteSmoke;
            cmdClassRooms.BackColor = Color.WhiteSmoke;
            cmdInstructors.BackColor = Color.WhiteSmoke;

            //undock other panels
            pnlDept1.Dock = DockStyle.None;
            pnlDept1.Visible = false;
            pnlDept4.Dock = DockStyle.None;
            pnlDept4.Visible = false;
            pnlDept2.Dock = DockStyle.None;
            pnlDept2.Visible = false;
            pnlDept3.Dock = DockStyle.None;
            pnlDept3.Visible = false;

            pnlCourses.Dock = DockStyle.None;
            pnlCourses.Visible = false;
            pnlClassRooms.Dock = DockStyle.None;
            pnlClassRooms.Visible = false;
            pnlInstructors.Dock = DockStyle.None;
            pnlInstructors.Visible = false;

            //focus item
            Panel_to_view.Dock = DockStyle.Fill;
            Panel_to_view.BringToFront();
            Button_menu.BackColor = Color.LightGray;
            Panel_to_view.Visible = true;
            Textbox_to_Focus.Focus();
            currentMenu = Button_menu;

        }

        // add programs
        private void AddProgram(TextBox Program_Code, TextBox Program_Description, ListBox Display_to_listiview, ComboBox Add_to_combobox)
        {
            Program.programs.Add(new acschedule.Program(Program_Code.Text, Program_Description.Text, current_departmentId));
            Display_to_listiview.Items.Add(string.Concat(Program_Code.Text, "  -\t", Program_Description.Text));
            Add_to_combobox.Items.Add(Program_Code.Text);

            //clear controls & fill the listview for items
            Program_Code.Text = "";
            Program_Description.Text = "";

            Program_Code.Focus();
        }

        // add sections
        private void AddSection(TextBox Section_Name, ComboBox YearLevel, TextBox Class_Density, ComboBox Program_Code, ListView Display_to_listview, Label Display_Total)
        {
            Program.sections.Add(new Section(Section_Name.Text, int.Parse(YearLevel.Text), Program_Code.Text, int.Parse(Class_Density.Text)));

            switch (int.Parse(YearLevel.Text))
            {
                case 1:
                    {
                        tmpString = "1st year";
                        break;
                    }
                case 2:
                    {
                        tmpString = "2nd year";
                        break;
                    }
                case 3:
                    {
                        tmpString = "3rd year";
                        break;
                    }
                case 4:
                    {
                        tmpString = "4th year";
                        break;
                    }
                case 5:
                    {
                        tmpString = "5th year";
                        break;
                    }
            }

            li = Display_to_listview.Items.Add(Section_Name.Text);
            li.SubItems.Add(YearLevel.Text);
            li.SubItems.Add(Class_Density.Text);
            li.SubItems.Add(Program_Code.Text);

            Display_Total.Text = (int.Parse(Display_Total.Text) + 1).ToString();

            //clear controls values
            Section_Name.Text = "";
            YearLevel.Text = "";
            Class_Density.Text = "";
            Program_Code.Text = "";

            Section_Name.Focus();
        }

        // add course
        private void AddCourse()
        {
            if (txtCourseCode.Text != "" && txtCourseDesc.Text != "" && cboCourseUnit.Text != "")
            {
                Program.courses.Add(new acschedule.Course(txtCourseCode.Text, txtCourseDesc.Text, int.Parse(cboCourseUnit.Text)));
                lbltotal_course.Text = string.Concat("Total: ", Program.courses.Count.ToString());
                lbltotal_course.Visible = true;

                lstCourses.Items.Clear();

                for (int i = 0; i < Program.courses.Count; i++)
                {
                    li = lstCourses.Items.Add(Program.courses[i].Coursecode);
                    li.SubItems.Add(Program.courses[i].CourseDescription);
                    li.SubItems.Add(Program.courses[i].Units.ToString());
                }

                txtCourseDesc.Text = "";
                txtCourseCode.Text = "";
                cboCourseUnit.Text = "";
                txtCourseCode.Focus();

            }
            else
            {
                MessageBox.Show("Incomplete data entered", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // add new room
        private void AddRoom()
        {
            if (txtRoomName.Text != "" && ((cboRoomType.Text != "") || (cboRoomType.Text != "Select from the list")))
            {
                Program.classRooms.Add(new acschedule.Room(txtRoomName.Text, cboRoomType.Text));
                lbltotal_classroom.Text = string.Concat("Total: ", Program.classRooms.Count.ToString());
                lbltotal_classroom.Visible = true;

                lstClassRooms.Items.Clear();

                for (int i = 0; i < Program.classRooms.Count; i++)
                {
                    li = lstClassRooms.Items.Add(Program.classRooms[i].Name);
                    li.SubItems.Add(Program.classRooms[i].RoomType);
                }

                cboRoomType.Text = "";
                txtRoomName.Text = "";
                txtRoomName.Focus();
                cboRoomType.Text = "Select from the list";

            }
            else
            {
                MessageBox.Show("Incomplete data entered", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // add instructor
        private void AddInstructor()
        {
            if (txtId.Text != "" && txtFirstName.Text != "" && txtLastName.Text != "" && (cboDepartments.Text != "" || cboDepartments.Text != "(Select from the list)"))
            {
                Program.instructors.Add(new Instructor(txtId.Text, txtFirstName.Text, txtLastName.Text, "", Program.departments[cboDepartments.SelectedIndex].DepartmentId, Program.departments[cboDepartments.SelectedIndex].DepartmentDescription, string.Concat(txtFirstName.Text.ToLower(), txtLastName.Text.ToLower()), Create_random_password()));

                lstInstructors.Items.Clear();

                for (int i = 0; i < Program.instructors.Count; i++)
                {
                    lstInstructors.Items.Add(string.Concat(Program.instructors[i].FirstName, " ", Program.instructors[i].LastName));
                }

                txtId.Text = string.Empty;
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                cboDepartments.Text = "(Select from the list)";
                cboDepartments.SelectedItem = null;
                cmdGenerateId.Focus();
            }
            else
            {
                MessageBox.Show("Please provide all the necessary datas.", "Incomplete data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // add courses to selected section
        private void AddCoursesToSection(ListView listview_of_sections)
        {
            if (listview_of_sections.SelectedItems.Count != 0)
            {
                for (int i = 0; i < Program.sections.Count; i++)
                {
                    if (Program.sections[i].SectionName == listview_of_sections.SelectedItems[0].Text)
                    {
                        Program.selectedSection = i;
                        break;
                    }
                }

                    Program.form_AddCoursetoSection.ShowDialog();
            }
        }

        // create a five-character random password
        private string Create_random_password()
        {
            string randomPassword = "";

            randomPassword = new Random().Next(599, 99999).ToString();
            randomPassword += new Random().Next(99, 999).ToString();


            return randomPassword;
        }

        // remove programs
        private void RemoveProgram()
        {
            // remove first in the list/collection
            /*for (int i = 0; i < Program.programs.Count; i++)
            {
                if (Program.programs[i].DepartmentId == current_departmentId)
                {
                    
                }
            }

            // remove in the control container
            if (current_departmentId == "Dpt-1")
            {
                
            }
            else if (current_departmentId == "Dpt-2")
	        {
		 
	        }
            else if (current_departmentId == "Dpt-3")
            {
                
            }
            else
            {

            }*/
        }

        // remove sections
        private void RemoveSection(ListView Section_Container)
        { 
            
        }
        //
        //  REMOVE ITEMS
        //
        // remove course item
        private void RemoveCourse()
        {
            Program.courses.RemoveAt(lstCourses.SelectedIndices[0]);
            lstCourses.SelectedItems[0].Remove();

            lbltotal_course.Text = string.Concat("Total: ", Program.courses.Count.ToString());
        }
        // remove instructor item
        private void RemoveInstructor()
        {
            Program.instructors.RemoveAt(lstInstructors.SelectedIndices[0]);
            lstInstructors.Items.RemoveAt(lstInstructors.SelectedIndex);
        }
        // remove classroom item
        private void RemoveClassroom()
        {
            Program.classRooms.RemoveAt(lstClassRooms.SelectedIndices[0]);
            lstClassRooms.SelectedItems[0].Remove();

            lbltotal_classroom.Text = string.Concat("Total: ", Program.classRooms.Count.ToString());
        }
        //
        //  EDIT ITEMS
        //
        // edit course item
        private void EditCourse()
        {
            txtCourseCode.Text = Program.courses[lstCourses.SelectedIndices[0]].Coursecode;
            txtCourseDesc.Text = Program.courses[lstCourses.SelectedIndices[0]].CourseDescription;
            cboCourseUnit.Text = Program.courses[lstCourses.SelectedIndices[0]].Units.ToString();

            cmdCourseAdd.Text = "Update";
            cmdCancel_course.Visible = true;
        }
        // edit instructor item
        private void EditInstructor()
        {
            txtId.Text = Program.instructors[lstInstructors.SelectedIndices[0]].Identification;
            txtFirstName.Text = Program.instructors[lstInstructors.SelectedIndices[0]].FirstName;
            txtLastName.Text = Program.instructors[lstInstructors.SelectedIndices[0]].LastName;

            // get department index
            for (int i = 0; i < Program.departments.Count; i++)
            {
                if (Program.instructors[lstInstructors.SelectedIndices[0]].Department_Id == Program.departments[i].DepartmentId)
                {
                    cboDepartments.Text = cboDepartments.Items[i].ToString();
                    break;
                }
            }

            cmdAddInstructor.Text = "Update";
            cmdCancel_instructor.Visible = true;
        }
        // edit classroom item
        private void EditClassroom()
        {
            txtRoomName.Text = Program.classRooms[lstClassRooms.SelectedIndices[0]].Name;
            cboRoomType.Text = Program.classRooms[lstClassRooms.SelectedIndices[0]].RoomType;

            cmdRoomAd.Text = "Update";
            cmdCancel_classroom.Visible = true;
        }
        //
        //  REMOVE ALL
        //
        // remove all
        private void RemoveAll_Courses()
        {
            Program.courses.Clear();
            lstCourses.Items.Clear();
            lbltotal_course.Text = "Total: 0";
        }
        private void RemoveAll_Instructor()
        {
            Program.instructors.Clear();
            lstInstructors.Items.Clear();
        }
        private void RemoveAll_ClassRoom()
        {
            Program.classRooms.Clear();
            lstClassRooms.Items.Clear();
            lbltotal_classroom.Text = "Total: 0";
        }
        //
        // UPDATE ITEMS
        //
        private void UpdateCourse()
        {
            if (txtCourseCode.Text != "" && txtCourseDesc.Text != "" && cboCourseUnit.Text != "")
            {
                // save to storage variable
                Program.courses[lstCourses.SelectedIndices[0]].Coursecode = txtCourseCode.Text;
                Program.courses[lstCourses.SelectedIndices[0]].CourseDescription = txtCourseDesc.Text;
                Program.courses[lstCourses.SelectedIndices[0]].Units = int.Parse(cboCourseUnit.Text);

                // update to listview
                li = lstCourses.SelectedItems[0];
                li.Text = txtCourseCode.Text;
                li.SubItems[1].Text = txtCourseDesc.Text;
                li.SubItems[2].Text = cboCourseUnit.Text;

                // clear
                txtCourseDesc.Text = "";
                txtCourseCode.Text = "";
                cboCourseUnit.Text = "";
                txtCourseCode.Focus();

                // change button & hide "cancel" button
                cmdCourseAdd.Text = "Add";
                cmdCancel_course.Visible = false;

            }
            else
            {
                MessageBox.Show("Incomplete data entered", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateInstructor()
        {
            if (txtId.Text != "" && txtFirstName.Text != "" && txtLastName.Text != "" && (cboDepartments.Text != "" || cboDepartments.Text != "(Select from the list)"))
            {
                // save to storage variable
                Program.instructors[lstInstructors.SelectedIndices[0]].Identification = txtId.Text;
                Program.instructors[lstInstructors.SelectedIndices[0]].FirstName = txtFirstName.Text;
                Program.instructors[lstInstructors.SelectedIndices[0]].LastName = txtLastName.Text;
                Program.instructors[lstInstructors.SelectedIndices[0]].Department_Id = Program.departments[cboDepartments.SelectedIndex].DepartmentId;
                Program.instructors[lstInstructors.SelectedIndices[0]].Department_Description = Program.departments[cboDepartments.SelectedIndex].DepartmentDescription;

                // update to listbox
                lstInstructors.Items.Clear();
                for (int i = 0; i < Program.instructors.Count; i++)
                {
                    lstInstructors.Items.Add(string.Concat(Program.instructors[i].FirstName, " ", Program.instructors[i].LastName));
                }

                // clear
                txtId.Text = string.Empty;
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                cboDepartments.Text = "(Select from the list)";
                cmdGenerateId.Focus();

                // change button & hide "cancel" button
                cmdAddInstructor.Text = "Add";
                cmdCancel_instructor.Visible = false;
            }
            else
            {
                MessageBox.Show("Incomplete data entered", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateClassroom()
        {
            if (txtRoomName.Text != "" && cboRoomType.Text != "")
            {
                //save to storage variables
                Program.classRooms[lstClassRooms.SelectedIndices[0]].Name = txtRoomName.Text;
                Program.classRooms[lstClassRooms.SelectedIndices[0]].RoomType = cboRoomType.Text;

                //update to listview
                li = lstClassRooms.SelectedItems[0];
                li.Text = txtRoomName.Text;
                li.SubItems[1].Text = cboRoomType.Text;

                // clear
                txtRoomName.Text = "";
                cboRoomType.Text = "";
                cboRoomType.SelectedItem = null;

                // change button & hide "cancel" button
                cmdRoomAd.Text = "Add";
                cmdCancel_classroom.Visible = false;
            }
            else
            {
                MessageBox.Show("Incomplete data entered", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //================================
        #endregion

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure you want to close the application?", "Exit confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.docStatus == "Not Activated" || Program.docStatus == "Deactivated")
            {
                if (MessageBox.Show("Do you want to save the changes before you log-out?", "Confirm save changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    new form_SaveProgress().ShowDialog();
                    this.Hide();

                    //clear user
                    Program.currentUser_userName = string.Empty;
                    Program.currentuser_firstName = string.Empty;
                    Program.currentuser_lastName = string.Empty;

                    new form_Load_not().ShowDialog();

                    Program.loginForm.Show();
                }
                else
                {
                    this.Hide();

                    //clear user
                    Program.currentUser_userName = string.Empty;
                    Program.currentuser_firstName = string.Empty;
                    Program.currentuser_lastName = string.Empty;

                    new form_Load_not().ShowDialog();

                    Program.loginForm.Show();
                }
            }
            else
            {
                this.Hide();
                Program.loginForm.Show();
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            // display current user to status bar
            sttsUser.Text = string.Concat(Program.currentuser_firstName," ",Program.currentuser_lastName," (",Program.currentUser_userName,")");
            sttsUser.Visible = true;        
        }

        private void cmdRooms_Click_1(object sender, EventArgs e)
        {
            ChangeMenu(pnlClassRooms, cmdClassRooms, txtRoomName);
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure you want to close the application?", "Exit confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void cmdCourses_Click(object sender, EventArgs e)
        {
            ChangeMenu(pnlCourses, cmdCourses, txtCourseCode);
        }

        private void cmdCourseAdd_Click(object sender, EventArgs e)
        {
            if (cmdCourseAdd.Text == "Add")
            {
                if (MessageBox.Show("Continue to add course?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    AddCourse();                
                }
            }
            else
            {
                if (MessageBox.Show("Continue to update course?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    UpdateCourse();
                }
            }
        }

        private void cmdRoomAd_Click(object sender, EventArgs e)
        {
            if (cmdRoomAd.Text == "Add")
            {
                if (MessageBox.Show("Continue to add classroom?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    AddRoom();
                }
            }
            else
            {
                if (MessageBox.Show("Continue to update classroom?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    UpdateClassroom();
                }
            }
        }

        private void cmdAddInstructor_Click(object sender, EventArgs e)
        {
            if (cmdAddInstructor.Text == "Add")
            {
                if (MessageBox.Show("Continue to add instructor?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    AddInstructor();
                }
            }
            else
            {
                if (MessageBox.Show("Continue to update instructor?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    UpdateInstructor();
                }
            }
        }

        private void cmdProgAdd_Dept1_Click(object sender, EventArgs e)
        {
            AddProgram(txtProgCode_Dept1, txtProgDesc_Dept1, lstProgDept1, cboSectProg_Dept1);
        }

        private void cmdProgAdd_Dept2_Click(object sender, EventArgs e)
        {
            AddProgram(txtProgCode_Dept2, txtProgDesc_Dept2, lstProgDept2, cboSectProg_Dept2);
        }

        private void cmdProgAdd_Dept3_Click(object sender, EventArgs e)
        {
            AddProgram(txtProgCode_Dept3, txtProgDesc_Dept3, lstProgDept3, cboSectProg_Dept3);
        }

        private void cmdProgAdd_Dept4_Click(object sender, EventArgs e)
        {
            AddProgram(txtProgCode_Dept4, txtProgDesc_Dept4, lstProgDept4, cboSectProg_Dept4);
        }

        private void cmdSectAdd_Dept1_Click(object sender, EventArgs e)
        {
            AddSection(txtSectName_Dept1, cboSectYrLvl_Dept1, txtSectDensity_Dept1, cboSectProg_Dept1, lstSect_Dept1, lblSectTotal_Dept1);
        }

        private void cmdSectAdd_Dept2_Click(object sender, EventArgs e)
        {
            AddSection(txtSectName_Dept2, cboSectYrLvl_Dept2, txtSectDensity_Dept2, cboSectProg_Dept2, lstSect_Dept2, lblSectTotal_Dept2);
        }

        private void cmdSectAdd_Dept3_Click(object sender, EventArgs e)
        {
            AddSection(txtSectName_Dept3, cboSectYrLvl_Dept3, txtSectDensity_Dept3, cboSectProg_Dept3, lstSect_Dept3, lblSectTotal_Dept3);
        }

        private void cmdSectAdd_Dept4_Click(object sender, EventArgs e)
        {
            AddSection(txtSectName_Dept4, cboSectYrLvl_Dept4, txtSectDensity_Dept4, cboSectProg_Dept4, lstSect_Dept4, lblSectTotal_Dept4);
        }

        private void cmdSave_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save the datas to the database now?","Save confirmation",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                new form_SaveProgress().ShowDialog();
            }
        }

        private void lotoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save the datas to the database now?", "Save confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                new form_SaveProgress().ShowDialog();
            }
        }

        private void cmdGenerateId_Click(object sender, EventArgs e)
        {
            int idnum = 0;

            if (Program.instructors.Count == 0)
            {
                txtId.Text = "2002000001";
            }
            else
            {
            generate:
                idnum = new Random().Next(0, 999);

                txtId.Text = string.Concat("2002000", idnum);

                foreach (Instructor r in Program.instructors)
                {
                    if (r.Identification == txtId.Text)
                    {
                        goto generate;
                    }
                }
            }

        }

        private void cmdDept3_Click(object sender, EventArgs e)
        {
            ChangeMenu(pnlDept3, cmdDept3, txtProgCode_Dept3);
            current_departmentId = "Dpt-3";
        }

        private void cmdDept1_Click(object sender, EventArgs e)
        {
            ChangeMenu(pnlDept1, cmdDept1, txtProgCode_Dept1);
            current_departmentId = "Dpt-1";
        }

        private void cmdDept4_Click(object sender, EventArgs e)
        {
            ChangeMenu(pnlDept4, cmdDept4, txtProgCode_Dept4);
            current_departmentId = "Dpt-4";
        }

        private void cmdDept2_Click(object sender, EventArgs e)
        {
            ChangeMenu(pnlDept2, cmdDept2, txtProgCode_Dept2);
            current_departmentId = "Dpt-2";
        }

        private void cmdInstructors_Click(object sender, EventArgs e)
        {
            ChangeMenu(pnlInstructors, cmdInstructors, cmdGenerateId);
        }

        private void sendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new form_ActivateSchedule().ShowDialog();
        }

        private void optAbout_Developer_Click(object sender, EventArgs e)
        {
            new form_Developer().ShowDialog();
        }

        private void optAbout_System_Click(object sender, EventArgs e)
        {
            new form_System().ShowDialog();
        }

        private void optView_Account_Click(object sender, EventArgs e)
        {
            new form_Account().ShowDialog();
        }

        private void optDocument_Description_Click(object sender, EventArgs e)
        {
            new form_DocumentUpdate().ShowDialog();
        }

        private void optDocument_Status_Click(object sender, EventArgs e)
        {
            new form_StatusUpdate().ShowDialog();
        }

        private void optView_SchedulingStatus_Click(object sender, EventArgs e)
        {
            new form_DPDSchedulingStatus().ShowDialog();
        }

        private void cmdActivate_Click(object sender, EventArgs e)
        {
            if (cmdActivate.Text == "Activate")
            {
                new form_ActivateSchedule().ShowDialog();
            }
            else if (cmdActivate.Text == "Release")
            {
                new form_DPDSchedulingStatus().ShowDialog();
            }
            else
            {
                new form_StatusUpdate().ShowDialog();
            }
        }

        private void lstSect_Dept1_DoubleClick(object sender, EventArgs e)
        {
            AddCoursesToSection(lstSect_Dept1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Program.instructors.Count; i++)
            {
                MessageBox.Show(string.Concat(Program.instructors[i].FirstName," ",Program.instructors[i].LastName,Program.instructors[i].UserName," ",Program.instructors[i].GetPassword()));
            }
        }

        private void lstSect_Dept3_DoubleClick(object sender, EventArgs e)
        {
            AddCoursesToSection(lstSect_Dept3);
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            lstInstructors.ClearSelected();
            txtId.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            cboDepartments.Text = "(Select from the list)";
            cboDepartments.SelectedItem = null;
            cmdGenerateId.Focus();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(Program.ActivateResource().ToString());
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentMenu.Name == cmdCourses.Name)
            {
                if (lstCourses.SelectedItems.Count != 0)
                {
                    if (MessageBox.Show("Are you sure you want to remove the course?","Confirm remove course",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        RemoveCourse();                    
                    }
                }
            }
            else if (currentMenu.Name == cmdInstructors.Name)
            {
                if (lstInstructors.SelectedItems.Count != 0)
                {
                    if (MessageBox.Show("Are you sure you want to remove instructor?", "Confirm remove instructor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        RemoveInstructor();

                        //clear controls/fields
                        txtId.Text = "";
                        txtFirstName.Text = "";
                        txtLastName.Text = "";
                        cboDepartments.Text = "(Select from the list)";
                        cmdGenerateId.Focus();
                    }
                }
            }
            else if (currentMenu.Name == cmdClassRooms.Name)
            {
                if (lstClassRooms.SelectedItems.Count != 0)
                {
                    if (MessageBox.Show("Are you sure you want to remove classroom?", "Confirm remove classroom", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        RemoveClassroom();
                    }
                }
            }
        }

        private void removeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentMenu.Name == cmdCourses.Name)
            {
                if (MessageBox.Show("Are you sure you want to remove all courses?", "Confirm remove all course", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    RemoveAll_Courses();                
                }
            }
            else if (currentMenu.Name == cmdInstructors.Name)
            {
                if (MessageBox.Show("Are you sure you want to remove all instructors?", "Confirm remove all instructors", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    RemoveAll_Instructor();

                    //clear controls/fields
                    txtId.Text = "";
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    cboDepartments.Text = "(Select from the list)";
                    cmdGenerateId.Focus();
                }
            }
            else if (currentMenu.Name == cmdClassRooms.Name)
            {
                if (MessageBox.Show("Are you sure you want to remove all classrooms?", "Confirm remove all classrooms", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    RemoveAll_ClassRoom();
                }
            }
        }

        private void cmdCancel_course_Click(object sender, EventArgs e)
        {
            txtCourseCode.Text = "";
            txtCourseDesc.Text = "";
            cboCourseUnit.Text = "";

            cmdCourseAdd.Text = "Add";
            lstCourses.SelectedItems.Clear();

            cmdCancel_course.Visible = false;
        }

        private void cmdCancel_instructor_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            cboDepartments.Text = "(Select from the list)";

            cmdAddInstructor.Text = "Add";
            lstInstructors.SelectedItems.Clear();

            cmdCancel_instructor.Visible = false;
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (currentMenu.Name == cmdCourses.Name)
            {
                if (lstCourses.SelectedItems.Count != 0)
                {
                    EditCourse();
                }
            }
            else if (currentMenu.Name == cmdInstructors.Name)
            {
                if (lstInstructors.SelectedItems.Count != 0)
                {
                    EditInstructor();
                }                
            }
            else if (currentMenu.Name == cmdClassRooms.Name)
            {
                if (lstClassRooms.SelectedItems.Count != 0)
                {
                    EditClassroom();
                }
            }
        }

        private void cmdCancel_classroom_Click(object sender, EventArgs e)
        {
            txtRoomName.Text = "";
            cboRoomType.Text = "";

            cmdRoomAd.Text = "Add";
            lstClassRooms.SelectedItems.Clear();

            cmdCancel_classroom.Visible = false;
        }

        private void optInstructors_Click(object sender, EventArgs e)
        {
            Program.instructors_form.ShowDialog();
        }

        private void lstCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdCourseAdd.Text == "Update")
            {
                txtCourseCode.Text = string.Empty;
                txtCourseDesc.Text = string.Empty;
                cboCourseUnit.Text = string.Empty;
                cmdCourseAdd.Text = "Add";
                cmdCancel_course.Visible = false;
            }
        }

        private void lstInstructors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdAddInstructor.Text == "Update")
            {
                txtId.Text = string.Empty;
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                cboDepartments.Text = "(Select from the list)";
                cboDepartments.SelectedItem = null;
                cmdAddInstructor.Text = "Add";
                cmdCancel_instructor.Visible = false;
            }
        }

        private void lstClassRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdRoomAd.Text == "Update")
            {
                txtRoomName.Text = string.Empty;
                cboRoomType.Text = string.Empty;
                cboRoomType.SelectedItem = null;
                cmdRoomAd.Text = "Add";
                cmdCancel_classroom.Visible = false;
            }
        }

        private void optSections_Click(object sender, EventArgs e)
        {
            new form_Sections().ShowDialog();
        }

        private void lstSect_Dept4_DoubleClick(object sender, EventArgs e)
        {
            AddCoursesToSection(lstSect_Dept4);
        }
    }
}