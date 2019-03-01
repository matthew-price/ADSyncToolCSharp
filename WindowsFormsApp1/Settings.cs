using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Settings
    {
        string directoryServerHostname;
        string directoryServerType;
        string directoryServerUsername;
        string directoryServerPassword;
        //Boolean ldaps;

        public Settings(string directoryServerHostname, string directoryServerType, string directoryServerUsername, string directoryServerPassword)
        {
            this.DirectoryServerHostname = directoryServerHostname;
            this.DirectoryServerType = directoryServerType;
            this.DirectoryServerUsername = directoryServerUsername;
            this.DirectoryServerPassword = directoryServerPassword;
            //this.ldaps = ldaps;
        }

        public string DirectoryServerHostname { get => directoryServerHostname; set => directoryServerHostname = value; }
        public string DirectoryServerType { get => directoryServerType; set => directoryServerType = value; }
        public string DirectoryServerUsername { get => directoryServerUsername; set => directoryServerUsername = value; }
        public string DirectoryServerPassword { get => directoryServerPassword; set => directoryServerPassword = value; }

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
