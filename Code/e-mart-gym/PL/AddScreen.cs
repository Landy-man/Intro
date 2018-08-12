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
    public class AddScreen
    {
        private IBL itsBL;

        public AddScreen(IBL BL)
        {
            this.itsBL = BL;
        }

        public void run()
        {
            string cmd;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What you wnat to add:");
                Console.WriteLine("\t1. Product ");
                Console.WriteLine("\t2. Department ");
                Console.WriteLine("\t3. Transaction ");
                Console.WriteLine("\t4. Club Member ");
                Console.WriteLine("\t5. Employee ");
                Console.WriteLine("\t6. User ");
                Console.WriteLine("\t7. Back ");

                cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "1":                                                   //add product
                        Console.Clear();
                        Console.WriteLine("To add a product please fill the following fields: ");
                        Console.Write("product name: ");
                        string productName = Console.ReadLine();                //get product name
                        Console.Write("product type: ");
                        string productType = Console.ReadLine();                //get product type
                        Console.Write("product location (notice! Location (department ID) must be numbers): ");
                        string productLocation = Console.ReadLine();            // get product location 
                        Console.Write("Units in stock (amount) : ");
                        string stockCount = Console.ReadLine();                 // get product stock count. How many products they have in stock
                        Console.Write("product price: ");
                        string productPrice = Console.ReadLine();              // get product price
                        Console.Write("when to order: ");
                        string whenToOrder = Console.ReadLine();              // the quantity of products that if there is less of it in stock they should make a reservation
                        Product productToAdd = null;
                        try
                        {
                            productToAdd = new Product(productName, productType, productLocation, stockCount, productPrice, whenToOrder);     // unite all the information into one product
                        }
                        catch (Exception e)
                        {
                            print(e.Message, "\n ERROR: ");                         // inform the user
                            Console.ReadKey();
                        }

                            try
                        {
                            itsBL.add(productToAdd);                                // add the prodect              
                            Console.WriteLine("Product successfully added \n");    // inform the user
                            Thread.Sleep(2300);

                        }
                        catch (Exception e)                                        // if the user has made illegal moves
                        {
                            print(e.Message, "\n ERROR: ");                         // inform the user
                            Console.ReadKey();
                        }

                        break;

                    case "2":                                                  // add department
                        Console.Clear();
                        Console.WriteLine("To add a department please fill the following fields:");
                        Console.Write("department name: ");
                        string departmentName = Console.ReadLine();                  // get department name
                        Department departmentToAdd = null;
                        try
                        {
                            departmentToAdd = new Department(departmentName);    // creat department
                        }
                        catch (Exception e)
                        {
                            print(e.Message, "\n ERROR: ");                         // inform the user
                            Console.ReadKey();
                        }
                           try
                        {
                            itsBL.add(departmentToAdd);                                 // add the department 
                            Console.WriteLine("Department successfully added \n");    // inform the user   
                            Thread.Sleep(2300);

                        }
                        catch (Exception e)                                      // if the user has made illegal moves 
                        {
                            print(e.Message, "\n \n ERROR: ");                       // inform the user
                            Console.ReadKey();
                        }

                        break;

                    case "3":                                               //add transaction
                        Console.Clear();
                        AddScreen addprodect = new AddScreen(itsBL);
                        Console.WriteLine("To add a transaction please fill the following fields:");
                        string paymentsMethod = addprodect.HowItPay();
                        Receipt receiptToAdd = new Receipt();
                        addprodect.showProductList();                   // show product list so the user can pick any prodect he want to add to the recipt. 
                        Transaction transactionToAdd = null;
                        try 
                        { 
                            transactionToAdd = new Transaction(receiptToAdd, paymentsMethod);
                        }
                        catch (Exception e)
                        {
                            print(e.Message, "\n ERROR: ");                         // inform the user
                            Console.ReadKey();
                        }
                            try
                        {
                            itsBL.add(transactionToAdd);                        // add transaction
                            Console.WriteLine("Transaction successfully added \n");
                            Thread.Sleep(2300);

                        }
                        catch (Exception e)
                        {
                            print(e.Message, "\n \n ERROR: ");                       // inform the user
                            Console.ReadKey();
                        }

                        break;

                    case "4":                                                   //add Club Members
                        Console.Clear();
                        Console.WriteLine("please fill the next fields:");
                        Console.Write("Club Member teudat zehute (notice! must be numbers): ");
                        string cTeudatZehute = Console.ReadLine();                  // get club memnber's teudat zehute
                        Console.Write("Club member first name: ");
                        string cFirstName = Console.ReadLine();                     // get club member's first name
                        Console.Write("Club member last name: ");
                        string cLastName = Console.ReadLine();                      // get club member's last name
                        Console.WriteLine("select a gender: ");
                        Console.WriteLine("\t1. Male");
                        Console.WriteLine("\t2. Female");
                        string cGender = Console.ReadLine();                        // get club member's gender
                        switch (cGender)
                        {
                            case "1":
                                cGender = "Male";
                                break;
                            case "2":
                                cGender = "Female";
                                break;
                            default:
                                Console.WriteLine("You have to choos 1 or 2");
                                break;
                        }
                       
                        Console.WriteLine("date of birth (notice! enter only numbers) : ");                       // get club member's birth date
                        Console.Write("Year:  ");
                        string year = Console.ReadLine();
                        Console.Write("Month (enter number between 01-12) : ");
                        string month = Console.ReadLine();
                        Console.Write("Day (enter number between 01-31) : ");
                        string day = Console.ReadLine();
                        string cDateOfBirth = (day + "/" + month + "/" + year);
                        ClubMember clubMemberToAdd = null;
                        try 
                        { 
                        clubMemberToAdd =new ClubMember(cTeudatZehute, cFirstName, cLastName, cGender, cDateOfBirth);       // create club member
                        }
                        catch (Exception e)
                        {
                            print(e.Message, "\n ERROR: ");                         // inform the user
                            Console.ReadKey();
                        }
                        try
                        {
                            itsBL.add(clubMemberToAdd);                         // add club member
                            Console.WriteLine("Club member successfully added  \n");
                            Thread.Sleep(2300);

                        }
                        catch (Exception e)
                        {
                            print(e.Message, "\n ERROR: ");                       // inform the user
                            Console.ReadKey();
                        }

                        break;

                    case "5":                                                   // add employee
                        Console.Clear();
                        Console.WriteLine("please fill the next fields:");
                        Console.Write("Employee teudat zehute (notice! must be numbers) : ");
                        string eTeudatZehute = Console.ReadLine();               // get employee's teudat zehute
                        Console.Write("Employee first name: ");
                        string eFirstName = Console.ReadLine();                 // get employee's first name
                        Console.Write("Employee last name: ");
                        string eLastName = Console.ReadLine();                  // get employee's last name
                        Console.WriteLine("select a gender: ");
                        Console.WriteLine("\t1. Male");
                        Console.WriteLine("\t2. Female");
                        string eGender = Console.ReadLine();                    // get employee's gender
                        switch (eGender)
                        {
                            case "1":
                                eGender = "Male";
                                break;
                            case "2":
                                eGender = "Female";
                                break;
                            default:
                                Console.WriteLine("You have to choos 1 or 2");
                                eGender = Console.ReadLine();
                                break;
                        }
                        Console.Write("To which department the employee is belongs to (Deprtment ID- must be numbers) :");
                        string departmentID = Console.ReadLine();               // get the department ID that the employee belong to
                        Console.Write(" employee salary (in numbers) : ");
                        string salary = Console.ReadLine();                     // get the employee's salary
                        Console.Write("His supervisor ID (notice! supervisor ID must be numbers) : ");
                        string supervisorID = Console.ReadLine();               //get the employee's supervisor ID
                        Employee employeeToAdd =null;
                        try
                        {
                           employeeToAdd= new Employee(eTeudatZehute, eFirstName, eLastName, departmentID, salary, supervisorID, eGender);       // create employee
                         }
                        catch (Exception e)
                        {
                            print(e.Message, "\n ERROR: ");                         // inform the user
                            Console.ReadKey();
                        }
                        try
                        {
                            itsBL.add(employeeToAdd);                       // add employee
                            Console.WriteLine("Employee successfully added \n");
                            Thread.Sleep(2300);
                        }
                        catch (Exception e)
                        {
                            print(e.Message, "\n ERROR: ");                       // inform the user
                            Console.ReadKey();
                        }
                        break;

                    case "6": // user
                        Console.Clear();
                        Console.WriteLine("please fill the next fields:");
                        Console.Write("Enter a username: ");
                        string userName = Console.ReadLine();                   //get username
                        Console.Write("Enter a password: ");
                        string password = Console.ReadLine();                   // get password
                        User userToAdd= null; 
                        try
                        {
                          userToAdd = new User(userName, password);          //create user
                        }
                        catch (Exception e)
                        {
                            print(e.Message, "\n ERROR: ");                         // inform the user
                            Console.ReadKey();
                        }
                            try
                            {
                                itsBL.add(userToAdd);                                  // add user 
                                Console.WriteLine("User successfully added \n");
                                Thread.Sleep(2300);

                            }
                            catch (Exception e)
                            {
                                print(e.Message, "\n ERROR: ");                       // inform the user
                                Console.ReadKey();
                            }
                        break;

                    case "7":                                                   //exit and option to save
                       Console.WriteLine("press 1 if you want to save");            // ask the user if he want to save
                        string toSave = Console.ReadLine();
                        if (toSave.Equals("1"))                                     // the user choose to save
                        {
                            itsBL.saveDataToFile();                                  // save
                            Console.WriteLine("Changes have been saved");              // inform the user
                            Thread.Sleep(1700);                                       
                        }
                        MainMenu moveToMenu = new MainMenu(itsBL);           // back to main menu
                        break;

                    default:
                        Console.WriteLine("You have performed an illegal move. choose number between 1-7");
                        Thread.Sleep(2300);
                        break;
                }
            }
        }
        
        public Receipt creatReceipt(List<Product> list, int totalRow )
        {
            Receipt newReceipt = null;
            try
            {
                newReceipt=new Receipt();
            }
            catch (Exception e)
            {
                print(e.Message, "\n ERROR: ");                         // inform the user
                Console.ReadKey();
            }
            bool more = true;
            while (more)                                              // add product 
            {
                Console.WriteLine("\n"+"Choose the product you want to add ( please enter the row number) : ");    // the user pick witch product to add
                int num = Convert.ToInt32(Console.ReadLine());
                if (num > 0 && num < totalRow)                                              // check if the prudect is in the list
                {
                    Product tmp = list.ElementAt(num-1);
                    ProductSale prod = null;
                    try                                                                
                    { 
                    prod= new ProductSale(tmp);
                    }
                    catch (Exception e)
                    {
                        print(e.Message, "\n ERROR: ");                         // inform the user
                        Console.ReadKey();
                    }
                        try
                    {
                        newReceipt.addProductSale(prod);                 // we add the product to the receipt 
                        Console.WriteLine("the product added to the receipt \n");
                        Thread.Sleep(1000);
                    }
                    catch (Exception e)
                    {
                        print(e.Message, "\n \n ERROR: ");                       // inform the user
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("You have performed an illegal move \n");
                    Thread.Sleep(2300);
                }
                Console.WriteLine("\t1. I dont have any more prodect to add");               // to finish creating the receipt
                Console.WriteLine("\t2. I want to add more prodect");
                string indicat = Console.ReadLine();
                switch (indicat)
                {
                    case "1":
                        more = false;
                        break;

                    case "2":
                        break;

                    default:
                        Console.WriteLine("You have performed an illegal move. Please choose 1 or 2 ");
                        Thread.Sleep(2300);
                        break;
                }
            }
            return newReceipt;
        }


        public void showProductList()                                               // Displays the list of products
        {
            AddScreen addprodect = new AddScreen(itsBL);
            Receipt receiptToAdd = new Receipt();
            List<Product> list;
            string choice;
            bool ans = true; 
            while (ans)
            {
                Console.WriteLine("How do you want to find the product: ");        // first we create list according to what the user want to search 
                Console.WriteLine("\t1. by product name");
                Console.WriteLine("\t2. by product ID");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":                                                                       // by product name   
                        Console.WriteLine("Enter product name");
                        string name = Console.ReadLine();
                        list = itsBL.queryByString(Classes.Product, stringFields.name, name).Cast<Product>().ToList();
                        Console.WriteLine("row.  Product Name | Product Type | Inventory ID");
                        if (list.LongCount() == 0)
                        {
                            Console.WriteLine("There are no items to show");
                            Thread.Sleep(1200);
                            AddScreen back = new AddScreen(itsBL);
                            back.run();
                        }
                        int counter = 1;
                        foreach (Product p in list)
                        {
                            Console.WriteLine("\t" + counter + ". " + p.Name + "  |  " + p.Type.ToString()+"  |  " + p.InventoryID.ToString());
                            counter++;
                        }
                        receiptToAdd = addprodect.creatReceipt(list, counter);
                        ans = false;
                        break;

                    case "2":                                                           //by prodect ID
                        Console.WriteLine("Enter product ID: ");
                        string id = Console.ReadLine();
                        while(!(InputCheck.isInt(id)))                          // check that the ID is numbers
                        {
                            Console.WriteLine("ID must be number. enter id again");
                            id=Console.ReadLine();
                        }
                        list = itsBL.queryByString(Classes.Product, stringFields.inventoryID, id).Cast<Product>().ToList();
                        Console.WriteLine("row. | Product Name | Product Type | Inventory ID");
                        if (list.LongCount() == 0)
                        {
                            Console.WriteLine("There are no items to show");
                            Thread.Sleep(1200);
                            AddScreen back = new AddScreen(itsBL);
                            back.run();
                        }
                        int counter2 = 1;
                        foreach (Product p in list)
                        {
                            Console.WriteLine("\t" + counter2 + ". " + p.Name + "  |  " + p.Type.ToString() +"  |  "+ p.InventoryID.ToString());
                            counter2++;
                        }
                        receiptToAdd = addprodect.creatReceipt(list, counter2);
                        ans = false;
                        break;

                    default:
                        Console.WriteLine("You have to choose 1 or 2 \n");
                        Thread.Sleep(2200);
                        break;

                }
            }
        }

        public String HowItPay()
        {
            string paymentsMethod = "";
            string pay;
            bool method = false ; 
            while (!method)
            {
                Console.WriteLine("How the buyer paid for the acquisition:");               // add  paymentsMethod
                Console.WriteLine("\t1. Cash");                                            // payment methods options
                Console.WriteLine("\t2. Credit");
                Console.WriteLine("\t3. Check");
                pay = Console.ReadLine();                                                   // the chosen payment method

                switch (pay)                                                                // to prevent Exception abot type enum
                {
                    case "1":
                        paymentsMethod = "Cash";
                        method = true;
                        break;

                    case "2":
                        paymentsMethod = "Credit";
                        method = true;
                        break;

                    case "3":
                        paymentsMethod = "Check";
                        method = true;
                        break;

                    default:
                        Console.WriteLine("You have performed an illegal move. Please choose 1 or 2 or 3 only");
                        break;
                }
            }
            return paymentsMethod;
        }

        private void print(object toPrint, string text)
        {
            Console.WriteLine(text + toPrint.ToString());

        }
    }
}
        
