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
    public partial class AdvancedSettingsDialog : Form
    {

        #region private variables

        private SplashForm myParent;
        private Settings settings;


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

            schoolSisIDTextBox.Text = settings.DefaultSisID;

        }

        private void LoadAdvancedSettings()
        {

        }

        private void SaveAdvancedSettings()
        {

            if(userSisIDComboBox.SelectedIndex == 0)
            {
                settings.UsingUsernameAsSisID = false;
            }
            else
            {
                settings.UsingUsernameAsSisID = true;
            }

            settings.DefaultSisID = schoolSisIDTextBox.Text;

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
    }
}
