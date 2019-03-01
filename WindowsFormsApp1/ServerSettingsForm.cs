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

namespace WindowsFormsApp1
{
    public partial class ServerSettingsForm : Form
    {
        public SplashForm myParent { get; set; }

        public ServerSettingsForm()
        {
            InitializeComponent();
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

            #region test server functionality

            DirectoryEntry searchRoot = new DirectoryEntry("LDAP://" + hostnameTextBox.Text, domainTextBox.Text + "\\" + usernameTextBox.Text, passwordTextBox.Text);
            DirectorySearcher search = new DirectorySearcher(searchRoot);
            search.PropertiesToLoad.Add("samaccountname");
            try
            {
                if (search.FindOne() != null)
                {
                    MessageBox.Show("Connected succesfully to " + hostnameTextBox.Text, "Connected", MessageBoxButtons.OK);
                    myParent.setDirectoryConnection(search);
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            } catch(DirectoryServicesCOMException ex)
            {
                MessageBox.Show("Error connecting. Please check server settings and username / password. \n Full details follow. \n" + ex);
            }
            #endregion

            Settings settings = new Settings(hostnameTextBox.Text, "AD", usernameTextBox.Text, passwordTextBox.Text);
            Console.WriteLine("Hostname text box: " + hostnameTextBox.Text);
            // settings.writeSettingsFile();
            string output = JsonConvert.SerializeObject(settings, Formatting.Indented);
            Console.WriteLine("Output: " + output);
            StreamWriter sw = new StreamWriter(@"c:\\Testing\\settings.json");
            sw.Write(output);
            sw.Close();

            Close();


        }

        private void ServerSettingsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
