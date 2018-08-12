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
using Backend2;

namespace PL_GUI
{
    /// <summary>
    /// Interaction logic for ViewShopDND.xaml
    /// </summary>
    public partial class ViewShopDnD : UserControl
    {
        private IBL itsBL;
        private List<object> wentedList;
        private string nfield;
        private string toFind;
        private string fromString;
        private List<object> listP;
        private Receipt receipt;
        private User user;
        private MainMenu main;
        

        public ViewShopDnD(IBL BL, List<Product> listP,Receipt receipt,User user,MainMenu main)
        {
            
            this.receipt = receipt;
            this.itsBL = BL;
            this.main = main;
            this.user = user;
            this.listP = listP.Cast<object>().ToList();
            InitializeComponent();
            this.topSeller_label.Visibility = Visibility.Visible;
            this.lbl.Visibility = Visibility.Visible;
            this.topSellerColor.Visibility = Visibility.Visible;
            this.Combox.Visibility = Visibility.Visible;
        }

        public void clearReceipt()
        {
            this.receipt = new Receipt();
            this.main.clearReciept();
        }

        public void reloadData()
        {
            this.listP = itsBL.queryByString(Classes.Product, stringFields.inStock, "True");
        }

        private void allProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.lbl.Visibility = Visibility.Visible;
                this.Combox.Visibility = Visibility.Visible;
                listP = itsBL.queryByString(Classes.Product, stringFields.inStock, "True");
                //List<object> allList = listP;
                ShowTable(listP);
                stringPanel.Visibility = System.Windows.Visibility.Collapsed;
                rangePanel.Visibility = System.Windows.Visibility.Collapsed;
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
            ContextMenu cm = this.FindResource("search") as ContextMenu;
            cm.PlacementTarget = sender as Button;
            cm.IsOpen = true;
        }

        private void sName_Click(object sender, RoutedEventArgs e)
        {
            stringPanel.Visibility = System.Windows.Visibility.Visible;
            nfield = "fName";
        }

        private void sTyElec_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wentedList = itsBL.queryByString(Classes.Product, stringFields.type, "Electronics", listP);
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

        private void sTyFashion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wentedList = itsBL.queryByString(Classes.Product, stringFields.type, "Fashion", listP);
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

        private void sTyFood_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wentedList = itsBL.queryByString(Classes.Product, stringFields.type, "Food", listP);
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

        private void sTyHAG_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wentedList = itsBL.queryByString(Classes.Product, stringFields.type, "HomeAndGarden", listP);
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

        private void sPid_Click(object sender, RoutedEventArgs e)
        {
            stringPanel.Visibility = System.Windows.Visibility.Visible;
            nfield = "fProid";
        }

        private void sStoC1_Click(object sender, RoutedEventArgs e)
        {
            stringPanel.Visibility = System.Windows.Visibility.Visible;
            nfield = "fStocCou";
        }

        private void sStoC2_Click(object sender, RoutedEventArgs e)
        {
            rangePanel.Visibility = System.Windows.Visibility.Visible;
            nfield = "fStocCou";
        }

        private void sPrice1_Click(object sender, RoutedEventArgs e)
        {
            stringPanel.Visibility = System.Windows.Visibility.Visible;
            nfield = "fPri";
        }

