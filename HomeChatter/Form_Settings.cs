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
using System.Windows.Forms;

namespace HomeChatter
{
    public partial class Form_Settings : Form
    {
        public Form_Settings()
        {
            InitializeComponent();
            checkBox_rememberServerIp.Checked = Program.Settings.RememberServerIps;
            checkBox_rememberServerName.Checked = Program.Settings.RememberServerNames;
            checkBox_rememberUserName.Checked = Program.Settings.RememberUserNames;
            checkBox_clearTextBox.Checked = Program.Settings.SelectAllTextWhenClickOnTextBox;
            checkBox_playSound.Checked = Program.Settings.PlaySoundForNewMessages;
            checkBox_alwaysPlaySound.Checked = Program.Settings.PlaySoundForNewMessagesAlways;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Save
        private void button1_Click(object sender, EventArgs e)
        {
            Program.Settings.RememberServerIps = checkBox_rememberServerIp.Checked;
            Program.Settings.RememberServerNames = checkBox_rememberServerName.Checked;
            Program.Settings.RememberUserNames = checkBox_rememberUserName.Checked;
            Program.Settings.SelectAllTextWhenClickOnTextBox = checkBox_clearTextBox.Checked;
            Program.Settings.PlaySoundForNewMessages = checkBox_playSound.Checked;
            Program.Settings.PlaySoundForNewMessagesAlways = checkBox_alwaysPlaySound.Checked;
            Program.Settings.Save();
            Close();
        }
        // Defaults
        private void button3_Click(object sender, EventArgs e)
        {
            checkBox_rememberServerIp.Checked = true;
            checkBox_rememberServerName.Checked = true;
            checkBox_rememberUserName.Checked = false;
            checkBox_clearTextBox.Checked = true;
            checkBox_playSound.Checked = true;
            checkBox_alwaysPlaySound.Checked = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.Settings.UserNames = new System.Collections.Specialized.StringCollection();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.Settings.ServerNames = new System.Collections.Specialized.StringCollection();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.Settings.ServerIPS = new System.Collections.Specialized.StringCollection();
        }
    }
}
