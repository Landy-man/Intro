using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Backend;

namespace DAL
{

    public class LINQ_DAL : IDAL
    {
        private E_Mart_Store eMart = new E_Mart_Store();
        private Product_LINQ_DAL product_Linq_DAL;
        private Employee_LINQ_DAL employee_Linq_DAL;
        private ClubMember_LINQ_DAL clubMember_Linq_DAL;
        private Department_LINQ_DAL department_Linq_DAL;
        private Transaction_LINQ_DAL transaction_Linq_DAL;
        private User_LINQ_DAL user_Linq_DAL;

        private Serialize serialize = new Serialize();
        private AES aes = new AES();

        //private string filename = "C:\\Users\\SHELDON\\Desktop\\DATAFILE1";
        private string filename = "DATAFILE12349";
        private string password = "MAKV2SPBNI99212";

        //constructor
        public LINQ_DAL()
        {
            enitializeLinqDal();
        }

        //sets variables to new and updated ones
        public void enitializeLinqDal()
        {
            this.product_Linq_DAL = new Product_LINQ_DAL(eMart.Products);
            this.employee_Linq_DAL = new Employee_LINQ_DAL(eMart.Employees);
            this.clubMember_Linq_DAL = new ClubMember_LINQ_DAL(eMart.Clubmembers);
            this.department_Linq_DAL = new Department_LINQ_DAL(eMart.Departments);
            this.transaction_Linq_DAL = new Transaction_LINQ_DAL(eMart.Transactions);
            this.user_Linq_DAL = new User_LINQ_DAL(eMart.Users);
        }

       //tester method: prints xml file to console
        //public void toConsole(E_Mart_Store db)
        //{

        //    XmlSerializer x1 = new XmlSerializer(typeof(E_Mart_Store));
        //    x1.Serialize(Console.Out, db);
        //    Console.WriteLine();
        //    Console.ReadLine();

        //}



        /************************************** <To File / From File> *************************************************/
        //saves the eMart to file
        public void saveDataToFile()
        {
            ToFile(this.eMart, password, filename);
        }

        //true if file exists, false otherwhise
        public bool doesFileExist()
        {
            return File.Exists(filename);
        }

        //loads data from file to this.eMart variable and then enitializes the rest
        public void loadDataFromFile()
        {
            this.eMart = FromFile(filename, password);
            enitializeLinqDal();
            //toConsole(this.eMart);
        }

        //private method which writes the eMart data onto a file after encrypting it
        private void ToFile(E_Mart_Store p, string password, string file)
        {
            byte[] passwordBytes = StrToByte(password);

            byte[] bytes = serialize.SerializeObjectToByteArray(p);

            byte[] encryptedBytes = aes.AES_Encrypt(bytes, passwordBytes);

            ByteToFile(encryptedBytes, file);

        }

        //private method which reads the encrypted data from file, decrypts it and enters it into eMart variable
        private E_Mart_Store FromFile(string file, string password)
        {


            byte[] passwordBytes = StrToByte(password);

            byte[] fileInBytes = FileToByte(file);

            byte[] decryptedFileInBytes = aes.AES_Decrypt(fileInBytes, passwordBytes);

            E_Mart_Store p = serialize.DeserializeByteArrayToObject(decryptedFileInBytes);

            return p;
        }

        //turns a given string into a byte array
        private byte[] StrToByte(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        //writes a byte array onto file
        private void ByteToFile(byte[] bytes, string filename)
        {
            File.WriteAllBytes(filename, bytes);
        }

        //reads a file into a byte array
        private byte[] FileToByte(string filename)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(filename);
            return bytes;

        }

        /************** GETTER / SETTER ***********/
        public string FileName
        {
            get { return this.filename; }
            set { this.filename = value; }
        }

        //public string Password ////should be deleted after
        //{
        //    get { return this.password; }
        //}
        /*************************************** <END> *<To File / From File>* <END> ***********************************************/


        /******************************************** ADD / REMOVE / EDIT *********************************************************/
            /*
             * the following methods forward the request to the correct class dealing with this data
             */
        public void addProduct(Product p)
        {
            this.product_Linq_DAL.addProduct(p);
        }

       
        public void removeProduct(Product p)
        {
            this.product_Linq_DAL.removeProduct(p);
        }

        public void editProduct(Product p)
        {
            this.product_Linq_DAL.editProduct(p);
        }
        public void addDepartment(Department d)
        {
            this.department_Linq_DAL.addDepartment(d);
        }
        public void removeDepartment(Department d)
        {
            this.department_Linq_DAL.removeDepartment(d);
        }
        public void editDepartment(Department d)
        {
            this.department_Linq_DAL.editDepartment(d);
        }

