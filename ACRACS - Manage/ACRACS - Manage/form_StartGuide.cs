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
    public partial class frmStartGuide : Form
    {
        private bool isSet;

        public frmStartGuide()
        {
            InitializeComponent();
        }

        private void frmStartGuide_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isSet == true)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void frmStartGuide_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.mainForm.pnlTopHeader.Visible = true;
            Program.mainForm.pnlToolBox.Visible = true;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit the application?", "Exit confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void cmdDone_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTitle.Text != "" && txtSYFrom.Text != "" && txtSYTo.Text != "" && (rdo1stSem.Checked || rdo2ndSem.Checked))
                {
                    Program.docDescription = txtTitle.Text;
                    Program.docSyFrom = int.Parse(txtSYFrom.Text);
                    Program.docSyTo = int.Parse(txtSYTo.Text);
                    Program.docStatus = "Not Activated";

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

                    Program.mainForm.pnlTopHeader.Visible = true;
                    Program.mainForm.pnlToolBox.Visible = true;
                    Program.mainForm.optView_SchedulingStatus.Enabled = false;

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please provide all the necessary datas.", "Incomplete data", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("A system error occured, please contact the developer with the following error message: ", ex.ToString()), "System error occured", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void txtSYFrom_Leave(object sender, EventArgs e)
        {
            if (txtSYFrom.Text != "")
            {
                txtSYTo.Text = (int.Parse(txtSYFrom.Text) + 1).ToString();
            }
        }
    }
}
