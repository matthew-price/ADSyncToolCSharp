﻿namespace Directorii
{
    partial class SplashForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashForm));
            this.openServerSettingsDialogButton = new System.Windows.Forms.Button();
            this.openDirectoryObjectsDialogButton = new System.Windows.Forms.Button();
            this.openSyncDialogButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openServerSettingsDialogButton
            // 
            this.openServerSettingsDialogButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openServerSettingsDialogButton.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openServerSettingsDialogButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.openServerSettingsDialogButton.Location = new System.Drawing.Point(228, 338);
            this.openServerSettingsDialogButton.Margin = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.openServerSettingsDialogButton.Name = "openServerSettingsDialogButton";
            this.openServerSettingsDialogButton.Size = new System.Drawing.Size(356, 60);
            this.openServerSettingsDialogButton.TabIndex = 0;
            this.openServerSettingsDialogButton.Text = "Server Settings";
            this.openServerSettingsDialogButton.UseVisualStyleBackColor = true;
            this.openServerSettingsDialogButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // openDirectoryObjectsDialogButton
            // 
            this.openDirectoryObjectsDialogButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openDirectoryObjectsDialogButton.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openDirectoryObjectsDialogButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.openDirectoryObjectsDialogButton.Location = new System.Drawing.Point(228, 425);
            this.openDirectoryObjectsDialogButton.Margin = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.openDirectoryObjectsDialogButton.Name = "openDirectoryObjectsDialogButton";
            this.openDirectoryObjectsDialogButton.Size = new System.Drawing.Size(356, 60);
            this.openDirectoryObjectsDialogButton.TabIndex = 1;
            this.openDirectoryObjectsDialogButton.Text = "Directory Objects";
            this.openDirectoryObjectsDialogButton.UseVisualStyleBackColor = true;
            this.openDirectoryObjectsDialogButton.Click += new System.EventHandler(this.openDirectoryObjectsDialogButton_Click);
            // 
            // openSyncDialogButton
            // 
            this.openSyncDialogButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openSyncDialogButton.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openSyncDialogButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.openSyncDialogButton.Location = new System.Drawing.Point(228, 512);
            this.openSyncDialogButton.Margin = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.openSyncDialogButton.Name = "openSyncDialogButton";
            this.openSyncDialogButton.Size = new System.Drawing.Size(356, 60);
            this.openSyncDialogButton.TabIndex = 2;
            this.openSyncDialogButton.Text = "Sync Now";
            this.openSyncDialogButton.UseVisualStyleBackColor = true;
            this.openSyncDialogButton.Click += new System.EventHandler(this.openSyncDialogButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(346, 96);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 123);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // SplashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(786, 719);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.openSyncDialogButton);
            this.Controls.Add(this.openDirectoryObjectsDialogButton);
            this.Controls.Add(this.openServerSettingsDialogButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SplashForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AD Sync Tool";
            this.Load += new System.EventHandler(this.SplashForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openServerSettingsDialogButton;
        private System.Windows.Forms.Button openDirectoryObjectsDialogButton;
        private System.Windows.Forms.Button openSyncDialogButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

