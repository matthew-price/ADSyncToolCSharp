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

        public string Name { get => name; set => name = value; }
        public string Adspath { get => adspath; set => adspath = value; }
        public bool IsOU { get => isOU; set => isOU = value; }



        public ADContainer(string name, string adspath, bool isOU)
        {
            this.name = name;
            this.adspath = adspath;
            this.isOU = isOU;
        }

    }
}
