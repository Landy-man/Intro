using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend;
using BL;

namespace PL
{
    public class PL_CLI : IPL
    {
        private IBL itsBL;

        public PL_CLI(IBL BL)
        {
            this.itsBL = BL;
        }

        private void displayResult(List<Product> prods)
        {
            foreach (Product p in prods)
            {
                Console.WriteLine(p.Name + " " + p.Type.ToString());
            }
        }

        private string receiveCmd()
        {
            ///////
            return Console.ReadLine();
        }

        public void start()
        {
            addStuff();
            //printALL();

        //List<object> queryByRange(Classes clas, rangeFields field, string fromValue, string ToValue);
        //List<object> queryByString(Classes clas, stringFields field, string value);
          //List<Product> list =  itsBL.queryByRange(Classes.Product, rangeFields.whenToOrder, "0", "0").Cast<Product>().ToList();
            //List<Product> list = itsBL.queryByString(Classes.Product, stringFields., "a").Cast<Product>().ToList();
           // List<Department> list = itsBL.queryByString(Classes.Department, stringFields.departmentID, "2").Cast<Department>().ToList();
            //List<User> list = itsBL.queryByString(Classes.User, stringFields.userName, "Yair").Cast<User>().ToList();
           // List<Employee> list = itsBL.queryByString(Classes.Employee, stringFields.teudatZehute, "56456456").Cast<Employee>().ToList();
            //string max = Convert.ToString(Int32.MaxValue);
            //List<Employee> list = itsBL.queryByRange(Classes.Employee, rangeFields.salary, "0", max).Cast<Employee>().ToList();
            
            //string from = "01/01/1800"; ////// מיכל תעיפי מבט על הדוגמא הזאת רק את צריכה לוודא שזה אכן משתנה מסוג דייט טיים
           // string to = "21/10/2090";
            //List<ClubMember> list = itsBL.queryByRange(Classes.ClubMember, rangeFields.date_of_birth, from, to).Cast<ClubMember>().ToList();
           // List<ClubMember> list = itsBL.queryByString(Classes.ClubMember, stringFields.teudatZehute, "1569").Cast<ClubMember>().ToList();
           // List<Transaction> list = itsBL.queryByRange(Classes.Transaction, rangeFields.dateTime, from, to).Cast<Transaction>().ToList();
            List<Transaction> list = itsBL.queryByString(Classes.Transaction, stringFields.transactionID,"1").Cast<Transaction>().ToList();
            foreach(Transaction p in list)
            {
                Console.WriteLine(p.toString() + "\n");
            }
            Console.Read();
        }
        private void printALL()
        {
            Users users = itsBL.getAllUsers();
            Transactions trans = itsBL.getAllTransaction();
            Products prods = itsBL.getAllProducts();
            Employees emps = itsBL.getAllEmployees();
            Departments deps = itsBL.getAllDepartments();
            ClubMembers clubs = itsBL.getAllClubMembers();

            print(users.toString(), "USERS: \n");
            print(trans.toString(), "TRANSACTIONS: \n");
            print(prods.toString(), "PRODUCTS: \n");
            print(emps.toString(), "EMPLOYEES: \n");
            print(deps.toString(), "DEPARTMENTS: \n");
            print(clubs.toString(), "CLUB MEMBERS: \n");
        }


        private void print(object toPrint,string text)
        {
            Console.WriteLine(text+toPrint.ToString());
           
        }

