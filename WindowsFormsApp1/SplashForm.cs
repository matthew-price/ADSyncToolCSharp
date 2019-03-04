﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public partial class SplashForm : Form
    {

        private Settings loadedSettings = null;


        public SplashForm()
        {
            InitializeComponent();
            loadSettingsJSON();
        }

        private void loadSettingsJSON()
        {
            try
            {
                using (StreamReader file = File.OpenText(AppDomain.CurrentDomain.BaseDirectory + "settings.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    LoadedSettings = (Settings)serializer.Deserialize(file, typeof(Settings));
                }
            } catch (Exception)
            {
                Console.WriteLine("Could not load settings JSON into Settings object. No settings JSON found?");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Attempt to load from Settings object, if it exists. Create a blank one if not
            if (LoadedSettings != null)
            {
                Console.WriteLine("Settings object found");
            }
            else
            {
                LoadedSettings = new Settings("Hostname", "AD", "Username", "Domain");
            }

            //Proceed to load the Settings form
            ServerSettingsForm settingsForm = new ServerSettingsForm();
            settingsForm.myParent = this;
            settingsForm.LoadedSettings = LoadedSettings;
            settingsForm.ShowDialog();
        }

        private void openDirectoryObjectsDialogButton_Click(object sender, EventArgs e)
        {
            DirectoryObjectsListForm directoryForm = new DirectoryObjectsListForm(this, search);
            directoryForm.ShowDialog();
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {

        }

        private DirectorySearcher search = null;

        internal Settings LoadedSettings { get => loadedSettings; set => loadedSettings = value; }

        public void setDirectoryConnection(DirectorySearcher search)
        {
            this.search = search;
            openServerSettingsDialogButton.ForeColor = System.Drawing.Color.FromArgb(128, 255, 128);
        }

    }
}