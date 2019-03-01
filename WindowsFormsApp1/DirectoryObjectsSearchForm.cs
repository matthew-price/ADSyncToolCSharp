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
    public partial class DirectoryObjectsSearchForm : Form
    {

        #region private variables
        private DirectorySearcher search;
        private DirectoryObjectsListForm myParent;
        #endregion

        public DirectoryObjectsSearchForm(DirectoryObjectsListForm myParent, DirectorySearcher search)
        {
            InitializeComponent();
            this.myParent = myParent;
            this.search = search;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DirectoryObjectsSearchForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("DirectorySearcher object: " + search.ToString());
            search.PropertiesToLoad.Clear();
            search.PropertiesToLoad.Add("adspath");
            search.PropertiesToLoad.Add("dN");
            search.Filter = "(&(objectClass=Group)(name=" + ouSearchQueryBox.Text + "*))";
            // SearchResult result;
            SearchResultCollection resultCol = search.FindAll();
            if (resultCol != null)
            {
                for (int i = 0; i < resultCol.Count; i++)
                {
                    Console.WriteLine(resultCol[i].Properties["adspath"][0].ToString());
                    ouSearchListBox.Items.Add(resultCol[i].Properties["adspath"][0]);
                }

            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
        }
    }
}
