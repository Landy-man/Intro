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
    public class ExitScreen
    {
        private IBL itsBL;

        public ExitScreen(IBL BL)
        {
            this.itsBL = BL;
      
            string cmd;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" do you want to save? ");                    // ask if the user want to save befor exit
                Console.WriteLine("\t1. no");
                Console.WriteLine("\t2. yes");
                cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "1":                                                   // close without saving 
                        Console.Clear();
                        Console.WriteLine("Bay, see you next time! ");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;

                    case "2":                                                   // save and close
                        itsBL.saveDataToFile();
                        Console.Clear();
                        Console.WriteLine("Changes saved ");
                        Console.WriteLine("Bay, see you next time! ");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;

                    default:                                                    // the user tried to do illegal move
                        Console.WriteLine("You have performed an illegal move. choose 1 or 2 \n");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }
    }
}
