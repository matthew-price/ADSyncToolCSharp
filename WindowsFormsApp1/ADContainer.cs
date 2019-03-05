using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class ADContainer
    {

        private string name;
        private string adspath;
        private bool isOU;
        private List<User> listOfMembers = new List<User>();
        private string guid;
        private List<ADContainer> listOfChildContainers = new List<ADContainer>();
        private ADContainer parentContainer;

        public string Name { get => name; set => name = value; }
        public string Adspath { get => adspath; set => adspath = value; }
        public bool IsOU { get => isOU; set => isOU = value; }
        internal List<User> ListOfMembers { get => listOfMembers; set => listOfMembers = value; }
        public string Guid { get => guid; set => guid = value; }
        internal List<ADContainer> ListOfChildContainers { get => listOfChildContainers; set => listOfChildContainers = value; }
        internal ADContainer ParentContainer { get => parentContainer; set => parentContainer = value; }

        public ADContainer(string name, string adspath, bool isOU, string guid)
        {
            this.name = name;
            this.adspath = adspath;
            this.isOU = isOU;
            this.Guid = guid;
        }

        public override string ToString()
        {
            return Name;
        }


    }



}
