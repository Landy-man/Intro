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
    /// Interaction logic for ViewTransection.xaml
    /// </summary>
    public partial class ViewTransection : UserControl
    {
        private IBL itsBL;
        List<object> wentedList;
        private string nfield;
        private string toFind;
        private string fromString;
        private User isUse; 

        public ViewTransection(IBL BL, User user)
        {
            this.itsBL = BL;
            this.isUse = user; 
            InitializeComponent();
        }

        private void allTransection_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                List<Transaction> newList7 = itsBL.getAllTransaction().Transactionss;
                List<object> allList = newList7.Cast<object>().ToList();
                ShowTable(allList);
                stringPanel.Visibility = System.Windows.Visibility.Collapsed;
                rangePanel.Visibility = System.Windows.Visibility.Collapsed;
                DatePanel1.Visibility = System.Windows.Visibility.Collapsed;
                DatePanel2.Visibility = System.Windows.Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void searchBy_Click(object sender, RoutedEventArgs e)
        {
            tableShow.Children.Clear();
            stringPanel.Visibility = System.Windows.Visibility.Collapsed;
            rangePanel.Visibility = System.Windows.Visibility.Collapsed;
            DatePanel1.Visibility = System.Windows.Visibility.Collapsed;
            DatePanel2.Visibility = System.Windows.Visibility.Collapsed;
            ContextMenu cm = this.FindResource("search") as ContextMenu;
            cm.PlacementTarget = sender as Button;
            cm.IsOpen = true;
        }

        private void stringSearch_Click(object sender, RoutedEventArgs e)
        {
            toFind = toSearch.Text;
            CreateList(toFind);
        }

        private void RangeSearch_Click(object sender, RoutedEventArgs e)
        {
            toFind = toSearchR.Text;
            fromString = fromSearchR.Text;
            CreateList(fromString, toFind);
        }

        private void DateSearch_Click(object sender, RoutedEventArgs e)
        {
            toFind = DtoFind.Text;
            fromString = DtoFind.Text;
            CreateList(fromString, toFind);
        }

        private void DateSearch2_Click(object sender, RoutedEventArgs e)
        {
            toFind = DToFind.Text;
            fromString = DFromFind.Text;
            CreateList(fromString, toFind);
        }

        private void sTraID_Click(object sender, RoutedEventArgs e)
        {
            stringPanel.Visibility = System.Windows.Visibility.Visible;
            nfield = "fTid";
        }

        private void sDateOP1_Click(object sender, RoutedEventArgs e)
        {
            DatePanel1.Visibility = System.Windows.Visibility.Visible;
            nfield = "fDop1";
        }

        private void sDateOP2_Click(object sender, RoutedEventArgs e)
        {
            DatePanel1.Visibility = System.Windows.Visibility.Visible;
            nfield = "fDop2";
        }

        private void noRet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wentedList = itsBL.queryByString(Classes.Transaction, stringFields.is_A_Return, "false");
                if (wentedList == null || wentedList.Count == 0)
                {
                    MessageBox.Show("there are no items to show");
                }
                else
                {
                    ShowTable(wentedList);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void yesRet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wentedList = itsBL.queryByString(Classes.Transaction, stringFields.is_A_Return, "true");
                if (wentedList == null || wentedList.Count == 0)
                {
                    MessageBox.Show("there are no items to show");
                }
                else
                {
                    ShowTable(wentedList);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sPCash_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wentedList = itsBL.queryByString(Classes.Transaction, stringFields.paymentMethod, "Cash");
                if (wentedList == null || wentedList.Count == 0)
                {
                    MessageBox.Show("there are no items to show");
                }
                else
                {
                    ShowTable(wentedList);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sPCredit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wentedList = itsBL.queryByString(Classes.Transaction, stringFields.paymentMethod, "Credit");
                if (wentedList == null || wentedList.Count == 0)
                {
                    MessageBox.Show("there are no items to show");
                }
                else
                {
                    ShowTable(wentedList);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sPCheck_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wentedList = itsBL.queryByString(Classes.Transaction, stringFields.paymentMethod, "Check");
                if (wentedList == null || wentedList.Count == 0)
                {
                    MessageBox.Show("there are no items to show");
                }
                else
                {
                    ShowTable(wentedList);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateList(string textToFind)
        {
            try
            {
                if (nfield == "fTid") { wentedList = itsBL.queryByString(Classes.Transaction, stringFields.transactionID, textToFind); }


                if (wentedList == null)
                {
                    MessageBox.Show("there are no items to show");
                }
                else
                {
                    ShowTable(wentedList);
                    stringPanel.Visibility = System.Windows.Visibility.Collapsed;
                    rangePanel.Visibility = System.Windows.Visibility.Collapsed;
                    DatePanel1.Visibility = System.Windows.Visibility.Collapsed;
                    DatePanel2.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void CreateList(string fromToFind, string textToFind)
        {
            try
            {
                if (nfield == "fDop1") { wentedList = itsBL.queryByRange(Classes.Transaction, rangeFields.dateTime, textToFind, textToFind); }
                else if (nfield == "fDop2") { wentedList = itsBL.queryByRange(Classes.Transaction, rangeFields.dateTime, fromToFind, textToFind); }
                if (wentedList == null)
                {
                    MessageBox.Show("there are no items to show");
                }
                else
                {
                    ShowTable(wentedList);
                    stringPanel.Visibility = System.Windows.Visibility.Collapsed;
                    rangePanel.Visibility = System.Windows.Visibility.Collapsed;
                    DatePanel1.Visibility = System.Windows.Visibility.Collapsed;
                    DatePanel2.Visibility = System.Windows.Visibility.Collapsed;
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
                TransectionT showTransection = new TransectionT(itsBL, table, isUse);
                tableShow.Children.Add(showTransection);
            }

        }
    }
}
