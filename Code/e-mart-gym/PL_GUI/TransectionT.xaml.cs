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
    /// Interaction logic for TransectionT.xaml
    /// </summary>
    public partial class TransectionT : UserControl
    {
        private IBL itsBL;
        private User whoUse;
        private Transaction selectedTra;
        private List<object> Permanent;


        public TransectionT(IBL BL, List<object> transection, User user)
        {
            if (transection.Count == 0) { MessageBox.Show("there are no item to show"); }
            else if (transection == null) { MessageBox.Show("wrong"); }
            this.itsBL = BL;
            this.whoUse = user;
            this.Permanent = transection;
            InitializeComponent();

            try
            {
                List<Transaction> trenList = transection.Cast<Transaction>().ToList();
                this.gridTransection.ItemsSource = trenList;
              
            }
            catch (Exception)
            {
                MessageBox.Show("there are no items to show");
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

        

        private void delete2_Click(object sender, RoutedEventArgs e)
        {
            DataGridRow dgRow = (DataGridRow)(gridTransection.ItemContainerGenerator.ContainerFromItem(gridTransection.SelectedItem));
            Transaction selectedTra = gridTransection.Items[gridTransection.SelectedIndex] as Transaction;
            string textToFind = Convert.ToString(selectedTra.TransactionID);

            if (whoUse.Hierarchy == Hierarchy.Clubmember || whoUse.Hierarchy == Hierarchy.Customer || whoUse.Hierarchy == Hierarchy.Worker)
            {
                MessageBox.Show("You are not allowed to delete this item");
            }
            else
            {
                try
                {
                    List<object> wentedList = itsBL.queryByString(Classes.Transaction, stringFields.transactionID, textToFind);
                    if (wentedList == null) { throw new Exception("there is no item to delete"); }
                    Transaction deleteTra = wentedList.Cast<Transaction>().ElementAt(0);
                    itsBL.remove(deleteTra);
                    itsBL.saveDataToFile();
                    MessageBox.Show("item sucessfuly deleted");
                    tablePanel.Children.Clear();
                    DepartmentT showProduct = new DepartmentT(itsBL, Permanent, whoUse);
                    tablePanel.Children.Add(showProduct);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void openReceipt_Click(object sender, RoutedEventArgs e)
        {
            DataGridRow dgRow = (DataGridRow)(gridTransection.ItemContainerGenerator.ContainerFromItem(gridTransection.SelectedItem));
            selectedTra = gridTransection.Items[gridTransection.SelectedIndex] as Transaction;
            try
            {
                if (dgRow == null) return;
                DataGridDetailsPresenter dgdPresenter = FindVisualChild<DataGridDetailsPresenter>(dgRow);
                Receipt toShow = selectedTra.Receipt;
                DataTemplate template = dgdPresenter.ContentTemplate;
                TextBox textBoxReci = (TextBox)template.FindName("reciept", dgdPresenter);
                string rec = Convert.ToString(toShow.toString());
                textBoxReci.Text = rec;
               
                            


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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


    }
}