        public void addStuff()
        {
            try
            {
                Department d1 = new Department("d1");
                Department d2 = new Department("d2");
                Department d3 = new Department("d3");
                itsBL.add(d1);
                itsBL.add(d2);
                itsBL.add(d3);
                Employee e1 = new Employee("56456456", "adsf", "sadf", "1", "39489", "-1", "Male");
                Employee e2 = new Employee("456496", "adsf", "sadf", "1", "31589", "56456456", "Male");
                Employee e3 = new Employee("65446", "adsf", "sadf", "1", "3145", "456496", "Female");
                itsBL.add(e1);
                itsBL.add(e2);
                itsBL.add(e3);
                Product p1 = new Product("product 1", "a", "1", "213", "6", "300");
                Product p4 = new Product("product 1", "a", "1", "213", "6", "301");
                Product p5 = new Product("product 1", "a", "1", "213", "6", "302");
                Product p6 = new Product("product 1", "a", "1", "213", "6", "303");
                Product p2 = new Product("product 2", "b", "1", "213", "23", "200");
                Product p3 = new Product("product 3", "a", "1", "0", "23", "300");
                itsBL.add(p1);
                itsBL.add(p2);
                itsBL.add(p3);
                itsBL.add(p4);
                itsBL.add(p5);
                itsBL.add(p6);
                ProductSale ps1 = new ProductSale(p1);
                ProductSale ps2 = new ProductSale(p2);
                ProductSale ps3 = new ProductSale(p3);
                ProductSale ps4 = new ProductSale("24123", "231");
                ProductSale ps5 = new ProductSale("231", "231");
                Receipt r1 = new Receipt();
                r1.addProductSale(ps1);
                r1.addProductSale(ps2);
                r1.addProductSale(ps3);
                Transaction t2 = new Transaction(r1, "Cash");
                itsBL.add(t2);
                ClubMember c1 = new ClubMember("1569", "Yair", "ga", "Male", "07/09/1990");
                ClubMember c2 = new ClubMember("368725", "Gal", "ga", "Male", "21/11/1990");
                ClubMember c3 = new ClubMember("7536287", "Yair", "ga", "Female", "03/07/1990");
                itsBL.add(c1);
                itsBL.add(c2);
                itsBL.add(c3);
                User u1 = new User("GalSheldon", "Googi");
                User u2 = new User("Yair", "Googi");
                User u3 = new User("GalSheldondddd", "Googi");
                itsBL.add(u1);
                itsBL.add(u2);
                itsBL.add(u3);
            }
        catch (Exception e) { print(e.Message, "ERROR: "); }
        }


        public void Run()
        {
            EnterScreen letsBegin= new EnterScreen(itsBL);
            letsBegin.enterScreenRun();
        
            }
        }

        ////private void Testing()
        ////{

            /****** CLASSES CREATION *******/

            /********************* Department Add/Remove/Edit Testing**************************/
            //Department d1=null;
            //Department d2 = new Department("d2");
            //Department d3 = new Department("d2");

            //try
            //{
            //    d1 = new Department("d1");
            //}
            //catch (Exception e) { print(e.Message, "ERROR: "); }

            //try
            //{
            //    itsBL.add(d1);
            //itsBL.add(d2);
            //    itsBL.add(d3);
            //}
            //catch (Exception e) { print(e.Message, "ERROR: "); }

            //Departments dps = itsBL.getAllDepartments();
            //print(dps.toString(), "DEPARTMENTS: \n");

            //d1.Name = "d3";

            //print(dps.toString(), "DEPARTMENTS: \n");

            //itsBL.remove(d2);

            //print(dps.toString(), "DEPARTMENTS: \n");

            /********************** User Add/Remove/Edit Testing ******************************/
            //User u1 = null;
            //User u2 = new User("GalSheldon" , "Googi");
            //User u3 = new User("Yair", "Googi");
            //User u4 = new User("GalSheldon", "Googi");

            //try
            //{
            //    u1 = new User("aggga","aggga");
            //}
            //catch (Exception e) { print(e.Message, "ERROR: "); }
            //u4.UserName = "Banana";
            //try
            //{
            //    itsBL.add(u1);
            //    itsBL.add(u2);
            //    itsBL.add(u3);
            //    itsBL.add(u4);
            //}
            //catch (Exception e) { print(e.Message, "ERROR: "); }

            //Users users = itsBL.getAllUsers();

            //print(users.toString(), "USERS: \n");

            //try
            //{
            //    itsBL.remove(u3);
            //}
            //catch (Exception e) { print(e.Message, "ERROR: "); }


            //print(users.toString(), "USERS: \n");

            //User u5 = new User(u2);
            //u5.Password = "Abbago";
            //itsBL.edit(u5);
            //print(users.toString(), "USERS: \n");
            /*********************ClubMember Add/Remove/Edit Test**********************/
            //ClubMember c1 = null;
            //ClubMember c2 = new ClubMember("1569", "Yair", "ga", "Male", "07/09/1990");
            //ClubMember c3 = new ClubMember("368725", "Gal", "ga", "Male", "21/11/1990");
            //ClubMember c4 = new ClubMember("7536287", "Yair", "ga", "Female", "03/07/1990");

            //try
            //{
            //    c1 = new ClubMember("45", "gas", "ga", "Male", "21/11/1990");
            //}
            //catch (Exception e) { print(e.Message, "ERROR: "); }

            //try
            //{
            //    itsBL.add(c1);
            //    itsBL.add(c2);
            //    itsBL.add(c3);
            //    itsBL.add(c4);
            //}
            //catch (Exception e) { print(e.Message, "ERROR: "); }

