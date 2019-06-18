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
    public partial class form_Developer : Form
    {
        public form_Developer()
        {
            InitializeComponent();
        }

        private void form_Developer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void form_Developer_Shown(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                this.Opacity += .01;
            }
        }
    }
}
