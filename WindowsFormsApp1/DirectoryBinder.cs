using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

namespace WindowsFormsApp1
{
    class DirectoryBinder
    {
        string directoryHostname;
        string baseDN;
        string searchQuery;
        string searchType;

        public DirectoryBinder(string directoryHostname, string baseDN, string searchQuery, string searchType)
        {
            this.directoryHostname = directoryHostname;
            this.baseDN = baseDN;
            this.searchQuery = searchQuery;
            this.searchType = searchType;
        }

        public void connectToServer()
        {
            try
            {
                List<User> lstADUsers = new List<User>();
                string domainPath = "LDAP://172.17.69.52";
                DirectoryEntry searchRoot = new DirectoryEntry(domainPath, "DARKSPEED\\ADMINISTRATOR", "L1ghtsp33d");
                DirectorySearcher search = new DirectorySearcher(searchRoot);
                search.Filter = "(&(objectClass=user)(objectCategory=person))";
                search.PropertiesToLoad.Add("samaccountname");
                search.PropertiesToLoad.Add("mail");
                search.PropertiesToLoad.Add("usergroup");
                search.PropertiesToLoad.Add("displayname");
                search.PropertiesToLoad.Add("adspath");
                SearchResult result;
                SearchResultCollection resultCol = search.FindAll();
                if (resultCol != null)
                {
                    for (int i = 0; i < resultCol.Count; i++)
                    {
                        string UserNameEmailString = string.Empty;
                        result = resultCol[i];
                        if (result.Properties.Contains("samaccountname") && result.Properties.Contains("mail") && result.Properties.Contains("displayname"))
                        {
                            string samaccname = (String)result.Properties["adspath"][0];
                            Console.WriteLine(samaccname);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public DirectorySearcher createDirectoryConnection(string domainPath, string friendlyDomain, string username, string password)
        {
            DirectoryEntry searchRoot = new DirectoryEntry(domainPath, friendlyDomain + "\\" + username, password);
            DirectorySearcher search = new DirectorySearcher(searchRoot);
            return search;
        }

        public void searchForContainer(string OU, DirectorySearcher search, bool isOU){
            if (isOU)
            {
                search.Filter = "&(dn="+OU+"*)(objectClass=OU)";
            }
            else
            {
                search.Filter = "&(dn="+OU+"*)(objectClass=Group)";
            }

            search.PropertiesToLoad.Clear();
            search.PropertiesToLoad.Add("adspath");
            SearchResult result;
            SearchResultCollection resultCol = search.FindAll();

            if (resultCol != null)
            {
                for (int i = 0; i < resultCol.Count; i++)
                {
                    string adsPathString = string.Empty;
                    result = resultCol[i];
                    if (result.Properties.Contains("adspath"))
                    {
                        adsPathString = (String)result.Properties["adspath"][0];
                        Console.WriteLine(adsPathString);
                    }
                }
            }
        }

    }
}
