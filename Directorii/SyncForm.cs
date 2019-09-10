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
using System.Text.RegularExpressions;

namespace Directorii
{
    public partial class SyncForm : Form
    {

        #region private variables
        private SplashForm myParent;
        private Dictionary<string, User> fullListOfUsers = new Dictionary<string, User>();
        private List<User> fullLisfOfUsers = new List<User>();
        private Dictionary<string, ADContainer> fullListOfContainers = new Dictionary<string, ADContainer>();
        private Settings settings;
        private DirectorySearcher search; //only used for user searching. Searching for child OUs requires a fresh DirectorySearcher, as there will be a different Base Path for each parent OU.
        private bool syncErrorExperienced = false;

        // for window dragging ability
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        // end of window dragging ability

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

            CreateFullListOfADContainers();
            if (syncErrorExperienced) { preparingUsersLabel.ForeColor = System.Drawing.Color.Red; }
            if (!syncErrorExperienced) { AddMembersToADContainers(); }
            if (!syncErrorExperienced) { writeUsers(); }

            if (!syncErrorExperienced) { preparingMembershipsLabel.ForeColor = System.Drawing.Color.WhiteSmoke; } else { preparingMembershipsLabel.ForeColor = System.Drawing.Color.Red;}
            if (!syncErrorExperienced) { WriteMemberships(); }

            if (!syncErrorExperienced) { preparingHeirarchyLabel.ForeColor = System.Drawing.Color.WhiteSmoke; } else { preparingHeirarchyLabel.ForeColor = System.Drawing.Color.Red; }
            if (!syncErrorExperienced) { setParentOUGUIDs(); }

            if (!syncErrorExperienced) { preparingGroupsLabel.ForeColor = System.Drawing.Color.WhiteSmoke; } else { preparingGroupsLabel.ForeColor = System.Drawing.Color.Red; }
            if (!syncErrorExperienced) { CheckWhetherParentGroupIsBeingImported(); }
            if (!syncErrorExperienced) { WriteGroups(); }

            if (!syncErrorExperienced) { doneLabel.ForeColor = System.Drawing.Color.WhiteSmoke; } else { doneLabel.ForeColor = System.Drawing.Color.Red; }
            if (!syncErrorExperienced) { CopyFilesToSmbShare(); }
        }

