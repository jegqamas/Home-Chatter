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
    partial class Form_CreateServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CreateServer));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_serverName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_portNumber = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_userName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox_remeberUser = new System.Windows.Forms.CheckBox();
            this.checkBox_rememberServer = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown_maxUsers = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_portNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_maxUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.toolTip1.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // comboBox_serverName
            // 
            resources.ApplyResources(this.comboBox_serverName, "comboBox_serverName");
            this.comboBox_serverName.FormattingEnabled = true;
            this.comboBox_serverName.Name = "comboBox_serverName";
            this.toolTip1.SetToolTip(this.comboBox_serverName, resources.GetString("comboBox_serverName.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.toolTip1.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // numericUpDown_portNumber
            // 
            resources.ApplyResources(this.numericUpDown_portNumber, "numericUpDown_portNumber");
            this.numericUpDown_portNumber.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_portNumber.Minimum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.numericUpDown_portNumber.Name = "numericUpDown_portNumber";
            this.toolTip1.SetToolTip(this.numericUpDown_portNumber, resources.GetString("numericUpDown_portNumber.ToolTip"));
            this.numericUpDown_portNumber.Value = new decimal(new int[] {
            8080,
            0,
            0,
            0});
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.toolTip1.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
            // 
            // comboBox_userName
            // 
            resources.ApplyResources(this.comboBox_userName, "comboBox_userName");
            this.comboBox_userName.FormattingEnabled = true;
            this.comboBox_userName.Name = "comboBox_userName";
            this.toolTip1.SetToolTip(this.comboBox_userName, resources.GetString("comboBox_userName.ToolTip"));
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            this.toolTip1.SetToolTip(this.label4, resources.GetString("label4.ToolTip"));
            // 
            // textBox_password
            // 
            resources.ApplyResources(this.textBox_password, "textBox_password");
            this.textBox_password.Name = "textBox_password";
            this.toolTip1.SetToolTip(this.textBox_password, resources.GetString("textBox_password.ToolTip"));
            this.textBox_password.UseSystemPasswordChar = true;
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
            // checkBox_remeberUser
            // 
            resources.ApplyResources(this.checkBox_remeberUser, "checkBox_remeberUser");
            this.checkBox_remeberUser.Name = "checkBox_remeberUser";
            this.toolTip1.SetToolTip(this.checkBox_remeberUser, resources.GetString("checkBox_remeberUser.ToolTip"));
            this.checkBox_remeberUser.UseVisualStyleBackColor = true;
            // 
            // checkBox_rememberServer
            // 
            resources.ApplyResources(this.checkBox_rememberServer, "checkBox_rememberServer");
            this.checkBox_rememberServer.Name = "checkBox_rememberServer";
            this.toolTip1.SetToolTip(this.checkBox_rememberServer, resources.GetString("checkBox_rememberServer.ToolTip"));
            this.checkBox_rememberServer.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            this.toolTip1.SetToolTip(this.label5, resources.GetString("label5.ToolTip"));
            // 
            // numericUpDown_maxUsers
            // 
            resources.ApplyResources(this.numericUpDown_maxUsers, "numericUpDown_maxUsers");
            this.numericUpDown_maxUsers.Name = "numericUpDown_maxUsers";
            this.toolTip1.SetToolTip(this.numericUpDown_maxUsers, resources.GetString("numericUpDown_maxUsers.ToolTip"));
            this.numericUpDown_maxUsers.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Form_CreateServer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDown_maxUsers);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox_rememberServer);
            this.Controls.Add(this.checkBox_remeberUser);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_userName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown_portNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_serverName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_CreateServer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_portNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_maxUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_serverName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_portNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_userName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox_remeberUser;
        private System.Windows.Forms.CheckBox checkBox_rememberServer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown_maxUsers;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}