        public void addUser(User u)
        {
            this.user_Linq_DAL.addUser(u);
        }

        public void removeUser(User u)
        {
            this.user_Linq_DAL.removeUser(u);
        }

        public void editUser(User u)
        {
            this.user_Linq_DAL.editUser(u);
        }

        public void addEmployee(Employee e)
        {
            employee_Linq_DAL.addEmployee(e);
        }

        public void removeEmployee(Employee e)
        {
            employee_Linq_DAL.removeEmployee(e);
        }

        public void editEmployee(Employee e)
        {
            employee_Linq_DAL.editEmployee(e);
        }

        public void addClubMember(ClubMember c)
        {
            clubMember_Linq_DAL.addClubMember(c);
        }

        public void editClubMember(ClubMember c)
        {
            clubMember_Linq_DAL.editClubMember(c);
        }

        public void removeClubMember(ClubMember c)
        {
            clubMember_Linq_DAL.removeClubMember(c);
        }




        public void addTransaction(Transaction t)
        {
            transaction_Linq_DAL.addTransaction(t);
        }

        public void editTransaction(Transaction t)
        {
            transaction_Linq_DAL.editTransaction(t);
        }

        public void removeTransaction(Transaction t)
        {
            transaction_Linq_DAL.removeTransaction(t);
        }

        /******************************************** <END> *ADD / REMOVE / EDIT* <END> *********************************************************/
            /*
             * the following methods return a container containing a list of the desired class **
             */
        //** = product
        public Products getAllProducts()
        {
            return eMart.Products;
        }

        //** = department
        public Departments getAllDepartments()
        {
            return eMart.Departments;
        }

        //** = clubMember
        public ClubMembers getAllClubMembers()
        {
            return eMart.Clubmembers;
        }

        //** = transaction
        public Transactions getAllTransactions()
        {
            return eMart.Transactions;
        }

        //** = employee
        public Employees getAllEmployees()
        {
            return eMart.Employees;
        }


        
        //** = user
        public Users getAllUsers()
        {
            return eMart.Users;
        }
        /********************************************************************************************************/

        /******************************************* QUERYS *************************************************/
        /*
         * the following methods direct the query according to stringFields / rangeFields field variable's value
         */
        //look up
        public List<Employee> employeeStringQuery(stringFields field, string value, List<Employee> listE = null)
        {
            if (field == stringFields.teudatZehute)
                return employee_Linq_DAL.employeeIDQuery(Convert.ToInt32(value), listE);
            else if (field == stringFields.departmentID)
                return employee_Linq_DAL.employeeDPIDQuery(Convert.ToInt32(value), listE);
            else if (field == stringFields.supervisorID)
                return employee_Linq_DAL.employeeSupervisorIDQuery(Convert.ToInt32(value), listE);
            else if (field == stringFields.firstName)
                return employee_Linq_DAL.employeeFirstNameQuery(value, listE);
            else if (field == stringFields.lastName)
                return employee_Linq_DAL.employeeLastNameQuery(value, listE);
            else if (field == stringFields.gender)
                return employee_Linq_DAL.employeeGenderQuery((Gender)Enum.Parse(typeof(Gender), value), listE);
            else
            {
                Console.WriteLine("WORNG SEARCH PARAMETERS");
                return null;
            }

        }

        //look up
        public List<Employee> employeeRangeQuery(rangeFields field, string fromValue, string toValue, List<Employee> listE=null)
        {
            if (field == rangeFields.salary)
                return employee_Linq_DAL.employeeSalaryQuery(Convert.ToDouble(fromValue), Convert.ToDouble(toValue), listE);
            else
            {
                Console.WriteLine("WORNG SEARCH PARAMETERS");
                return null;
            }
        }

        public List<Product> productStringQuery(stringFields field, string value,List<Product> listP=null)
        {
            if (field == stringFields.inventoryID)
                return product_Linq_DAL.productInventoryIDQuery(Convert.ToInt32(value),listP);
            else if (field == stringFields.location)
                return product_Linq_DAL.productLocationQuery(Convert.ToInt32(value), listP);
            else if (field == stringFields.name)
                return product_Linq_DAL.productNameQuery(value, listP);
            else if (field == stringFields.type)
                return product_Linq_DAL.productTypeQuery((Backend.Type)Enum.Parse(typeof(Backend.Type), value), listP);
            else if (field == stringFields.inStock)
                return product_Linq_DAL.productInStockQuery((InStock)Enum.Parse(typeof(InStock), value), listP);
            else
            {
                Console.WriteLine("WORNG SEARCH PARAMETERS");
                return null;
            }
        }

