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

namespace WindowsFormsApp1
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServerSettingsForm settingsForm = new ServerSettingsForm();
            settingsForm.myParent = this;
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
        public void setDirectoryConnection(DirectorySearcher search)
        {
            this.search = search;
            openServerSettingsDialogButton.ForeColor = System.Drawing.Color.FromArgb(128, 255, 128);
        }

    }
}
