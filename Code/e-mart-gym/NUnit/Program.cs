using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Backend;
using BL;
using DAL;
using PL_GUI;

namespace Nunit_testing
{
    [TestFixture]
    public class Program
    {
       
        static void Main(string[] args)
        {
            prodcutStringContractorTest();
            addAndRemovingInList();
            isEditOK();
            isEncyptionOK();
            checkDefultHierarchy();
            searchInspacificList();
            checkIntInput();
            addAndRemoveCreditCard();
            checkIsType();
            isUserAdmin();

        }

        [Test]
        public static void prodcutStringContractorTest()
        {
            Department d1 = new Department("First Department");
            Product p1 = new Product("Banana", "Food", "1", "300", "500", "150");
            Assert.IsInstanceOf(typeof(double), p1.Price);
            Assert.IsInstanceOf(typeof(int), p1.StockCount);
            Assert.IsInstanceOf(typeof(int), p1.WhenToOrder);
            Assert.IsInstanceOf(typeof(int), p1.Location);
            Assert.IsInstanceOf(typeof(Backend.Type), p1.Type);

        }
        [Test]
        public static void addAndRemovingInList()
        {
            IDAL adal = new LINQ_DAL();
            IBL abl = new E_Mart_BL(adal);
            Department d1 = new Department("Department 1");
            abl.add(d1);
            Departments Deps = abl.getAllDepartments();
            Assert.IsTrue(Deps.Departmentss.Count == 1);
            abl.remove(d1);
            Departments Deps2 = abl.getAllDepartments();
            Assert.IsTrue(Deps2.Departmentss.Count == 0);
        }
        [Test]
        public static void isEditOK()
        {
            IDAL adal = new LINQ_DAL();
            IBL abl = new E_Mart_BL(adal);
            User user = new User("Naharda", "Kawabanga");
            string s1 = user.UserName;
            string s2 = user.Password;
            User editedUser = new User(user);
            editedUser.Password = "Banana";
            abl.add(user);
            abl.edit(editedUser);
            Users users = abl.getAllUsers();
            Assert.IsTrue(users.Userss.ElementAt(0).Password.Equals("Banana"));
            Assert.IsTrue(users.Userss.ElementAt(0).UserName.Equals("Naharda"));

        }
        [Test]
        public static void isEncyptionOK()
        {
            IDAL adal = new LINQ_DAL();
            IBL abl = new E_Mart_BL(adal);
            Department d1 = new Department("Department 1");
            d1.DepartmentID = 1;
            User user = new User("Naharda", "Kawabanga");
            Employee emp = new Employee(305, "Yair", "LAnd", 1, 50000.5, "Male", -1);
            Product prod = new Product("Banana", "Food", 1, 1, InStock.True, 300, 2.5, 100);
            ClubMember clu = new ClubMember("2516", "Googi", "Sheldi", "Male", "08/10/1989");
            clu.MemberID = 1;
            Receipt rec = new Receipt();
            ProductSale ps = new ProductSale(prod, 3);
            rec.addProductSale(ps);
            Transaction tranc = new Transaction(rec, "Cash");
            tranc.TransactionID = 1;
            E_Mart_Store e = new E_Mart_Store();
            e.addClubMember(clu);
            e.addDepartment(d1);
            e.addEmployee(emp);
            e.addProduct(prod);
            e.addTransaction(tranc);
            e.addUser(user);
            Serialize b = new Serialize();
            AES aes = new AES();
            String s1 = "password";
            byte[] a = b.SerializeObjectToByteArray(e);
            byte[] password = new byte[s1.Length * sizeof(char)];
            System.Buffer.BlockCopy(s1.ToCharArray(), 0, password, 0, password.Length);
            byte[] ans = aes.AES_Encrypt(a, password);
            Assert.IsFalse(ByteArrayCompare(a,ans));
            byte[] ans2 = aes.AES_Decrypt(ans, password);
            Assert.IsTrue(ByteArrayCompare(ans2 , a));

        }
        public static bool ByteArrayCompare(byte[] a1, byte[] a2)
        {
            if (a1.Length != a2.Length)
                return false;

            for (int i = 0; i < a1.Length; i++)
                if (a1[i] != a2[i])
                    return false;

            return true;
        }

        [Test]
        public static void checkDefultHierarchy()
        {
            IDAL adal = new LINQ_DAL();
            IBL abl = new E_Mart_BL(adal);
            User theUser = new User("testUser", "1111");
            Assert.IsTrue(theUser.Hierarchy==Hierarchy.Customer);
        }

        [Test]
        public static void searchInspacificList()
        {
            IDAL adal = new LINQ_DAL();
            IBL abl = new E_Mart_BL(adal);
            
            Department dp1 = new Department("dep1");
            
            dp1.DepartmentID = 1;
            Department dp2 = new Department("dep2");

            dp1.DepartmentID = 2;
            abl.add(dp1);
            Product p1 = new Product("Banana", "Food", "1", "500", "3.5", "300");
            Product p2 = new Product("Apple", "Food", "1", "800", "5", "1000");
            Product p3 = new Product("T-Shirt", "Fashion", "1", "500", "3.5", "300");
            List<Object> listP=new List<Object>();
            listP.Add(p1);
            listP.Add(p2);
            listP.Add(p3);

            List<Object> findDep1 = abl.queryByString(Classes.Product, stringFields.location, "1", listP);
            List<Product> testList = abl.queryByString(Classes.Product, stringFields.type, "Fashion", findDep1).Cast<Product>().ToList();
            
            
            Assert.IsTrue(testList.Count == 1); 
        }

        [Test]
        public static void checkIntInput()
        {
            string str = "1234";
            Assert.IsTrue(isItInt(str));
            str = "ah69";
            Assert.IsFalse(isItInt(str)); 
        }

        public static bool isItInt(string abc)
        {
            try
            {
                InputCheck.isInt(abc, "test");
                return true;
            }
            catch (Exception)
            {
                return false; 
            }
        }

        [Test]
        public static void addAndRemoveCreditCard()
        {
            ClubMember buyer = new ClubMember("9999", "Tal", "Mosseri", "Male", "10/08/1175");
            string creditNumber = "1234567890654321"; 
            string cvv = "356";
            string monthExp = "07";
            string yearExp = "2000";
            buyer.addCreditCard(creditNumber, monthExp, yearExp, cvv);
            Assert.IsTrue(hasCradit(buyer));
            buyer.removeCreditCard();
            Assert.IsFalse(hasCradit(buyer)); 

        }

        public static bool hasCradit(ClubMember person)
        {
            if (person.CreditCard == null)
                return false;
            else return true; 
        }

        
        [Test]
        public static void checkIsType()
        {
            string isType = "Electronics";
            Assert.IsTrue(isItType(isType));
            isType = "Food";
            Assert.IsTrue(isItType(isType));
            isType = "Drinks";
            Assert.IsFalse(isItType(isType));
            isType = "Home";
            Assert.IsFalse(isItType(isType));
        }

        public static bool isItType(string abc)
        {
            try
            {
                InputCheck.isType(abc);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        [Test]
        public static void isUserAdmin()
        {
            IDAL adal = new LINQ_DAL();
            IBL abl = new E_Mart_BL(adal);
            User isAdmin1 = new User("Admin", "1234*");
            Assert.IsTrue(abl.isUserAdmin(isAdmin1)!=null); 
        }


    }
}
