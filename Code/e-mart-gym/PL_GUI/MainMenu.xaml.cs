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
using Backend2;
using E_Mart_GYM;

namespace PL_GUI
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        private IBL itsBL;
        private User isUse;
        private Receipt receipt = new Receipt();

        public MainMenu(IBL BL, User user)
        {
            this.isUse = user;
            this.itsBL = BL;
            InitializeComponent();
            clearBtnFromScreen(isUse.Hierarchy);
            if (isUse.UserName.Equals("Admin")) this.details.Visibility = Visibility.Collapsed;
            //if (user.UserName == "Admin")
            //{
            //    ViewEmployee employeeToShow = new ViewEmployee(itsBL);
            //    employeeToShow.add.BringIntoView();
            //}
        }


        private void Details_Click(object sender, RoutedEventArgs e)
        {
            //ProgressBarUI pbui = new ProgressBarUI();
            //chengeScreen.Children.Clear();
            //chengeScreen.Children.Add(pbui);
    
            itsBL.clearReceipt(receipt);
            Profile aboutMe = new Profile(itsBL, isUse);
            chengeScreen.Children.Clear();
            chengeScreen.Children.Add(aboutMe);

        }

        private void Employee_Click(object sender, RoutedEventArgs e)
        {
            itsBL.clearReceipt(receipt);
            ViewEmployee employeeToShow = new ViewEmployee(itsBL, isUse);
            chengeScreen.Children.Clear();
            chengeScreen.Children.Add(employeeToShow);
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            itsBL.clearReceipt(receipt);
            ViewProduct productToShow = new ViewProduct(itsBL, isUse);
            chengeScreen.Children.Clear();
            chengeScreen.Children.Add(productToShow);
        }

        private void department_Click(object sender, RoutedEventArgs e)
        {
            itsBL.clearReceipt(receipt);
            ViewDepartment departmentToShow = new ViewDepartment(itsBL, isUse);
            chengeScreen.Children.Clear();
            chengeScreen.Children.Add(departmentToShow);
        }

        private void custemers_Click(object sender, RoutedEventArgs e)
        {
            itsBL.clearReceipt(receipt);

        }

        private void clubMembers_Click(object sender, RoutedEventArgs e)
        {
            itsBL.clearReceipt(receipt);
            ViewClubMember clubMemberToShow = new ViewClubMember(itsBL, isUse);
            chengeScreen.Children.Clear();
            chengeScreen.Children.Add(clubMemberToShow);
        }

        private void transaction_Click(object sender, RoutedEventArgs e)
        {
            itsBL.clearReceipt(receipt);
            ViewTransection transectionToShow = new ViewTransection(itsBL, isUse);
            chengeScreen.Children.Clear();
            chengeScreen.Children.Add(transectionToShow);
        }

        private void user_Click(object sender, RoutedEventArgs e)
        {
            itsBL.clearReceipt(receipt);
            ViewUser userToShow = new ViewUser(itsBL, isUse);
            chengeScreen.Children.Clear();
            chengeScreen.Children.Add(userToShow);
        }


        private void Shop_Click(object sender, RoutedEventArgs e)
        {
            ProgressBarUI psbu = new ProgressBarUI();
            psbu.Show();
            psbu.actionbtn_Click(sender, e);
            while (!psbu.isComplete())
            {

            }
            itsBL.clearReceipt(receipt);
            receipt = new Receipt();
            List<Product> listP = itsBL.queryByString(Classes.Product, stringFields.inStock, "True").Cast<Product>().ToList();
            ViewShopDnD shopToShow = new ViewShopDnD(itsBL, listP, receipt,isUse,this);
            chengeScreen.Children.Clear();
            chengeScreen.Children.Add(shopToShow);
        }

        public void clearReciept()
        {
            this.receipt = new Receipt();
        }

        private void clearBtnFromScreen(Hierarchy hierarchy)
        {

            if (hierarchy == Hierarchy.Customer)
            {
                employees.Visibility = Visibility.Collapsed;
                clubMembers.Visibility = Visibility.Collapsed;
                transaction.Visibility = Visibility.Collapsed;
                department.Visibility = Visibility.Collapsed;
                user.Visibility = Visibility.Collapsed;

                products.Visibility = Visibility.Collapsed;

            }

            if (hierarchy == Hierarchy.Clubmember)
            {
                employees.Visibility = Visibility.Collapsed;
                clubMembers.Visibility = Visibility.Collapsed;
                transaction.Visibility = Visibility.Collapsed;
                department.Visibility = Visibility.Collapsed;
                user.Visibility = Visibility.Collapsed;
                products.Visibility = Visibility.Collapsed;


            }

            if (hierarchy == Hierarchy.Worker)
            {
                employees.Visibility = Visibility.Collapsed;
                department.Visibility = Visibility.Collapsed;
                user.Visibility = Visibility.Collapsed;
                products.Visibility = Visibility.Collapsed;
            }
            if (hierarchy == Hierarchy.Manager)
            {

            }
            if (hierarchy == Hierarchy.Adminstor)
            {

            }

        }


        private void beClub_Click(object sender, RoutedEventArgs e)
        {
            ProgressBarUI psbu = new ProgressBarUI();
            psbu.Show();
            psbu.actionbtn_Click(sender, e);
            while (!psbu.isComplete())
            {

            }
            itsBL.clearReceipt(receipt);
            AddClubMember join = new AddClubMember(itsBL, isUse);
            chengeScreen.Children.Clear();
            chengeScreen.Children.Add(join);

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                itsBL.saveDataToFile();
                MessageBox.Show("successfully asved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void logOut_Click(object sender, RoutedEventArgs e)
        {
            EnterScreen newEnter = new EnterScreen(itsBL);
            newEnter.Show();
            this.Close();

        }

    }
}
