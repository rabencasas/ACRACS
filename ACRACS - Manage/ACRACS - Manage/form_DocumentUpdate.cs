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
    public partial class form_DocumentUpdate : Form
    {
        public form_DocumentUpdate()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdDone_Click(object sender, EventArgs e)
        {
            Program.docDescription = txtTitle.Text;
            Program.docSyFrom = int.Parse(txtSYFrom.Text);
            Program.docSyTo = int.Parse(txtSYTo.Text);

            if (rdo1stSem.Checked == true)
            {
                Program.docSemLevel = "1st semester";
            }
            else
            {
                Program.docSemLevel = "2nd semester";
            }

            Program.mainForm.lblDocTitle.Text = Program.docDescription;
            Program.mainForm.lblDocInfo.Text = string.Concat("SCHOOL YEAR: ", Program.docSyFrom, " - ", Program.docSyTo, ", ", Program.docSemLevel);

            this.Close();
        }

        private void txtSYFrom_Leave(object sender, EventArgs e)
        {
            txtSYTo.Text = (int.Parse(txtSYFrom.Text) + 1).ToString();
        }
    }
}
