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

        #region private variables
        private SplashForm myParent;
        private List<ADContainer> fullListOfContainers = new List<ADContainer>();
        private Settings settings;
        private DirectorySearcher search; //only used for user searching. Searching for child OUs requires a fresh DirectorySearcher, as there will be a different Base Path for each parent OU.
        #endregion

        public SyncForm(SplashForm myParent, Settings settings, DirectorySearcher search)
        {
            InitializeComponent();
            this.myParent = myParent;
            this.settings = settings;
        }

        private void SyncForm_Load(object sender, EventArgs e)
        {
            
            #region Generate full list of OUs (including Child OUs) and Groups

            for (int i = 0; i < myParent.ListOfAdContainers.Count; i++)
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
                    Console.WriteLine("***" +
                        "* ADDED GROUP: " + containerToAdd.Name);
                }
            }
            #endregion

            foreach(var group in fullListOfContainers)
            {
                DirectoryEntry ouToSearch = new DirectoryEntry(group.Adspath, settings.DirectoryServerUsername, settings.getDecryptedPassword());
                DirectorySearcher userSearch = new DirectorySearcher(ouToSearch);

                userSearch.PropertiesToLoad.Add("givenName");
                userSearch.PropertiesToLoad.Add("sn");
                userSearch.PropertiesToLoad.Add("mail");
                userSearch.PropertiesToLoad.Add("samaccountname");
                userSearch.PropertiesToLoad.Add("name");

                userSearch.Filter = "(objectCategory=User)";

                SearchResultCollection resultCol = userSearch.FindAll();

                foreach(SearchResult user in resultCol)
                {
                    Console.WriteLine("USER ADDED: " + user.Properties["Name"][0]);
                }
            }


        }
    }
}
