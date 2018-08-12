using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using BL;
using Backend;

namespace PL
{
   

    public class Edit
    {
        private IBL itsBL;
        public Edit(IBL BL)
        {
            this.itsBL = BL;
        }

                private void print(object toPrint, string text)
        {
            Console.WriteLine(text + toPrint.ToString());

        }

        public Edit() { }

        public void toEdit(object toEdit, string classnum)
        {
            Edit move = new Edit(itsBL);

            if (classnum == "1") { move.editProduct((Product)toEdit); }                     // change the type of the object to its original type
            else if (classnum == "2") { move.editDepartment((Department)toEdit); }
            else if (classnum == "3") { move.editTransaction((Transaction)toEdit); }
            else if (classnum == "4") { move.editClubMember((ClubMember)toEdit); }
            else if (classnum == "5") { move.editEmployee((Employee)toEdit); }
            else if (classnum == "6") { move.editUser((User)toEdit); }

        }

        public void editDepartment(Department dep)                                      //EDIT department
        {
            Console.Clear();
            Department departmmentToEdit = new Department(dep);                         // create new department with the same value like the department that we want to edit
            Console.WriteLine("you choose to edit the next department: ");
            Console.WriteLine(dep.toString());                                          // Show the information on the department that the user want to edit on the screen
            Console.WriteLine("new name: ");                                            // the user can change only the  department name
            string nameToEdit = Console.ReadLine();
            if (nameToEdit.Length < 1) throw new Exception("Invalid Name, Must Contain Atleast One Character"); // if the user has made an illegal move
            else departmmentToEdit.Name = nameToEdit;                                   // change the name of the new department we created
            try
            {
                itsBL.edit(departmmentToEdit);                                          // try to edit the department
                Console.WriteLine("Changes have been done");
                Thread.Sleep(2000);
                saveAndBack();                                                          // menu to back to serach menu and ask if the user want to save
            }
            catch (Exception e)
            {
                print(e.Message, "ERROR: ");                                            // check if the user has made an illegal move
                Console.ReadKey();
            }

        }