        private void AddMembersToADContainers()
        {
            foreach (var group in fullListOfContainers.Values)
            {
                // getting ADDC details
                ADDomainController dc = myParent.DictionaryOfADDomainControllers[group.DomainControllerKey];
                if (group.IsOU)
                {
                    Console.WriteLine("*****SEARCHING OU: " + group.Name + "GUID: " + group.Guid);
                    DirectoryEntry ouToSearch = new DirectoryEntry(group.Adspath, dc.DirectoryServerUsername, dc.getDecryptedPassword());
                    DirectorySearcher userSearch = new DirectorySearcher(ouToSearch);
                    userSearch.PageSize = 1000;
                    userSearch.SearchScope = SearchScope.OneLevel;

                    userSearch.PropertiesToLoad.Add("givenName");
                    userSearch.PropertiesToLoad.Add("sn");
                    userSearch.PropertiesToLoad.Add("mail");
                    userSearch.PropertiesToLoad.Add("samaccountname");
                    userSearch.PropertiesToLoad.Add("name");
                    userSearch.PropertiesToLoad.Add("objectguid");

                    userSearch.Filter = "(&(objectCategory=User)(givenname=*)(sn=*)(samaccountname=*)(name=*))";

                    SearchResultCollection resultCol = userSearch.FindAll();

                    foreach (SearchResult user in resultCol)
                    {
                        //Console.WriteLine("USER ADDED: " + new Guid((System.Byte[])user.Properties["objectguid"][0]).ToString());
                        string mailAddress;
                        if (user.Properties["mail"].Count == 0)
                        {
                            mailAddress = user.Properties["samaccountname"][0].ToString() + "@" + dc.DirectoryServerDomain + ".com";
                        }
                        else
                        {
                            mailAddress = user.Properties["mail"][0].ToString();
                        }
                        User newUser = new User(user.Properties["samaccountname"][0].ToString(), user.Properties["givenName"][0].ToString(), user.Properties["sn"][0].ToString(), mailAddress, new Guid((System.Byte[])user.Properties["objectguid"][0]).ToString());
                        newUser.SchoolSISId = group.SchoolSisID;

                        if (settings.UsingUsernameAsSisID)
                        {
                            newUser.UserSISId = user.Properties["samaccountname"][0].ToString();
                        }
                        else
                        {
                            newUser.UserSISId = newUser.Guid;
                        }

                        group.ListOfMembers.Add(newUser);
                        //Console.WriteLine("ADDED TO GROUP:" + group.Name);

                        if (!fullListOfUsers.ContainsKey(newUser.Guid))
                        {
                            fullListOfUsers.Add(newUser.Guid, newUser);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Searching Group: " + group.Name);
                    string port;
                    if (dc.Ldaps) { port = ":636";} else { port = ":389"; }
                    DirectoryEntry groupDE = new DirectoryEntry("LDAP://" + dc.DirectoryServerHostname + port, dc.DirectoryServerUsername, dc.getDecryptedPassword());
                    DirectorySearcher groupSE = new DirectorySearcher(groupDE);
                    groupSE.PropertiesToLoad.Add("givenName");
                    groupSE.PropertiesToLoad.Add("sn");
                    groupSE.PropertiesToLoad.Add("mail");
                    groupSE.PropertiesToLoad.Add("samaccountname");
                    groupSE.PropertiesToLoad.Add("name");
                    groupSE.PropertiesToLoad.Add("objectguid");

                    Console.WriteLine("GETTING USERS FOR GROUP WITH DN: " + group.Cn);
                    groupSE.Filter = "(&(memberOf=" + group.Cn + ")(objectCategory=User)(givenname=*)(sn=*)(samaccountname=*)(name=*))";
                    Console.WriteLine("FILTERING: " + groupSE.Filter);

                    foreach (SearchResult user in groupSE.FindAll())
                    {

                        string mailAddress;
                        if (user.Properties["mail"].Count == 0)
                        {
                            mailAddress = user.Properties["samaccountname"][0].ToString() + "@" + dc.DirectoryServerDomain + ".com";
                        }
                        else
                        {
                            mailAddress = user.Properties["mail"][0].ToString();
                        }

                        User newUser = new User(user.Properties["samaccountname"][0].ToString(), user.Properties["givenName"][0].ToString(), user.Properties["sn"][0].ToString(), mailAddress.ToString(), new Guid((System.Byte[])user.Properties["objectguid"][0]).ToString());
                        newUser.SchoolSISId = group.SchoolSisID;
                        if (settings.UsingUsernameAsSisID)
                        {
                            newUser.UserSISId = user.Properties["samaccountname"][0].ToString();
                        }
                        else
                        {
                            newUser.UserSISId = newUser.Guid;
                        }

                        group.ListOfMembers.Add(newUser);
                        Console.WriteLine("ADDED TO GROUP:" + group.Name);

                        if (!fullListOfUsers.ContainsKey(newUser.Guid))
                        {
                            fullListOfUsers.Add(newUser.Guid, newUser);
                        }
                    }
                }
            }
        }

        private void CreateFullListOfADContainers()
        {
            for (int i = 0; i < myParent.ListOfAdContainers.Count; i++)
            {
                // Process Organizational Units
                if (myParent.ListOfAdContainers[i].IsOU)
                {
                    
                    // adding this container first, to ensure that any custom sisID fields are preserved. if it already exists, remove it
                    if (fullListOfContainers.ContainsKey(myParent.ListOfAdContainers[i].Guid))
                    {
                        fullListOfContainers.Remove(myParent.ListOfAdContainers[i].Guid);
                    }
                    fullListOfContainers.Add(myParent.ListOfAdContainers[i].Guid, myParent.ListOfAdContainers[i]);

                    ADDomainController dc = myParent.DictionaryOfADDomainControllers[myParent.ListOfAdContainers[i].DomainControllerKey];
                    DirectoryEntry parentOU = new DirectoryEntry(myParent.ListOfAdContainers[i].Adspath, dc.DirectoryServerUsername, dc.getDecryptedPassword());
                    Console.WriteLine("!!!!!!" + myParent.ListOfAdContainers[i].Adspath);
                    DirectorySearcher searchForChildOUs = new DirectorySearcher(parentOU);

                    searchForChildOUs.PropertiesToLoad.Add("adspath");
                    searchForChildOUs.PropertiesToLoad.Add("Name");
                    searchForChildOUs.PropertiesToLoad.Add("objectguid");
                    searchForChildOUs.Filter = "(objectCategory=organizationalUnit)";

                    try
                    {
                        SearchResultCollection resultCol = searchForChildOUs.FindAll();

                        for (int j = 0; j < resultCol.Count; j++)
                        {
                            Console.WriteLine("New OU: " + resultCol[j].Properties["Name"][0].ToString() + " PATH: " + resultCol[j].Properties["adspath"][0].ToString());
                            ADContainer containerToAdd = new ADContainer(resultCol[j].Properties["Name"][0].ToString(), resultCol[j].Properties["adspath"][0].ToString(), true, new Guid((System.Byte[])resultCol[j].Properties["objectguid"][0]).ToString(), myParent.ListOfAdContainers[i].SchoolSisID);
                            if (!fullListOfContainers.ContainsKey(containerToAdd.Guid))
                            {
                                fullListOfContainers.Add(containerToAdd.Guid, containerToAdd);
                                containerToAdd.DomainControllerKey = myParent.ListOfAdContainers[i].DomainControllerKey;
                                Console.WriteLine("*** ADDED OU: " + containerToAdd.Name);
                            }
                        }
                    } catch (System.Runtime.InteropServices.COMException)
                    {
                        MessageBox.Show("The server does not appear to be running at " + myParent.ListOfAdContainers[i].Adspath, "Cannot reach server", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        syncErrorExperienced = true;
                        return;
                    }
                }
                else
                // Process Groups
                {
                    fullListOfContainers.Add(myParent.ListOfAdContainers[i].Guid, myParent.ListOfAdContainers[i]);
                    Console.WriteLine("***" + "* ADDED GROUP: " + myParent.ListOfAdContainers[i].Name);
                }
            }
        }

        private void writeUsers()
        {
            var csv = new StringBuilder();
            csv.AppendLine("unique_sis_user_id,username,first_name,last_name,unique_sis_school_id,grade,email,user_type,password,authentication");

            foreach(User user in fullListOfUsers.Values)
            {
                var uniqueUserSisId = user.UserSISId;
                var userName = user.UserName;
                //var firstName = Regex.Replace(user.FirstName, @"[^\u0000-\u007F]+", string.Empty);
                //var lastName = Regex.Replace(user.LastName, @"[^\u0000-\u007F]+", string.Empty);
                var firstName = user.FirstName;
                var lastName = user.LastName;
                var uniqueSchoolSisId = user.SchoolSISId;
                var grade = "";
                var email = user.Mail;
                var user_type = 1;
                var password = "";
                var authentication = 0;

                string newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", uniqueUserSisId.ToString(), userName.ToString(), firstName.ToString(), lastName.ToString(), uniqueSchoolSisId.ToString(), grade.ToString(), email.ToString(), user_type.ToString(), password.ToString(), authentication.ToString());
                csv.AppendLine(newLine);
            }
            try
            {
                File.WriteAllText(myParent.SavePath + "\\users-v2.csv", csv.ToString(), new System.Text.UTF8Encoding(false));
            } catch (System.IO.IOException)
            {
                MessageBox.Show("Unable to write users-v2.csv file. \n Is the file open in another application?");
            }
        }

        private void WriteMemberships()
        {
            var csv = new StringBuilder();
            csv.AppendLine("unique_sis_group_id,unique_sis_user_id,unique_sis_school_id,mm_admin");

            foreach(ADContainer group in fullListOfContainers.Values)
            {
                Console.WriteLine("CHECKING GROUP GUID " + group.Guid);
                if(group.ListOfMembers.Count >= 1)
                {
                    Console.WriteLine("WRITING GROUP GUID: " + group.Guid);
                    foreach(User user in group.ListOfMembers)
                    {
                        string groupSisID;
                        if (group.UsingManualSisID)
                        {
                            groupSisID = group.ManualSisID;
                        }
                        else
                        {
                            groupSisID = group.Guid;
                        }
                        string newLine = string.Format("{0},{1},{2},{3}", groupSisID, user.UserSISId, group.SchoolSisID, "0");
                        csv.AppendLine(newLine);
                    }
                }
            }
            try
            {
                File.WriteAllText(myParent.SavePath + "\\memberships-v2.csv", csv.ToString(), new System.Text.UTF8Encoding(false));
            } catch (System.IO.IOException)
            {
                MessageBox.Show("Unable to write to memberships-v2.csv \n Is the file being used by another application?");
            }
        }

        private void CheckWhetherParentGroupIsBeingImported()
        {
            foreach(ADContainer group in fullListOfContainers.Values){
                if (group.IsOU == true)
                {
                    var parentID = group.ParentGuid;
                    if (!fullListOfContainers.ContainsKey(parentID))
                    {
                        Console.WriteLine("REMOVING PARENT ID FOR: " + group.Name);
                        group.ParentContainerID = "";
                    }
                }
            }
        }

        private void WriteGroups()
        {
            var csv = new StringBuilder();
            csv.AppendLine("unique_sis_group_id,group_name,unique_sis_user_id,unique_sis_school_id,sis_parent_group_id,apple_classroom");

            foreach(ADContainer group in fullListOfContainers.Values)
            {
                if (!group.UsingManualSisID)
                {
                    string newLine = string.Format("{0},{1},{2},{3},{4},{5}", group.Guid, group.Name, "GroupOwner", group.SchoolSisID, group.ParentContainerID, "");
                    csv.AppendLine(newLine);
                }
                else
                {
                    string newLine = string.Format("{0},{1},{2},{3},{4},{5}", group.ManualSisID, group.Name, "GroupOwner", group.SchoolSisID, group.ParentContainerID, "");
                    csv.AppendLine(newLine);
                }
            }
            try
            {
                File.WriteAllText(myParent.SavePath + "\\groups-v2.csv", csv.ToString(), new System.Text.UTF8Encoding(false));
            }
            catch (System.IO.IOException){
                MessageBox.Show("Unable to write groups-v2.csv file. \n Is the file being used by another application?");
            }
        }

     

        private void setParentOUGUIDs()
        {
            foreach(ADContainer group in fullListOfContainers.Values)
            {
                if (group.IsOU)
                {

                    ADDomainController dc = myParent.DictionaryOfADDomainControllers[group.DomainControllerKey];
                    DirectoryEntry parentOU = new DirectoryEntry(group.Adspath, dc.DirectoryServerUsername, dc.getDecryptedPassword());
                    //Console.WriteLine("PARENT is: " + parentOU.Parent.Guid);

                    //Check whether the parent group has a manual SIS ID in place, and use that if it exists
                    if(fullListOfContainers.ContainsKey(parentOU.Parent.Guid.ToString()) && fullListOfContainers[parentOU.Parent.Guid.ToString()].UsingManualSisID)
                    {
                        Console.WriteLine("OU NAME TO CHECK: " + fullListOfContainers[parentOU.Guid.ToString()].Name);
                        Console.WriteLine("CUSTOM ID: " + fullListOfContainers[parentOU.Parent.Guid.ToString()].UsingManualSisID + " Parent: " + fullListOfContainers[parentOU.Parent.Guid.ToString()].ManualSisID);
                        group.ParentContainerID = fullListOfContainers[parentOU.Parent.Guid.ToString()].ManualSisID;
                        group.ParentGuid = parentOU.Parent.Guid.ToString();
                    }
                    else
                    {
                        Console.WriteLine("NOT CUSTOM. CHECKING: " + parentOU.Parent.Name + " USING PARENT ID: " + parentOU.Parent.Guid.ToString());
                        group.ParentContainerID = parentOU.Parent.Guid.ToString();
                        group.ParentGuid = parentOU.Parent.Guid.ToString();
                    }
                } else
                {
                    ADDomainController dc = myParent.DictionaryOfADDomainControllers[group.DomainControllerKey];
                    DirectoryEntry parentGroup = new DirectoryEntry(group.Adspath, dc.DirectoryServerUsername, dc.getDecryptedPassword());
                    Console.WriteLine("PARENT GROUP IS: " + parentGroup.Parent.Guid);

                    if(fullListOfContainers.ContainsKey(parentGroup.Parent.Guid.ToString()) && fullListOfContainers[parentGroup.Parent.Guid.ToString()].UsingManualSisID)
                    {
                        Console.WriteLine("GROUP NAME TO CHECK: " + fullListOfContainers[parentGroup.Guid.ToString()].Name);
                        Console.WriteLine("CUSTOM ID: " + fullListOfContainers[parentGroup.Parent.Guid.ToString()].ManualSisID);
                    }

                }
            }
        }

        private void CopyFilesToSmbShare()
        {
            if (!settings.SmbCopyEnabled) return;
            try
            {
                File.Copy(myParent.SavePath + "\\users-v2.csv", settings.SmbDriveLetter + ":\\sis_import\\users-v2.csv", true);
                File.Copy(myParent.SavePath + "\\memberships-v2.csv", settings.SmbDriveLetter + ":\\sis_import\\memberships-v2.csv", true);
                File.Copy(myParent.SavePath + "\\groups-v2.csv", settings.SmbDriveLetter + ":\\sis_import\\groups-v2.csv", true);
            } catch (IOException)
            {
                MessageBox.Show("Unable to write files to the Rocket share. \nIs the share mapped to the correct drive letter and available?", "Failed to copy sync files", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void SyncForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
