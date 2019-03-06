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
using System.IO;

namespace Directorii
{
    public partial class SyncForm : Form
    {

        #region private variables
        private SplashForm myParent;
        private List<User> fullLisfOfUsers = new List<User>();
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

        }

        private void runSync()
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
                    searchForChildOUs.PropertiesToLoad.Add("objectguid");
                    searchForChildOUs.Filter = "(objectCategory=organizationalUnit)";

                    SearchResultCollection resultCol = searchForChildOUs.FindAll();

                    for (int j = 0; j < resultCol.Count; j++)
                    {
                        Console.WriteLine("New OU: " + resultCol[j].Properties["Name"][0].ToString() + " PATH: " + resultCol[j].Properties["adspath"][0].ToString());
                        ADContainer containerToAdd = new ADContainer(resultCol[j].Properties["Name"][0].ToString(), resultCol[j].Properties["adspath"][0].ToString(), true, new Guid((System.Byte[])resultCol[j].Properties["objectguid"][0]).ToString());
                        fullListOfContainers.Add(containerToAdd);
                        Console.WriteLine("*** ADDED OU: " + containerToAdd.Name);
                    }
                }
                else
                {
                    ADContainer containerToAdd = new ADContainer(myParent.ListOfAdContainers[i].Name, myParent.ListOfAdContainers[i].Adspath, false, myParent.ListOfAdContainers[i].Guid);
                    fullListOfContainers.Add(containerToAdd);
                    Console.WriteLine("***" +
                        "* ADDED GROUP: " + containerToAdd.Name);
                }
            }
            #endregion


            #region Iterate over each Container object and add Users to it
            foreach (var group in fullListOfContainers)
            {
                DirectoryEntry ouToSearch = new DirectoryEntry(group.Adspath, settings.DirectoryServerUsername, settings.getDecryptedPassword());
                DirectorySearcher userSearch = new DirectorySearcher(ouToSearch);

                userSearch.PropertiesToLoad.Add("givenName");
                userSearch.PropertiesToLoad.Add("sn");
                userSearch.PropertiesToLoad.Add("mail");
                userSearch.PropertiesToLoad.Add("samaccountname");
                userSearch.PropertiesToLoad.Add("name");
                userSearch.PropertiesToLoad.Add("objectguid");

                userSearch.Filter = "(objectCategory=User)";

                SearchResultCollection resultCol = userSearch.FindAll();

                foreach (SearchResult user in resultCol)
                {
                    Console.WriteLine("USER ADDED: " + new Guid((System.Byte[])user.Properties["objectguid"][0]).ToString());
                    string mailAddress;
                    if (user.Properties["mail"].Count == 0)
                    {
                        mailAddress = user.Properties["samaccountname"][0].ToString() + settings.DirectoryServerHostname + ".com";
                    }
                    else
                    {
                        mailAddress = user.Properties["mail"][0].ToString();
                    }
                    User newUser = new User(user.Properties["samaccountname"][0].ToString(), user.Properties["givenName"][0].ToString(), user.Properties["sn"][0].ToString(), mailAddress, new Guid((System.Byte[])user.Properties["objectguid"][0]).ToString());

                    group.ListOfMembers.Add(newUser);
                    fullLisfOfUsers.Add(newUser);
                    System.Threading.Thread.Sleep(100);
                }
            }
            #endregion

            writeUsers();
            preparingMembershipsLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            WriteMemberships();
            preparingHeirarchyLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            setParentOUGUIDs();
            preparingGroupsLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            WriteGroups();
            doneLabel.ForeColor = System.Drawing.Color.WhiteSmoke;

        }

        private void writeUsers()
        {
            var csv = new StringBuilder();
            csv.AppendLine("unique_sis_user_id,username,first_name,last_name,unique_sis_school_id,grade,email,user_type,password,authentication");

            foreach(User user in fullLisfOfUsers)
            {
                var uniqueUserSisId = user.UserName;
                var userName = user.UserName;
                var firstName = user.FirstName;
                var lastName = user.LastName;
                var uniqueSchoolSisId = "TopLevel";
                var grade = "";
                var email = user.Mail;
                var user_type = 1;
                var password = "";
                var authentication = 0;

                string newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", uniqueUserSisId.ToString(), userName.ToString(), firstName.ToString(), lastName.ToString(), uniqueSchoolSisId.ToString(), grade.ToString(), email.ToString(), user_type.ToString(), password.ToString(), authentication.ToString());
                csv.AppendLine(newLine);
            }

            File.WriteAllText(myParent.SavePath + "\\users-v2.csv", csv.ToString(), Encoding.UTF8);
        }

        private void WriteMemberships()
        {
            var csv = new StringBuilder();
            csv.AppendLine("unique_sis_group_id,unique_sis_user_id,unique_sis_school_id,mm_admin");

            foreach(ADContainer group in fullListOfContainers)
            {
                if(group.ListOfMembers.Count >= 1)
                {
                    foreach(User user in group.ListOfMembers)
                    {
                        string newLine = string.Format("{0},{1},{2},{3}", group.Guid, user.Guid, "TopLevel", "0");
                        csv.AppendLine(newLine);
                    }
                }
            }

            File.WriteAllText(myParent.SavePath + "\\memberships-v2.csv", csv.ToString(), Encoding.UTF8);

        }

        private void WriteGroups()
        {
            var csv = new StringBuilder();
            csv.AppendLine("unique_sis_group_id,group_name,unique_sis_user_id,unique_sis_school_id,sis_parent_group_id,apple_classroom");

            foreach(ADContainer group in fullListOfContainers)
            {
                string newLine = string.Format("{0},{1},{2},{3},{4},{5}", group.Guid, group.Name, "GroupOwner", "TopLevel", group.ParentContainerID, "");
                csv.AppendLine(newLine);
            }

            File.WriteAllText(myParent.SavePath + "\\groups-v2.csv", csv.ToString(), Encoding.UTF8);

        }

     

        private void setParentOUGUIDs()
        {
            foreach(ADContainer group in fullListOfContainers)
            {
                if (group.IsOU)
                {
  
                    DirectoryEntry parentOU = new DirectoryEntry(group.Adspath, settings.DirectoryServerUsername, settings.getDecryptedPassword());
                    //Console.WriteLine("PARENT is: " + parentOU.Parent.Guid);

                    group.ParentContainerID = parentOU.Parent.Guid.ToString();
                    Console.WriteLine("PARENT: " + group.Guid);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SyncForm_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            runSync();
        }
    }
}
