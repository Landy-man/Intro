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
using System.Windows.Controls.Primitives;
using BL;
using Backend;

namespace PL_GUI
{
    /// <summary>
    /// Interaction logic for ProductT.xaml
    /// </summary>
    public partial class ProductT : UserControl
    {
        private IBL itsBL;
        private List<Product> proList;
        private List<object> permanent;
        private string editType;
        private User whoUse;
        private Employee emp;

        public ProductT(IBL BL, List<object> products, User user)
        {
            this.permanent = products;
            if (products.Count == 0) { MessageBox.Show("there are no item to show"); }
            else if (products == null) { MessageBox.Show("wrong"); }
            this.itsBL = BL;
            this.whoUse = user; 
            InitializeComponent();
            if (user.Hierarchy == Hierarchy.Adminstor)
            {
                try
                {
                    proList = products.Cast<Product>().ToList();
                    this.gridProduct.ItemsSource = proList;
                }
                catch (Exception)
                {
                    MessageBox.Show("there are no items to show");
                }
            }
            else if (user.Hierarchy == Hierarchy.Manager)
            {
                try
                {
                    List<Employee> listEmp = itsBL.queryByString(Classes.Employee, stringFields.teudatZehute, user.UserName.ToString()).Cast<Employee>().ToList();
                    //if (user.Hierarchy==Hierarchy.Worker)
                    //gridProduct.RowDetailsVisibilityMode = DataGridRowDetailsVisibilityMode.Collapsed;
                    if (listEmp == null || listEmp.Count != 1)
                    {
                        MessageBox.Show("Invalid move");
                        return;
                    }
                    this.emp = listEmp.ElementAt(0);
                    proList = itsBL.queryByString(Classes.Product, stringFields.location, emp.DepartmentID.ToString()).Cast<Product>().ToList();
                    this.gridProduct.ItemsSource = proList;
                }
                catch (Exception)
                {
                    MessageBox.Show("there are no items to show");
                }
            }
        }

              private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                itsBL.saveDataToFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      


        private void electronics_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                List<object> wentedList = itsBL.queryByString(Classes.Product, stringFields.type, "Electronics", permanent);

