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
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography;

namespace Directorii
{
    public partial class ServerSettingsForm : Form
    {
        public SplashForm myParent { get; set; }
        internal Settings LoadedSettings { get => loadedSettings; set => loadedSettings = value; }

        private Settings loadedSettings;
        private bool ldapsSwitch;
        private ADDomainController dc;

        public ServerSettingsForm(ADDomainController dc)
        {
            InitializeComponent();
            this.loadedSettings = LoadedSettings;
            this.dc = dc;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string usernameToSave;
            if (!usernameTextBox.Text.Contains('\\') && !(domainTextBox.Text == "Domain"))
            {
                usernameToSave = domainTextBox.Text + '\\' + usernameTextBox.Text;
                
            }
            else
            {
                    usernameToSave = usernameTextBox.Text;
            }

            #region test server functionality

            string ldapProtocol;
            if (ldapsSwitch) { ldapProtocol = ":636"; } else { ldapProtocol = ":389"; }
            DirectoryEntry searchRoot = new DirectoryEntry("LDAP://" + hostnameTextBox.Text + ldapProtocol, usernameToSave, passwordTextBox.Text);
            DirectorySearcher search = new DirectorySearcher(searchRoot);
            search.PropertiesToLoad.Add("samaccountname");
            try
            {
                Console.WriteLine("TRYING USERNAME: " + usernameToSave);
                if (search.FindOne() != null)
                {
                    MessageBox.Show("Connected succesfully to " + hostnameTextBox.Text, "Connected", MessageBoxButtons.OK);
                    myParent.setDirectoryConnection(search);
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }
            catch (DirectoryServicesCOMException ex)
            {
                MessageBox.Show("Error connecting. Please check server settings and username / password. \n Full details follow. \n" + ex);
            } catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("Server does not appear to be running at address: " + hostnameTextBox.Text + "\n" + ex);
            }
            #endregion

            #region Creating Settings object, and writing to JSON file

            dc.Ldaps = ldapsSwitch;
            encryptPassword(dc);      

            Close();

            #endregion
        }


        private void encryptPassword(ADDomainController dc)
        {
            byte[] toEncrypt = UnicodeEncoding.UTF8.GetBytes(passwordTextBox.Text);
            byte[] entropy = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(entropy);
            byte[] encryptedData = ProtectedData.Protect(toEncrypt, entropy, DataProtectionScope.LocalMachine);
        

            // converted encryptedData from a byte[] to a string, and write it to settings.EncryptedPassword
            dc.EncryptedPassword = Convert.ToBase64String(encryptedData);
            dc.Entropy = (Convert.ToBase64String(entropy));
       
        }

        private void ServerSettingsForm_Load(object sender, EventArgs e)
        {
            // Load from Settings object
            Console.WriteLine("*** Ran ServerSettingsForm_Load");
            hostnameTextBox.Text = loadedSettings.DirectoryServerHostname;
            passwordTextBox.Text = loadedSettings.getDecryptedPassword();
            usernameTextBox.Text = loadedSettings.DirectoryServerUsername;
            domainTextBox.Text = loadedSettings.DirectoryServerDomain;
            ldapsSwitch = loadedSettings.Ldaps;
            if (loadedSettings.Ldaps)
            {
                ldapEnabledLabel.Text = "LDAPS Enabled";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (loadedSettings.Ldaps)
            {
                ldapEnabledLabel.Text = "LDAPS Disabled";
                ldapsSwitch = false;
            }
            else
            {
                ldapEnabledLabel.Text = "LDAPS Enabled";
                ldapsSwitch = true;
            }
        }
    }
}