        //look up
        public List<Product> productRangeQuery(rangeFields field, string fromValue, string toValue, List<Product> listP=null)
        {
            if (field == rangeFields.price)
                return product_Linq_DAL.productPriceQuery(Convert.ToDouble(fromValue), Convert.ToDouble(toValue), listP);
            else if (field == rangeFields.stockCount)
                return product_Linq_DAL.productStockCountQuery(Convert.ToInt32(fromValue), Convert.ToInt32(toValue), listP);
            else if (field == rangeFields.whenToOrder)
                return product_Linq_DAL.productWhenToOrderQuery(Convert.ToInt32(fromValue), Convert.ToInt32(toValue), listP);
            else
            {
                Console.WriteLine("WORNG SEARCH PARAMETERS");
                return null;
            }
        }

        //look up
        public List<Transaction> transactionStringQuery(stringFields field, string value)
        {
            if (field == stringFields.transactionID)
                return transaction_Linq_DAL.transactionIDQuery(Convert.ToInt32(value));
            else if (field == stringFields.is_A_Return)
                return transaction_Linq_DAL.transactionIsAReturnQuery(Convert.ToBoolean(value));
            else if (field == stringFields.paymentMethod)
                return transaction_Linq_DAL.transactionPaymentMethodQuery((PaymentMethod)Enum.Parse(typeof(PaymentMethod), value));
            else
            {
                Console.WriteLine("WORNG SEARCH PARAMETERS");
                return null;
            }
        }

        //look up
        public List<Transaction> transactionRangeQuery(rangeFields field, string fromValue, string toValue)
        {
            if (field == rangeFields.dateTime)
                return transaction_Linq_DAL.transactionDateTimeQuery(Convert.ToDateTime(fromValue), Convert.ToDateTime(toValue));
            else
            {
                Console.WriteLine("WORNG SEARCH PARAMETERS");
                return null;
            }
        }

        //look up
        public List<User> userStringQuery(stringFields field, string value)
        {
            if (field == stringFields.userName)
                return user_Linq_DAL.userNameQuery(value);
            else
            {
                Console.WriteLine("WORNG SEARCH PARAMETERS");
                return null;
            }
        }

        //look up
        public List<ClubMember> clubMemberRangeQuery(rangeFields field, string fromValue, string toValue)
        {
            if (field == rangeFields.date_of_birth)
                return clubMember_Linq_DAL.clubMemberDateOfBirthQuery(Convert.ToDateTime(fromValue), Convert.ToDateTime(toValue));
            else
            {
                Console.WriteLine("WORNG SEARCH PARAMETERS");
                return null;
            }
        }

        //look up
        public List<ClubMember> ClubMemberStringQuery(stringFields field, string value)
        {
            if (field == stringFields.memberID)
                return clubMember_Linq_DAL.clubMemberIDQuery(Convert.ToInt32(value));
            else if (field == stringFields.teudatZehute)
                return clubMember_Linq_DAL.clubMemberTeudatZehuteQuery(Convert.ToInt32(value));
            else if (field == stringFields.firstName)
                return clubMember_Linq_DAL.clubMemberFirstNameQuery(value);
            else if (field == stringFields.lastName)
                return clubMember_Linq_DAL.clubMemberLastNameQuery(value);
            else if (field == stringFields.gender)
                return clubMember_Linq_DAL.clubMemberGenderQuery((Gender)Enum.Parse(typeof(Gender), value));
            else
            {
                Console.WriteLine("WORNG SEARCH PARAMETERS");
                return null;
            }
        }

        //look up
        public List<Department> departmentStringQuery(stringFields field, string value)
        {
            if (field == stringFields.name)
                return department_Linq_DAL.departmentNameQuery(value);
            else if (field == stringFields.departmentID)
                return department_Linq_DAL.departmentIDQuery(Convert.ToInt32(value));
            else
            {
                Console.WriteLine("WORNG SEARCH PARAMETERS");
                return null;
            }
        }






        //public User getAdmin()//////
        //{
        //    return user_Linq_DAL.getAdmin();
        //}

        //true - > user exists in database otherwise false
        public User isUserOk(User user)
        {
            return user_Linq_DAL.isUserOk(user);
        }

        //true-> if user is admin Otherwise false
        public User isUserAdmin(User user)
        {
            return user_Linq_DAL.isUserAdmin(user);
        }
    }
}
