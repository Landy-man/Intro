using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BL;
using Backend;

namespace PL_GUI
{
    /// <summary>
    /// Interaction logic for EnterScreen.xaml
    /// </summary>
    public partial class EnterScreen : Window
    {
        private IBL itsBL;
        private int index = 0; 

        public EnterScreen(IBL BL)
        {
            InitializeComponent();
            this.itsBL = BL;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {

            string passwordTmp = password.Password;
            string usernameTmp = userName.Text;
            bool ans;
            try
            {
               User tempUser = new User(usernameTmp, passwordTmp);
               User user;


                ans = itsBL.doesFileExist();

                if (ans)
                {
                    itsBL.loadDataFromFile();
                    user = itsBL.isUserOk(tempUser);

                    if(user == null)
                    {

                        user = itsBL.isUserAdmin(tempUser);
                        if (usernameTmp == "Admin")
                            user.Hierarchy = Hierarchy.Adminstor;

                    }
                    
                    if (user!=null)
                    {
                        MainMenu enter = new MainMenu(itsBL, user);
                        if (usernameTmp == "Admin")
                        {
                            user.Hierarchy = Hierarchy.Adminstor;
                            AddEmployee addFirstEmployee = new AddEmployee(itsBL,user);
                            enter.chengeScreen.Children.Add(addFirstEmployee);
                        }
                        this.Close();
                        enter.Show();
                    }
                    else
                    {
                        throw new Exception("Username or password are incorrect");
                    }
                }
                else
                {
                    user = itsBL.isUserAdmin(tempUser);

                    if (user!=null)
                    {
                        if (usernameTmp == "Admin")
                            user.Hierarchy = Hierarchy.Adminstor;
                        MainMenu enter = new MainMenu(itsBL, user);
                        AddEmployee addFirstEmployee = new AddEmployee(itsBL,user);
                        this.Close();
                        enter.chengeScreen.Children.Add(addFirstEmployee);
                        enter.Show();
                       
                        
                    }
                }
                // להוסיף פונקציה שמבחינה בין רמות שונות 

            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message);
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Register signIn = new Register(itsBL);
            this.Close();
            signIn.Show();
        }

        private void guest_Click(object sender, RoutedEventArgs e)
        {
            index = index + 1;
            string ind = Convert.ToString(index);
            string name = "guest" + ind;
            try
            {
                User tmpuser = new User(name, "7645983");
                MainMenu enter = new MainMenu(itsBL, tmpuser);
                this.Close();
                enter.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
