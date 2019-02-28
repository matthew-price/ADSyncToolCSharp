using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

namespace WindowsFormsApp1
{
    class Playground
    {

        public static void CheckUser()
        {
            try
            {
                List<User> lstADUsers = new List<User>();
                string domainPath = "LDAP://172.17.69.52";
                DirectoryEntry searchRoot = new DirectoryEntry(domainPath);
                DirectorySearcher search = new DirectorySearcher(searchRoot);
                search.Filter = "(&(objectClass=user)(objectCategory=person))";
                search.PropertiesToLoad.Add("samaccountname");
                search.PropertiesToLoad.Add("mail");
                search.PropertiesToLoad.Add("usergroup");
                search.PropertiesToLoad.Add("displayname");
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
                            string samaccname = (String)result.Properties["samaccountname"][0];
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
    }
}
