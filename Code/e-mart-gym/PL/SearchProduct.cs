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
    public class SearchProduct
    {
        private IBL itsBL;

        public SearchProduct(IBL BL)
        {
            this.itsBL = BL;
     
            string cmd;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("search product by :");
                Console.WriteLine("\t1. name ");
                Console.WriteLine("\t2. type ");
                Console.WriteLine("\t3. product ID ");
                Console.WriteLine("\t4. location (department ID ");
                Console.WriteLine("\t5. product in stock ");
                Console.WriteLine("\t6. stock count ");
                Console.WriteLine("\t7. price");
                Console.WriteLine("\t8. gat all the products ");
                Console.WriteLine("\t9. back ");
                Console.WriteLine("\t10. back to main menu ");

                cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "1" :                                                // search product by name
                        Console.WriteLine("Enter product name which you want to search: ");
                        string pName = Console.ReadLine();                   // get the name the user want to search 
                        List<object> nameList = itsBL.queryByString(Classes.Product, stringFields.name , pName);
                        Console.Clear();
                        Console.WriteLine("row. Product Name|Product Type|Inventory ID|Location|In Stock|Stock Count|Price");                        
                        List<Product> newList1 = nameList.Cast<Product>().ToList();
                        if (newList1.LongCount() == 0)
                        {
                            Console.WriteLine("There are no items to show");
                        }
                        int counterN=1;
                        foreach (Product p in newList1)
                            {
                                Console.WriteLine(counterN + ".  " + p.Name + " | " + p.Type.ToString() + " | " +p.InventoryID.ToString()+" | "+p.Location.ToString()+" | "+p.INStock.ToString()+" | "+p.StockCount.ToString()+" | "+p.Price.ToString());         // print the list on the screen
                                counterN++;
                            }
                          subMenu whatNext1 = new subMenu(itsBL);
                          whatNext1.Menu("1", counterN, nameList);

                            break;

                    case "2":                                                       // search by type
                        Console.WriteLine("Search for products from this type : ");
                        string pType = Console.ReadLine();                          // get the type the user want to search 
                        try
                        {
                            InputCheck.isType(pType);
                        }
                        catch (Exception e)
                        {
                            print(e.Message, "\n ERROR: ");                       // inform the user
                            Console.ReadKey();
                        }
                        List<object> typeList = itsBL.queryByString(Classes.Product, stringFields.type, pType);
                        Console.Clear();
                        Console.WriteLine("row. Product Name|Product Type|Inventory ID|Location|In Stock|Stock Count|Price");
                        List<Product> newList2 = typeList.Cast<Product>().ToList();
                        if (newList2.LongCount() == 0)
                        {
                            Console.WriteLine("There are no items to show");
                        }
                        int counterT = 1;
                        foreach (Product p in newList2)
                            {
                                Console.WriteLine(counterT+ ".  " + p.Name + " | " + p.Type.ToString() + " | " + p.InventoryID.ToString() + " | " + p.Location.ToString() + " | " + p.INStock.ToString() + " | " + p.StockCount.ToString() + " | " + p.Price.ToString());         // print the list on the screen                                
                                counterT++;
                            }
                          subMenu whatNext2 = new subMenu(itsBL);
                          whatNext2.Menu("1", counterT, typeList);
                          break;
                           

                    case "3":                                                        // search by product ID
                        Console.WriteLine("Search products by the ID : (notice! numbers only) ");
                        string pID = Console.ReadLine();                           // get the product ID the user want to search 
                        while (!(InputCheck.isInt(pID)))
                        {
                            Console.WriteLine("Invalid ID. \n enter again");
                            pID = Console.ReadLine();
                        }
                        List<object> iDList = itsBL.queryByString(Classes.Product, stringFields.inventoryID , pID);
                        Console.Clear();
                        Console.WriteLine("row. Product Name|Product Type|Inventory ID|Location|In Stock|Stock Count|Price");
                        List<Product> newList3 = iDList.Cast<Product>().ToList();
                        if (newList3.LongCount() == 0)
                        {
                            Console.WriteLine("There are no items to show");
                        }
                        int counterI = 1;
                            foreach (Product p in newList3)
                            {
                                Console.WriteLine(counterI+ ".  " + p.Name + " | " + p.Type.ToString() + " | " + p.InventoryID.ToString() + " | " + p.Location.ToString() + " | " + p.INStock.ToString() + " | " + p.StockCount.ToString() + " | " + p.Price.ToString());         // print the list on the screen                                
                                counterI++;
                            }
                            subMenu whatNext3 = new subMenu(itsBL);
                            whatNext3.Menu("1", counterI, iDList);
                            break;
                           

                   case "4":                                                       // search product by name
                        Console.WriteLine("Search all products in the department (notice! enter ID department- only numbers) : ");
                        string pDepartment = Console.ReadLine();                         // get the name the user want to search 
                        while (!(InputCheck.isInt(pDepartment)))
                        {
                            Console.WriteLine("Invalid department ID. \n enter again");
                            pDepartment = Console.ReadLine();
                        }

                        List<object> departmentList = itsBL.queryByString(Classes.Product, stringFields.location, pDepartment);
                        Console.Clear();
                        Console.WriteLine("row. Product Name|Product Type|Inventory ID|Location|In Stock|Stock Count|Price");
                        List<Product> newList4 = departmentList.Cast<Product>().ToList();
                        if (newList4.LongCount() == 0)
                        {
                            Console.WriteLine("There are no items to show");
                        }
                        int counterD = 1;
                        foreach (Product p in newList4)
                        {
                            Console.WriteLine(counterD+ ".  " + p.Name + " | " + p.Type.ToString() + " | " + p.InventoryID.ToString() + " | " + p.Location.ToString() + " | " + p.INStock.ToString() + " | " + p.StockCount.ToString() + " | " + p.Price.ToString());         // print the list on the screen                            
                            counterD++;
                        }
                        subMenu whatNext4 = new subMenu(itsBL);
                        whatNext4.Menu("1", counterD, departmentList);
                        break;



                   case "5":  
                            Console.WriteLine("choose a number: ");
                            Console.WriteLine("\t1. show all the product that in stock ");
                            Console.WriteLine("\t2. show all the product that not in stock ");
                            Console.WriteLine("\t3. show all the product that need to ordered ");
                            string pStock = Console.ReadLine();
                            string pInStock="";       
                            switch (pStock)
                                {
                                    case "1":
                                        pInStock = "True";
                                        break;
                                    case "2":
                                        pInStock = "False";
                                        break;
                                    case "3":
                                        pInStock = "NeedToOrder";
                                        break; 

                                    default:
                                        Console.WriteLine("You have performed an illegal move, please enter 1 or 2");
                                        break;
                                }                          
                            List<object> inStockList = itsBL.queryByString(Classes.Product, stringFields.inStock, pInStock);
                        Console.Clear();
                        Console.WriteLine("row. Product Name|Product Type|Inventory ID|Location|In Stock|Stock Count|Price");
                        List<Product> newList5 = inStockList.Cast<Product>().ToList();
                        if (newList5.LongCount() == 0)
                        {
                            Console.WriteLine("There are no items to show");
                        }
                        int counterS = 1;
                        foreach (Product p in newList5)
                            {
                                Console.WriteLine(+counterS+ ".  " + p.Name + " | " + p.Type.ToString() + " | " + p.InventoryID.ToString() + " | " + p.Location.ToString() + " | " + p.INStock.ToString() + " | " + p.StockCount.ToString() + " | " + p.Price.ToString());         // print the list on the screen                               
                                counterS++;
                            }
                            subMenu whatNext5 = new subMenu(itsBL);
                            whatNext5.Menu("1", counterS, inStockList);
                            break;   

                    case "6":
                         Console.WriteLine("Choose an option: ");
                         Console.WriteLine("\t1. Search for specific stock count ");
                         Console.WriteLine("\t2. Search range of stock count ");
                         string search = Console.ReadLine();
                         string fromValue = Int32.MinValue.ToString();
                         string toValue = Int32.MaxValue.ToString();         
                         switch (search)
                                {
                                    case "1":
                                        Console.WriteLine("enter stock count: ");
                                        string stockCount = Console.ReadLine();
                                        while (!(InputCheck.isInt(stockCount)))
                                        {
                                            Console.WriteLine("Invalid stock count. \n try again");
                                            stockCount = Console.ReadLine();
                                        }

                                        fromValue = stockCount;
                                        toValue = stockCount;

                                        break;

                                    case "2":
                                        Console.WriteLine("from which stock count to search: ");
                                        string fromCount = Console.ReadLine();
                                        while (!(InputCheck.isInt(fromCount)))
                                        {
                                            Console.WriteLine("Invalid stock count. \n try again");
                                            fromCount = Console.ReadLine();
                                        }
                                        fromValue = fromCount;

                                        Console.WriteLine("until which stock count to search: ");
                                        string toCount = Console.ReadLine();
                                        while (!(InputCheck.isInt(toCount)))
                                        {
                                            Console.WriteLine("Invalid stock count. \n try again");
                                            toCount = Console.ReadLine();
                                        }
                                        toValue = toCount;

                                        break;

                                    default:
                                        Console.WriteLine("You perform illegal move, please choose 1 or 2");
                                        Thread.Sleep(2400);
                                        break; 
                                }
                            List<object> stockList = itsBL.queryByRange(Classes.Product, rangeFields.stockCount, fromValue, toValue);
                            Console.Clear();
                            Console.WriteLine("row. Product Name|Product Type|Inventory ID|Location|In Stock|Stock Count|Price");
                            int counterC = 1;
                            List<Product> newList6 = stockList.Cast<Product>().ToList();
                            if (newList6.LongCount() == 0)
                            {
                                Console.WriteLine("There are no items to show");
                            }
                            foreach (Product p in newList6)
                            {
                                Console.WriteLine(+counterC+ ".  " + p.Name + " | " + p.Type.ToString() + " | " + p.InventoryID.ToString() + " | " + p.Location.ToString() + " | " + p.INStock.ToString() + " | " + p.StockCount.ToString() + " | " + p.Price.ToString());         // print the list on the screen     Console.WriteLine(+counterC + ".  " + p.Name + "  " + p.Type.ToString() + "  " + p.InventoryID.ToString());         // print the list on the screen
                                counterC++;
                            }
                            subMenu whatNext6 = new subMenu(itsBL);
                            whatNext6.Menu("1", counterC, stockList);
                            break;

                    case "7":
                        Console.WriteLine("Choose an option: ");
                         Console.WriteLine("\t1. Search for specific price ");
                         Console.WriteLine("\t2. Search range of prices ");
                         string howSearch = Console.ReadLine();
                         string fromPrice = Int32.MinValue.ToString();
                         string toPrice = Int32.MaxValue.ToString();   
                         switch (howSearch)
                                {
                                    case "1":
                                        Console.WriteLine("enter price: ");
                                        string price = Console.ReadLine();
                                        while (!(InputCheck.isDouble(price)))
                                        {
                                            Console.WriteLine("Invalid price. \n try again");
                                            price = Console.ReadLine();
                                        }
                                        fromPrice = price;
                                        toPrice = price;

                                        break;

                                    case "2":
                                        Console.WriteLine("from which price to search: ");
                                        string price1 = Console.ReadLine();
                                        while (!(InputCheck.isDouble(price1)))
                                        {
                                            Console.WriteLine("Invalid price. \n try again");
                                            price1 = Console.ReadLine();
                                        }
                                        fromPrice = price1;

                                        Console.WriteLine("until which price count to search: ");
                                        string price2 = Console.ReadLine();
                                        while (!(InputCheck.isDouble(price2)))
                                        {
                                            Console.WriteLine("Invalid price. \n try again");
                                            price2 = Console.ReadLine();
                                        }
                                        toPrice = price2;

                                        break;

                                    default:
                                        Console.WriteLine("You perform illegal move, please choose 1 or 2");
                                        Thread.Sleep(2400);
                                        break; 
                                }
                         List<object> priceList = itsBL.queryByRange(Classes.Product, rangeFields.price, fromPrice, toPrice);
                            Console.Clear();
                            Console.WriteLine("row. Product Name|Product Type|Inventory ID|Location|In Stock|Stock Count|Price");
                            List<Product> newList7 = priceList.Cast<Product>().ToList();
                            if (newList7.LongCount() == 0)
                            {
                                Console.WriteLine("There are no items to show");
                            }
                            int counterP = 1;
                            foreach (Product p in newList7)
                            {
                                Console.WriteLine(+counterP+ ".  " + p.Name + " | " + p.Type.ToString() + " | " + p.InventoryID.ToString() + " | " + p.Location.ToString() + " | " + p.INStock.ToString() + " | " + p.StockCount.ToString() + " | " + p.Price.ToString());         // print the list on the screen                                
                                counterP++;
                            }
                            subMenu whatNext7 = new subMenu(itsBL);
                            whatNext7.Menu("1", counterP, priceList);
                            break;
                    case "8":
                            List<Product> newList8 = itsBL.getAllProducts().Productss;
                            Console.Clear();
                            Console.WriteLine("row. Product Name|Product Type|Inventory ID|Location|In Stock|Stock Count|Price");
                            if (newList8.LongCount() == 0)
                            {
                                Console.WriteLine("There are no items to show");
                            }
                            int counterA = 1;
                            foreach (Product p in newList8)
                            {
                                Console.WriteLine(+counterA+ ".  " + p.Name + " | " + p.Type.ToString() + " | " + p.InventoryID.ToString() + " | " + p.Location.ToString() + " | " + p.INStock.ToString() + " | " + p.StockCount.ToString() + " | " + p.Price.ToString());         // print the list on the screen                                
                                counterA++;
                            }
                            List<object> allList = newList8.Cast<object>().ToList();
                            subMenu whatNext8 = new subMenu(itsBL);
                            whatNext8.Menu("1", counterA, allList);
                            break;

                    case "9":
                            Search back = new Search(itsBL);
                            back.run();
                            break;

                    case "10":
                            MainMenu moveToMenu = new MainMenu(itsBL);
                            break;

                    default:
                            Console.WriteLine("You have performed an illegal move, please enter a number between 1-10");
                            Thread.Sleep(2400);
                            break;

          }
        }
      }
        private void print(object toPrint, string text)
        {
            Console.WriteLine(text + toPrint.ToString());

        }

   }
}
