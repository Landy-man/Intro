using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Backend
{
    [XmlRoot("E-Mart"), Serializable]
    public class Users
    {
        private List<User> users = new List<User>();

        /*********************Constructor************************/
        public Users(List<User> users)
        {
            this.users = users;
        }
        public Users()
        {

        }
        /**************Methods***********************/
        /********Get/Set****************/
        public List<User> Userss
        {
            get { return this.users; }
            set { this.users = value; }
        }
        public void addUser(User userToAdd)
        {
            users.Add(userToAdd);
        }
        public void removeUser(User userToRemove)
        {
            users.Remove(userToRemove);
        }
        /*************Other***************/
        public string toString()
        {
            string ans = "";
            foreach (User user in users)
            {
                ans = ans + user.toString() + "\n";
            }
            return ans;
        }
    }
}
