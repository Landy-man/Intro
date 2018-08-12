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
    public class SearchClubMember
    {

        private IBL itsBL;

        public SearchClubMember(IBL BL)
        {
            this.itsBL = BL;
       
            string cmd;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("search club member by :");
                Console.WriteLine("\t1. his teudat Zehute ");
                Console.WriteLine("\t2. his first name ");
                Console.WriteLine("\t3. his last name ");
                Console.WriteLine("\t4. member ID ");
                Console.WriteLine("\t5. date of birth ");
                Console.WriteLine("\t6. gender ");
                Console.WriteLine("\t7. gat all clab members"); 
                Console.WriteLine("\t8. back ");
                Console.WriteLine("\t9. back to main menu ");

                cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Enter the teudat Zehute you want to find: (notice! must by numbers) ");
                        string cTZ = Console.ReadLine();
                        while (!(InputCheck.isInt(cTZ)))
                        {
                            Console.WriteLine("Invalid teudat zehute. entar again");
                            cTZ = Console.ReadLine();
                        }
                        List<object> tehudotList = itsBL.queryByString(Classes.ClubMember, stringFields.teudatZehute, cTZ);
                        Console.Clear();
                        Console.WriteLine("row. teudat Zehute|First Name|Last Name|Member ID|Date Of Birth|Gender  ");
                        List<ClubMember> newList1 = tehudotList.Cast<ClubMember>().ToList();
                        if (newList1.LongCount() == 0)
                        {
                            Console.WriteLine("There are no items to show");
                        }
                        int counterT = 1;
                        foreach (ClubMember c in newList1)
                        {
                            Console.WriteLine(+counterT + ".  " + c.TeudatZehute.ToString() + " | " + c.FirstName + " | " + c.LastName + " | " + c.MemberID.ToString() + " | " + c.Date_of_birth.ToString() + " | " + c.Gender.ToString() );         // print the list on the screen
                            counterT++;
                        }
                        subMenu whatNext1 = new subMenu(itsBL);
                        whatNext1.Menu("4", counterT, tehudotList);

                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Enter the first name you want to find: ");
                        string cFirst = Console.ReadLine();
                        List<object> firstList = itsBL.queryByString(Classes.ClubMember, stringFields.firstName, cFirst);
                        Console.Clear();
                        Console.WriteLine("row. teudat Zehute|First Name|Last Name|Member ID|Date Of Birth|Gender  ");
                        List<ClubMember> newList2 = firstList.Cast<ClubMember>().ToList();
                        if (newList2.LongCount() == 0)
                        {
                            Console.WriteLine("There are no items to show");
                        }
                        int counterF = 1;
                        foreach (ClubMember c in newList2)
                        {
                            Console.WriteLine(+counterF + ".  " + c.TeudatZehute.ToString() + " | " + c.FirstName + " | " + c.LastName + " | " + c.MemberID.ToString() + " | " + c.Date_of_birth.ToString() + " | " + c.Gender.ToString());         // print the list on the screen
                            counterF++;
                        }
                        subMenu whatNext2 = new subMenu(itsBL);
                        whatNext2.Menu("4", counterF, firstList);

                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Enter the last name you want to find: ");
                        string clast = Console.ReadLine();
                        List<object> lastList = itsBL.queryByString(Classes.ClubMember, stringFields.lastName, clast);
                        Console.Clear();
                        Console.WriteLine("row. teudat Zehute|First Name|Last Name|Member ID|Date Of Birth|Gender  ");
                        List<ClubMember> newList3 = lastList.Cast<ClubMember>().ToList();
                        if (newList3.LongCount() == 0)
                        {
                            Console.WriteLine("There are no items to show");
                        }
                        int counterL = 1;
                        foreach (ClubMember c in newList3)
                        {
                            Console.WriteLine(+counterL + ".  " + c.TeudatZehute.ToString() + " | " + c.FirstName + " | " + c.LastName + " | " + c.MemberID.ToString() + " | " + c.Date_of_birth.ToString() + " | " + c.Gender.ToString());         // print the list on the screen
                            counterL++;
                        }
                        subMenu whatNext3 = new subMenu(itsBL);
                        whatNext3.Menu("4", counterL, lastList);

                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("Enter the member ID you want to find: ");
                        string cMember = Console.ReadLine();
                        while (!(InputCheck.isInt(cMember)))
                        {
                            Console.WriteLine("Invalid member ID. \n entar again");
                            cMember = Console.ReadLine();
                        }
                        List<object> membIDList = itsBL.queryByString(Classes.ClubMember, stringFields.memberID, cMember);
                        Console.Clear();
                        Console.WriteLine("row. teudat Zehute|First Name|Last Name|Member ID|Date Of Birth|Gender  ");
                        List<ClubMember> newList4 = membIDList.Cast<ClubMember>().ToList();
                        if (newList4.LongCount() == 0)
                        {
                            Console.WriteLine("There are no items to show");
                        }
                        int counterM = 1;
                        foreach (ClubMember c in newList4)
                        {
                            Console.WriteLine(+counterM + ".  " + c.TeudatZehute.ToString() + " | " + c.FirstName + " | " + c.LastName + " | " + c.MemberID.ToString() + " | " + c.Date_of_birth.ToString() + " | " + c.Gender.ToString());         // print the list on the screen
                            counterM++;
                        }
                        subMenu whatNext4 = new subMenu(itsBL);
                        whatNext4.Menu("4", counterM, membIDList);

                        break;

                    case "5":
                        Console.Clear();
                         Console.WriteLine("Choose an option: ");
                            Console.WriteLine("\t1. Search for specific date of birth ");
                            Console.WriteLine("\t2. Search range of dates of birth ");
                            string search = Console.ReadLine();
                            string fromValue = DateTime.MinValue.ToString() ;
                            string toValue = DateTime.MaxValue.ToString() ;
                            bool ans = false;
                            while(!ans)
                            {
                                switch (search)
                                    {
                                        case "1":
                                            Console.WriteLine("enter the date: ");
                                            Console.Write("Year: ");
                                            string year = Console.ReadLine();
                                            Console.Write("Month: (notice! enter number between 01-12) ");
                                            string month = Console.ReadLine();
                                            Console.Write("Day: (notice! enter number between 01-31)" );
                                            string day = Console.ReadLine();
                                            fromValue = (day + "/" + month + "/" + year);
                                            toValue = (day + "/" + month + "/" + year);

                                            break;

                                        case "2":
                                            Console.WriteLine("enter from which data of birth to search: ");
                                            Console.Write("Year: ");
                                            string fromYear = Console.ReadLine();
                                            Console.Write("Month: ");
                                            string fromMonth = Console.ReadLine();
                                            Console.Write("Day: ");
                                            string fromDay = Console.ReadLine();
                                            fromValue = (fromDay + "/" + fromMonth + "/" + fromYear);

                                            Console.WriteLine("enter until which data of birth to search: ");
                                            Console.Write("Year: ");
                                            string toYear = Console.ReadLine();
                                            Console.Write("Month: ");
                                            string toMonth = Console.ReadLine();
                                            Console.Write("Day: ");
                                            string toDay = Console.ReadLine();
                                            toValue = (toDay + "/" + toMonth + "/" + toYear);

                                            break;

                                        default:
                                            Console.WriteLine("You perform illegal move, please choose 1 or 2");
                                            Thread.Sleep(2400);
                                            break; 
                                    }
                                try
                                {
                                bool ans1 = InputCheck.isDateTime(fromValue);
                                bool ans2 = InputCheck.isDateTime(toValue);
                                ans = ans1 || ans2;
                                }
                                catch (Exception e)
                                {
                                    print(e.Message, "\n ERROR: ");                       // inform the user
                                    Console.ReadKey();
                                }

                             }
                            List<object> birthList = itsBL.queryByRange(Classes.ClubMember, rangeFields.date_of_birth, fromValue, toValue);
                        Console.Clear();
                        Console.WriteLine("row. teudat Zehute|First Name|Last Name|Member ID|Date Of Birth|Gender  ");
                        List<ClubMember> newList5 = birthList.Cast<ClubMember>().ToList();
                        if (newList5.LongCount()== 0)
                        {
                            Console.WriteLine("There are no items to show");
                        }
                        int counterB = 1;
                        foreach (ClubMember c in newList5)
                        {
                            Console.WriteLine(+counterB + ".  " + c.TeudatZehute.ToString() + " | " + c.FirstName + " | " + c.LastName + " | " + c.MemberID.ToString() + " | " + c.Date_of_birth.ToString() + " | " + c.Gender.ToString());         // print the list on the screen
                            counterB++;
                        }
                        subMenu whatNext5 = new subMenu(itsBL);
                        whatNext5.Menu("4", counterB, birthList);
                        break;

                    case "6":
                        Console.Clear();
                        Console.WriteLine("Enter the gender you want to find:  ");
                        Console.WriteLine("\t1. Male");
                        Console.WriteLine("\t2. Female");
                        string cho = Console.ReadLine(); 
                        string cGender="null";
                        bool gend = true;
                        while (gend)
                        {
                            if (cho == "1") { cGender = "Male"; gend = false; }
                            else if (cho == "2") { cGender = "Female"; gend = false; }
                            else 
                            {
                             Console.WriteLine("choose 1 Or 2 only");
                             cho = Console.ReadLine();
                            }
                        }
                        List<object> genderList = itsBL.queryByString(Classes.ClubMember, stringFields.gender, cGender);
                        Console.Clear();
                        Console.WriteLine("row. teudat Zehute|First Name|Last Name|Member ID|Date Of Birth|Gender  ");
                        List<ClubMember> newList6 = genderList.Cast<ClubMember>().ToList();
                        if (newList6.LongCount() == 0)
                        {
                            Console.WriteLine("There are no items to show");
                        }
                        int counterG = 1;
                        foreach (ClubMember c in newList6)
                        {
                            Console.WriteLine(+counterG + ".  " + c.TeudatZehute.ToString() + " | " + c.FirstName + " | " + c.LastName + " | " + c.MemberID.ToString() + " | " + c.Date_of_birth.ToString() + " | " + c.Gender.ToString());         // print the list on the screen
                            counterG++;
                        }
                        subMenu whatNext6 = new subMenu(itsBL);
                        whatNext6.Menu("4", counterG, genderList);

                        break;

                    case "7":
                        Console.Clear();
                        List<ClubMember> newList7 = itsBL.getAllClubMembers().ClubMemberss;
                        Console.Clear();
                        Console.WriteLine("row. teudat Zehute|First Name|Last Name|Member ID|Date Of Birth|Gender  ");
                         if (newList7.LongCount() == 0)
                        {
                            Console.WriteLine("There are no items to show");
                        }
                        int counterA = 1;
                        foreach (ClubMember c in newList7)
                        {
                            Console.WriteLine(+counterA + ".  " + c.TeudatZehute.ToString() + " | " + c.FirstName + " | " + c.LastName + " | " + c.MemberID.ToString() + " | " + c.Date_of_birth.ToString() + " | " + c.Gender.ToString());         // print the list on the screen
                            counterA++;
                        }
                        List<object> allList = newList7.Cast<object>().ToList();
                        subMenu whatNext7 = new subMenu(itsBL);
                        whatNext7.Menu("4", counterA, allList);
                        break;

                    case "8":
                            Search back = new Search(itsBL);
                            back.run();
                            break;

                    case "9":
                        MainMenu moveToMenu = new MainMenu(itsBL);
                        break;

                    default:
                        Console.WriteLine("You have performed an illegal move, please enter a number between 1-9");
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
