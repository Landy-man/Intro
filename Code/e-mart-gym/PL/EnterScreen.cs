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
    public class EnterScreen
    {
        private IBL itsBL;
        public EnterScreen(IBL BL)
        {
            this.itsBL = BL;
        }

        public EnterScreen()
        { }


        public void enterScreenRun()                                // log in 
        {
            Console.Clear();
            Console.WriteLine("welcome to Emart - ");
            Console.Write("Plase enter username: ");
            string username = Console.ReadLine();                   // get the user username
            Console.Write("password: ");
            string password = Console.ReadLine();                   // get the user passowrd
            User user = new User();
            bool ans;
            try
            {
                 user = new User(username, password);
                 ans = itsBL.doesFileExist();                        // checks if this is the first use of the system
                 if (ans) 
                 { 
                     itsBL.loadDataFromFile();
                     most(user); 
                 }
                 else {first(user); }

            }
            catch (Exception e)
            { print(e.ToString(), "ERROR: ");
            Console.ReadKey();
            enterScreenRun(); 
            }
        }
       
                    

            public void most(User user)                                               // its not the first time 
            {
                
                if (itsBL.isUserOk(user))                     //  the username and password that the user submit are recognize in the system 
                {
                    MainMenu moveToMenu = new MainMenu(itsBL);                   // successfully entered to the system.  move to the next screen- the main menu
                    PL_CLI tmp1 = new PL_CLI(itsBL);
                    tmp1.addStuff();
                }
                else 
                {
                    Console.Clear();
                    Console.WriteLine("The username or password is incorrect, please try again: ");
                    Console.Write("username: ");
                    string  username = Console.ReadLine();                   // get the user username
                   Console.Write("password: ");
                   string password = Console.ReadLine();                   // get the user passowrd
                   try{ 
                    user = new User(username, password);
                    most (user);
                   }
                    catch (Exception e)
                    { print(e.Message, "ERROR: ");
                      Console.ReadKey();
                      User tmp = new User();
                      most(tmp); 
                    }
                 }
            }

            private void first(User user)                                // it is the first enter to the system 
                {
                       if ( itsBL.isUserAdmin(user))                        // there exists only one username and password with which you can enter the system.
                       {
                           PL_CLI tmp1 = new PL_CLI(itsBL);
                           tmp1.addStuff(); 
                           MainMenu moveToMenu = new MainMenu(itsBL);                   //entered to the system, move to main menu                   

                       }
                       else
                       {
                           Console.Clear();
                           Console.WriteLine("The username or password is incorrect, please try again: ");
                           Console.Write("username: ");
                           string  username = Console.ReadLine();                   // get the user username
                           Console.Write("password: ");
                           string password = Console.ReadLine();                   // get the user passowrd
                           try
                           { 
                            user = new User(username, password);
                            first (user);
                           }
                            catch (Exception e)
                            { print(e.Message, "ERROR: ");
                              Console.ReadKey();
                              User tmp = new User();
                              first(tmp); 
                            }
                          }
                       }

            private void print(object toPrint, string text)
            {
                Console.WriteLine(text + toPrint.ToString());

            }  
        
         }
   }
   

