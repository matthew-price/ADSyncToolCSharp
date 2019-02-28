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
    public partial class DirectoryObjectsListForm : Form
    {
        public DirectoryObjectsListForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            DirectoryObjectsSearchForm searchForm = new DirectoryObjectsSearchForm();
            searchForm.ShowDialog();
        }
    }
}
