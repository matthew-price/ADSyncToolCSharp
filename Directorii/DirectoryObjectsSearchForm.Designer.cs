﻿namespace Directorii
{
    partial class DirectoryObjectsSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectoryObjectsSearchForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ouSearchListBox = new System.Windows.Forms.ListBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.ouSearchQueryBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.directoryObjectTypeComboBox = new System.Windows.Forms.ComboBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Label();
            this.quitAppButton = new System.Windows.Forms.Label();
            this.manualSisIDTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.schoolSisIDTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.taskEventWatcher1 = new Microsoft.Win32.TaskScheduler.TaskEventWatcher();
            this.domainControllerListBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskEventWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(396, 25);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 123);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ouSearchListBox
            // 
            this.ouSearchListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ouSearchListBox.ForeColor = System.Drawing.SystemColors.Window;
            this.ouSearchListBox.FormattingEnabled = true;
            this.ouSearchListBox.ItemHeight = 25;
            this.ouSearchListBox.Location = new System.Drawing.Point(110, 558);
            this.ouSearchListBox.Margin = new System.Windows.Forms.Padding(4);
            this.ouSearchListBox.Name = "ouSearchListBox";
            this.ouSearchListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ouSearchListBox.Size = new System.Drawing.Size(666, 329);
            this.ouSearchListBox.TabIndex = 1;
            this.ouSearchListBox.SelectedIndexChanged += new System.EventHandler(this.OuSearchListBox_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(162, 144);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 62);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(162, 236);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 62);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // ouSearchQueryBox
            // 
            this.ouSearchQueryBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ouSearchQueryBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ouSearchQueryBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ouSearchQueryBox.ForeColor = System.Drawing.SystemColors.Menu;
            this.ouSearchQueryBox.Location = new System.Drawing.Point(260, 169);
            this.ouSearchQueryBox.Margin = new System.Windows.Forms.Padding(6);
            this.ouSearchQueryBox.Name = "ouSearchQueryBox";
            this.ouSearchQueryBox.Size = new System.Drawing.Size(388, 37);
            this.ouSearchQueryBox.TabIndex = 4;
            this.ouSearchQueryBox.Text = "Search Term";
            this.ouSearchQueryBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Location = new System.Drawing.Point(162, 217);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 2);
            this.panel1.TabIndex = 5;
            // 
            // directoryObjectTypeComboBox
            // 
            this.directoryObjectTypeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.directoryObjectTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.directoryObjectTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.directoryObjectTypeComboBox.ForeColor = System.Drawing.SystemColors.Window;
            this.directoryObjectTypeComboBox.FormattingEnabled = true;
            this.directoryObjectTypeComboBox.Items.AddRange(new object[] {
            "Organizational Unit",
            "Group"});
            this.directoryObjectTypeComboBox.Location = new System.Drawing.Point(260, 256);
            this.directoryObjectTypeComboBox.Margin = new System.Windows.Forms.Padding(6);
            this.directoryObjectTypeComboBox.Name = "directoryObjectTypeComboBox";
            this.directoryObjectTypeComboBox.Size = new System.Drawing.Size(398, 33);
            this.directoryObjectTypeComboBox.TabIndex = 6;
            this.directoryObjectTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.directoryObjectTypeComboBox_SelectedIndexChanged);
            // 
            // searchButton
            // 
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.searchButton.Location = new System.Drawing.Point(374, 449);
            this.searchButton.Margin = new System.Windows.Forms.Padding(6);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(150, 52);
            this.searchButton.TabIndex = 7;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // addButton
            // 
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Arial", 12F);
            this.addButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.addButton.Location = new System.Drawing.Point(608, 1077);
            this.addButton.Margin = new System.Windows.Forms.Padding(4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(168, 48);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.ForeColor = System.Drawing.Color.Snow;
            this.closeButton.Location = new System.Drawing.Point(850, 10);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(0, 25);
            this.closeButton.TabIndex = 9;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // quitAppButton
            // 
            this.quitAppButton.AutoSize = true;
            this.quitAppButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.quitAppButton.Location = new System.Drawing.Point(770, 25);
            this.quitAppButton.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.quitAppButton.Name = "quitAppButton";
            this.quitAppButton.Size = new System.Drawing.Size(26, 25);
            this.quitAppButton.TabIndex = 10;
            this.quitAppButton.Text = "X";
            this.quitAppButton.Click += new System.EventHandler(this.quitAppButton_Click);
            // 
            // manualSisIDTextBox
            // 
            this.manualSisIDTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.manualSisIDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.manualSisIDTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manualSisIDTextBox.ForeColor = System.Drawing.SystemColors.Menu;
            this.manualSisIDTextBox.Location = new System.Drawing.Point(260, 929);
            this.manualSisIDTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.manualSisIDTextBox.Name = "manualSisIDTextBox";
            this.manualSisIDTextBox.Size = new System.Drawing.Size(552, 37);
            this.manualSisIDTextBox.TabIndex = 11;
            this.manualSisIDTextBox.Text = "Manual SIS ID? (Default: automatic)";
            this.manualSisIDTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(162, 904);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(64, 62);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // schoolSisIDTextBox
            // 
            this.schoolSisIDTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.schoolSisIDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.schoolSisIDTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schoolSisIDTextBox.ForeColor = System.Drawing.SystemColors.Menu;
            this.schoolSisIDTextBox.Location = new System.Drawing.Point(260, 992);
            this.schoolSisIDTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.schoolSisIDTextBox.Name = "schoolSisIDTextBox";
            this.schoolSisIDTextBox.Size = new System.Drawing.Size(378, 37);
            this.schoolSisIDTextBox.TabIndex = 13;
            this.schoolSisIDTextBox.Text = "TopLevel";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(162, 977);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(64, 62);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 14;
            this.pictureBox5.TabStop = false;
            // 
            // taskEventWatcher1
            // 
            this.taskEventWatcher1.SynchronizingObject = this;
            // 
            // domainControllerListBox
            // 
            this.domainControllerListBox.FormattingEnabled = true;
            this.domainControllerListBox.Location = new System.Drawing.Point(260, 336);
            this.domainControllerListBox.Name = "domainControllerListBox";
            this.domainControllerListBox.Size = new System.Drawing.Size(398, 33);
            this.domainControllerListBox.TabIndex = 15;
            this.domainControllerListBox.SelectedIndexChanged += new System.EventHandler(this.DomainControllerListBox_SelectedIndexChanged);
            // 
            // DirectoryObjectsSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(888, 1231);
            this.Controls.Add(this.domainControllerListBox);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.schoolSisIDTextBox);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.manualSisIDTextBox);
            this.Controls.Add(this.quitAppButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.directoryObjectTypeComboBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ouSearchQueryBox);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ouSearchListBox);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DirectoryObjectsSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.DirectoryObjectsSearchForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DirectoryObjectsSearchForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskEventWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox ouSearchListBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox ouSearchQueryBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox directoryObjectTypeComboBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.Label quitAppButton;
        private System.Windows.Forms.TextBox manualSisIDTextBox;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox schoolSisIDTextBox;
        private System.Windows.Forms.PictureBox pictureBox5;
        private Microsoft.Win32.TaskScheduler.TaskEventWatcher taskEventWatcher1;
        private System.Windows.Forms.ComboBox domainControllerListBox;
    }
}