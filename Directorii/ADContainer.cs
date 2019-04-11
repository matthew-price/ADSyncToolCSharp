using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directorii
{
    class ADContainer
    {

        private string name;
        private string adspath;
        private bool isOU;
        private List<User> listOfMembers = new List<User>();
        private string guid;
        private List<ADContainer> listOfChildContainers = new List<ADContainer>();
        private string parentContainerID;
        private string manualSisID;
        private string parentGuid;
        private bool usingManualSisID = false;
        private string schoolSisID;

        public string Name { get => name; set => name = value; }
        public string Adspath { get => adspath; set => adspath = value; }
        public bool IsOU { get => isOU; set => isOU = value; }
        internal List<User> ListOfMembers { get => listOfMembers; set => listOfMembers = value; }
        public string Guid { get => guid; set => guid = value; }
        internal List<ADContainer> ListOfChildContainers { get => listOfChildContainers; set => listOfChildContainers = value; }
        internal string ParentContainerID { get => parentContainerID; set => parentContainerID = value; }
        public string ManualSisID { get => manualSisID; set => manualSisID = value; }
        public bool UsingManualSisID { get => usingManualSisID; set => usingManualSisID = value; }
        public string ParentGuid { get => parentGuid; set => parentGuid = value; }
        public string SchoolSisID { get => schoolSisID; set => schoolSisID = value; }

        public ADContainer(string name, string adspath, bool isOU, string guid, string schoolSisID)
        {
            this.name = name;
            this.adspath = adspath;
            this.isOU = isOU;
            this.Guid = guid;
            this.schoolSisID = schoolSisID;
        }

        public override string ToString()
        {
            return Name;
        }


    }



}