            //ClubMembers clu = itsBL.getAllClubMembers();
            //print(clu.toString(), "CLUBMEMBERS: \n");
            //itsBL.remove(c2);
            //print(clu.toString(), "CLUBMEMBERS: \n");
            //ClubMember c5 = new ClubMember(c4);
            //c5.LastName = "afsf";
            //try
            //{
            //    itsBL.edit(c5);
            //}
            //catch (Exception e) { print(e.Message, "ERROR: "); }
            //print(clu.toString(), "CLUBMEMBERS: \n");
            /*******************Employees Add/Remove/Edit Test**************/
            //Employee e1 = null;
            //Employee e2 = new Employee("56456456", "adsf", "sadf", "1", "39489", "-1", "Male");
            //Employee e3 = new Employee("456496", "adsf", "sadf", "1", "31589", "56456456", "Male");
            //Employee e4 = new Employee("65446", "adsf", "sadf", "1", "3145", "456496", "Female");

            //try
            //{
            //    e1 = new Employee("214463", "hjgf", "jtf", "1", "39489", "-1", "Male");
            //}
            //catch (Exception e) { print(e.Message, "ERROR: "); }
            //try
            //{
            //    itsBL.add(e1);
            //    itsBL.add(e2);
            //    itsBL.add(e3);
            //    itsBL.add(e4);

            //}
            //catch (Exception e) { print(e.Message, "ERROR: "); }
            //Employees emps = itsBL.getAllEmployees();
            //print(emps.toString(), "EMPLOYEES: \n");
            //try
            //{
            //    itsBL.remove(e1);

            //}
            //catch (Exception e) { print(e.Message, "ERROR: "); }
            //print(emps.toString(), "EMPLOYEES: \n");

            //Employee e5 = new Employee(e3);
            //e5.Salary = 56464892;
            //itsBL.edit(e5);
            //print(emps.toString(), "EMPLOYEES: \n");

            /**************************************** PRODUCT ADD ? REMOVE ? EDIT TEST **********************************************/

            //Product p1 = new Product("product 1", "a", "1", "213", "23", "300");
            //Product p2 = new Product("product 2", "b", "1", "213", "23", "200");
            //Product p3 = new Product("product 3", "a", "1", "0", "23", "300");
            //Product p4 = null;

            //try
            //{
            //    p4 = new Product("product 4", "a", "1", "6", "23", "300");
            //}
            //catch (Exception e) { print(e.Message, "ERROR: "); }

            //try
            //{

            //    itsBL.add(p1);
            //    itsBL.add(p2);
            //    itsBL.add(p3);
            //    itsBL.add(p4);

            //}
            //catch (Exception e) { print(e.Message, "ERROR: "); }

            //Products prods = itsBL.getAllProducts();
            //print(prods.toString(), "PRODUCTS: \n");

            //itsBL.remove(p4);
            //print(prods.toString(), "PRODUCTS: \n");

            //Product p5 = new Product(p2);
            //p5.StockCount = 0;
            //itsBL.edit(p5);
            //print(prods.toString(), "PRODUCTS: \n");

            /******************************* TRANSACTION ADD/REMOVE/Edit TEST ************************************************/

            //Product p1 = new Product("product 1", "a", "1", "213", "23", "300");
            //Product p2 = new Product("product 2", "b", "1", "213", "23", "200");
            //Product p3 = new Product("product 3", "a", "1", "0", "23", "300");
            //itsBL.add(p1);
            //itsBL.add(p2);
            //itsBL.add(p3);
            //ProductSale ps1 = new ProductSale(p1);
            //ProductSale ps2 = new ProductSale(p2);
            //ProductSale ps3 = new ProductSale(p3);
            //ProductSale ps4 = new ProductSale("24123", "231");
            //ProductSale ps5 = new ProductSale("231", "231");
            //Receipt r1 = new Receipt();
            //r1.addProductSale(ps1);
            //r1.addProductSale(ps2);
            //r1.addProductSale(ps3);


            //Transaction t2 = new Transaction(r1, "Cash");
            //itsBL.add(t2);
            //try
            //{
            //    //itsBL.add(t2);
            //}
            //catch (Exception e) { print(e.Message, "ERROR: "); }

            //Transactions trans = itsBL.getAllTransaction();
            //print(trans.toString(), "TRANSACTIONS: \n");

            //Transaction t3 = new Transaction(t2);
            //t3.Receipt.removeProductSale(ps2);
            //itsBL.edit(t3);
            //print(trans.toString(), "TRANSACTIONS: \n");

        }

   //// }

////}
