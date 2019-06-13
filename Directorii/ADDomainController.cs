using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Directorii
{
    public class ADDomainController
    {
        #region private variables
        private string directoryServerDomain;
        private string directoryServerHostname;
        private string directoryServerType;
        private string directoryServerUsername;
        private string encryptedPassword;
        private string entropy;
        private bool ldaps = false;
        private string ldapConnectionAddress;

        public string DirectoryServerDomain { get => directoryServerDomain; set => directoryServerDomain = value; }
        public string DirectoryServerHostname { get => directoryServerHostname; set => directoryServerHostname = value; }
        public string DirectoryServerType { get => directoryServerType; set => directoryServerType = value; }
        public string DirectoryServerUsername { get => directoryServerUsername; set => directoryServerUsername = value; }
        public string EncryptedPassword { get => encryptedPassword; set => encryptedPassword = value; }
        public string Entropy { get => entropy; set => entropy = value; }
        public bool Ldaps { get => ldaps; set => ldaps = value; }
        public string LdapConnectionAddress { get => ldapConnectionAddress; set => ldapConnectionAddress = value; }

        #endregion


        public ADDomainController(string directoryServerHostname, string directoryServerType, string directoryServerUsername, string directoryServerDomain)
        {
            this.DirectoryServerHostname = directoryServerHostname;
            this.DirectoryServerUsername = directoryServerUsername;
            this.DirectoryServerDomain = directoryServerDomain;
        }

        public string getDecryptedPassword()
        {
            if (encryptedPassword != null)
            {
                string decryptedPassword = UnicodeEncoding.UTF8.GetString(ProtectedData.Unprotect(Convert.FromBase64String(encryptedPassword), Convert.FromBase64String(Entropy), DataProtectionScope.LocalMachine));
                //Console.WriteLine("DECRYPTED PASSWORD: " + decryptedPassword);
                return decryptedPassword;
            }
            else
            {
                return "password";
            }
        }

    }
}
