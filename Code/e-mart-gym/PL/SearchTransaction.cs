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
    class SearchTransaction
    {
        private IBL itsBL;
        public SearchTransaction(IBL BL)
        {
            this.itsBL = BL;
            
            string cmd;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("search transaction by :");
                Console.WriteLine("\t1. transaction ID ");
                Console.WriteLine("\t2. date time ");
                Console.WriteLine("\t3. is a return ");
                Console.WriteLine("\t4. payment method ");
                Console.WriteLine("\t5. gat all transaction ");
                Console.WriteLine("\t6. back ");
                Console.WriteLine("\t7. back to main menu ");

                cmd = Console.ReadLine();

                    switch (cmd)
                    {
                        case "1":
                            Console.WriteLine("Enter the ID you want to search (notice! must be numbers): ");
                            string tID = Console.ReadLine();
                            while (!(InputCheck.isInt(tID)))
                            {
                                Console.WriteLine("Invalid ID. \n try again");
                                tID = Console.ReadLine();
                            }
                            List<object> tIDList = itsBL.queryByString(Classes.Transaction, stringFields.transactionID, tID);
                            Console.Clear();
                            Console.WriteLine("row. Transaction ID|Transaction Date Time|Is a Return|Payment Method");
                            List<Transaction> newList1 = tIDList.Cast<Transaction>().ToList();
                            if (newList1.LongCount() == 0)
                            {
                                Console.WriteLine("There are no items to show");
                            }
                            int counterI = 1;
                            foreach (Transaction t in newList1)
                            {
                                Console.WriteLine(counterI + ".  " + t.TransactionID.ToString() + " | " + t.DateTime.ToString() + " | " + t.Is_a_return.ToString() + " | " + t.PaymentMethod.ToString());         // print the list on the screen
                                counterI++;
                            }
                            subMenu whatNext1 = new subMenu(itsBL);
                            whatNext1.Menu("3", counterI, tIDList);

                            break; 

                        case "2":
                            Console.WriteLine("Choose an option: ");
                            Console.WriteLine("\t1. Search for specific date ");
                            Console.WriteLine("\t2. Search range of dates ");
                            string search = Console.ReadLine();
                            string fromValue=DateTime.MinValue.ToString();
                            string toValue = DateTime.MaxValue.ToString();
                            bool ans = false;
                            while (!ans)
                            {
                                switch (search)
                                {
                                    case "1":
                                        Console.WriteLine("enter the date: ");
                                        Console.Write("Year: ");
                                        string year = Console.ReadLine();
                                        Console.Write("Month: ");
                                        string month = Console.ReadLine();
                                        Console.Write("Day: ");
                                        string day = Console.ReadLine();
                                        fromValue = (day + "/" + month + "/" + year);
                                        toValue = (day + "/" + month + "/" + year);

                                        break;

                                    case "2":
                                        Console.WriteLine("enter from when to search: ");
                                        Console.Write("Year: ");
                                        string fromYear = Console.ReadLine();
                                        Console.Write("Month: ");
                                        string fromMonth = Console.ReadLine();
                                        Console.Write("Day: ");
                                        string fromDay = Console.ReadLine();
                                        fromValue = (fromDay + "/" + fromMonth + "/" + fromYear);

                                        Console.WriteLine("enter until when to search: ");
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
                             
                            List<object> dateList = itsBL.queryByRange(Classes.Transaction, rangeFields.dateTime, fromValue, toValue) ;
                            Console.Clear();
                            Console.WriteLine("row. Transaction ID|Transaction Date Time|Is a Return|Payment Method");
                            List<Transaction> newList2 = dateList.Cast<Transaction>().ToList();
                            if (newList2.LongCount() == 0)
                            {
                                Console.WriteLine("There are no items to show");
                            }
                            int counterD = 1;
                            foreach (Transaction t in newList2)
                            {
                                Console.WriteLine(counterD + ".  " + t.TransactionID.ToString() + " | " + t.DateTime.ToString() + " | " + t.Is_a_return.ToString() + " | " + t.PaymentMethod.ToString());         // print the list on the screen
                                counterD++;
                            }
                            subMenu whatNext2 = new subMenu(itsBL);
                            whatNext2.Menu("3", counterD, dateList);

                            break;

                        case "3":
                            Console.WriteLine("choose an option: ");
                            Console.WriteLine("\t1. show all the transaction that returned ");
                            Console.WriteLine("\t2. show all the transaction that didn't reurn ");
                            string tReturn = Console.ReadLine();
                            string tIsReturn="";   
                                switch (tReturn)
                                {
                                    case "1":
                                        tIsReturn = "true";
                                        break;
                                    case "2":
                                        tIsReturn = "false";
                                        break;
                                    default:
                                        Console.WriteLine("You have performed an illegal move, please enter 1 or 2");
                                        Thread.Sleep(2400);
                                        break;
                                }  
                            List<object> isReturnList = itsBL.queryByString(Classes.Transaction, stringFields.is_A_Return, tIsReturn);
                            Console.Clear();
                            Console.WriteLine("row. Transaction ID|Transaction Date Time|Is a Return|Payment Method");
                            List<Transaction>newList3 = isReturnList.Cast<Transaction>().ToList();
                            if (newList3.LongCount() == 0)
                            {
                                Console.WriteLine("There are no items to show");
                            }
                            int counterR = 1;
                            foreach (Transaction t in newList3)
                            {
                                Console.WriteLine(counterR + ".  " + t.TransactionID.ToString() + " | " + t.DateTime.ToString() + " | " + t.Is_a_return.ToString() + " | " + t.PaymentMethod.ToString());         // print the list on the screenn
                                counterR++;
                            }
                            subMenu whatNext3 = new subMenu(itsBL);
                            whatNext3.Menu("3", counterR, isReturnList);

                            break; 

                        case "4":
                            Console.WriteLine("Choose the number of the payment method that you want to search by:  ");
                            Console.WriteLine("\t1. Cash \n\t 2. Credit \n\t 3. Check  ");
                            string tPay = Console.ReadLine();
                            string tPayment="";
                                switch (tPay)
                                {
                                    case "1":
                                        tPayment = "Cash";
                                        break;
                                    case "2":
                                        tPayment = "Credit";
                                        break;
                                    case "3":
                                        tPayment = "Check";
                                        break;
                                    default:
                                        Console.WriteLine("You have to choose number between 1 to 3");
                                        Thread.Sleep(2400);
                                        break;
                                }
                            List<object> paymentList = itsBL.queryByString(Classes.Transaction, stringFields.paymentMethod, tPayment);
                            Console.Clear();
                            Console.WriteLine("row. Transaction ID|Transaction Date Time|Is a Return|Payment Method");
                            List<Transaction> newList4 = paymentList.Cast<Transaction>().ToList();
                            if (newList4.LongCount() == 0)
                            {
                                Console.WriteLine("There are no items to show");
                            }
                            int counterP = 1;
                            foreach (Transaction t in newList4)
                            {
                                Console.WriteLine(counterP + ".  " + t.TransactionID.ToString() + " | " + t.DateTime.ToString() + " | " + t.Is_a_return.ToString() + " | " + t.PaymentMethod.ToString());         // print the list on the screen
                                counterP++;
                            }
                            subMenu whatNext4 = new subMenu(itsBL);
                            whatNext4.Menu("3", counterP, paymentList);

                            break;

                        case "5":
                            List<Transaction> newList5 = itsBL.getAllTransaction().Transactionss;
                            Console.Clear();
                            Console.WriteLine("row. Transaction ID|Transaction Date Time|Is a Return|Payment Method");
                            if (newList5.LongCount() == 0)
                            {
                                Console.WriteLine("There are no items to show");
                            }
                            int counterA = 1;
                            foreach (Transaction t in newList5)
                            {
                                Console.WriteLine(counterA + ".  " + t.TransactionID.ToString() + " | " + t.DateTime.ToString() + " | " + t.Is_a_return.ToString() + " | " + t.PaymentMethod.ToString());         // print the list on the screen
                                counterA++;
                            }
                            List<object> allList = newList5.Cast<object>().ToList();
                            subMenu whatNext5 = new subMenu(itsBL);
                            whatNext5.Menu("3", counterA, allList);
                            break;

                        case "6":
                            Search back = new Search(itsBL);
                            back.run();
                            break;

                        case "7":
                            MainMenu moveToMenu = new MainMenu(itsBL);
                            break; 

                        default:
                             Console.WriteLine("You have performed an illegal move, please enter a number between 1-7");
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


