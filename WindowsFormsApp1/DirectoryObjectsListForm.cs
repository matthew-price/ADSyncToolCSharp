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
    public partial class DirectoryObjectsListForm : Form
    {
        #region private variables

        private DirectorySearcher search;
        private SplashForm myParent;

        #endregion


        public DirectoryObjectsListForm(SplashForm myParent, DirectorySearcher search)
        {
            InitializeComponent();
            this.search = search;
            this.myParent = myParent;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            DirectoryObjectsSearchForm searchForm = new DirectoryObjectsSearchForm(this, search);
            searchForm.ShowDialog();
        }

        private void DirectoryObjectsListForm_Load(object sender, EventArgs e)
        {

        }
    }
}