        private void sPrice2_Click(object sender, RoutedEventArgs e)
        {
            rangePanel.Visibility = System.Windows.Visibility.Visible;
            nfield = "fPri";
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

        private void CreateList(string textToFind)
        {
            try
            {
                if (nfield == "fName") { wentedList = itsBL.queryByString(Classes.Product, stringFields.name, textToFind, listP); }
                else if (nfield == "fProid") { wentedList = itsBL.queryByString(Classes.Product, stringFields.name, textToFind, listP); }
                else if (nfield == "fPri") { wentedList = itsBL.queryByRange(Classes.Product, rangeFields.price, textToFind, textToFind, listP); }
                else if (nfield == "fStocCou") { wentedList = itsBL.queryByRange(Classes.Product, rangeFields.stockCount, textToFind, textToFind, listP); }
                if (wentedList == null)
                {
                    MessageBox.Show("there are no items to show");
                }
                else
                {
                    ShowTable(wentedList);
                    stringPanel.Visibility = System.Windows.Visibility.Collapsed;
                    rangePanel.Visibility = System.Windows.Visibility.Collapsed;
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
                if (nfield == "fPri") { wentedList = itsBL.queryByRange(Classes.Product, rangeFields.price, fromToFind, textToFind, listP); }
                else if (nfield == "fStocCou") { wentedList = itsBL.queryByRange(Classes.Product, rangeFields.stockCount, fromToFind, textToFind, listP); }
                if (wentedList == null)
                {
                    MessageBox.Show("there are no items to show");
                }
                else
                {
                    ShowTable(wentedList);
                    stringPanel.Visibility = System.Windows.Visibility.Collapsed;
                    rangePanel.Visibility = System.Windows.Visibility.Collapsed;
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
                ProductDTG showProduct = new ProductDTG(itsBL, listP);
                tableShow.Children.Add(showProduct);
            }

        }

        private void btn16x16_Drop(object sender, DragEventArgs e)
        {
            //ProductCollection productCollection = Resources["ProductList"] as ProductCollection;
            Product changedProduct = (Product)listP.ElementAt(ProductDTG.rowIndex);
            PopUpAmount temp = new PopUpAmount();
            temp.ShowDialog();
            int amount = temp.amount;
            if (amount <= 0)
            {
                MessageBox.Show("The Amount must be a positive number. Are you trying to test our patience?");
                return;
            }
            ProductSale ps=null;
            try
            {
                ps = new ProductSale(changedProduct, amount);
            }
            catch (Exception u)
            {
                MessageBox.Show(u.Message);
                return;
            }
            

            this.receipt.addProductSale(ps);
            
            temp.Close();
            changedProduct.StockCount -= amount;
            itsBL.edit(changedProduct);
            listP = itsBL.queryByString(Classes.Product, stringFields.inStock, "True",listP);

            ShowTable(listP);
        }

        private void btn16x16_Click(object sender, RoutedEventArgs e)
        {
            ProgressBarUI psbu = new ProgressBarUI();
            psbu.Show();
            psbu.actionbtn_Click(sender, e);
            while (!psbu.isComplete())
            {

            }
            
            if (receipt == null || receipt.Data.Count == 0)
            {
                MessageBox.Show("There Are No Products In Cart.");
            }
            else
            {
                PaymentScreen ps = new PaymentScreen(itsBL, receipt, this, user);
                topSeller_label.Visibility = Visibility.Collapsed;
                topSellerColor.Visibility = Visibility.Collapsed;
                lbl.Visibility = Visibility.Collapsed;
                Combox.Visibility = Visibility.Collapsed;
                tableShow.Children.Clear();
                tableShow.Children.Add(ps);
            }
        }

        private void food_Selected(object sender, RoutedEventArgs e)
        {
            allProduct_Click(sender, e);
            this.wentedList = itsBL.queryByString(Classes.Product, stringFields.type, "Food", listP);
            this.listP = wentedList;
            showWantedList(listP);
        }

        private void electronics_Selected(object sender, RoutedEventArgs e)
        {
            allProduct_Click(sender, e);
            this.wentedList = itsBL.queryByString(Classes.Product, stringFields.type, "Electronics", listP);
            this.listP = wentedList;
            showWantedList(listP);
        }

        private void fashion_Selected(object sender, RoutedEventArgs e)
        {
            allProduct_Click(sender, e);
            this.wentedList = itsBL.queryByString(Classes.Product, stringFields.type, "Fashion", listP);
            this.listP = wentedList;
            showWantedList(listP);
        }

        private void homeAndGarden_Selected(object sender, RoutedEventArgs e)
        {
            allProduct_Click(sender, e);
            this.wentedList = itsBL.queryByString(Classes.Product, stringFields.type, "HomeAndGarden", listP);
            this.listP = wentedList;
            showWantedList(listP);
        }

        private void showWantedList(List<object> wanted)
        {
            if (wanted == null || wanted.Count == 0)
            {
                MessageBox.Show("there are no items to show");
            }
            else
            {
                tableShow.Children.Clear();
                ProductDTG showProduct = new ProductDTG(itsBL, wanted);
                tableShow.Children.Add(showProduct);
            }
        }

 
        //private void changeDTG()
        //{
        //    listP = itsBL.queryByString(Classes.Product, stringFields.inStock, "True");
        //    ShowTable(listP);
        //}
    }
}