using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class User
    {

        private string userName;
        private string firstName;
        private string lastName;
        private string mail;
        private string guid;
        private string userSISId;

        public User(string userName, string firstName, string lastName, string mail, string guid)
        {
            this.userName = userName;
            this.firstName = firstName;
            this.lastName = lastName;
            this.mail = mail;
            this.guid = guid;
            userSISId = userName;
        }


    }
}
