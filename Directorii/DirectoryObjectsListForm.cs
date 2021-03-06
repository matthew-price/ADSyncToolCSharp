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

namespace Directorii
{
    public partial class DirectoryObjectsListForm : Form
    {
        #region private variables

        private DirectorySearcher search;
        private SplashForm myParent;

        public SplashForm MyParent { get => myParent; set => myParent = value; }

        private Settings settings;

        // for window dragging ability
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        // end of window dragging ability

        #endregion


        public DirectoryObjectsListForm(SplashForm myParent, DirectorySearcher search, Settings settings)
        {
            InitializeComponent();
            this.search = search;
            this.MyParent = myParent;
            this.settings = settings;
        }

        #region event handlers
        private void saveButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            DirectoryObjectsSearchForm searchForm = new DirectoryObjectsSearchForm(this, search, settings);
            searchForm.ShowDialog();
            UpdateUI();
        }

        private void adContainersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (adContainersListBox.SelectedItem != null)
            {
                RemoveSelectedContainer(adContainersListBox.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Please select an item to remove first.", "Nothing selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        private void DirectoryObjectsListForm_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (MyParent.ListOfAdContainers != null)
            {
                adContainersListBox.Items.Clear();
                foreach (var item in MyParent.ListOfAdContainers)
                {
                    adContainersListBox.Items.Add(item.Adspath);
                }
            }
        }

        private void RemoveSelectedContainer(string adspath)
        {
                try
                {
                    foreach (ADContainer container in MyParent.ListOfAdContainers)
                    {
                        if (container.Adspath.Equals(adspath))
                        {
                            MyParent.ListOfAdContainers.Remove(container);
                        }
                    }
                } catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                UpdateUI();
        }

        private void DirectoryObjectsListForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
