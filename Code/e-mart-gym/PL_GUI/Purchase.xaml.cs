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
using Backend;
using BL;

namespace PL_GUI
{
    /// <summary>
    /// Interaction logic for Purchase.xaml
    /// </summary>
    public partial class Purchase : UserControl
    {
        private IBL itsBL;
        private User user;
        private ClubMember clbMember = null;
        private Receipt receipt;
        private Int64 crcNumber = 0;
        private double totleSum=0;
        private PaymentScreen payScreen;


        public Purchase(IBL itsBL,User user,Receipt receipt,double ttlSum,PaymentScreen payScreen)
        {
            InitializeComponent();
            this.payScreen = payScreen;
            this.itsBL = itsBL;
            this.user = user;
            cash.IsChecked = true;
            this.receipt = receipt;
            this.totleSum = ttlSum;
            if (user.Hierarchy==Hierarchy.Clubmember)
            {
                List<ClubMember> temp = itsBL.queryByString(Classes.ClubMember, stringFields.teudatZehute, user.UserName).Cast<ClubMember>().ToList();
                if (temp != null && temp.Count != 0)
                    this.clbMember = temp[0];
            }
            this.recieptGrid.ItemsSource = receipt.Data;


            
            }

        private void credit_Checked(object sender, RoutedEventArgs e)
        {
            oneTimeShop.Visibility = Visibility.Visible;
            if (clbMember != null)
            {
                if (clbMember.CreditCard != null)
                    isMemberWithCRC.Visibility = Visibility.Visible;
            }
        }

        private void isMemberWithCRC_Click(object sender, RoutedEventArgs e)
        {
            this.crcNumber = clbMember.CreditCard.CreditCardd;
            buy_Click(sender, e);

        }



        private void oneTimeShop_Click(object sender, RoutedEventArgs e)
        {
            isMemberWithCRC.Visibility = Visibility.Collapsed;
            onTimeCredit.Visibility = Visibility.Visible;
        }

        private void onTimeCredit_GotFocus(object sender, RoutedEventArgs e)
        {
            onTimeCredit.Text = "";
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.sum.Content = "You total sum is: " + totleSum.ToString();

        }

        private void buy_Click(object sender, RoutedEventArgs e)
        {
            if (credit.IsChecked == true&& crcNumber==0)
            {
                string s = onTimeCredit.Text;
                if (s.Length<16)
                {
                    MessageBox.Show("Your credit card Number must Be 16 digits");
                    return;
                }
                try
                {
                  Transaction t = new Transaction(receipt, "Credit");
                  t.CrcNum = Convert.ToInt64(s);
                  itsBL.add(t);
                  updateStock();
                  if (clbMember != null)
                  {
                      clbMember.addTransactionToHistory(t.TransactionID);
                      itsBL.edit(clbMember);
                  }
                  itsBL.saveDataToFile();
                   
                  this.receipt = new Receipt();
                  this.recieptGrid.ItemsSource = receipt.Data;
                    MessageBox.Show("Transaction has been successful");
                  return;
                }
                catch (Exception)
                {
                MessageBox.Show("Your credit card Number must be a number smartAss");
                return;
                }
           }
            else
            {
                if (credit.IsChecked == true)
                {
                    Transaction t = new Transaction(receipt, "Credit");
                    t.CrcNum = crcNumber;
                    itsBL.add(t);
                    updateStock();
                    if (clbMember != null)
                    {
                        clbMember.addTransactionToHistory(t.TransactionID);
                        itsBL.edit(clbMember);
                    }
                    itsBL.saveDataToFile();
                    this.receipt = new Receipt();
                    MessageBox.Show("Transaction has been successful");
                    return;
                }
                else if (cash.IsChecked==true)
                {
                    {
                        Transaction t = new Transaction(receipt, "Cash");
                        itsBL.add(t);
                        updateStock();
                        if (clbMember != null)
                        {
                            clbMember.addTransactionToHistory(t.TransactionID);
                            itsBL.edit(clbMember);
                        }
                        
                        itsBL.saveDataToFile();
                        this.receipt = new Receipt();
                        this.recieptGrid.ItemsSource = receipt.Data;
                        payScreen.clearReceipt();
                      //  payScreen.receiptDTG
                        MessageBox.Show("Transaction has been successful");
                        return;
                    }

                }
                else if (check.IsChecked==true)
                {
                    {
                        Transaction t = new Transaction(receipt, "Check");
                        itsBL.add(t);
                        updateStock();
                        if (clbMember != null)
                        {
                            clbMember.addTransactionToHistory(t.TransactionID);
                            itsBL.edit(clbMember);
                        }
                        itsBL.saveDataToFile();
                        this.receipt = new Receipt();
                        MessageBox.Show("Transaction has been successful");
                        return;
                    }
                }
            }
        }
        private void updateStock()
        {
            foreach (ProductSale ps in receipt.Data)
            {
              //  ps.PRODUCT.StockCount = ps.PRODUCT.StockCount - ps.Amount;
                //ps.PRODUCT.SoldThisMonth = ps.PRODUCT.SoldThisMonth + ps.Amount;
                //itsBL.edit(ps.PRODUCT);
                //itsBL.saveDataToFile();

            }
        }

        private void check_Checked(object sender, RoutedEventArgs e)
        {
            oneTimeShop.Visibility = Visibility.Collapsed;
            onTimeCredit.Visibility = Visibility.Collapsed;
            isMemberWithCRC.Visibility = Visibility.Collapsed;
            
        }

        private void cash_Checked(object sender, RoutedEventArgs e)
        {
            oneTimeShop.Visibility = Visibility.Collapsed;
            onTimeCredit.Visibility = Visibility.Collapsed;
            isMemberWithCRC.Visibility = Visibility.Collapsed;
        }




    }
}
