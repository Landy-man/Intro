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
    public class Search
    {
        private IBL itsBL;
        public Search(IBL BL)
        {
            this.itsBL = BL;
        }

        public void run()
        {
            string cmd;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What you wnat to search:");
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
                    case "1":
                        SearchProduct searchProudect = new SearchProduct(itsBL);
                        break;

                    case "2":
                        SearchDepartment searchDepartment = new SearchDepartment(itsBL);
                        break;

                    case "3":
                        SearchTransaction searchTransaction = new SearchTransaction(itsBL);
                        break;

                    case "4":
                        SearchClubMember searchMember = new SearchClubMember(itsBL);
                        break;

                    case "5":
                        SearchEmployee searchEmployee = new SearchEmployee(itsBL);
                        break;

                    case "6":
                        SearchUser searchUser = new SearchUser(itsBL);
                        break;

                    case "7":
                        MainMenu backTo = new MainMenu(itsBL);
                        break;

                    default:
                        Console.WriteLine("You have performed an illegal move \n");
                        Thread.Sleep(2300);
                        break;

                }
            }
        }
    }
}

