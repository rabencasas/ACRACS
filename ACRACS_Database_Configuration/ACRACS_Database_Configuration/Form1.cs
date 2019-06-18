using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ACRACS_Database_Configuration
{
    public partial class Form1 : Form
    {
        private bool isAddAuthDetails = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void cmd_save_Click(object sender, EventArgs e)
        {
            if (isAddAuthDetails)
            {
                if (cbo_app.SelectedItem != null)
                {
                    if (txt_id.Text != "" && txt_password.Text != "")
                    {
                        Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), cbo_app.SelectedItem.ToString()));
                        File.WriteAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), cbo_app.SelectedItem.ToString()), @"\config.dbc"), string.Concat(txt_id.Text, "\t", txt_password.Text));
                        txt_id.Clear();
                        txt_id.Enabled = false;
                        txt_password.Clear();
                        txt_password.Enabled = false;
                        cbo_app.SelectedItem = null;
                        cbo_app.Enabled = false;

                        cmd_Cancel.Enabled = false;
                        cmd_save.Enabled = false;

                        MessageBox.Show("Done!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Please complete the required fields.", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select an application.", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbo_app.Focus();
                }
            }
            else
            {
                if (cbo_app.SelectedItem != null)
                {
                    if (MessageBox.Show("Are you sure to use the default authentication details?","Use default authentication details",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (File.Exists(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), cbo_app.SelectedItem.ToString()), @"\config.dbc")))
                        {
                            File.Delete(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), cbo_app.SelectedItem.ToString()), @"\config.dbc"));
                            txt_id.Clear();
                            txt_id.Enabled = false;
                            txt_password.Clear();
                            txt_password.Enabled = false;
                            cbo_app.SelectedItem = null;
                            cbo_app.Enabled = false;

                            cmd_Cancel.Enabled = false;
                            cmd_save.Enabled = false;

                            MessageBox.Show("Done!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Done!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select an application.", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbo_app.Focus();
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            cmd_create.Focus();
        }

        private void cmd_Cancel_Click(object sender, EventArgs e)
        {
            cbo_app.Text = string.Empty;
            cbo_app.SelectedItem = null;
            cbo_app.Enabled = false;
            txt_id.Clear();
            txt_id.Enabled = false;
            txt_password.Clear();
            txt_password.Enabled = false;

            cmd_save.Enabled = false;
            cmd_Cancel.Enabled = false;

            cmd_create.Focus();
        }

        private void cmd_create_Click(object sender, EventArgs e)
        {
            isAddAuthDetails = true;

            txt_id.Enabled = true;
            txt_password.Enabled = true;
            cmd_Cancel.Enabled = true;
            cmd_save.Enabled = true;

            cbo_app.Enabled = true;
            cbo_app.Focus();
        }

        private void cmd_delete_Click(object sender, EventArgs e)
        {
            isAddAuthDetails = false;

            // clear control values
            txt_id.Clear();
            txt_password.Clear();

            // disable controls
            txt_id.Enabled = false;
            txt_password.Enabled = false;
            
            cmd_Cancel.Enabled = true;
            cmd_save.Enabled = true;

            cbo_app.Enabled = true;
            cbo_app.Focus();
        }

        private void cbo_app_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_app.SelectedItem != null)
            {
                if (isAddAuthDetails)
                {
                    txt_id.Enabled = true;
                    txt_password.Enabled = true;
                }
                else
                {
                    txt_id.Enabled = false;
                    txt_password.Enabled = false;
                }
            }
        }

        private void cmd_Cancel1_Click(object sender, EventArgs e)
        {
            txt_instanceName.Enabled = false;
            cmd_Save1.Enabled = false;
            cmd_Cancel1.Enabled = false;
            chk_NamedInstance.Checked = false;
            cbo_app1.Text = string.Empty;
            cbo_app1.SelectedItem = null;
            cbo_app1.Enabled = false;
            
            chk_NamedInstance.Focus();
        }

        private void cmd_Close_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void chk_NamedInstance_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_NamedInstance.Checked)
            {
                txt_instanceName.Enabled = true;
                cmd_Cancel1.Enabled = true;
                cmd_Save1.Enabled = true;
                cbo_app1.Enabled = true;
                txt_instanceName.Focus();
            }
            else
            {
                txt_instanceName.Enabled = false;
                cmd_Cancel1.Enabled = false;
                cmd_Save1.Enabled = false;
            }
        }

        private void cmd_Save1_Click(object sender, EventArgs e)
        {
            if (cbo_app1.SelectedItem != null)
            {
                if (txt_instanceName.Text != string.Empty)
                {
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), cbo_app1.SelectedItem.ToString()));
                    File.WriteAllText(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), cbo_app1.SelectedItem.ToString()), @"\config_instance.dbc"), txt_instanceName.Text);
                    txt_id.Clear();
                    txt_id.Enabled = false;
                    txt_password.Clear();
                    txt_password.Enabled = false;
                    cbo_app.SelectedItem = null;
                    cbo_app.Enabled = false;

                    cmd_Cancel.Enabled = false;
                    cmd_save.Enabled = false;

                    MessageBox.Show("Done!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please input an instance name.", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an application.", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbo_app1.Focus();
            }
        }

        private void cmd_removeInstance_Click(object sender, EventArgs e)
        {
            cbo_app1.Enabled = true;
            cbo_app1.Focus();

            if (cbo_app1.SelectedItem != null)
            {
                if (MessageBox.Show("Are you sure to remove currently saved instance name?", "Remove saved instance name", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (File.Exists(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), cbo_app1.SelectedItem.ToString()), @"\config_instance.dbc")))
                    {
                        File.Delete(string.Concat(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), cbo_app1.SelectedItem.ToString()), @"\config_instance.dbc"));
                        txt_id.Clear();
                        txt_id.Enabled = false;
                        txt_password.Clear();
                        txt_password.Enabled = false;
                        cbo_app.SelectedItem = null;
                        cbo_app.Enabled = false;

                        cmd_Cancel.Enabled = false;
                        cmd_save.Enabled = false;

                        MessageBox.Show("Done!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Done!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an application.", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbo_app1.Focus();
            }
        }
    }
}