        public void editUser(User prevUser)                                                             ////user
        {
            Console.Clear();
            User newUser = new User(prevUser);                                       // create new user with the same value like the user that we want to edit
            Console.WriteLine("To etit user you must fill the next fields about the user you want to edit:");
            Console.WriteLine("username:");
            string name = Console.ReadLine();
            Console.WriteLine("password: ");
            string password = Console.ReadLine();


            if (name == prevUser.UserName && password == prevUser.Password)             // only the user himself can edit his user. so he need to enter his previos date.
            {
                bool pass = true;
                while (pass)                                // its the user himself
                {
                    Console.WriteLine("enter new password: ");                  // he can edit only his password
                    string newPassword = Console.ReadLine();
                    if (newPassword.Length < 4) { Console.WriteLine("Password Must Contain Atleast 4 Characters."); }               // the password must be 4 tabs at least
                    else
                    {
                        newUser.Password = newPassword;
                        pass = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("Username or password are incorrect");
                editUser(prevUser);
            }
            try
            {
                itsBL.edit(newUser);                                    // try to edit the user in the DB
                Console.WriteLine("Changes have been done");
                Thread.Sleep(2000);
                saveAndBack();
            }
            catch (Exception e)
            {
                print(e.Message, "ERROR: ");                            // inform the user if there was an exception
                Console.ReadKey();
            }
        }

        public void editClubMember(ClubMember premember)                            /////club member
        {
            Console.Clear();
            ClubMember newClubMember = new ClubMember(premember);
            Console.WriteLine("you choose to edit the next club member: ");
            Console.WriteLine(premember.toString() + "\n");
            bool ans = true;

            while (ans)
            {
                string cmd;
                Console.WriteLine("Choose the field you want to change: ");
                Console.WriteLine("\t1. Club member's first name ");
                Console.WriteLine("\t2. Club member's last name ");
                Console.WriteLine("\t3. Club member's transaction history ");
                cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "1":
                        Console.WriteLine("enter the new first name: ");
                        string first = Console.ReadLine();
                        if (first.Length < 1)    { Console.WriteLine("Invalid First Name, Must Have Atleast One Character");}
                        else { newClubMember.FirstName = first; }

                        break;

                    case "2":
                        Console.WriteLine("enter the new last name: ");
                        string last = Console.ReadLine();
                        if (last.Length < 1) {Console.WriteLine("Invalid last Name, Must Have Atleast One Character");}
                        else { newClubMember.LastName = last; }

                        break;

                    case "3":
                        Console.WriteLine("press 1 to add transaction to club member's transaction history ");
                        Console.WriteLine("press 2 to remove transaction from club member's transaction history ");
                        string next = Console.ReadLine();
                        switch (next)
                            {
                                case "1":
                                    Console.WriteLine("enter transaction ID for add it to the history (notice! must be numbers): ");
                                    string tranID = Console.ReadLine();
                                    while (!(InputCheck.isInt(tranID)))
                                    {
                                        Console.WriteLine("The transaction ID must be a positive number");
                                        Console.WriteLine("enter transaction ID (notice! must be numbers): ");
                                        tranID = Console.ReadLine();
                                    }
                                    int add= Convert.ToInt32(tranID);
                                    try
                                    {
                                        newClubMember.addTransactionToHistory(add);
                                    }
                                    catch (Exception e)
                                    {
                                        print(e.Message, "ERROR: ");
                                        Console.ReadKey();
                                    } 
                                break;

                                case "2":
                                    Console.WriteLine("enter transaction to remove fron the history");
                                    string remove= Console.ReadLine();
                                     while (!(InputCheck.isInt(remove)))
                                     {
                                        Console.WriteLine("The transaction ID must be a positive number");
                                        Console.WriteLine("enter transaction ID (notice! must be numbers): ");
                                        tranID = Console.ReadLine();
                                     }
                                       int toRemove= Convert.ToInt32(remove);
                                    try{
                                            newClubMember.removeTransactionHostory(toRemove);
                                        }
                                        catch (Exception e)
                                        {
                                            print(e.Message, "ERROR: ");
                                            Console.ReadKey();
                                        }
                                   
                                    break;

                                default:
                                    Console.WriteLine(" You have performed an illegal move ");
                                    break;
                                 }
                            break;         
                         }

                        Console.WriteLine("In order to continue edit the same club member press  1 ");
                        Console.WriteLine("if you finish press any other key ");
                        string indicate = Console.ReadLine();
                        if (indicate != "1")
                        {
                            ans = false;
                            try
                            {
                                itsBL.edit(newClubMember);
                                Console.WriteLine("Changes have been done");
                                Thread.Sleep(2000);
                                saveAndBack();

                            }
                            catch (Exception e)
                            {
                                print(e.Message, "ERROR: ");
                                Console.ReadKey();
                            }
                        }
                    }

                 }

        public void editProduct(Product prevproduct)                                                                    /////product
        {
            Console.Clear();
            Product newProduct = new Product(prevproduct);
            Console.WriteLine("you choose to edit the next product: ");
            Console.WriteLine(prevproduct.toString() + "\n");
            bool ans = true;

            while (ans)
            {
                string cmd;
                Console.WriteLine("Choose the field you want to change: ");
                Console.WriteLine("\t1. name ");
                Console.WriteLine("\t2. type ");
                Console.WriteLine("\t3. location (department ID) ");
                Console.WriteLine("\t4. stock count ");
                Console.WriteLine("\t5. price ");
                Console.WriteLine("\t6. when to order ");

                cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "1":
                        Console.WriteLine("enter the new name:");
                        string name = Console.ReadLine();
                        if (name.Length < 1) { Console.WriteLine("Invalid product Name, Must Have Atleast One Character"); }
                        else { newProduct.Name = name; }
                        break;

                    case "2":
                        Console.WriteLine("enter new type: ");
                        string type = Console.ReadLine();
                        try
                        { 
                            InputCheck.isType(type);
                            newProduct.Type = (Backend.Type)Enum.Parse(typeof(Backend.Type), type); 
                        }
                        catch (Exception e)
                        {
                            print(e.Message, "\n ERROR: ");
                            Console.ReadKey();
                        }
                       break;

                    case "3":
                        Console.WriteLine("enter the new product location (notice! department ID must be numbers): ");
                        string newdepar = Console.ReadLine();
                        while (!(InputCheck.isInt(newdepar)))
                        {
                            Console.WriteLine("department ID must be numbers");
                            Console.WriteLine("enter again the new product location");
                            newdepar = Console.ReadLine();
                        }
                        newProduct.Location = Convert.ToInt32(newdepar);
                        break;

                    case "4":
                        Console.WriteLine("enter new stock count:");
                        string stockCountString = Console.ReadLine();
                        while (!(InputCheck.isInt(stockCountString)))
                        {
                            Console.WriteLine("stock count must be number bigger or equal to 0 ");
                            Console.WriteLine("enter stock count again: ");
                            stockCountString = Console.ReadLine();
                        }
                            newProduct.StockCount =Convert.ToInt32( stockCountString);
                       
                        break;

                    case "5":
                        Console.WriteLine("enter new price:");
                        string priceS = Console.ReadLine();
                        while (!(InputCheck.isDouble(priceS)))
                        {
                            Console.WriteLine("price must be number above 0 (it can be Decimals) ");
                            Console.WriteLine("enter new price again:");
                            priceS=Console.ReadLine();
                        }

                        newProduct.Price = Convert.ToDouble(priceS);
                            
                        break;

                    case "6":
                        Console.WriteLine("change whan to order value");
                        string whenToOrderS = Console.ReadLine();
                        while (!(InputCheck.isInt(whenToOrderS)))
                        {
                            Console.WriteLine("whan to order must be a number");
                            Console.WriteLine("enter the whan to order value"); 
                            whenToOrderS=Console.ReadLine(); 
                        }
                        
                         newProduct.WhenToOrder = Convert.ToInt32(whenToOrderS);

                        break;

                    default:
                        Console.WriteLine("You have performed an illegal move");
                        break;
                }
                Console.WriteLine("if you want to change more fields press 1");
                Console.WriteLine("if you finish press any other key ");
                string want = Console.ReadLine();
                if (want != "1")
                {
                    ans = false;
                    try
                    {
                        itsBL.edit(newProduct);
                        Console.WriteLine("Changes have been done");
                        Thread.Sleep(2000);
                        saveAndBack();
                    }
                    catch (Exception e)
                    {
                        print(e.Message, "ERROR: ");
                        Console.ReadKey();
                    }
                }
            }
        }


