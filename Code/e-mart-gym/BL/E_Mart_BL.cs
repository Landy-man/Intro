using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend;
using DAL;


namespace BL
{
    public class E_Mart_BL : IBL
    {
        /*
         * E_Mart_BL serves as a container to smaller classes that devide E_Mart_BL's responsabilitys 
         */ 
        private IDAL itsDAL;
        private Product_BL prod_bl;
        private Employee_BL employee_bl;
        private ClubMember_BL clubMember_bl;
        private Department_BL department_bl;
        private Transaction_BL transaction_bl;
        private User_BL user_bl;

        /*
         * constructor. recieves the data layer which E_Mart_BL works with directly
         */ 
        public E_Mart_BL(IDAL dal)
        {
            this.itsDAL = dal;
            this.prod_bl = new Product_BL(dal);
            this.employee_bl = new Employee_BL(dal);
            this.clubMember_bl = new ClubMember_BL(dal);
            this.department_bl = new Department_BL(dal);
            this.transaction_bl = new Transaction_BL(dal);
            this.user_bl = new User_BL(dal);
        }
        
        public E_Mart_BL() { }//////////וואלה לא יודע למה זה פה למחוק????????

        /******************************** ADD/REMOVE/EDIT ************************************/
            /********* ADD **********/
        /*
         * recieves an object obj intended to be added to the data base
         * obj is directed according the its instance to the correct class to handle the add(instance)
         * if obj doesnt match any of the intended classes an exception will be thrown
         */ 
        public void add(object obj)
        {
            try
            {
                if (obj is Product) { prod_bl.addProduct((Product)obj); }
                else if (obj is Employee) { employee_bl.addEmployee((Employee)obj); }
                else if (obj is ClubMember) { clubMember_bl.addClubMember((ClubMember)obj); }
                else if (obj is Department) { department_bl.addDepartment((Department)obj); }
                else if (obj is Transaction) { transaction_bl.addTransaction((Transaction)obj); }
                else if (obj is User) { user_bl.addUser((User)obj); }
                else
                {
                    throw new Exception("You Are Trying To Add An Unfamiliar Object");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

            /********* REMOVE ***********/
        /*
         * recieves an object obj intended to be removed from the data base
         * obj is directed according the its instance to the correct class to handle the remove(instance)
         * if obj doesnt match any of the intended classes an exception will be thrown
         */ 
        public void remove(object obj)
        {
            try
            {
                if (obj is Product) { prod_bl.removeProduct((Product)obj); }
                else if (obj is Employee) { employee_bl.removeEmployee((Employee)obj); }
                else if (obj is ClubMember) { clubMember_bl.removeClubMember((ClubMember)obj); }
                else if (obj is Department) { department_bl.removeDepartment((Department)obj); }
                else if (obj is Transaction) { transaction_bl.removeTransaction((Transaction)obj); }
                else if (obj is User) { user_bl.removeUser((User)obj); }
                else
                {
                    throw new Exception("You Are Trying To Remove An Unfamiliar Object");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

            /*************** EDIT ******************/
        /*
         * recieves an object obj to intended to override its previous data from data base
         * obj is directed according the its instance to the correct class to handle the edit(instance)
         * if obj doesnt match any of the intended classes an exception will be thrown
         */
        public void edit(object obj)
        {
            try
            {
                if (obj is Product) { prod_bl.editProduct((Product)obj); }
                else if (obj is Employee) { employee_bl.editEmployee((Employee)obj); }
                else if (obj is ClubMember) { clubMember_bl.editClubMember((ClubMember)obj); }
                else if (obj is Department) { department_bl.editDepartment((Department)obj); }
                else if (obj is Transaction) { transaction_bl.editTransaction((Transaction)obj); }
                else if (obj is User) { user_bl.editUser((User)obj); }
                else
                {
                    throw new Exception("You Are Trying To Edit An Unfamiliar Object");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /********************************** <END> ADD/EDIT/REMOVE <END> *************************************/
        
        /******************************************** QUERYS ******************************************************/

            /********* RANGE QUERY **********/
        /*
       * will direct the query requested to the correct function according to the instance of clas (recieved in function) 
       * and return a list containing the query results:
       * a list of objects where all where: fromValue<=field<=ToValue
       */ 
        public List<object> queryByRange(Classes clas, rangeFields field, string fromValue, string ToValue, List<object> listO=null)
        {
            if (clas == Classes.ClubMember)
            {
                return clubMember_bl.queryByRange(field, fromValue, ToValue).Cast<object>().ToList();
            }
            else if (clas == Classes.Employee)
            {
                if (listO!=null)
                    return employee_bl.queryByRange(field, fromValue, ToValue, listO.Cast<Employee>().ToList()).Cast<object>().ToList();
                else
                    return employee_bl.queryByRange(field, fromValue, ToValue).Cast<object>().ToList();
            }
            else if (clas == Classes.Product)
            {
                if (listO!=null)
                    return prod_bl.queryByRange(field, fromValue, ToValue, listO.Cast<Product>().ToList()).Cast<object>().ToList();
                else
                    return prod_bl.queryByRange(field, fromValue, ToValue).Cast<object>().ToList();
            }
            else if (clas == Classes.Transaction)
            {
                return transaction_bl.queryByRange(field, fromValue, ToValue).Cast<object>().ToList();
            }
            else
            {
                Console.WriteLine("WRONG SEARCH PARAMETERS");
                return null;
            }

        }

            /********** STRING QUERY ************/
        /*
       * will direct the query requested to the correct function according to the instance of clas (recieved in function) 
       * and return a list containing the query results:
       * a list of objects where: field == Value
       */ 
        public List<object> queryByString(Classes clas, stringFields field, string value, List<object> listO=null)
        {
            if (clas == Classes.ClubMember)
            {
                return clubMember_bl.queryByString(field, value).Cast<object>().ToList();
            }
            else if (clas == Classes.Department)
            {
                return department_bl.queryByString(field, value).Cast<object>().ToList();
            }
            else if (clas == Classes.Employee)
            {
                if (listO != null)
                    return employee_bl.queryByString(field, value, listO.Cast<Employee>().ToList()).Cast<object>().ToList();
                else
                    return employee_bl.queryByString(field, value).Cast<object>().ToList();
            }
            else if (clas == Classes.Product)
            {
                if (listO!=null)
                    return prod_bl.queryByString(field, value, listO.Cast<Product>().ToList()).Cast<object>().ToList();
                else
                    return prod_bl.queryByString(field, value).Cast<object>().ToList();
            }
            else if (clas == Classes.Transaction)
            {
                return transaction_bl.queryByString(field, value).Cast<object>().ToList();
            }
            else if (clas == Classes.User)
            {
                return user_bl.queryByString(field, value).Cast<object>().ToList();
            }
            else
            {
                Console.WriteLine("WRONG SEARCH PARAMETERS");
                return null;
            }
        }

        /**************************************** <END> QUERYS <END> ******************************************/

        /****************************************** OTHER ******************************************************/
        
        /*
         * requests itsDAL to save data to file
         */
        public void saveDataToFile()
        {
            itsDAL.saveDataToFile();
        }

        /*
         * true -> file exists
         * false -> file doesnt exist
         */ 
        public bool doesFileExist()
        {
            return itsDAL.doesFileExist();
        }

        /*
         * requests itsDAL to load data from file
         */ 
        public void loadDataFromFile()
        {
            itsDAL.loadDataFromFile();
        }

        /*
         * true -> user given equals admin
         * false -> user doesnt equal admin
         */ 
        public User isUserAdmin(User user)
        {
            return user_bl.isUserAdmin(user);
        }

        /*
         * true -> user exists in data base
         * false -> user doesnt exist in data base
         */ 
        public User isUserOk(User user)
        {
            return user_bl.isUserOk(user);
        }

        //public User getAdmin()
        //{
        //    return itsDAL.getAdmin();
        //}

        /*************//* LOOK DOWN NOW *//****************/

        /*
         * The Following Methods Returns The Container Of The Desired Class 
         * Which Contains A List Of All Instances Of The Class Desired
         */
 
        //look up
        public Products getAllProducts()
        {
            return prod_bl.getAllProducts();
        }
        //look up
        public Users getAllUsers()
        {
            return user_bl.getAllUsers();
        }
        //look up
        public Departments getAllDepartments()
        {
            return department_bl.getAllDepartments();
        }
        //look up
        public ClubMembers getAllClubMembers()
        {
            return clubMember_bl.getAllClubMembers();
        }
        //look up
        public Transactions getAllTransaction()
        {
            return transaction_bl.getAllTransaction();
        }
        //look up
        public Employees getAllEmployees()
        {
            return employee_bl.getAllEmployees();
        }


        public void clearReceipt(Receipt receipt)
        {
            this.prod_bl.clearReceipt(receipt);
        }
    }
}
