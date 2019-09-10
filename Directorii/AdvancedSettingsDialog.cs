using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;

namespace Directorii
{
    public partial class AdvancedSettingsDialog : Form
    {

        #region private variables

        private SplashForm myParent;
        private Settings settings;
        // for window dragging ability
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        // end of window dragging ability

        #endregion


        public AdvancedSettingsDialog(SplashForm myParent, Settings settings)
        {
            InitializeComponent();
            this.myParent = myParent;
            this.settings = settings;
            LoadAdvancedSettings();
        }

        private void AdvancedSettingsDialog_Load(object sender, EventArgs e)
        {
            if (!settings.UsingUsernameAsSisID)
            {
                userSisIDComboBox.SelectedIndex = 0;
            }
            else
            {
                userSisIDComboBox.SelectedIndex = 1;
            }

            using (TaskService ts = new TaskService())
            {
                Microsoft.Win32.TaskScheduler.Task t = ts.GetTask(@"ADSyncToolDaily");
                if (t != null) scheduledTaskCheckBox.Checked = true;
            }

            schoolSisIDTextBox.Text = settings.DefaultSisID;

            if (settings.SmbCopyEnabled)
            {
                smbCopyCheckBox.Checked = true;
            }
            else
            {
                smbCopyCheckBox.Checked = false;
            }

            smbDriveLetterComboBox.SelectedItem = settings.SmbDriveLetter;

        }

        private void LoadAdvancedSettings()
        {

        }

        private void SaveAdvancedSettings()
        {

            if (userSisIDComboBox.SelectedIndex == 0)
            {
                settings.UsingUsernameAsSisID = false;
            }
            else
            {
                settings.UsingUsernameAsSisID = true;
            }

            settings.DefaultSisID = schoolSisIDTextBox.Text;

            settings.SmbCopyEnabled = smbCopyCheckBox.Checked;
            settings.SmbDriveLetter = smbDriveLetterComboBox.SelectedItem.ToString();

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveAdvancedSettings();
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void scheduledTaskCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (scheduledTaskCheckBox.Checked)
            {
                using (TaskService ts = new TaskService())
                {
                    Microsoft.Win32.TaskScheduler.Task t = ts.GetTask(@"ADSyncToolDaily");
                    if (t != null) return; //if a task with this name already exists, stop
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = "Runs daily sync between AD and Lightspeed CSV";
                    td.Triggers.Add(new DailyTrigger { DaysInterval = 1 });
                    td.Actions.Add(new ExecAction(System.Reflection.Assembly.GetEntryAssembly().Location, "quiet", null));
                    ts.RootFolder.RegisterTaskDefinition(@"ADSyncToolDaily", td);
                }
            } else
            {
                using (TaskService ts = new TaskService())
                {
                    Microsoft.Win32.TaskScheduler.Task t = ts.GetTask(@"ADSyncToolDaily");
                    if (t == null) return; //if no task with this name exists, stop
                    var identity = WindowsIdentity.GetCurrent();
                    var principal = new WindowsPrincipal(identity);
                    if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                    {
                        MessageBox.Show("You need to run this program as administrator to remove the scheduled task. \nAlternatively, you can delete it manually, using Windows Scheduled Tasks", "Run as administrator", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        scheduledTaskCheckBox.Checked = true;
                        return;
                    }
                    // Remove the task we just created
                    ts.RootFolder.DeleteTask(@"ADSyncToolDaily");
                }
            }
        }

        private void AdvancedSettingsDialog_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
