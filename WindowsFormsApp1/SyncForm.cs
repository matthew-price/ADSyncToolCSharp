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

namespace WindowsFormsApp1
{
    public partial class SyncForm : Form
    {

        private SplashForm myParent;
        private List<ADContainer> fullListOfContainers = new List<ADContainer>();
        private Settings settings;


        public SyncForm(SplashForm myParent, Settings settings)
        {
            InitializeComponent();
            this.myParent = myParent;
            this.settings = settings;
        }

        private void SyncForm_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < myParent.ListOfAdContainers.Count; i++)
            {
                if (myParent.ListOfAdContainers[i].IsOU)
                {
                    DirectoryEntry parentOU = new DirectoryEntry(myParent.ListOfAdContainers[i].Adspath, settings.DirectoryServerUsername, settings.getDecryptedPassword());
                    DirectorySearcher searchForChildOUs = new DirectorySearcher(parentOU);

                    searchForChildOUs.PropertiesToLoad.Add("adspath");
                    searchForChildOUs.PropertiesToLoad.Add("Name");
                    searchForChildOUs.Filter = "(objectCategory=organizationalUnit)";

                    SearchResultCollection resultCol = searchForChildOUs.FindAll();

                    for (int j = 0; j < resultCol.Count; j++)
                    {
                        Console.WriteLine("New OU: " + resultCol[j].Properties["Name"][0].ToString() + " PATH: " + resultCol[j].Properties["adspath"][0].ToString());
                        ADContainer containerToAdd = new ADContainer(resultCol[j].Properties["Name"][0].ToString(), resultCol[j].Properties["adspath"][0].ToString(), true);
                        fullListOfContainers.Add(containerToAdd);
                        Console.WriteLine("*** ADDED OU: " + containerToAdd.Name);
                    }
                }
                else
                {
                    ADContainer containerToAdd = new ADContainer(myParent.ListOfAdContainers[i].Name, myParent.ListOfAdContainers[i].Adspath, false);
                    fullListOfContainers.Add(containerToAdd);
                    Console.WriteLine("**** ADDED GROUP: " + containerToAdd.Name);
                }
            }
        }
    }
}
