using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Backend;

namespace BL
{
    public class User_BL
    {
        IDAL itsDAL;

        public User_BL(IDAL dal)
        {
            this.itsDAL = dal;
        }

        /********************************** ADD/REMOVE/EDIT ****************************/
            /********* ADD **********/
        /*
         * requests itsDAL to add user after:
         * 1. checking if the user's userName doesnt allready exist in database
         */
        public void addUser(User user)
        {
            try
            {
                doesNameExist(user);
            }
            catch (Exception e)
            {
                throw e;
            }
            this.itsDAL.addUser(user);
        }

            /************ EDIT ************/
        /*
         * requests itsDAL to edit user
         */
        public void editUser(User user)
        {
            this.itsDAL.editUser(user);
        }

            /******** REMOVE *******/
        /*
         * requests itsDAL to remove user after:
         * 1. checking if the user trying to be deleted isnt the last user
         * 2. checking if the user attempted to be deleted isnt admin
         * 3. checks if the user attempted to be deleted truely exists
         */
        public void removeUser(User user)
        {
            try
            {
                checkIsOnlyUser(user);//1
            }
            catch (Exception e)
            {
                throw e;
            }

            if(itsDAL.isUserAdmin(user)!=null) throw new Exception("The Admin User Cannot Be Deleted");//2
            if (!doesUserExist(user.UserName, user.Password))//3
            {
                throw new Exception("User you are tring to delet is not on record please check again.");
            }
            this.itsDAL.removeUser(user);
        }

            /*********** PRIVATE METHODS ***********/
        /*
         * throws an exception if the user.userName allready exists in the user database
         */
        private void doesNameExist(User user)
        {
            Users allUsers = this.itsDAL.getAllUsers();
            foreach (User user1 in allUsers.Userss)
            {
                if (user1.UserName.Equals(user.UserName))
                {
                    throw new Exception("User name is in use");
                }
            }
        }

        
        /*
         * throws an exception if the user is the only user left in database
         */
        private void checkIsOnlyUser(User user)
        {
            Users allUsers = this.itsDAL.getAllUsers();
            if ((allUsers.Userss.Count() == 1) && allUsers.Userss.ElementAt(0) == user)
                throw new Exception("You are the last user, there must be at least one user in archive");
        }

        /****************************** <END> ADD/REMOVE/EDIT <END> **********************************/
        
        /*************************************** QUERYS *****************************************/
            /*********** STRING QUERY ***************/
        /*
     * will direct the query requested to the correct function in the this.itsDAL interface 
     * and return a list containing the query results:
     * a list of all the users where field equals value
     */
        public List<User> queryByString(stringFields field, string value)
        {
            if (field == stringFields.userName)
            {
                return itsDAL.userStringQuery(field, value);
            }
            Console.WriteLine("WRONG SEARCH PARAMETERS");
            return null;
        }

        /******************** <END> QUERYS <END> ****************************/

        /************************************** OTHER *****************************************/

        /*
         * true -> user exists in user database
         * false -> user doesnt exist in user database
         */
        internal User isUserOk(User user)
        {
            return itsDAL.isUserOk(user);
        }

        /*
         * true -> user is admin
         * false -> user isnt admin
         */
        internal User isUserAdmin(User user)
        {
            return itsDAL.isUserAdmin(user);
        }

        /*
         * requests,recieves and returns a container containing a list of all users in database
         */
        public Users getAllUsers()
        {
           return itsDAL.getAllUsers();
        }

        /*
         * true -> user exists in database
         * false -> user doesnt exist in the database
         */
        public bool doesUserExist(string name, string password)
        {
            bool ans = false;
            Users allUsers = this.itsDAL.getAllUsers();
            foreach (User user in allUsers.Userss)
            {
                if (user.UserName.Equals(name) && (user.Password.Equals(password)))
                {
                    ans = true;
                }
            }
            return ans;
        }
    }
}
