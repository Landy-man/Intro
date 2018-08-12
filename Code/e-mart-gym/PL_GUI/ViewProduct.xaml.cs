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
    /// Interaction logic for ViewProduct.xaml
    /// </summary>
    public partial class ViewProduct : UserControl
    {
        private IBL itsBL;
        List<object> wentedList;
        private string nfield;
        private string toFind;
        private string fromString;
        private User user;
        

        public ViewProduct(IBL BL, User user)
        {
            this.itsBL = BL;
            this.user = user;
            InitializeComponent();
            if ((user.Hierarchy == Hierarchy.Manager) || (user.Hierarchy == Hierarchy.Adminstor))
                add.Visibility = Visibility.Visible;
            else
                add.Visibility = Visibility.Collapsed;

        }

        public ViewProduct(IBL BL, User user, List<object> prodList)
        {
            this.user = user;
            this.itsBL = BL;
            this.wentedList = prodList;
            ShowTable(wentedList);
        }

        private void allProduct_Click(object sender, RoutedEventArgs e)
        {
            List<Product> newList8 = null;
            Employee employee=null;
            try
            {
                if (user.Hierarchy == Hierarchy.Manager)
                {
                    List<Employee> emp = itsBL.queryByString(Classes.Employee, stringFields.teudatZehute, user.UserName).Cast<Employee>().ToList();
                    if (emp.Count==1)
                        employee = (Employee)emp.ElementAt(0);
                                         
                    newList8 = itsBL.queryByString(Classes.Product, stringFields.location, employee.DepartmentID.ToString()).Cast<Product>().ToList();
                }
                else if (user.Hierarchy == Hierarchy.Adminstor)
                    newList8 = itsBL.getAllProducts().Productss;
                
                List<object> allList = newList8.Cast<object>().ToList();
                ShowTable(allList);
                stringPanel.Visibility = System.Windows.Visibility.Collapsed;
                rangePanel.Visibility = System.Windows.Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            stringPanel.Visibility = System.Windows.Visibility.Collapsed;
            rangePanel.Visibility = System.Windows.Visibility.Collapsed;
            AddProduct addProduct = new AddProduct(itsBL);
            tableShow.Children.Clear();
            tableShow.Children.Add(addProduct);
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
                wentedList = itsBL.queryByString(Classes.Product, stringFields.type, "Electronics");
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
                wentedList = itsBL.queryByString(Classes.Product, stringFields.type, "Fashion");
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
                wentedList = itsBL.queryByString(Classes.Product, stringFields.type, "Food");
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
                wentedList = itsBL.queryByString(Classes.Product, stringFields.type, "HomeAndGarden");
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

        private void sDepID_Click(object sender, RoutedEventArgs e)
        {
            stringPanel.Visibility = System.Windows.Visibility.Visible;
            nfield = "fDepid";
        }

        private void sYesInS_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wentedList = itsBL.queryByString(Classes.Product, stringFields.inStock, "True");
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

        private void sNoInS_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wentedList = itsBL.queryByString(Classes.Product, stringFields.inStock, "False");
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

        private void sNeedInS_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wentedList = itsBL.queryByString(Classes.Product, stringFields.inStock, "NeedToOrder");
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
                if (nfield == "fName") { wentedList = itsBL.queryByString(Classes.Product, stringFields.name, textToFind); }
                else if (nfield == "fProid") { wentedList = itsBL.queryByString(Classes.Product, stringFields.inventoryID, textToFind); }
                else if (nfield == "fDepid") { wentedList = itsBL.queryByString(Classes.Product, stringFields.location, textToFind); }
                else if (nfield == "fPri") { wentedList = itsBL.queryByRange(Classes.Product, rangeFields.price, textToFind, textToFind); }
                else if(nfield=="fStocCou")  { wentedList = itsBL.queryByRange(Classes.Product, rangeFields.stockCount, textToFind, textToFind);}
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
                 if (nfield == "fPri") { wentedList = itsBL.queryByRange(Classes.Product, rangeFields.price, fromToFind, textToFind); }
                 else if (nfield == "fStocCou") { wentedList = itsBL.queryByRange(Classes.Product, rangeFields.stockCount, fromToFind, textToFind); }
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
                ProductT showProduct = new ProductT(itsBL, table,user);
                tableShow.Children.Add(showProduct);
            }

        }
    }
}
