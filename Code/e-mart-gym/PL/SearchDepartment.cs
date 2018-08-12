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
    public class SearchDepartment
    {
        private IBL itsBL;

        public SearchDepartment(IBL bl)
        {
            this.itsBL = bl;
            string cmd;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("search department by :");                        
                Console.WriteLine("\t1. name ");
                Console.WriteLine("\t2. department ID ");
                Console.WriteLine("\t3. gat all department");
                Console.WriteLine("\t4. back ");
                Console.WriteLine("\t5. back to main menu ");

                cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "1":
                        Console.WriteLine("search department with the name: ");
                        string dName = Console.ReadLine();                                                               //get fron the user the requested name
                        List<object> nameList = itsBL.queryByString(Classes.Department, stringFields.name, dName);          // sand the name to the appropriate query
                        Console.Clear();
                        Console.WriteLine("row. Department Name|Department ID");
                        List<Department> newDList1 = nameList.Cast<Department>().ToList();                                  // convert the list to department type
                        if (newDList1.LongCount() == 0)
                        {
                            Console.WriteLine("There are no items to show");                                                // if the list is empty
                        }
                        int counterN = 1;
                        foreach (Department d in newDList1)
                        {
                            Console.WriteLine(+counterN + ".  " + d.Name + " | " + d.DepartmentID.ToString());         // print the list on the screen
                            counterN++;
                        }
                        subMenu whatNext1 = new subMenu(itsBL);
                        whatNext1.Menu("2", counterN, nameList);                                                        // send the object list to screen that presents remove and edit option

                        break;

                    case "2":
                        
                        Console.WriteLine("search department with the department ID: ");
                        string dID = Console.ReadLine();                                                                   //get fron the user the requested department ID
                        while (!(InputCheck.isInt(dID)))                                                                    // check if the user enter valid department ID
                        {
                            Console.WriteLine("Department Id must be number. enter ID again");                              // if he didnt , asked him to enter ID again
                            dID = Console.ReadLine();
                        }
                        List<object> listID = itsBL.queryByString(Classes.Department, stringFields.departmentID , dID);      //if the ID is valid send him to the appropiate query
                        Console.Clear();
                        Console.WriteLine("row. Department Name|Department ID");
                        List<Department> newDList2 = listID.Cast<Department>().ToList();                                    //convert the list to deprtment type
                        if (newDList2.LongCount() == 0)
                        {
                            Console.WriteLine("There are no items to show");                                                //if the list is empty
                        }
                        int counterI = 1;
                        foreach (Department d in newDList2)
                        {
                            Console.WriteLine(+counterI + ".  " + d.Name + "  " + d.DepartmentID.ToString());         // print the list on the screen
                            counterI++;
                        }
                        subMenu whatNext2 = new subMenu(itsBL);
                       whatNext2.Menu("2", counterI, listID);                                                           // send the object list to screen that presents remove and edit option
                                
                        break;

                    case "3":
                        List<Department> newList3 = itsBL.getAllDepartments().Departmentss;                         //presents all the departments that in the system
                        Console.Clear();
                        Console.WriteLine("row. Department Name|Department ID");
                        if (newList3.LongCount() == 0)
                        {
                            Console.WriteLine("There are no items to show");                                        // if the list is empty
                        }
                        int counterA = 1;
                        foreach (Department d in newList3)
                        {
                            Console.WriteLine(+counterA + ".  " + d.Name + "  " + d.DepartmentID.ToString());         // print the list on the screen
                            counterA++;
                        }
                         List<object> allList = newList3.Cast<object>().ToList();
                        subMenu whatNext3 = new subMenu(itsBL);
                        whatNext3.Menu("2", counterA, allList);                                                          // send the object list to screen that presents remove and edit option
                        break;

                    case "4":
                         Search back = new Search(itsBL);                                                               // return to the serch menu
                         back.run();
                         break;

                    case "5":
                         MainMenu moveToMenu = new MainMenu(itsBL);                                                     //return to the main menu
                         break; 

                    default:
                         Console.WriteLine("You have performed an illegal move, please enter a number between 1-5");                // if the user tried to do illegal move
                         Thread.Sleep(2400);
                         break;

                }

            }
        }
    }
}
