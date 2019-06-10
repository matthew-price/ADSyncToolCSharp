namespace Directorii
{
    partial class AdvancedSettingsDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.userSisIDComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.schoolSisIDTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.smbCopyCheckBox = new System.Windows.Forms.CheckBox();
            this.smbDriveLetterComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.scheduledTaskCheckBox = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(25, 172);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User SIS ID";
            // 
            // userSisIDComboBox
            // 
            this.userSisIDComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.userSisIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userSisIDComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userSisIDComboBox.ForeColor = System.Drawing.SystemColors.Window;
            this.userSisIDComboBox.FormattingEnabled = true;
            this.userSisIDComboBox.Items.AddRange(new object[] {
            "AD/LDAP Unique GUID (Default)",
            "Username"});
            this.userSisIDComboBox.Location = new System.Drawing.Point(169, 170);
            this.userSisIDComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userSisIDComboBox.Name = "userSisIDComboBox";
            this.userSisIDComboBox.Size = new System.Drawing.Size(274, 21);
            this.userSisIDComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(25, 220);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Default School SIS ID";
            // 
            // schoolSisIDTextBox
            // 
            this.schoolSisIDTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.schoolSisIDTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.schoolSisIDTextBox.Location = new System.Drawing.Point(169, 217);
            this.schoolSisIDTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.schoolSisIDTextBox.Name = "schoolSisIDTextBox";
            this.schoolSisIDTextBox.Size = new System.Drawing.Size(274, 20);
            this.schoolSisIDTextBox.TabIndex = 3;
            // 
            // saveButton
            // 
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.saveButton.Location = new System.Drawing.Point(399, 409);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(87, 31);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.cancelButton.Location = new System.Drawing.Point(298, 409);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(97, 31);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(25, 265);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Copy files to Rocket?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(25, 310);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Rocket Mapped Drive Letter";
            // 
            // smbCopyCheckBox
            // 
            this.smbCopyCheckBox.AutoSize = true;
            this.smbCopyCheckBox.Location = new System.Drawing.Point(169, 264);
            this.smbCopyCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.smbCopyCheckBox.Name = "smbCopyCheckBox";
            this.smbCopyCheckBox.Size = new System.Drawing.Size(15, 14);
            this.smbCopyCheckBox.TabIndex = 8;
            this.smbCopyCheckBox.UseVisualStyleBackColor = true;
            // 
            // smbDriveLetterComboBox
            // 
            this.smbDriveLetterComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(46)))), ((int)(((byte)(49)))));
            this.smbDriveLetterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.smbDriveLetterComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.smbDriveLetterComboBox.ForeColor = System.Drawing.SystemColors.Window;
            this.smbDriveLetterComboBox.FormattingEnabled = true;
            this.smbDriveLetterComboBox.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.smbDriveLetterComboBox.Location = new System.Drawing.Point(169, 305);
            this.smbDriveLetterComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.smbDriveLetterComboBox.Name = "smbDriveLetterComboBox";
            this.smbDriveLetterComboBox.Size = new System.Drawing.Size(62, 21);
            this.smbDriveLetterComboBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(25, 349);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Run sync automatically every day?";
            // 
            // scheduledTaskCheckBox
            // 
            this.scheduledTaskCheckBox.AutoSize = true;
            this.scheduledTaskCheckBox.Location = new System.Drawing.Point(201, 349);
            this.scheduledTaskCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.scheduledTaskCheckBox.Name = "scheduledTaskCheckBox";
            this.scheduledTaskCheckBox.Size = new System.Drawing.Size(15, 14);
            this.scheduledTaskCheckBox.TabIndex = 11;
            this.scheduledTaskCheckBox.UseVisualStyleBackColor = true;
            this.scheduledTaskCheckBox.CheckedChanged += new System.EventHandler(this.scheduledTaskCheckBox_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::Directorii.Properties.Resources.settings_2;
            this.pictureBox1.Location = new System.Drawing.Point(224, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // AdvancedSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(512, 508);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.scheduledTaskCheckBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.smbDriveLetterComboBox);
            this.Controls.Add(this.smbCopyCheckBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.schoolSisIDTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userSisIDComboBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AdvancedSettingsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AdvancedSettingsDialog";
            this.Load += new System.EventHandler(this.AdvancedSettingsDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox userSisIDComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox schoolSisIDTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox smbCopyCheckBox;
        private System.Windows.Forms.ComboBox smbDriveLetterComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox scheduledTaskCheckBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}