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
using AutoUpdaterDotNET;

namespace Directorii
{
    public partial class SplashForm : Form
    {

        #region private variables
        private Settings loadedSettings = null;
        private List<ADContainer> listOfAdContainers = new List<ADContainer>();
        private Dictionary<string, ADDomainController> dictionaryOfADDomainControllers = new Dictionary<string, ADDomainController>();
        private string savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ADSyncTool");
        private DirectorySearcher search = null;
        // for window dragging ability
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        // end of window dragging ability
        #endregion

        #region getters and setters
        internal List<ADContainer> ListOfAdContainers { get => listOfAdContainers; set => listOfAdContainers = value; }
        public string SavePath { get => savePath; set => savePath = value; }
        public Settings LoadedSettings { get => loadedSettings; set => loadedSettings = value; }
        public DirectorySearcher Search { get => search; set => search = value; }
        public Dictionary<string, ADDomainController> DictionaryOfADDomainControllers { get => dictionaryOfADDomainControllers; set => dictionaryOfADDomainControllers = value; }
        #endregion


        public SplashForm()
        {
            InitializeComponent();
            System.IO.Directory.CreateDirectory(savePath);
            loadSettingsJSON();
            loadADDomainControllersJSON();
        }

        #region settings JSON
        private void loadSettingsJSON()
        {
            try
            {
                using (StreamReader file = File.OpenText(SavePath + "\\settings.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    LoadedSettings = (Settings)serializer.Deserialize(file, typeof(Settings));
                    DirectoryEntry searchRoot = new DirectoryEntry("LDAP://" + LoadedSettings.DirectoryServerHostname, LoadedSettings.DirectoryServerUsername, LoadedSettings.getDecryptedPassword());
                    search = new DirectorySearcher(searchRoot);
                }
            } catch (Exception)
            {
                Console.WriteLine("Could not load settings JSON into Settings object. No settings JSON found?");
                LoadedSettings = new Settings("hostname", "AD", "username", "doamin");
            }

            try
            {
                using (StreamReader file = File.OpenText(SavePath + "\\directoryList.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    ListOfAdContainers = (List<ADContainer>)serializer.Deserialize(file, typeof(List<ADContainer>));
                }
            } catch (Exception)
            {
                Console.WriteLine("Could not load directory objects list. No directory objects JSON found?");
                LoadedSettings.ListOfADDomainControllers = new List<ADDomainController>();
            }

            

        }

        private void loadADDomainControllersJSON()
        {
            try
            {
                using (StreamReader file = File.OpenText(SavePath + "\\ADDomainControllers.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    List<ADDomainController> temporaryList = (List<ADDomainController>)serializer.Deserialize(file, typeof(List<ADDomainController>));
                    LoadedSettings.ListOfADDomainControllers = new List<ADDomainController>();
                    foreach (ADDomainController dc in temporaryList)
                    {
                        dictionaryOfADDomainControllers.Add(dc.DirectoryServerHostname, dc);
                        Application.DoEvents();
                        Console.WriteLine(dc.DirectoryServerHostname + " *** " + dc);
                        LoadedSettings.ListOfADDomainControllers.Add(dc);
                    }
                }
            }
            catch(Exception ex)
            { Console.WriteLine("Failed. " + ex); }
        }

        private void serializeSettingsToJSON()
            {
                if (LoadedSettings != null)
                {
                    try
                    {
                        LoadedSettings.ListOfADContainers = ListOfAdContainers;
                        //writing Settings file
                        string output = JsonConvert.SerializeObject(LoadedSettings, Formatting.Indented);
                        StreamWriter sw = new StreamWriter(savePath + "\\settings.json");
                        sw.Write(output);
                        sw.Close();

                        //writing Directory Objects file
                        string directoryObjectsOutput = JsonConvert.SerializeObject(LoadedSettings.ListOfADContainers, Formatting.Indented);
                        StreamWriter directoryWriter = new StreamWriter(savePath + "\\directoryList.json");
                        directoryWriter.Write(directoryObjectsOutput);
                        directoryWriter.Close();

                    } catch (IOException)
                    {
                        MessageBox.Show("Unable to write settings file. Configuration has not been saved.");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("Permisson denied when writing settings file. Configuration has not been saved.");
                    }
                }
                else
                {
                    Console.WriteLine("SKIPPING WRITE");
                }
            }


        private void writeADDomainControllersJSON()
        {
            if (loadedSettings.ListOfADDomainControllers != null)
            {
                try
                {
                    string output = JsonConvert.SerializeObject(LoadedSettings.ListOfADDomainControllers, Formatting.Indented);
                    StreamWriter sw = new StreamWriter(savePath + "\\ADDomainControllers.json");
                    sw.Write(output);
                    sw.Close();
                }
                catch (UnauthorizedAccessException){
                    MessageBox.Show("Permisson denied when writing domain controllers file. Configuration has not been saved.");
                }
            }
        }


        #endregion

        #region event handlers
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
            ServerListForm serverListForm = new ServerListForm(this);
            //ServerSettingsForm settingsForm = new ServerSettingsForm(this);
            //settingsForm.myParent = this;
            //settingsForm.LoadedSettings = LoadedSettings;
            serverListForm.ShowDialog();
        }

        private void openDirectoryObjectsDialogButton_Click(object sender, EventArgs e)
        {
            DirectoryObjectsListForm directoryForm = new DirectoryObjectsListForm(this, Search, loadedSettings);
            directoryForm.ShowDialog();
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            //AutoUpdater.Start("https://s3.eu-west-2.amazonaws.com/directorii/DirectoriiUpdateCheck.xml");
        }

        private void openSyncDialogButton_Click(object sender, EventArgs e)
        {
            SyncForm syncForm = new SyncForm(this, LoadedSettings, Search);
            syncForm.ShowDialog();
        }

        private void quitApplicationButton_Click(object sender, EventArgs e)
        {
            serializeSettingsToJSON();
            writeADDomainControllersJSON();
            Application.DoEvents();
            Application.Exit();
        }

        private void openAdvancedDialogButton_Click(object sender, EventArgs e)
        {
            AdvancedSettingsDialog advancedSettingsDialog = new AdvancedSettingsDialog(this, LoadedSettings);
            advancedSettingsDialog.ShowDialog();
        }
        #endregion

        public void setDirectoryConnection(DirectorySearcher search)
        {
            this.Search = search;
            openServerSettingsDialogButton.ForeColor = System.Drawing.Color.FromArgb(128, 255, 128);
        }

        private void SplashForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