        public void editEmployee(Employee preEmployee)                                              /////employee
        {
            Console.Clear();
            Employee newEmployee = new Employee(preEmployee);
            Console.WriteLine("you choose to edit the next employee: ");
            Console.WriteLine(preEmployee.toString() + "\n");
            bool ans = true;

            while (ans)
            {
                string cmd;
                Console.WriteLine("Choose the field you want to change: ");
                Console.WriteLine("\t1. employee first name ");
                Console.WriteLine("\t2. Employee last name ");
                Console.WriteLine("\t3. location (department ID) ");
                Console.WriteLine("\t4. Employee salary ");
                Console.WriteLine("\t5. supervisor ID ");
                cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "1":
                        Console.WriteLine("enter the new first name");
                        string newFirst = Console.ReadLine();
                        if (newFirst.Length < 1) throw new Exception("Invalid First Name, Must Have Atleast One Character");
                        else { newEmployee.FirstName = newFirst; }
                        break;

                    case "2":
                        Console.WriteLine("enter the new last name");
                        string newLast = Console.ReadLine();
                        if (newLast.Length < 1) throw new Exception("Invalid First Name, Must Have Atleast One Character");
                        else { newEmployee.LastName = newLast; }
                        break;

                    case "3":
                        Console.WriteLine("enter the new employee location (notice! department ID must be number ");
                        string newdepar = Console.ReadLine();
                        while (!(InputCheck.isInt(newdepar)))
                        {
                            Console.WriteLine("department ID must be numbers");
                            Console.WriteLine("enter again the new employee location");
                            newdepar = Console.ReadLine();
                        }
                        newEmployee.DepartmentID = Convert.ToInt32(newdepar);

                        break;
                    

                    case "4":
                        Console.WriteLine("enter the new employee's salary: ");
                        string salaryS = Console.ReadLine();
                        while (!(InputCheck.isDouble(salaryS)))
                        {
                            Console.WriteLine("The salary must be a posative number");
                            Console.WriteLine("enter the salary again");
                            salaryS = Console.ReadLine(); 
                        }
                            newEmployee.Salary = Convert.ToDouble(salaryS);
                           
                        break;

                    case "5":
                        Console.WriteLine("the new employee's suprvisor ID is (notice! supervisor ID must be number) : ");
                        string superID = Console.ReadLine();
                        while (!(InputCheck.isInt(superID)))
                        {
                            Console.WriteLine("supervisor ID must be number bigger then 0");
                            Console.WriteLine("enter new employee's supervisor ID again: ");
                            superID = Console.ReadLine();
                        }
                           newEmployee.SupervisorID  = Convert.ToInt32(superID);
                           
                        break;

                    default:
                        Console.WriteLine("You have performed an illegal move");
                        break;
                }
                Console.WriteLine("if you want to change more fields press 1");
                Console.WriteLine("if you finish press any other key ");
                string want = Console.ReadLine();
                if (want != "1")
                {
                    ans = false;
                    try
                    {
                        itsBL.edit(newEmployee);
                        Console.WriteLine("Changes have been done");
                        Thread.Sleep(2000);
                        saveAndBack();
                    }
                    catch (Exception e)
                    {
                        print(e.Message, "ERROR: ");
                        Console.ReadKey();
                    }
                }
            }
        }


