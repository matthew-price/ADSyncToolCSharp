using System;
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

namespace Directorii
{
    public partial class SplashForm : Form
    {

        private Settings loadedSettings = null;
        private List<ADContainer> listOfAdContainers = new List<ADContainer>();
        private string savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "ADSyncTool");
        

        public SplashForm()
        {
            InitializeComponent();
            Console.WriteLine("PATH: " + savePath);
            System.IO.Directory.CreateDirectory(savePath);
            loadSettingsJSON();
        }

        private void loadSettingsJSON()
        {
            try
            {
                using (StreamReader file = File.OpenText(SavePath + "\\settings.json"))
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

        private void serializeSettingsToJSON()
        {
            if (LoadedSettings != null)
            {
                try
                {
                    Console.WriteLine("ATTEMPTING WRITE");
                    Console.WriteLine("HOSTNAME IS: " + LoadedSettings.DirectoryServerHostname);
                    string output = JsonConvert.SerializeObject(LoadedSettings, Formatting.Indented);
                    StreamWriter sw = new StreamWriter(savePath + "\\settings.json");
                    sw.Write(output);
                    sw.Close();
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

        private void SplashForm_Load(object sender, EventArgs e)
        {

        }

        private DirectorySearcher search = null;

        internal List<ADContainer> ListOfAdContainers { get => listOfAdContainers; set => listOfAdContainers = value; }
        public string SavePath { get => savePath; set => savePath = value; }
        public Settings LoadedSettings { get => loadedSettings; set => loadedSettings = value; }

        public void setDirectoryConnection(DirectorySearcher search)
        {
            this.search = search;
            openServerSettingsDialogButton.ForeColor = System.Drawing.Color.FromArgb(128, 255, 128);
        }

        private void openSyncDialogButton_Click(object sender, EventArgs e)
        {
            SyncForm syncForm = new SyncForm(this, LoadedSettings, search);
            syncForm.ShowDialog();
        }

        private void quitApplicationButton_Click(object sender, EventArgs e)
        {
            serializeSettingsToJSON();
            Application.DoEvents();
            Application.Exit();
        }

        private void openAdvancedDialogButton_Click(object sender, EventArgs e)
        {

        }

    }
}
