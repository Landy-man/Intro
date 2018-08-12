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
    public class E_Mart_Store
    {
        /********************************************************
         * 
         * The class will simulate the whole Super Market
         * will contain all the lists of all relevnt data such as:
         * Club Members, Departments, Employees, Products, Transactions & Users
         * 
         * *******************************************************/
        private Products products;
        private Employees employees;
        private Transactions transactions;
        private ClubMembers clubMembers;
        private Users users;
        private Departments departments;


        public E_Mart_Store()
        {
            products = new Products();
            employees = new Employees();
            transactions = new Transactions();
            clubMembers = new ClubMembers();
            users = new Users();
            departments = new Departments();
        }
        /***************************************Methods*****************************************************/
        /************Get/Set***************/
        public Products Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
        public Employees Employees
        {
            get { return this.employees; }
            set { this.employees = value; }
        }
        public Transactions Transactions
        {
            get { return this.transactions; }
            set { this.transactions = value; }
        }
        public ClubMembers Clubmembers
        {
            get { return this.clubMembers; }
            set { this.clubMembers = value; }
        }
        public Departments Departments
        {
            get { return this.departments; }
            set { this.departments = value; }
        }
        public Users Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
        /****************************** Add/Remove To/From Lists ***********************************/
        public void addProduct(Product product)
        {
            this.products.addProduct(product);
        }
        public void addEmployee(Employee employee)
        {
            this.employees.addEmployee(employee);
        }
        public void addTransaction(Transaction transaction)
        {
            this.transactions.addTransaction(transaction);
        }
        public void addClubMember(ClubMember clubMember)
        {
            this.clubMembers.addClubMember(clubMember);
        }
        public void addUser(User user)
        {
            this.users.addUser(user);
        }
        public void addDepartment(Department department)
        {
            this.departments.addDepartment(department);
        }

        /******************Other*********************************/
        public string toString()
        {
            string ans = "";
            ans = ans +
                "products: \n" + products.toString() + "\n" +
                "transactions: \n" + transactions.toString() + "\n" +
                "CLUB MBMERS: \n" + clubMembers.toString() + "\n" +
                "EMployees: \n" + employees.toString() + "\n" +
                "Departments: \n" + departments.toString() + "\n" +
                "USERS: \n" + users.toString();
            return ans;
        }
        //    public ObjectToSerialize()
        // {
        // }
        //public void save()
        //{

        //}
    }
}
