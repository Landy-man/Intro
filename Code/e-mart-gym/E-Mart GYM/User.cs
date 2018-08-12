using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Backend
{
    public enum Hierarchy { Adminstor , Manager, Worker, Clubmember, Customer}

    [XmlRoot("E-Mart"), Serializable]
    public class User
    {
        /**********************Fields****************************/
        private string userName;
        private string password;
        private Hierarchy hierarchy = Hierarchy.Customer;
        /**********************Methods**********************************/
        /***************************************Constructor*************************************/
        public User(string userName, string password)
        {
            if (userName.Length < 4) throw new Exception("User Name Must Contain Atleast 4 Characters.");
            if (password.Length < 4) throw new Exception("Password Must Contain Atleast 4 Characters.");
            this.userName = userName;
            this.password = password;
        }

        public User(string userName, string password, Hierarchy hierarchy)
        {
            if (userName.Length < 4) throw new Exception("User Name Must Contain Atleast 4 Characters.");
            if (password.Length < 4) throw new Exception("Password Must Contain Atleast 4 Characters.");
            this.userName = userName;
            this.password = password;
            this.hierarchy = hierarchy;
        }

        public User(User user)
        {
            this.UserName = user.UserName;
            this.Password = user.Password;
        }

        public User()
        {

        }
        /***********gETTERS/sETTERS**************/
        public string UserName
        {
            get { return this.userName; }
            set { this.userName = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public Hierarchy Hierarchy
        {
            get { return this.hierarchy; }
            set { this.hierarchy = value; }
        }

        public bool equals(User other)
        {
            return ((this.userName.Equals(other.userName)) && (this.password.Equals(other.password)));
        }

        /**********************Other******************/
        public string toString()
        {
            return "User Name: " + userName;
                   
        }
    }
}
