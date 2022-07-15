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
    public partial class Form_CreateServer : Form
    {
        public Form_CreateServer()
        {
            InitializeComponent();
            checkBox_remeberUser.Checked = Program.Settings.RememberUserNames;
            checkBox_rememberServer.Checked = Program.Settings.RememberServerNames;
            // Load servers
            if (Program.Settings.RememberServerNames)
            {
                if (Program.Settings.ServerNames == null)
                    Program.Settings.ServerNames = new System.Collections.Specialized.StringCollection();
                foreach (string server in Program.Settings.ServerNames)
                {
                    comboBox_serverName.Items.Add(server);
                }
                if (comboBox_serverName.Items.Count > 0)
                    comboBox_serverName.SelectedIndex = comboBox_serverName.Items.Count - 1;
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
        }
        public string UserName
        { get { return comboBox_userName.Text; } }
        public string Password
        { get { return textBox_password.Text; } }
        public string ServerName
        { get { return comboBox_serverName.Text; } }
        public int MaxUsersNumber
        { get { return (int)numericUpDown_maxUsers.Value; } }
        // Cancel
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Ok
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox_userName.Text == "")
            {
                MessageBox.Show(Program.ResourceManager.GetString("Message_YouMustEnterUserName"));
                return;
            }
            if (comboBox_serverName.Text == "")
            {
                MessageBox.Show(Program.ResourceManager.GetString("Message_YouMustEnterTheServerName"));
                return;
            }
            // create the server
            RemotingObject theObject = new RemotingObject();

            theObject.IsPasswordProtected = textBox_password.Text.Length > 0;
            theObject.Password = textBox_password.Text;

            string serverName = comboBox_serverName.Text.Replace(" ", "_");
            theObject.ServerName = serverName;
            // register the server
            ChatServer.CreateServer(serverName, theObject, (int)numericUpDown_portNumber.Value);
            // remember...
            Program.Settings.RememberUserNames = checkBox_remeberUser.Checked;
            Program.Settings.RememberServerNames = checkBox_rememberServer.Checked;
            if (Program.Settings.RememberServerNames)
            {
                if (Program.Settings.ServerNames == null)
                    Program.Settings.ServerNames = new System.Collections.Specialized.StringCollection();
                if (!Program.Settings.ServerNames.Contains(comboBox_serverName.Text))
                    Program.Settings.ServerNames.Add(comboBox_serverName.Text);
            }
            if (Program.Settings.RememberUserNames)
            {
                if (Program.Settings.UserNames == null)
                    Program.Settings.UserNames = new System.Collections.Specialized.StringCollection();
                if (!Program.Settings.UserNames.Contains(comboBox_userName.Text))
                    Program.Settings.UserNames.Add(comboBox_userName.Text);
            } 
            Program.Settings.Save();
            // close this window
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
