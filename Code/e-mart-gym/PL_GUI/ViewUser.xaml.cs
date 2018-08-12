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
    /// Interaction logic for ViewUser.xaml
    /// </summary>
    public partial class ViewUser : UserControl
    {
        private IBL itsBL;
        List<object> wentedList;
        private string nfield;
        private string toFind;
        private User isUse;

        public ViewUser(IBL BL, User user)
        {
            this.isUse = user; 
            this.itsBL = BL;
            InitializeComponent();
        }

        private void allUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<User> newList8 = itsBL.getAllUsers().Userss;
                List<object> allList = newList8.Cast<object>().ToList();
                ShowTable(allList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void searchBy_Click(object sender, RoutedEventArgs e)
        {
            tableShow.Children.Clear();
            ContextMenu cm = this.FindResource("search") as ContextMenu;
            cm.PlacementTarget = sender as Button;
            cm.IsOpen = true;
        }


        private void sUN_Click(object sender, RoutedEventArgs e)
        {
            stringPanel.Visibility = System.Windows.Visibility.Visible;
            nfield = "fUn";
        }

        private void stringSearch_Click(object sender, RoutedEventArgs e)
        {
            toFind = toSearch.Text;
            CreateList(toFind);
        }

        private void CreateList(string textToFind)
        {
            try
            {
                if (nfield == "fUn") { wentedList = itsBL.queryByString(Classes.User, stringFields.userName, textToFind); }

                if (wentedList == null)
                {
                    MessageBox.Show("there are no items to show");
                }
                else
                {
                    ShowTable(wentedList);
                    stringPanel.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ShowTable(List<object> table)
        {
            if (table == null || table.Count == 0)
            {
                MessageBox.Show("there are no items to show");
            }
            else
            {
                tableShow.Children.Clear();
                UserT showUser = new UserT(itsBL, table, isUse);
                tableShow.Children.Add(showUser);
            }

        }

    }
}
