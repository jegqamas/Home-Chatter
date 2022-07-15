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
namespace HomeChatter
{
    partial class Form_Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Settings));
            this.checkBox_rememberUserName = new System.Windows.Forms.CheckBox();
            this.checkBox_rememberServerName = new System.Windows.Forms.CheckBox();
            this.checkBox_rememberServerIp = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.checkBox_clearTextBox = new System.Windows.Forms.CheckBox();
            this.checkBox_playSound = new System.Windows.Forms.CheckBox();
            this.checkBox_alwaysPlaySound = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBox_rememberUserName
            // 
            resources.ApplyResources(this.checkBox_rememberUserName, "checkBox_rememberUserName");
            this.checkBox_rememberUserName.Name = "checkBox_rememberUserName";
            this.toolTip1.SetToolTip(this.checkBox_rememberUserName, resources.GetString("checkBox_rememberUserName.ToolTip"));
            this.checkBox_rememberUserName.UseVisualStyleBackColor = true;
            // 
            // checkBox_rememberServerName
            // 
            resources.ApplyResources(this.checkBox_rememberServerName, "checkBox_rememberServerName");
            this.checkBox_rememberServerName.Name = "checkBox_rememberServerName";
            this.toolTip1.SetToolTip(this.checkBox_rememberServerName, resources.GetString("checkBox_rememberServerName.ToolTip"));
            this.checkBox_rememberServerName.UseVisualStyleBackColor = true;
            // 
            // checkBox_rememberServerIp
            // 
            resources.ApplyResources(this.checkBox_rememberServerIp, "checkBox_rememberServerIp");
            this.checkBox_rememberServerIp.Name = "checkBox_rememberServerIp";
            this.toolTip1.SetToolTip(this.checkBox_rememberServerIp, resources.GetString("checkBox_rememberServerIp.ToolTip"));
            this.checkBox_rememberServerIp.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.toolTip1.SetToolTip(this.button1, resources.GetString("button1.ToolTip"));
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.toolTip1.SetToolTip(this.button2, resources.GetString("button2.ToolTip"));
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.toolTip1.SetToolTip(this.button3, resources.GetString("button3.ToolTip"));
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.toolTip1.SetToolTip(this.linkLabel1, resources.GetString("linkLabel1.ToolTip"));
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            resources.ApplyResources(this.linkLabel2, "linkLabel2");
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.TabStop = true;
            this.toolTip1.SetToolTip(this.linkLabel2, resources.GetString("linkLabel2.ToolTip"));
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel3
            // 
            resources.ApplyResources(this.linkLabel3, "linkLabel3");
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.TabStop = true;
            this.toolTip1.SetToolTip(this.linkLabel3, resources.GetString("linkLabel3.ToolTip"));
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // checkBox_clearTextBox
            // 
            resources.ApplyResources(this.checkBox_clearTextBox, "checkBox_clearTextBox");
            this.checkBox_clearTextBox.Name = "checkBox_clearTextBox";
            this.toolTip1.SetToolTip(this.checkBox_clearTextBox, resources.GetString("checkBox_clearTextBox.ToolTip"));
            this.checkBox_clearTextBox.UseVisualStyleBackColor = true;
            // 
            // checkBox_playSound
            // 
            resources.ApplyResources(this.checkBox_playSound, "checkBox_playSound");
            this.checkBox_playSound.Name = "checkBox_playSound";
            this.toolTip1.SetToolTip(this.checkBox_playSound, resources.GetString("checkBox_playSound.ToolTip"));
            this.checkBox_playSound.UseVisualStyleBackColor = true;
            // 
            // checkBox_alwaysPlaySound
            // 
            resources.ApplyResources(this.checkBox_alwaysPlaySound, "checkBox_alwaysPlaySound");
            this.checkBox_alwaysPlaySound.Name = "checkBox_alwaysPlaySound";
            this.toolTip1.SetToolTip(this.checkBox_alwaysPlaySound, resources.GetString("checkBox_alwaysPlaySound.ToolTip"));
            this.checkBox_alwaysPlaySound.UseVisualStyleBackColor = true;
            // 
            // Form_Settings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox_alwaysPlaySound);
            this.Controls.Add(this.checkBox_playSound);
            this.Controls.Add(this.checkBox_clearTextBox);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox_rememberServerIp);
            this.Controls.Add(this.checkBox_rememberServerName);
            this.Controls.Add(this.checkBox_rememberUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_rememberServerName;
        private System.Windows.Forms.CheckBox checkBox_rememberUserName;
        private System.Windows.Forms.CheckBox checkBox_rememberServerIp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.CheckBox checkBox_clearTextBox;
        private System.Windows.Forms.CheckBox checkBox_playSound;
        private System.Windows.Forms.CheckBox checkBox_alwaysPlaySound;
    }
}