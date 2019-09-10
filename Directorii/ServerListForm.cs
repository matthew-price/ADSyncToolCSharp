using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Directorii
{
    public partial class ServerListForm : Form

    {

        private SplashForm myParent;
        // for window dragging ability
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        // end of window dragging ability

        public ServerListForm(SplashForm splashForm)
        {
            InitializeComponent();
            myParent = splashForm;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ADDomainController dc = new ADDomainController("Hostname", "AD", "Username", "Domain");
            myParent.LoadedSettings.ListOfADDomainControllers.Add(dc);

            ServerSettingsForm serverSettingsForm = new ServerSettingsForm(dc, myParent);
            serverSettingsForm.ShowDialog();
            UpdateUI();
        }

        private void ServerListForm_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (myParent.LoadedSettings.ListOfADDomainControllers != null)
            {
                listOfServersListBox.Items.Clear();
                {
                    foreach (var item in myParent.LoadedSettings.ListOfADDomainControllers)
                    {
                        listOfServersListBox.Items.Add(item.DirectoryServerHostname);
                    }
                }
            }

    }
        private void RemoveSelectedDomainController(string serverName)
        {
            try
            {


                foreach (ADDomainController server in myParent.LoadedSettings.ListOfADDomainControllers)
                {
                    if (server.DirectoryServerHostname.Equals(serverName))
                    {
                        myParent.LoadedSettings.ListOfADDomainControllers.Remove(server);
                        UpdateUI();
                    }
                }

                Console.WriteLine(serverName);
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (listOfServersListBox.SelectedItem != null)
            {
                RemoveSelectedDomainController(listOfServersListBox.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Please select a server to remove first", "No server selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void ServerListForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
