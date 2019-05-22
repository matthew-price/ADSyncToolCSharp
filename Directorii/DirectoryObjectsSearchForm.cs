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

namespace Directorii
{
    public partial class DirectoryObjectsSearchForm : Form
    {

        #region private variables
        private DirectorySearcher search;
        private DirectoryObjectsListForm myParent;

        public DirectoryObjectsListForm MyParent { get => myParent; set => myParent = value; }
        private Settings settings;
        #endregion

        public DirectoryObjectsSearchForm(DirectoryObjectsListForm myParent, DirectorySearcher search, Settings settings)
        {
            InitializeComponent();
            this.MyParent = myParent;
            this.search = search;
            this.settings = settings;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DirectoryObjectsSearchForm_Load(object sender, EventArgs e)
        {
            directoryObjectTypeComboBox.SelectedIndex = 0;
            schoolSisIDTextBox.Text = settings.DefaultSisID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            search.PropertiesToLoad.Clear();
            search.PropertiesToLoad.Add("adspath");
            search.PropertiesToLoad.Add("objectguid");
            search.PropertiesToLoad.Add("name");
            search.PropertiesToLoad.Add("distinguishedName");

            string directoryObjectType;
            string objectSearchType;
            if (directoryObjectTypeComboBox.SelectedItem.Equals("Group")){
                directoryObjectType = "Group";
                objectSearchType = "name";
            }
            else
            {
                directoryObjectType = "organizationalUnit";
                objectSearchType = "name";
            }

            search.Filter = "(&(objectClass=" + directoryObjectType + ")(" + objectSearchType + "=" + ouSearchQueryBox.Text + "*))";
            SearchResultCollection resultCol = search.FindAll();
            if (resultCol != null)
            {
                bool OUSelected = false;
                if(directoryObjectTypeComboBox.SelectedText == "Organizational Unit")
                {
                    OUSelected = true;
                }
                for (int i = 0; i < resultCol.Count; i++)
                {
                    Console.WriteLine(resultCol[i].Properties["adspath"][0].ToString());
                    ADContainer adcontainer = new ADContainer(resultCol[i].Properties["name"][0].ToString(), resultCol[i].Properties["adspath"][0].ToString(), OUSelected, new Guid((System.Byte[])resultCol[i].Properties["objectguid"][0]).ToString(), schoolSisIDTextBox.Text);
                    Console.WriteLine("Dn is: " + resultCol[i].Properties["distinguishedName"][0].ToString());
                    adcontainer.Cn = resultCol[i].Properties["distinguishedName"][0].ToString();
                    Console.WriteLine("Saved DN is: " + adcontainer.Cn);
                    ouSearchListBox.Items.Add(adcontainer);
                }

            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            bool isOU = true;
            if (directoryObjectTypeComboBox.SelectedItem.Equals("Group"))
            {
                isOU = false;
            }
            foreach (ADContainer item in ouSearchListBox.SelectedItems)
            {
                if(manualSisIDTextBox.Text != "Manual SIS ID? (Default: automatic)")
                {
                    item.ManualSisID = manualSisIDTextBox.Text;
                    item.UsingManualSisID = true;
                    Console.WriteLine("MANUAL SIS ID DETECTED");
                }
                else
                {
                    item.ManualSisID = "TopLevel";
                }

                item.SchoolSisID = schoolSisIDTextBox.Text;
                item.IsOU = isOU;

                MyParent.MyParent.ListOfAdContainers.Add(item);
                Console.WriteLine("ITEM DN IS: " + item.Cn);
            }
            Close();
        }

        private void directoryObjectTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void quitAppButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
