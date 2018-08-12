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
    public class SearchEmployee
    {

            private IBL itsBL;
            private string minInt;
            private string maxInt;
            private string minDateTime;
            private string maxDateTIme;


            public SearchEmployee(IBL BL)
            {
                this.itsBL = BL;
                minInt = Convert.ToString(Int32.MinValue);
                maxInt = Convert.ToString(Int32.MaxValue);
                minDateTime = Convert.ToString(DateTime.MinValue);
                maxDateTIme = Convert.ToString(DateTime.MaxValue);
          
                string cmd;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("search employee by :");
                    Console.WriteLine("\t1. his teudat Zehute ");
                    Console.WriteLine("\t2. his first name ");
                    Console.WriteLine("\t3. his last name ");
                    Console.WriteLine("\t4. department ID ");
                    Console.WriteLine("\t5. salary ");
                    Console.WriteLine("\t6. gender ");
                    Console.WriteLine("\t7. supervisor ID");
                    Console.WriteLine("\t8. gat all employees ");
                    Console.WriteLine("\t9. back ");
                    Console.WriteLine("\t10. back to main menu ");
                    
                    cmd = Console.ReadLine();

                    switch (cmd)
                    {
                        case "1":
                            
                            Console.WriteLine("Enter the teudat Zehute you want to find (notice! must my numbers): ");
                            string eTZ = Console.ReadLine();
                            while (!(InputCheck.isInt(eTZ)))
                            {
                                Console.WriteLine("Invalid teudat zehute. \n enter again");
                                eTZ = Console.ReadLine();
                            }

                            List<object> tehudotList = itsBL.queryByString(Classes.Employee, stringFields.teudatZehute, eTZ);
                            Console.Clear();
                            Console.WriteLine("row. teudat Zehute|First Name|Last Name|Department ID|Salary|Gender|Supervisor IS ");
                            List<Employee> newDList1 = tehudotList.Cast<Employee>().ToList();
                            if (newDList1.LongCount() == 0)
                            {
                                Console.WriteLine("There are no items to show");
                            }
                            int counterT = 1;
                            foreach (Employee e in newDList1)
                            {
                                Console.WriteLine(+counterT + ".  " + e.TeudatZehute.ToString() + " | " + e.FirstName+" | "+ e.LastName+" | " + e.DepartmentID.ToString()+" | " + e.Salary.ToString() +" | "+e.Gender.ToString()+" | "+e.SupervisorID.ToString() );         // print the list on the screen
                                counterT++;
                            }
                            subMenu whatNext1 = new subMenu(itsBL);
                            whatNext1.Menu("5", counterT, tehudotList);

                            break;

                        case "2":
                            Console.Clear();
                            Console.WriteLine("Enter the first name you want to find: ");
                            string efirst = Console.ReadLine();
                            List<object> firstList = itsBL.queryByString(Classes.Employee, stringFields.firstName, efirst);
                            Console.Clear();
                            Console.WriteLine("row. teudat Zehute|First Name|Last Name|Department ID|Salary|Gender|Supervisor IS ");
                            List<Employee> newDList2 = firstList.Cast<Employee>().ToList();
                            if (newDList2.LongCount() == 0)
                            {
                                Console.WriteLine("There are no items to show");
                            }
                            int counterF = 1;
                            foreach (Employee e in newDList2)
                            {
                                Console.WriteLine(+counterF + ".  " + e.TeudatZehute.ToString() + " | " + e.FirstName + " | " + e.LastName + " | " + e.DepartmentID.ToString() + " | " + e.Salary.ToString() + " | " + e.Gender.ToString() + " | " + e.SupervisorID.ToString());         // print the list on the screen
                                counterF++;
                            }
                            subMenu whatNext2 = new subMenu(itsBL);
                            whatNext2.Menu("5", counterF, firstList);

                            break;

                        case "3":
                            Console.Clear();
                            Console.WriteLine("Enter the last name you want to find: ");
                            string elast = Console.ReadLine();
                            List<object> lastList = itsBL.queryByString(Classes.Employee, stringFields.lastName, elast);
                            Console.Clear();
                            Console.WriteLine("row. teudat Zehute|First Name|Last Name|Department ID|Salary|Gender|Supervisor IS ");
                            List<Employee> newDList3 = lastList.Cast<Employee>().ToList();
                            if (newDList3.LongCount() == 0)
                            {
                             Console.WriteLine("There are no items to show");
                            }
                            int counterL = 1;
                            foreach (Employee e in newDList3)
                            {
                                Console.WriteLine(+counterL + ".  " + e.TeudatZehute.ToString() + " | " + e.FirstName + " | " + e.LastName + " | " + e.DepartmentID.ToString() + " | " + e.Salary.ToString() + " | " + e.Gender.ToString() + " | " + e.SupervisorID.ToString());         // print the list on the screen
                                counterL++;
                            }
                            subMenu whatNext3 = new subMenu(itsBL);
                            whatNext3.Menu("5", counterL, lastList);

                            break;

                        case "4":
                            Console.Clear();
                            Console.WriteLine("Enter the department ID you want to find: (notice! must be numbers) ");
                            string edepar = Console.ReadLine();
                            while (!(InputCheck.isInt(edepar)))
                            {
                                Console.WriteLine("Invalid department ID. \n enter again");
                                edepar = Console.ReadLine();
                            }
                            List<object> depList = itsBL.queryByString(Classes.Employee, stringFields.departmentID, edepar);
                            Console.Clear();
                            Console.WriteLine("row. teudat Zehute|First Name|Last Name|Department ID|Salary|Gender|Supervisor IS ");
                            List<Employee> newList4 = depList.Cast<Employee>().ToList();
                            if (newList4.LongCount() == 0)
                            {
                                Console.WriteLine("There are no items to show");
                            }
                            int counterD = 1;
                            foreach (Employee e in newList4)
                            {
                                Console.WriteLine(+counterD + ".  " + e.TeudatZehute.ToString() + " | " + e.FirstName + " | " + e.LastName + " | " + e.DepartmentID.ToString() + " | " + e.Salary.ToString() + " | " + e.Gender.ToString() + " | " + e.SupervisorID.ToString());         // print the list on the screen
                                counterD++;
                            }
                            subMenu whatNext4 = new subMenu(itsBL);
                            whatNext4.Menu("5", counterD, depList);

                            break;

                        case "5":
                            Console.Clear();
                            Console.WriteLine("Choose an option: ");
                            Console.WriteLine("\t1. Search for specific salary ");
                            Console.WriteLine("\t2. Search range of salary ");
                            string search = Console.ReadLine();
                            string fromValue = null;
                            string toValue = null;
                            //bool ans = true;
                            //while (ans) 
                            //{
                            switch (search)
                                {
                                    case "1":
                                        Console.WriteLine("enter salary: ");
                                        string salary = Console.ReadLine();
                                   while(!(InputCheck.isDouble(salary)))
                                    {
                                        Console.WriteLine("invalid salary. \n try again");
                                        salary = Console.ReadLine();
                                     }
                                        fromValue = salary;
                                        toValue = salary;
                                        //ans=false;
                                        break;

                                    case "2":
                                        Console.WriteLine("from which salary to search: ");
                                        string fromSalary = Console.ReadLine();
                                        while(!(InputCheck.isDouble(fromSalary)))
                                        {
                                             Console.WriteLine("invalid salary. \n try again");
                                              fromSalary = Console.ReadLine();
                                        }
                                        fromValue = fromSalary;
                                       
                                        Console.WriteLine("until which salary to search: ");
                                        string toSalary = Console.ReadLine();
                                        while(!(InputCheck.isDouble(toSalary)))
                                        {
                                             Console.WriteLine("invalid salary. \n try again");
                                              toSalary = Console.ReadLine();
                                        }
                                        toValue = toSalary;
                                    
                                        //ans=false;
                                    break;

                                    default:
                                        Console.WriteLine("You perform illegal move, please choose 1 or 2");
                                        break; 
                                     }    
                           // }
                            List<object> salaryList = itsBL.queryByRange(Classes.Employee, rangeFields.salary, fromValue, toValue);
                            Console.Clear();
                            Console.WriteLine("row. teudat Zehute|First Name|Last Name|Department ID|Salary|Gender|Supervisor IS ");
                            List<Employee> newList5 = salaryList.Cast<Employee>().ToList();
                            if (newList5.LongCount() == 0)
                            {
                                Console.WriteLine("There are no items to show");
                            }
                            int counterS = 1;
                            foreach (Employee e in newList5)
                            {
                                Console.WriteLine(+counterS + ".  " + e.TeudatZehute.ToString() + " | " + e.FirstName + " | " + e.LastName + " | " + e.DepartmentID.ToString() + " | " + e.Salary.ToString() + " | " + e.Gender.ToString() + " | " + e.SupervisorID.ToString());         // print the list on the screen
                                counterS++;
                            }
                            subMenu whatNext5 = new subMenu(itsBL);
                            whatNext5.Menu("5", counterS, salaryList);
                            break;

                        case "6":
                            Console.Clear();
                            Console.WriteLine("Enter the gender you want to find: ");
                            Console.WriteLine("\t1. Male");
                            Console.WriteLine("\t2. Female");
                            string cho = Console.ReadLine(); 
                            string eGender="null";
                            bool gend = true;
                            while (gend)
                            {
                                if (cho == "1") { eGender = "Male"; gend = false; }
                                else if (cho == "2") { eGender = "Female"; gend = false; }
                                else 
                                {
                                 Console.WriteLine("choose 1 Or 2 only");
                                 cho = Console.ReadLine();
                                }
                            }
                            List<object> genderList = itsBL.queryByString(Classes.Employee, stringFields.gender, eGender);
                            Console.Clear();
                            Console.WriteLine("row. teudat Zehute|First Name|Last Name|Department ID|Salary|Gender|Supervisor IS ");
                            List<Employee> newList6 = genderList.Cast<Employee>().ToList();
                            if (newList6.LongCount() == 0)
                            {
                                Console.WriteLine("There are no items to show");
                            }
                            int counterG = 1;
                            foreach (Employee e in newList6)
                            {
                                Console.WriteLine(+counterG + ".  " + e.TeudatZehute.ToString() + " | " + e.FirstName + " | " + e.LastName + " | " + e.DepartmentID.ToString() + " | " + e.Salary.ToString() + " | " + e.Gender.ToString() + " | " + e.SupervisorID.ToString());         // print the list on the screen
                                counterG++;
                            }
                            subMenu whatNext6 = new subMenu(itsBL);
                            whatNext6.Menu("5", counterG, genderList);

                            break;

                        case "7":
                            Console.Clear();
                            Console.WriteLine("Enter the supervisor ID you want to find (notice! must be numbers):  ");
                            string eSuper = Console.ReadLine();
                                while (!(InputCheck.isInt(eSuper)))
                            {
                                Console.WriteLine("Invalid supervisor ID. \n try again");
                                eSuper = Console.ReadLine();
                            }
                            List<object> superList = itsBL.queryByString(Classes.Employee, stringFields.supervisorID, eSuper);
                            Console.Clear();
                            Console.WriteLine("row. teudat Zehute|First Name|Last Name|Department ID|Salary|Gender|Supervisor IS ");
                            List<Employee> newList7 = superList.Cast<Employee>().ToList();
                            if (newList7.LongCount() == 0)
                            {
                                Console.WriteLine("There are no items to show");
                            }
                            int counterV = 1;
                            foreach (Employee e in newList7)
                            {
                                Console.WriteLine(+counterV + ".  " + e.TeudatZehute.ToString() + " | " + e.FirstName + " | " + e.LastName + " | " + e.DepartmentID.ToString() + " | " + e.Salary.ToString() + " | " + e.Gender.ToString() + " | " + e.SupervisorID.ToString());         // print the list on the screen
                                counterV++;
                            }
                            subMenu whatNext7 = new subMenu(itsBL);
                            whatNext7.Menu("5", counterV, superList);

                            break;

                        case "8":
                            List<Employee> newList8 = itsBL.getAllEmployees().Employeess;
                            Console.Clear();
                            Console.WriteLine("row. teudat Zehute|First Name|Last Name|Department ID|Salary|Gender|Supervisor IS ");
                            if (newList8.LongCount() == 0)
                            {
                                Console.WriteLine("There are no items to show");
                            }
                            int counterA= 1;
                            foreach (Employee e in newList8)
                            {
                                Console.WriteLine(+counterA + ".  " + e.TeudatZehute.ToString() + " | " + e.FirstName + " | " + e.LastName + " | " + e.DepartmentID.ToString() + " | " + e.Salary.ToString() + " | " + e.Gender.ToString() + " | " + e.SupervisorID.ToString());         // print the list on the screen
                                counterA++;
                            }
                            List<object> allList = newList8.Cast<object>().ToList();
                            subMenu whatNext8 = new subMenu(itsBL);
                            whatNext8.Menu("5", counterA, allList);
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
        }
    }

