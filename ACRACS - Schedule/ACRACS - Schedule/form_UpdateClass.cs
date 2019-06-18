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
    public partial class form_UpdateClass : Form
    {
        public form_UpdateClass()
        {
            InitializeComponent();
        }

        private void DisplayTime()
        {
            DateTime timeloader = DateTime.Parse("6:00 AM");
            int ctr = 0;
            ListViewItem itmtime = new ListViewItem(timeloader.ToShortTimeString());

            do
            {
                cboFromTime.Items.Add(timeloader.AddMinutes(ctr).ToShortTimeString());
                cboToTime.Items.Add(timeloader.AddMinutes(ctr).ToShortTimeString());


                ctr += 30;

            } while (timeloader.AddMinutes(ctr).Hour < DateTime.Parse("11:00 PM").Hour);

            cboFromTime.Items.Add("11:00 PM");
            cboToTime.Items.Add("11:00 PM");

            itmtime = null;
        }


        private void form_UpdateClass_Load(object sender, EventArgs e)
        {

        }
    }
}
