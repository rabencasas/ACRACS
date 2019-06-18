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
    public partial class form_Account : Form
    {
        public form_Account()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void form_Account_Load(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = Program.dbConnection;
                cmd.CommandText = "SELECT * FROM tbl_User WHERE userPosition = 'Administrator'";
                cmd.Connection.Open();
                Program.dr = cmd.ExecuteReader();

                while (Program.dr.Read())
                {
                    txtUserName.Text = Program.dr["userName"].ToString();
                    txtFirstName.Text = Program.dr["firstName"].ToString();
                    txtLastName.Text = Program.dr["lastName"].ToString();
                    txtEmail.Text = Program.dr["emailAddr"].ToString();
                }

                Program.dr.Close();
                Program.dr.Dispose();
                cmd.Connection.Close();
            }
        }
    }
}
