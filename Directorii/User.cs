using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directorii
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
            this.UserName = userName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Mail = mail;
            this.Guid = guid;
            UserSISId = userName;
        }

        public string UserName { get => userName; set => userName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Guid { get => guid; set => guid = value; }
        public string UserSISId { get => userSISId; set => userSISId = value; }
    }
}
