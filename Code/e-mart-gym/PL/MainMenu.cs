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
    public class MainMenu
    {
        private IBL itsBL;

        public MainMenu(IBL bl)
        {
            this.itsBL = bl;
            string cmd;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please select an option:");
                Console.WriteLine("\t1. Add ");
                Console.WriteLine("\t2. Search ");
                //Console.WriteLine("\t3. Show all ");
                Console.WriteLine("\t3. Save ");
                Console.WriteLine("\t4. Exit ");
                cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "1":                                         // Add
                        AddScreen addMenu = new AddScreen(itsBL);
                        addMenu.run();                                  // move to add menu
                        break;

                    case "2":                                           // search
                        Search searchMenu = new Search(itsBL);
                        searchMenu.run();                               // move to search menu
                        break;

                    //case "3":

                    //    break;

                    case "3":                                            //save
                        itsBL.saveDataToFile();
                        Console.WriteLine(" saved ");
                        Thread.Sleep(1500);
                        break;

                    case "4":                                                // exit
                        ExitScreen finalScreen = new ExitScreen(itsBL);          // move to exit menu
                        break;

                    default:
                        Console.WriteLine("You have performed an illegal move. choose number between 1-4 "); 
                        Thread.Sleep(2300); 
                        break; 

                }

            }
        }
    }
}