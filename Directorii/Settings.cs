using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Directorii
{
    public class Settings
    {
        private string directoryServerDomain;
        private string directoryServerHostname;
        private string directoryServerType;
        private string directoryServerUsername;
        private string encryptedPassword;
        private string entropy;
        private List<ADContainer> listOfADContainers;
        private bool usingUsernameAsSisID;
        private string defaultSisID;

        //Boolean ldaps;

        public Settings(string directoryServerHostname, string directoryServerType, string directoryServerUsername, string directoryServerDomain)
        {
            this.DirectoryServerHostname = directoryServerHostname;
            this.DirectoryServerType = directoryServerType;
            this.DirectoryServerUsername = directoryServerUsername;
            this.DirectoryServerDomain = directoryServerDomain;
            usingUsernameAsSisID = false;
            defaultSisID = "TopLevel";
            //this.ldaps = ldaps;

        }

        public string DirectoryServerHostname { get => directoryServerHostname; set => directoryServerHostname = value; }
        public string DirectoryServerType { get => directoryServerType; set => directoryServerType = value; }
        public string DirectoryServerUsername { get => directoryServerUsername; set => directoryServerUsername = value; }
        public string EncryptedPasssword { get => encryptedPassword; set => encryptedPassword = value; }
        public string Entropy { get => entropy; set => entropy = value; }
        public string DirectoryServerDomain { get => directoryServerDomain; set => directoryServerDomain = value; }
        public bool UsingUsernameAsSisID { get => usingUsernameAsSisID; set => usingUsernameAsSisID = value; }
        public string DefaultSisID { get => defaultSisID; set => defaultSisID = value; }
        internal List<ADContainer> ListOfADContainers { get => listOfADContainers; set => listOfADContainers = value; }

        public string getDecryptedPassword()
        {
            if (encryptedPassword != null)
            {
                string decryptedPassword = UnicodeEncoding.UTF8.GetString(ProtectedData.Unprotect(Convert.FromBase64String(encryptedPassword), Convert.FromBase64String(Entropy), DataProtectionScope.LocalMachine));
                Console.WriteLine("DECRYPTED PASSWORD: " + decryptedPassword);
                return decryptedPassword;
            }
            else
            {
                return "password";
            }
        }

        public void setEntropy(string entropy)
        {
            this.Entropy = entropy;
        }




        /* public void writeSettingsFile()
         {
             string output = JsonConvert.SerializeObject(this, Formatting.Indented);
             Console.WriteLine("Output: " + output);
             StreamWriter sw = new StreamWriter(@"c:\\Testing\\settings.json");
             sw.Write(output);
             sw.Close();
         }
         */

    }
}
