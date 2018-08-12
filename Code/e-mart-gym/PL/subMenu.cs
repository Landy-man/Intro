using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Backend;
using BL;

namespace PL
{
    public class subMenu
    {
        private IBL itsBL;

        public subMenu(IBL BL)
        {
            this.itsBL = BL;
        }

        
       public subMenu()
        { }

       public void Menu(string classNum, int toatlRow, List<object> list)
       {
           if (list.LongCount() == 0)
           {
               string whatNext;
               while (true)
               {
                   Console.WriteLine("\t1. back");
                   Console.WriteLine("\t2. Bask to main menu");
                   whatNext = Console.ReadLine();

                   switch (whatNext)
                   {
                       case "1":
                           Search back = new Search(itsBL);
                           back.run();
                           break;

                       case "2":
                           MainMenu backTo = new MainMenu(itsBL);
                           break;

                       default:
                           Console.WriteLine("you must enter 1 or 2 only");
                           Thread.Sleep(1700);
                           break;

                   }
               }
           }
          else
           {
               string whatNext1;
               while (true)
               {
                   Console.WriteLine("\t1. Remove ");
                   Console.WriteLine("\t2. Edit ");
                   Console.WriteLine("\t3. Save");
                   Console.WriteLine("\t4. back");
                   Console.WriteLine("\t5. Bask to main menu");

                   if (classNum == "1") { list.Cast<Product>().ToList(); }
                   if (classNum == "2") { list.Cast<Department>().ToList(); }
                   if (classNum == "3") { list.Cast<Transaction>().ToList(); }
                   if (classNum == "4") { list.Cast<ClubMember>().ToList(); }
                   if (classNum == "5") { list.Cast<Employee>().ToList(); }
                   if (classNum == "6") { list.Cast<User>().ToList(); }

                   whatNext1 = Console.ReadLine();

                   switch (whatNext1)
                   {
                       case "1":
                           Console.WriteLine("Enter the row number of the item that you want to remove :");
                           String remove1 = Console.ReadLine();
                           bool toRemove = true;
                           while (toRemove)
                           {
                               while (!(InputCheck.isInt(remove1)))
                               {
                                   Console.WriteLine("You have to choose number. \n enter row");
                                   remove1 = Console.ReadLine();
                               }
                               int rowNum = Convert.ToInt32(remove1);
                               if (rowNum > 0 && rowNum <= toatlRow)                         // check if the user choose product from the list
                               {
                                   try
                                   {
                                       itsBL.remove(list.ElementAt(rowNum - 1));                     // remove the prodect
                                       Console.WriteLine("item successfully removed \n");
                                       Thread.Sleep(2200);
                                       Console.WriteLine("press 1 to remove more items ");
                                       Console.WriteLine("if you finish press any other key ");
                                       string choice = Console.ReadLine();
                                       if (choice != "1")
                                       {
                                           toRemove = false;
                                       }
                                   }
                                   catch (Exception e)
                                   {
                                       toRemove = false;
                                       print(e.Message, "ERROR: ");
                                       Thread.Sleep(2500);
                                   }

                               }
                               else
                               {
                                   Console.WriteLine("You have to enter number from the list");
                                   Thread.Sleep(2200);
                               }

                           }
                           break;

                       case "2":
                           Console.WriteLine("Enter the row number for the item you want to edit : ");
                            String remove2 = Console.ReadLine();
                            bool ans = true;
                            while (ans)
                            {
                                while (!(InputCheck.isInt(remove2)))
                                {
                                    Console.WriteLine("You have to enter number. \n enter row");
                                    remove2 = Console.ReadLine();
                                }
                                int rowNumber = Convert.ToInt32(remove2);
                                if (rowNumber > 0 && rowNumber <= toatlRow-1)
                                {
                                    ans = false;
                                    object toEdit = list.ElementAt(rowNumber - 1);
                                    Edit moveToEdit = new Edit(itsBL);
                                    moveToEdit.toEdit(toEdit, classNum);
                                }
                                else
                                {
                                    Console.WriteLine("you have to choose number from the list");
                                    remove2 = Console.ReadLine();

                                }
                            }
                           break;

                       case "3":
                           itsBL.saveDataToFile();
                           Console.WriteLine("saved");
                           Thread.Sleep(2300);
                           break;

                       case "4":
                           Search back = new Search(itsBL);
                           back.run();
                           break;

                       case "5":
                           MainMenu backTo = new MainMenu(itsBL);
                           break;

                       default:
                           Console.WriteLine("You have to choose number between 1-5 ");
                           Thread.Sleep(2200);
                           break;
                   }
               }
           }
       }

        private void print(object toPrint, string text)
        {
            Console.WriteLine(text + toPrint.ToString());

        }   
        }
    }

