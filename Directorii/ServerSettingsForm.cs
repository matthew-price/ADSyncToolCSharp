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

        public ServerSettingsForm()
        {
            InitializeComponent();
            this.loadedSettings = LoadedSettings;
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
            //TODO implement save functionality

            string usernameToSave;
            if (usernameTextBox.Text.Contains('\\'))
            {
                usernameToSave = usernameTextBox.Text;
            }
            else
            {
                usernameToSave = domainTextBox.Text + '\\' + usernameTextBox.Text;
            }

            #region test server functionality

            DirectoryEntry searchRoot = new DirectoryEntry("LDAP://" + hostnameTextBox.Text, usernameToSave, passwordTextBox.Text);
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
            } catch (System.Runtime.InteropServices.COMException)
            {
                MessageBox.Show("Server does not appear to be running at address: " + hostnameTextBox.Text);
            }
            #endregion

            #region Creating Settings object, and writing to JSON file



            Settings settings = new Settings(hostnameTextBox.Text, "AD", usernameToSave, domainTextBox.Text);
            encryptPassword(settings);
            myParent.LoadedSettings = settings;

            Close();

            #endregion
        }


        private void encryptPassword(Settings settings)
        {
            byte[] toEncrypt = UnicodeEncoding.UTF8.GetBytes(passwordTextBox.Text);
            byte[] entropy = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(entropy);
            byte[] encryptedData = ProtectedData.Protect(toEncrypt, entropy, DataProtectionScope.LocalMachine);
        

            // converted encryptedData from a byte[] to a string, and write it to settings.EncryptedPassword
            settings.EncryptedPasssword = Convert.ToBase64String(encryptedData);
            settings.setEntropy(Convert.ToBase64String(entropy));
       
        }

        private void ServerSettingsForm_Load(object sender, EventArgs e)
        {
            // Load from Settings object
            Console.WriteLine("*** Ran ServerSettingsForm_Load");
            hostnameTextBox.Text = loadedSettings.DirectoryServerHostname;
            passwordTextBox.Text = loadedSettings.getDecryptedPassword();
            usernameTextBox.Text = loadedSettings.DirectoryServerUsername;
            domainTextBox.Text = loadedSettings.DirectoryServerDomain;
        }
    }
}