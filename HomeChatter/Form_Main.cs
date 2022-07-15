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
using System.Media;

namespace HomeChatter
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
            LoadSettings();
        }
        private string currentUserName = "";
        private bool isServer = false;
        private RemotingObject remotingObject;
        private int messageIndex;
        private bool isOnline = false;
        private int maxUsers = 0;
        private string currentServerName = "";
        private string currentServerIP = "";
        private int currentServerPort = 0;

        private void LoadSettings()
        {
            //languages
            for (int i = 0; i < Program.SupportedLanguages.Length / 3; i++)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = Program.SupportedLanguages[i, 2];
                item.Checked = Program.SupportedLanguages[i, 0] == Program.Settings.Language;
                languageToolStripMenuItem.DropDownItems.Add(item);
            }
            this.Size = Program.Settings.Win_Size;
            this.Location = Program.Settings.Win_Location;
        }
        private void SaveSettings()
        {
            Program.Settings.Win_Size = this.Size;
            Program.Settings.Win_Location = this.Location;
            Program.Settings.Save();
        }
        private void CreateServer(object sender, EventArgs e)
        {
            if (remotingObject != null)
            {
                if (isOnline)
                {
                    MessageBox.Show(Program.ResourceManager.GetString("Message_YouAreAlreadyLoggedInPleaseLogOutFirst"));
                    return;
                }
            }
            if (ChatServer.Status == ServerStatus.Running)
            {
                MessageBox.Show(Program.ResourceManager.GetString("Message_ServerIsAlreadyCreated"));
                return;
            }
            Form_CreateServer frm = new Form_CreateServer();
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                currentServerName = frm.ServerName;
                maxUsers = frm.MaxUsersNumber;
                LogIn(currentUserName = frm.UserName, frm.Password, ChatServer.GetServerAddress(), true);
            }
        }
        private void JoinServer(object sender, EventArgs e)
        {
            if (remotingObject != null)
            {
                if (isOnline)
                {
                    MessageBox.Show(Program.ResourceManager.GetString("Message_YouAreAlreadyLoggedInPleaseLogOutFirst"));
                    return;
                }
            }
            Form_JoinServer frm = new Form_JoinServer();
            if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                ChatServer.ObjectName = frm.ServerName.Replace(" ", "_");
                currentServerIP = frm.ServerIP;
                currentServerPort = frm.ServerPort;
                LogIn(frm.UserName, frm.Password, ChatServer.BuildAddress(frm.ServerIP, frm.ServerPort), false);
            }
        }
        private void EnablePanels(bool enable)
        {
            panel_usersControlPanel.Visible = enable;
            splitContainer1.Enabled = enable;
            listView1.Items.Clear();
        }
        private void LogIn(string userName, string password, string serverAddress, bool isCreatingServer)
        {
            isServer = isCreatingServer;
            currentUserName = userName;
            // Get the remoting object
            try
            {
                remotingObject = ChatServer.GetServerObject(serverAddress);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Program.ResourceManager.GetString("Message_CantJoinThisServer") + ":\n" + ex.Message);
                return;
            }

            // Enable panels (as admin...)
            if (remotingObject != null)
            {
                if (isCreatingServer)
                {
                    // in this case the user is the admin and creating this server ...
                    try
                    {
                        remotingObject.Join(userName, password, true);
                        remotingObject.IsServerRunning = true;
                        remotingObject.MaxUsersNumber = maxUsers;
                        remotingObject.ServerName = currentServerName;
                        remotingObject.IsPasswordProtected = password.Length > 0;
                        remotingObject.Password = password;
                        richTextBox1.Text = "";
                        textBox_ip.Text = ChatServer.GetServerIPAddress();
                        textBox_port.Text = ChatServer.PortNumber.ToString();
                        textBox_serverName.Text = ChatServer.ObjectName;
                        isOnline = true;

                        remotingObject.SendMessage(Program.ResourceManager.GetString("Message_SessionStarted"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Program.ResourceManager.GetString("Message_CantJoinThisServer") + "\n" + ex.Message);
                        return;
                    }
                    EnablePanels(true);
                }
                else
                {
                    try
                    {
                        remotingObject.Join(userName, password);
                        isOnline = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Program.ResourceManager.GetString("Message_CantJoinThisServer") + "\n" + ex.Message);
                        return;
                    }
                    panel_usersControlPanel.Visible = false;
                    splitContainer1.Enabled = true;
                }
                // Enable timer
                timer1.Start();
                messageIndex = remotingObject.messageIndex - 1;
            }
            else
            {
                MessageBox.Show(Program.ResourceManager.GetString("Message_CantJoinThisServer") + ": " +
                    Program.ResourceManager.GetString("Message_TheRemotingObjectIsCurrepted"));
            }
        }
        private void LogOut()
        {
            if (remotingObject == null)
            {
                return;
            }
            if (isServer)
            {
                if (ChatServer.Status == ServerStatus.Running)
                {
                    if (MessageBox.Show(Program.ResourceManager.GetString("Message_AreYouSure") +
                        "\n" +
                       Program.ResourceManager.GetString("Message_YourPCIsServer_LoggingOutWarning"),
                       Program.ResourceManager.GetString("MessageCaption_LogOut"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        timer1.Stop();
                        remotingObject.LogOut(currentUserName);
                        remotingObject.IsServerRunning = false;
                        ChatServer.KillServer();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                remotingObject.LogOut(currentUserName);
            }
            isOnline = false;
            EnablePanels(false);
        }
        private void SendMessage()
        {
            if (textBox1.Text != "")
            {
                remotingObject.SendMessage(currentUserName + ": " + textBox1.Text);
            }
        }
        private void ShowMessage(string text)
        {
            richTextBox1.Text += text + "\n";
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.ScrollToCaret();
            // Play sound for new messages
            if (Program.Settings.PlaySoundForNewMessages)
            {
                if (!Program.Settings.PlaySoundForNewMessagesAlways) 
                {
                    if (this.ContainsFocus)
                        return;
                }
                try
                {
                    SoundPlayer player = new SoundPlayer(".\\Sounds\\NewMessage.WAV");
                    player.Play();
                }
                catch
                {

                }
            }
        }
        private void AddUserToTheList(User user)
        {
            listView1.Items.Add(user.Name);
            listView1.Items[listView1.Items.Count - 1].SubItems.Add(user.Admin ? Program.ResourceManager.GetString("Yes")
                : Program.ResourceManager.GetString("No"));
        }
        // Check out timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (remotingObject != null)
            {
                // check server status ...
                if (isServer)
                {
                    // server stoped for unexpected reason ...
                    if (ChatServer.Status == ServerStatus.Off)
                    {
                        timer1.Stop();
                        // log out the user
                        remotingObject.LogOut(currentUserName);
                        isOnline = false;
                        ChatServer.KillServer();
                        MessageBox.Show(Program.ResourceManager.GetString("Message_ServerStoppedForUnknownReason"));
                        EnablePanels(false);
                        return;
                    }
                    StatusLabel.Text = Program.ResourceManager.GetString("Status_ServerStatus") + ": " +
                        ChatServer.Status.ToString() + "; " + Program.ResourceManager.GetString("Status_RoomName") + ": " +
                        remotingObject.ServerName +
                        "; " + Program.ResourceManager.GetString("Status_ServerAddress") + ": " +
                        ChatServer.GetServerIPAddress() + ":" + ChatServer.PortNumber +
                        ". " + Program.ResourceManager.GetString("Status_LoggedInAs") + ": " + currentUserName;
                }
                else
                {
                    if (!remotingObject.IsServerRunning)
                    {
                        timer1.Stop();
                        isOnline = false;
                        ChatServer.KillServer();
                        // the server is not running !
                        MessageBox.Show(Program.ResourceManager.GetString("Message_ServerIsNotRunningLoggingOut"));
                        EnablePanels(false);
                        return;
                    }
                    StatusLabel.Text = Program.ResourceManager.GetString("Status_LoggedInAs") + ": " + currentUserName + "; " +
                        Program.ResourceManager.GetString("Status_RoomName")
                        + ": " + remotingObject.ServerName + "; " + Program.ResourceManager.GetString("Status_Address") + ": " +
                        currentServerIP + ":" + currentServerPort;
                }
            }
            // Check if this user still in server
            if (!remotingObject.IsUserExist(currentUserName))
            {
                timer1.Stop();
                isOnline = false;
                ChatServer.KillServer();
                MessageBox.Show(Program.ResourceManager.GetString("Message_LoggedOutFromTheServer"));
                EnablePanels(false);
                return;
            }
            // Messages
            if (this.messageIndex != remotingObject.messageIndex)
            {
                if (this.messageIndex >= 0 & this.messageIndex < remotingObject.messages.Count)
                {
                    ShowMessage(remotingObject.messages[messageIndex]);
                    messageIndex++;
                }
            }
            // Refresh users
            if (listView1.Items.Count != remotingObject.Users.Count)
            {
                listView1.Items.Clear();
                foreach (User user in remotingObject.Users)
                    AddUserToTheList(user);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SendMessage();
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                SendMessage();
        }
        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isServer && ChatServer.Status == ServerStatus.Running)
            {
                if (MessageBox.Show(Program.ResourceManager.GetString("Message_AreYouSure") + "\n" +
                   Program.ResourceManager.GetString("Message_YourPCIsServer_CloseWarning"),
                       Program.ResourceManager.GetString("MessageCaption_Close"),
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true; return;
                }
            }
            // log out the user
            if (remotingObject != null)
            {
                remotingObject.LogOut(currentUserName);
                if (isServer)
                {
                    remotingObject.IsServerRunning = false;
                }
            }
            ChatServer.KillServer();
            // save settings
            SaveSettings();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogOut();
        }

        private void linkLabel_kickOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
            {
                return;
            }
            if (remotingObject == null)
            {
                MessageBox.Show(Program.ResourceManager.GetString("Message_YouCantDoThatNowTheRemotingObjectIsCurrepted"));
                return;
            }
            if (!isServer)
            {
                MessageBox.Show(Program.ResourceManager.GetString("Message_OnlyRoomOwnerCanKickOutUsers"));
                return;
            }
            if (!isOnline)
            {
                MessageBox.Show(Program.ResourceManager.GetString("Message_YoureOffline"));
                return;
            }
            string username = listView1.SelectedItems[0].Text;
            if (username == currentUserName)
            {
                MessageBox.Show(Program.ResourceManager.GetString("Message_YouCantKickOutYourself"));
                return;
            }

            if (MessageBox.Show(Program.ResourceManager.GetString("Message_AreYouSureYouWantToKick") + " " +
                username + " " + Program.ResourceManager.GetString("Message_Out") + " ?",
                Program.ResourceManager.GetString("MessageCaption_KickOut"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes)
            {
                remotingObject.SendMessage(Program.ResourceManager.GetString("Message_RoomOwnerKickedOut") + " " + username + " !");
                remotingObject.LogOut(username);
            }
        }

        private void linkLabel_setBanned_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
            {
                return;
            }
            if (remotingObject == null)
            {
                MessageBox.Show(Program.ResourceManager.GetString("Message_YouCantDoThatNowTheRemotingObjectIsCurrepted"));
                return;
            }
            if (!isServer)
            {
                MessageBox.Show(Program.ResourceManager.GetString("Message_OnlyRoomOwnerCanBanUsers"));
                return;
            }
            if (!isOnline)
            {
                MessageBox.Show(Program.ResourceManager.GetString("Message_YoureOffline"));
                return;
            }
            string username = listView1.SelectedItems[0].Text;
            if (username == currentUserName)
            {
                MessageBox.Show(Program.ResourceManager.GetString("Message_YouCantBanYourself"));
                return;
            }

            if (MessageBox.Show(Program.ResourceManager.GetString("Message_AreYouSureYouWantToBan") + " " + username + " ?\n" +
                Program.ResourceManager.GetString("Message_ThisUserWillNotBeAbleToJoinThisSessionAnyMore"),
                Program.ResourceManager.GetString("MessageCaption_SetBanned"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                remotingObject.SendMessage(Program.ResourceManager.GetString("Message_RoomOwnerBAN") + " " + username + " !");
                remotingObject.SetUserBanned(username, true);
                remotingObject.LogOut(username);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Settings frm = new Form_Settings();
            frm.ShowDialog(this);
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, ".\\Help.chm", HelpNavigator.TableOfContents);
        }

        private void aboutHomeChatterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_About frm = new Form_About();
            frm.ShowDialog(this);
        }

        private void languageToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int i = 0;
            int index = 0;
            foreach (ToolStripMenuItem item in languageToolStripMenuItem.DropDownItems)
            {
                if (item.Text == e.ClickedItem.Text)
                {
                    item.Checked = true;
                    index = i;
                }
                else
                    item.Checked = false;
                i++;
            }
            Program.Language = Program.SupportedLanguages[index, 0];
            Program.Settings.Language = Program.SupportedLanguages[index, 0];

            MessageBox.Show(Program.ResourceManager.GetString("Message_YouMustRestartTheProgramToApplyLanguage"),
                Program.ResourceManager.GetString("MessageCaption_ApplyLanguage"));
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (Program.Settings.SelectAllTextWhenClickOnTextBox)
            {
                textBox1.SelectAll();
            }
        }
    }
}
