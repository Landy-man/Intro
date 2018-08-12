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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
             private IBL itsBL;
             private User user;

        public Register(IBL BL)
        {
            this.itsBL = BL;
            InitializeComponent();   
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string passwordTmp = newPassword.Password;
            string usernameTmp = newUsername.Text;
            if (itsBL.doesFileExist())
            {
                itsBL.loadDataFromFile();
            }
            else
            {
                MessageBox.Show("Sorry there is no data for you to browse from, Be paticent");
                MessageBox.Show("Winter is coming!!!");
                MessageBox.Show("For The Night Is Dark And Full Of Terror's");
                MessageBox.Show("It Will Be Worth It, E-Mart Always Pay's Its Debts!");
                return;
            }
            try
            {
                user = new User(usernameTmp, passwordTmp);
                MessageBox.Show(user.UserName + " welcom to Emart!");
                //MainScreen enter = new MainScreen(itsBL);
                itsBL.add(user);
                itsBL.saveDataToFile();
                MainMenu enter = new MainMenu(itsBL,user);
                this.Close();
               enter.Show(); 

                // move to main menu screen wuth רמה 4 - לקוח
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            EnterScreen enterBack = new EnterScreen(itsBL);
            enterBack.Show();
            this.Close();
        }
    }
}
