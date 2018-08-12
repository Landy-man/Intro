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
    class SearchUser
    {
         private IBL itsBL;
         public SearchUser(IBL BL)
        {
            this.itsBL = BL;
        
            string cmd;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t1. search user by username");
                Console.WriteLine("\t2. gat all users");
                Console.WriteLine("\t3. back");
                Console.WriteLine("\t4. back to main menu ");
                cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "1" :
                        Console.WriteLine("enter the username you want to search: ");
                        string userName = Console.ReadLine();                                               
                        List<object> userList = itsBL.queryByString(Classes.User, stringFields.userName, userName);             // Sends the requested user to the appropriate query
                        Console.Clear();
                        Console.WriteLine("row. Username");
                        List<User> newList1 = userList.Cast<User>().ToList();               // convert the list to user
                        if (newList1.LongCount() == 0)                                  // if the list is empty 
                        {
                            Console.WriteLine("There are no items to show");
                        }
                        int counterU = 1;
                        foreach (User u in newList1)                                    // If the query has found requested users
                        {
                            Console.WriteLine(counterU + ".  " + u.UserName );         // print the list on the screen
                            counterU++;
                        }
                        subMenu whatNext =new subMenu(itsBL);
                        whatNext.Menu("6", counterU, userList);                 // send the (object) list to edit and remove option
                        break;

                    case "2":
                        List<User> newList2 = itsBL.getAllUsers().Userss;                       // list of all the users 
                         Console.Clear();
                         Console.WriteLine("row. Username");
                        if (newList2.LongCount() == 0)                                      // if the list is empty
                        {
                            Console.WriteLine("There are no items to show");
                        }
                        int counterA = 1;
                        foreach (User u in newList2)
                        {
                            Console.WriteLine(counterA + ".  " + u.UserName );         // print the list on the screen
                            counterA++;
                        }
                         List<object> allList = newList2.Cast<object>().ToList();        // convert the list to object type
                        subMenu whatNext2 = new subMenu(itsBL);
                        whatNext2.Menu("6", counterA, allList);                         // send the list to edit and remove option

                        break; 

                    case "3":
                        Search back = new Search(itsBL);                            // return to the last screen. (the search screen) 
                        back.run();
                        break;

                    case "4":
                        MainMenu moveToMenu = new MainMenu(itsBL);                  // return to the main menu.
                        break;

                    default:
                        Console.WriteLine("You have performed an illegal move, please enter a number between 1-3");
                        Thread.Sleep(2400);
                        break;
                }
               
            }
        }
    }
}
