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
    partial class Form_JoinServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_JoinServer));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_ip = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_ServerName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_port = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_userName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox_rememberUser = new System.Windows.Forms.CheckBox();
            this.checkBox_rememberServerName = new System.Windows.Forms.CheckBox();
            this.checkBox_rememberServerIP = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_port)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.toolTip1.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // comboBox_ip
            // 
            resources.ApplyResources(this.comboBox_ip, "comboBox_ip");
            this.comboBox_ip.FormattingEnabled = true;
            this.comboBox_ip.Name = "comboBox_ip";
            this.toolTip1.SetToolTip(this.comboBox_ip, resources.GetString("comboBox_ip.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.toolTip1.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // comboBox_ServerName
            // 
            resources.ApplyResources(this.comboBox_ServerName, "comboBox_ServerName");
            this.comboBox_ServerName.FormattingEnabled = true;
            this.comboBox_ServerName.Name = "comboBox_ServerName";
            this.toolTip1.SetToolTip(this.comboBox_ServerName, resources.GetString("comboBox_ServerName.ToolTip"));
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.toolTip1.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
            // 
            // numericUpDown_port
            // 
            resources.ApplyResources(this.numericUpDown_port, "numericUpDown_port");
            this.numericUpDown_port.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_port.Minimum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.numericUpDown_port.Name = "numericUpDown_port";
            this.toolTip1.SetToolTip(this.numericUpDown_port, resources.GetString("numericUpDown_port.ToolTip"));
            this.numericUpDown_port.Value = new decimal(new int[] {
            8080,
            0,
            0,
            0});
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            this.toolTip1.SetToolTip(this.label4, resources.GetString("label4.ToolTip"));
            // 
            // comboBox_userName
            // 
            resources.ApplyResources(this.comboBox_userName, "comboBox_userName");
            this.comboBox_userName.FormattingEnabled = true;
            this.comboBox_userName.Name = "comboBox_userName";
            this.toolTip1.SetToolTip(this.comboBox_userName, resources.GetString("comboBox_userName.ToolTip"));
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            this.toolTip1.SetToolTip(this.label5, resources.GetString("label5.ToolTip"));
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.toolTip1.SetToolTip(this.textBox1, resources.GetString("textBox1.ToolTip"));
            this.textBox1.UseSystemPasswordChar = true;
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
            // checkBox_rememberUser
            // 
            resources.ApplyResources(this.checkBox_rememberUser, "checkBox_rememberUser");
            this.checkBox_rememberUser.Name = "checkBox_rememberUser";
            this.toolTip1.SetToolTip(this.checkBox_rememberUser, resources.GetString("checkBox_rememberUser.ToolTip"));
            this.checkBox_rememberUser.UseVisualStyleBackColor = true;
            // 
            // checkBox_rememberServerName
            // 
            resources.ApplyResources(this.checkBox_rememberServerName, "checkBox_rememberServerName");
            this.checkBox_rememberServerName.Name = "checkBox_rememberServerName";
            this.toolTip1.SetToolTip(this.checkBox_rememberServerName, resources.GetString("checkBox_rememberServerName.ToolTip"));
            this.checkBox_rememberServerName.UseVisualStyleBackColor = true;
            // 
            // checkBox_rememberServerIP
            // 
            resources.ApplyResources(this.checkBox_rememberServerIP, "checkBox_rememberServerIP");
            this.checkBox_rememberServerIP.Name = "checkBox_rememberServerIP";
            this.toolTip1.SetToolTip(this.checkBox_rememberServerIP, resources.GetString("checkBox_rememberServerIP.ToolTip"));
            this.checkBox_rememberServerIP.UseVisualStyleBackColor = true;
            // 
            // Form_JoinServer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox_rememberServerIP);
            this.Controls.Add(this.checkBox_rememberServerName);
            this.Controls.Add(this.checkBox_rememberUser);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_userName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown_port);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_ServerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_ip);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_JoinServer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_port)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_ip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_ServerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_port;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_userName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox_rememberUser;
        private System.Windows.Forms.CheckBox checkBox_rememberServerName;
        private System.Windows.Forms.CheckBox checkBox_rememberServerIP;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}