        public void editTransaction(Transaction prevTransaction)                                                                    /////tramsaction
        {
            Console.Clear();
            Console.Clear();
            Transaction newTransaction = new Transaction(prevTransaction);
            Console.WriteLine("you choose to edit the next transaction: ");
            Console.WriteLine(prevTransaction.toString() + "\n");
            bool ans = true;

            while (ans)
            {
                string cmd;
                Console.WriteLine("Choose the field you want to change: ");
                Console.WriteLine("\t1. remove from receipt ");
                Console.WriteLine("\t2. add to receipt ");
                Console.WriteLine("\t3. is a returend ");
                Console.WriteLine("\t4. payment methoud ");
                cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "1":
                        bool more = true;
                        while (more)
                        {

                            int counter = 1;
                            List<ProductSale> receiptList = newTransaction.Receipt.Data;
                            foreach (ProductSale p in receiptList)
                            {
                                Console.WriteLine(counter + ". " + p.toString());
                                counter++;
                            }
                            Console.WriteLine("choose row number of the product you want to remove from the receipt");
                            string row = Console.ReadLine();
                            int remove = Convert.ToInt32(row);
                            while (remove < 0 || remove > receiptList.LongCount())
                            {
                                Console.WriteLine("you have to choose number from the list");
                                remove = Convert.ToInt32(Console.ReadLine());
                            }
                            ProductSale toRemove = receiptList.ElementAt(remove-1);
                            newTransaction.Receipt.removeProductSale(toRemove);
                            Console.WriteLine("the prodect have been deleted. \n");

                            Console.WriteLine("press 1 if you want to remove more products from the receipt");
                            Console.WriteLine("press any other key to if you finish");
                            string next = Console.ReadLine();
                            if (next != "1")
                                more = false;
                        }
                        break;

                    case "2":
                        Console.WriteLine("Insert the following fields according to the product that you would like to add to receipt");
                        Console.WriteLine("enter the name prodect you want to add to the receipt: ");
                        string searchName = Console.ReadLine();
                        if (searchName.Length < 1) { Console.WriteLine("Invalid Product Name, Must Have Atleast One Character"); }
                        List<Product> list = itsBL.queryByString(Classes.Product, stringFields.name, searchName).Cast<Product>().ToList();
                        int counter2 = 1;
                        foreach (Product p in list)
                        {
                            Console.WriteLine("\t" + counter2 + ". " + p.Name + " " + p.Type.ToString() + p.InventoryID.ToString());
                            counter2++;
                        }
                        bool getIn = true;
                        int rowNum = 0;
                        while (getIn)
                        {
                            Console.WriteLine("choose the row number of the product you want to add to the receipt");
                            rowNum = Convert.ToInt32(Console.ReadLine());
                            if (rowNum < 1 || rowNum > counter2)
                            {
                                Console.WriteLine("the number must be one of the row in the product list");
                            }
                            else { getIn = false; }
                        }
                        Product productToAdd = new Product(list.ElementAt(rowNum-1));
                        ProductSale addProdutSall = new ProductSale(productToAdd);
                        newTransaction.Receipt.addProductSale(addProdutSall);

                        break;

                    case "3":
                        Console.WriteLine("The product has been returned? - change state ' is a returned ' to the truth.");
                        Console.WriteLine("\t1.  yes");
                        Console.WriteLine("\t2.  no");
                        string isAreturn = Console.ReadLine();
                        switch (isAreturn)
                        {
                            case "1":
                                newTransaction.Is_a_return = true;
                                break;

                            case "2":
                                break;

                            default:
                                Console.WriteLine("You have performed an illegal move");
                                break;
                        }
                        break;

                    case "4":
                        Console.WriteLine("change the payment method of the trensaction. the new payment method is: ");
                        Console.WriteLine("\t1. Cash");                                            // payment methods options
                        Console.WriteLine("\t2. Credit");
                        Console.WriteLine("\t3. Check");
                        string payment = "";
                        string paymentNum = Console.ReadLine();

                        switch (paymentNum)
                        {
                            case "1":
                                payment = "Cash";
                                break;

                            case "2":
                                payment = "Credit";
                                break;

                            case "3":
                                payment = "Check";
                                break;

                            default:
                                Console.WriteLine("You have performed an illegal move");
                                break;
                        }

                        try
                        {
                            newTransaction.PaymentMethod = (PaymentMethod)Enum.Parse(typeof(PaymentMethod), payment);


                        }
                        catch (ArgumentException)
                        {
                            throw new Exception("The Payment method of Produce doesnt exist.");
                        }

                        break;

                    default:
                        Console.WriteLine("You have performed an illegal move, choose number between 1 to 4");
                        break;
                }
            }
            try
            {
                itsBL.edit(newTransaction);
                Console.WriteLine("changes have been saved");
                Thread.Sleep(2000);
                saveAndBack();
            }
            catch (Exception e)
            {
                print(e.Message, "ERROR: ");
                Console.ReadKey();
            }
                
          }

        public void saveAndBack()                                                                       ////save and exit 
        {
            string cmd;
            while (true)
            {
                Console.WriteLine("choose an option: ");
                Console.WriteLine("\t1. save and back to search menu");
                Console.WriteLine("\t2. back to search menu");
                cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "1":
                        itsBL.saveDataToFile();
                        Console.WriteLine("changes saved");
                        Thread.Sleep(2000);
                        Search moveTo = new Search(itsBL);
                        moveTo.run(); 
                        break; 

                    case "2":
                         Search move2 = new Search(itsBL);
                         move2.run();
                        break;

                    default:
                        Console.WriteLine("You have performed an illegal move. enter 1 or 2");
                        break;

                }
            }
        }
  

       }

   }

   
