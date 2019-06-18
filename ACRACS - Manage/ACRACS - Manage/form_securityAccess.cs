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
    public partial class form_securityAccess : Form
    {
        //internal variables
        internal string username;
        internal string selectedInstrID;

        public form_securityAccess()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void form_securityAccess_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && txt_password.Text != string.Empty)
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = Program.dbConnection;
                        cmd.Parameters.Clear();
                        cmd.CommandText = "SELECT * FROM tbl_User WHERE username = @uname";
                        cmd.Parameters.AddWithValue("@uname", username);

                        cmd.Connection.Open();
                        Program.dr = cmd.ExecuteReader();

                        while (Program.dr.Read())
                        {
                            if (txt_password.Text == Program.dr["passWord"].ToString())
	                        {
		                        for (int i = 0; i < Program.instructors.Count; i++)
                                {
                                    if (Program.instructors[i].Identification == selectedInstrID)
                                    {
                                        txt_message.Text = string.Concat(Program.instructors[i].FirstName, ' ', Program.instructors[i].LastName, "'s password is:");
                                        txt_instrPassword.Text = Program.instructors[i].GetPassword();

                                        this.Height = 182;

                                        break;
                                    }
                                }
	                        }
                            else
	                        {
                                MessageBox.Show("The password is incorrect.", "Incorrect password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txt_password.Clear();
	                        }
                        }
                        Program.dr.Close();
                        
                        cmd.Connection.Close();
                    }

                }
                catch (Exception ex)
                {
                    Program.dr.Close();
                    Program.dbConnection.Close();
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
