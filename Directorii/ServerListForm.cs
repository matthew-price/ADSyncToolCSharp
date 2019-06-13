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

        public ServerListForm(SplashForm splashForm)
        {
            InitializeComponent();
            myParent = splashForm;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ADDomainController dc = new ADDomainController("Hostname", "AD", "Username", "Domain");
            myParent.LoadedSettings.ListOfADDomainControllers.Add(dc);

            ServerSettingsForm serverSettingsForm = new ServerSettingsForm(dc);

        }
    }
}
