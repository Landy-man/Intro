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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL;
using Backend;

namespace PL_GUI
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        private IBL itsBL;
        private User isUse;
        ClubMember isClub;

        public Profile(IBL BL, User user)
        {
            this.itsBL = BL;
            this.isUse = user;
            string nameUser = isUse.UserName;
            InitializeComponent();
            rightSplite.Visibility = System.Windows.Visibility.Collapsed;
            rightSplite2.Visibility = System.Windows.Visibility.Collapsed;
            rightSplite3.Visibility = System.Windows.Visibility.Collapsed;

            if (isUse.Hierarchy == Hierarchy.Clubmember)
            {
                List<object> theUser = itsBL.queryByString(Classes.ClubMember, stringFields.teudatZehute, nameUser);
                isClub = theUser.Cast<ClubMember>().ElementAt(0);
                teudatZ.Text = Convert.ToString(isClub.TeudatZehute);
                firstN.Text = isClub.FirstName;
                lastN.Text = isClub.LastName;
                if (isClub.CreditCard == null)
                {
                    creditAdd.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    creditRemove.Visibility = System.Windows.Visibility.Visible;
                }
            }

            else if (isUse.Hierarchy== Hierarchy.Customer)
            {
                teudatZ.Text = isUse.UserName;
                first.Visibility = System.Windows.Visibility.Collapsed;
                last.Visibility = System.Windows.Visibility.Collapsed;
            }
            else if (isUse.Hierarchy == Hierarchy.Worker || isUse.Hierarchy == Hierarchy.Manager || isUse.Hierarchy == Hierarchy.Adminstor)
            {
                List<object> theUser = itsBL.queryByString(Classes.Employee, stringFields.teudatZehute, nameUser);
               Employee isEmployee = theUser.Cast<Employee>().ElementAt(0);
               teudatZ.Text = Convert.ToString(isEmployee.TeudatZehute);
               firstN.Text = isEmployee.FirstName;
               lastN.Text = isEmployee.LastName;
            }
        }


        private void changePassword_Click(object sender, RoutedEventArgs e)
        {
            rightSplite.Visibility = System.Windows.Visibility.Visible;
            rightSplite2.Visibility = System.Windows.Visibility.Collapsed;
            rightSplite3.Visibility = System.Windows.Visibility.Collapsed;

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
         
            if (oldPassword.Password == isUse.Password)
            {
                string password = newPassword.Password;
                if (password.Length < 4) { MessageBox.Show("Password Must Contain Atleast 4 Characters."); }
                isUse.Password = password;
                try 
                { 
                    itsBL.saveDataToFile(); 
                    MessageBox.Show("saved");
                    rightSplite.Visibility = System.Windows.Visibility.Collapsed; 
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else { MessageBox.Show("password is incorrect"); }
        }



        private void save2_Click(object sender, RoutedEventArgs e)
        {
            string number = creditNumber.Text;
            string cvvNum = cvv.Text;
            DateTime date = (DateTime)calander.SelectedDate;
            try
            {
                if (date == null)
                {
                    throw new Exception("you have to choose expiery date");
                }
                //string[] dataArr = date.Split('/', ' ');
                //string month = dataArr[1];
                //string year = dataArr[2];
                //char[] chYear = year.ToCharArray();
                //string exYear = Convert.ToString(chYear[2]) + Convert.ToString(chYear[3]);

                if (number.Length != 16)
                {
                    throw new Exception("the credit number must contain 16 numbers");
                }
                if (cvvNum.Length != 3)
                {
                    throw new Exception("the CVV number must be  3-digit code");
                }

                isClub.addCreditCard(number, date.Month.ToString(),date.Year.ToString(), cvvNum);
                MessageBox.Show("Successfully saved");
                rightSplite2.Visibility = Visibility.Collapsed; 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }

        }

        private void credit_Click(object sender, RoutedEventArgs e)
        {
            rightSplite2.Visibility = System.Windows.Visibility.Visible;
            rightSplite.Visibility = System.Windows.Visibility.Collapsed;
            rightSplite3.Visibility = System.Windows.Visibility.Collapsed;

        }

        private void creditAdd_Click(object sender, RoutedEventArgs e)
        {
            rightSplite2.Visibility=System.Windows.Visibility.Visible;
            rightSplite.Visibility = System.Windows.Visibility.Collapsed;
            rightSplite3.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void creditRemove_Click(object sender, RoutedEventArgs e)
        {
            rightSplite3.Visibility = System.Windows.Visibility.Visible;
            rightSplite2.Visibility = System.Windows.Visibility.Collapsed;
            rightSplite.Visibility = System.Windows.Visibility.Collapsed;

        }

        private void continue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isClub.CreditCard == null)
                {
                    throw new Exception(isClub.TeudatZehute.ToString() + " has no credis card in our גatabase");
                }
                isClub.removeCreditCard();
                MessageBox.Show("Credit Card remove successfully");
                rightSplite3.Visibility = Visibility.Collapsed; 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            rightSplite3.Visibility = System.Windows.Visibility.Collapsed;
            rightSplite2.Visibility = System.Windows.Visibility.Collapsed;
            rightSplite.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}
