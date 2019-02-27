using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            settingsForm.ShowDialog();
        }

        private void openDirectoryObjectsDialogButton_Click(object sender, EventArgs e)
        {
            DirectoryObjectsListForm directoryForm = new DirectoryObjectsListForm();
            directoryForm.ShowDialog();
        }
    }
}
