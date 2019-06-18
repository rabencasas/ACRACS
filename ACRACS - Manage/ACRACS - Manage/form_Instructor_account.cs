using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace ACRACS___Manage
{
    public partial class form_Instructor_account : Form
    {
        public form_Instructor_account()
        {
            InitializeComponent();
        }

        private void form_Instructor_account_Load(object sender, EventArgs e)
        {
            Text = string.Concat(Program.instructors[Program.instructors_form.selectedInstructor_index].FirstName, " ", Program.instructors[Program.instructors_form.selectedInstructor_index].LastName);

            lbl_Id.Text = Program.instructors[Program.instructors_form.selectedInstructor_index].Identification;
            lbl_FirstName.Text = Program.instructors[Program.instructors_form.selectedInstructor_index].FirstName;
            lbl_LastName.Text = Program.instructors[Program.instructors_form.selectedInstructor_index].LastName;
            lbl_Email.Text = Program.instructors[Program.instructors_form.selectedInstructor_index].Email_Address;
            lbl_UserName.Text = Program.instructors[Program.instructors_form.selectedInstructor_index].UserName;
        }

        private void cmd_PassWord_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = Program.dbConnection;
                cmd.CommandText = "SELECT passWord FROM tbl_User FULL JOIN tbl_Instructor ON tbl_User.userName = tbl_Instructor.instrUserName WHERE tbl_Instructor.instrId = @1";
                cmd.Parameters.AddWithValue("@1", int.Parse(lbl_Id.Text));
                cmd.Connection.Open();
                Program.dr = cmd.ExecuteReader();

                while (Program.dr.Read())
                {
                    txt_password.Text = Program.dr["passWord"].ToString();
                }

                Program.dr.Close();
                Program.dr.Dispose();
                cmd.Connection.Close();
            }
        }

        private void form_Instructor_account_FormClosed(object sender, FormClosedEventArgs e)
        {
            txt_password.Text = "";
        }
    }
}