                if (wentedList == null || wentedList.Count == 0)
                {
                    MessageBox.Show("there are no items to show");
                }
                else
                {
                    tablePanel.Children.Clear(); 
                    ProductT showProduct = new ProductT(itsBL, wentedList, whoUse);
                    tablePanel.Children.Add(showProduct);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


   
        private void fashion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<object> wentedList = itsBL.queryByString(Classes.Product, stringFields.type, "Fashion", permanent);
                if (wentedList == null || wentedList.Count == 0)
                {
                    MessageBox.Show("there are no items to show");
                }
                else
                {
                    tablePanel.Children.Clear();
                    ProductT showProduct = new ProductT(itsBL, wentedList, whoUse);
                    tablePanel.Children.Add(showProduct);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void food_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<object> wentedList = itsBL.queryByString(Classes.Product, stringFields.type, "Food", permanent);
                if (wentedList == null || wentedList.Count == 0)
                {
                    MessageBox.Show("there are no items to show");
                }
                else
                {
                    tablePanel.Children.Clear();
                    ProductT showProduct = new ProductT(itsBL, wentedList, whoUse);
                    tablePanel.Children.Add(showProduct);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void homeG_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<object> wentedList = itsBL.queryByString(Classes.Product, stringFields.type, "HomeAndGarden", permanent);
                if (wentedList == null || wentedList.Count == 0)
                {
                    MessageBox.Show("there are no items to show");
                }
                else
                {
                    tablePanel.Children.Clear();
                    ProductT showProduct = new ProductT(itsBL, wentedList, whoUse);
                    tablePanel.Children.Add(showProduct);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            DataGridRow dgRow = (DataGridRow)(gridProduct.ItemContainerGenerator.ContainerFromItem(gridProduct.SelectedItem));
            Product selectedProd = gridProduct.Items[gridProduct.SelectedIndex] as Product;

            if (dgRow == null) return;

            DataGridDetailsPresenter dgdPresenter = FindVisualChild<DataGridDetailsPresenter>(dgRow);

            DataTemplate template = dgdPresenter.ContentTemplate;
            TextBox textBoxName = (TextBox)template.FindName("editName", dgdPresenter);
            TextBox textBoxLoc = (TextBox)template.FindName("editLocation", dgdPresenter);
            TextBox textBoxStock = (TextBox)template.FindName("editStock", dgdPresenter);
            TextBox textBoxPrice = (TextBox)template.FindName("editPrice", dgdPresenter);
            TextBox textBoxWhen = (TextBox)template.FindName("editWhen", dgdPresenter);
            ComboBox textBoxType = (ComboBox)template.FindName("Atype", dgdPresenter);
            editType = textBoxType.Text;

            if (whoUse.Hierarchy == Hierarchy.Clubmember || whoUse.Hierarchy == Hierarchy.Customer || whoUse.Hierarchy == Hierarchy.Worker)
            {
                textBoxName.IsReadOnly = true;
                textBoxLoc.IsReadOnly = true;
                textBoxStock.IsReadOnly = true;
                textBoxPrice.IsReadOnly = true;
                textBoxWhen.IsReadOnly = true;
                textBoxType.IsReadOnly = true;
                MessageBox.Show("You are not allowed to edit this field");
            }
            else
            {
                if (editType == "Home And Garden")
                {
                    editType = "HomeAndGarden";
                }
                if (textBoxName == null || textBoxLoc == null || textBoxStock == null || textBoxPrice == null || textBoxWhen == null || textBoxType == null)
                {
                    MessageBox.Show("you have to fill all the empty fields");
                }
                else
                {
                    try
                    {
                        selectedProd.Name = textBoxName.Text;
                        if (textBoxName.Text.Length < 1) throw new Exception("Invalid First Name, Must Have Atleast One Character");
                        InputCheck.isType(editType);
                        selectedProd.Type = (Backend.Type)Enum.Parse(typeof(Backend.Type), editType);
                        InputCheck.isInt(textBoxLoc.Text, " location (Department ID) ");
                        selectedProd.Location = Convert.ToInt32(textBoxLoc.Text);
                        InputCheck.isInt(textBoxStock.Text, " units in stock ");
                        selectedProd.StockCount = Convert.ToInt32(textBoxStock.Text);
                        InputCheck.isDouble(textBoxPrice.Text, " price ");
                        selectedProd.Price = Convert.ToDouble(textBoxPrice.Text);
                        InputCheck.isInt(textBoxWhen.Text, " 'when to order' ");
                        selectedProd.WhenToOrder = Convert.ToInt32(textBoxWhen.Text);

                        itsBL.edit(selectedProd);
                        itsBL.saveDataToFile();
                        MessageBox.Show("Changes have been done");
                        tablePanel.Children.Clear();
                        DepartmentT showProduct = new DepartmentT(itsBL, permanent, whoUse);
                        tablePanel.Children.Add(showProduct);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        public static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }


        private void delete2_Click(object sender, RoutedEventArgs e)
        {
            DataGridRow dgRow = (DataGridRow)(gridProduct.ItemContainerGenerator.ContainerFromItem(gridProduct.SelectedItem));
            Product selectedProd = gridProduct.Items[gridProduct.SelectedIndex] as Product;

            string textToFind = Convert.ToString(selectedProd.InventoryID);

             if (whoUse.Hierarchy == Hierarchy.Clubmember || whoUse.Hierarchy == Hierarchy.Customer || whoUse.Hierarchy == Hierarchy.Worker)
            {
                MessageBox.Show("You are not allowed to delete this item");
            }
            else
            {
                try
                {
                    List<object> wentedList = itsBL.queryByString(Classes.Product, stringFields.inventoryID, textToFind);
                    if (wentedList == null) { throw new Exception("there is no item to delete"); }
                    Product deleteEmpo = wentedList.Cast<Product>().ElementAt(0);
                    itsBL.remove(deleteEmpo);
                    itsBL.saveDataToFile();
                    MessageBox.Show("item sucessfuly deleted");
                    tablePanel.Children.Clear();
                    DepartmentT showProduct = new DepartmentT(itsBL, permanent, whoUse);
                    tablePanel.Children.Add(showProduct);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
           }
        }

        private void gridProduct_RowDetailsVisibilityChanged(object sender, DataGridRowDetailsEventArgs e)
        {

        }


     

    }
}
