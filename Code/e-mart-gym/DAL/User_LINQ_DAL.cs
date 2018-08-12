using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend;

namespace DAL
{
    public class User_LINQ_DAL
    {
        private List<User> users;

        //constructor
        public User_LINQ_DAL(Users users)
        {
            this.users = users.Userss;
        }
        //adds user to user databaase
        public void addUser(User users)
        {
            this.users.Add(users);
        }

        //removes user userToDelete from database, finds him by comparing userName's
        public void removeUser(User userToDelete)
        {
            foreach(User user in users)
            {
                if(user.UserName == userToDelete.UserName)
                {
                    this.users.Remove(user);
                    return;
                }
            }
        }

        //replaces previous users data with new users data, finds previous by comparing user name's
        public void editUser(User users)
        {
            for (int i = 0; i < this.users.Count; i++)
            {
                if (this.users.ElementAt(i).UserName.Equals(users.UserName))
                {
                    removeUser(this.users.ElementAt(i));
                    addUser(users);
                    return;
                }
            }

        }

        //returns a list of users where userName = value
        internal List<User> userNameQuery(string value)
        {
            var name =
                from u in users
                where u.UserName == value
                select u;

            return name.ToList<User>();
        }

        private User getAdmin()
        {
            User admin = new User("Admin", "1234*",Hierarchy.Adminstor);
            return admin;
        }

        //returns true if user exists in user database, false otherwhise
        public User isUserOk(User user)
        {
            foreach (User u in users)
            {
                if (u.equals(user)) return u;
            }
            return null;
        }

        //returns true if user is admin, false otherwhise
        public User isUserAdmin(User user)
        {
            if (user.equals(getAdmin()))
            {
                //addUser(user);
                return getAdmin();
            }
            return null;
        }
    }
}
