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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "User SIS ID";
            // 
            // userSisIDComboBox
            // 
            this.userSisIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userSisIDComboBox.FormattingEnabled = true;
            this.userSisIDComboBox.Items.AddRange(new object[] {
            "AD/LDAP Unique GUID (Default)",
            "Username"});
            this.userSisIDComboBox.Location = new System.Drawing.Point(275, 60);
            this.userSisIDComboBox.Name = "userSisIDComboBox";
            this.userSisIDComboBox.Size = new System.Drawing.Size(409, 28);
            this.userSisIDComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Default School SIS ID";
            // 
            // schoolSisIDTextBox
            // 
            this.schoolSisIDTextBox.Location = new System.Drawing.Point(275, 137);
            this.schoolSisIDTextBox.Name = "schoolSisIDTextBox";
            this.schoolSisIDTextBox.Size = new System.Drawing.Size(409, 26);
            this.schoolSisIDTextBox.TabIndex = 3;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(609, 341);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 36);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(473, 341);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 36);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // AdvancedSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 429);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.schoolSisIDTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userSisIDComboBox);
            this.Controls.Add(this.label1);
            this.Name = "AdvancedSettingsDialog";
            this.Text = "AdvancedSettingsDialog";
            this.Load += new System.EventHandler(this.AdvancedSettingsDialog_Load);
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
    }
}