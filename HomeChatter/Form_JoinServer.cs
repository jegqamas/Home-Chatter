/* This file is part of Home Chatter
 * A program that allows to chat using basic LAN connection.
 *
 * Copyright © Ala Ibrahim Hadid 2013
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeChatter
{
    public partial class Form_JoinServer : Form
    {
        public Form_JoinServer()
        {
            InitializeComponent();
            // Load servers
            if (Program.Settings.RememberServerNames)
            {
                if (Program.Settings.ServerNames == null)
                    Program.Settings.ServerNames = new System.Collections.Specialized.StringCollection();
                foreach (string server in Program.Settings.ServerNames)
                {
                    comboBox_ServerName.Items.Add(server);
                }
                if (comboBox_ServerName.Items.Count > 0)
                    comboBox_ServerName.SelectedIndex = comboBox_ServerName.Items.Count - 1;
            }
            // Load ips
            if (Program.Settings.RememberServerIps)
            {
                if (Program.Settings.ServerIPS == null)
                    Program.Settings.ServerIPS = new System.Collections.Specialized.StringCollection();
                foreach (string ip in Program.Settings.ServerIPS)
                {
                    comboBox_ip.Items.Add(ip);
                }
                if (comboBox_ip.Items.Count > 0)
                    comboBox_ip.SelectedIndex = comboBox_ip.Items.Count - 1;
            }
            // Load names
            if (Program.Settings.RememberUserNames)
            {
                if (Program.Settings.UserNames == null)
                    Program.Settings.UserNames = new System.Collections.Specialized.StringCollection();
                foreach (string user in Program.Settings.UserNames)
                {
                    comboBox_userName.Items.Add(user);
                }
                if (comboBox_userName.Items.Count > 0)
                    comboBox_userName.SelectedIndex = comboBox_userName.Items.Count - 1;
            }
            // Load settings
            checkBox_rememberServerIP.Checked = Program.Settings.RememberServerIps;
            checkBox_rememberServerName.Checked = Program.Settings.RememberServerNames;
            checkBox_rememberUser.Checked = Program.Settings.RememberUserNames;
        }

        public string UserName
        { get { return comboBox_userName.Text; } }
        public string Password
        { get { return textBox1.Text; } }
        public string ServerName
        { get { return comboBox_ServerName.Text; } }
        public string ServerIP
        { get { return comboBox_ip.Text; } }
        public int ServerPort
        { get { return (int)numericUpDown_port.Value; } }
        // Ok
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox_userName.Text == "")
            {
                MessageBox.Show(Program.ResourceManager.GetString("Message_YouMustEnterUserName"));
                return;
            }
            if (comboBox_ServerName.Text == "")
            {
                MessageBox.Show(Program.ResourceManager.GetString("Message_YouMustEnterTheServerName"));
                return;
            }
            if (comboBox_ip.Text == "")
            {
                MessageBox.Show(Program.ResourceManager.GetString("Message_PleaseEnterServerIPAddressFirst"));
                return;
            }
            // remember...
            Program.Settings.RememberUserNames = checkBox_rememberUser.Checked;
            Program.Settings.RememberServerNames = checkBox_rememberServerName.Checked;
            Program.Settings.RememberServerIps = checkBox_rememberServerIP.Checked;
            if (Program.Settings.RememberServerNames)
            {
                if (Program.Settings.ServerNames == null)
                    Program.Settings.ServerNames = new System.Collections.Specialized.StringCollection();
                if (!Program.Settings.ServerNames.Contains(comboBox_ServerName.Text))
                    Program.Settings.ServerNames.Add(comboBox_ServerName.Text);
            }
            if (Program.Settings.RememberUserNames)
            {
                if (Program.Settings.UserNames == null)
                    Program.Settings.UserNames = new System.Collections.Specialized.StringCollection();
                if (!Program.Settings.UserNames.Contains(comboBox_userName.Text))
                    Program.Settings.UserNames.Add(comboBox_userName.Text);
            } 
            if (Program.Settings.RememberServerIps)
            {
                if (Program.Settings.ServerIPS == null)
                    Program.Settings.ServerIPS = new System.Collections.Specialized.StringCollection();
                if (!Program.Settings.ServerIPS.Contains(comboBox_ip.Text))
                    Program.Settings.ServerIPS.Add(comboBox_ip.Text);
            }
            Program.Settings.Save();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
