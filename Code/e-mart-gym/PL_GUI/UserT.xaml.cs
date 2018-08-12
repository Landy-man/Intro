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
    /// Interaction logic for UserT.xaml
    /// </summary>
    public partial class UserT : UserControl
    {
        private IBL itsBL;
        private User whoUse;
        private List<object> Permanent;


        public UserT(IBL BL, List<object> users, User user)
        {
           if (users.Count == 0) { MessageBox.Show("there are no item to show"); }
            else if (users == null) { MessageBox.Show("wrong"); }
            this.itsBL = BL;
            this.whoUse = user;
            this.Permanent = users;
            InitializeComponent();

            try
            {
                List<User> userList = users.Cast<User>().ToList();
                this.gridUser.ItemsSource = userList;
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


        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //itsBL.remove(???); // איך הוא ידע את מי להוריד  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void delete2_Click(object sender, RoutedEventArgs e)
        {
            DataGridRow dgRow = (DataGridRow)(gridUser.ItemContainerGenerator.ContainerFromItem(gridUser.SelectedItem));
            User selectedUser = gridUser.Items[gridUser.SelectedIndex] as User;
            string textToFind = Convert.ToString(selectedUser.UserName);

            if (whoUse.Hierarchy == Hierarchy.Clubmember || whoUse.Hierarchy == Hierarchy.Customer || whoUse.Hierarchy == Hierarchy.Worker)
            {
                MessageBox.Show("You are not allowed to delete this item");
            }
            else
            {
                try
                {
                    List<object> wentedList = itsBL.queryByString(Classes.User, stringFields.userName, textToFind);
                    if (wentedList == null) { throw new Exception("there is no item to delete"); }
                    User deleteUser = wentedList.Cast<User>().ElementAt(0);
                    itsBL.remove(deleteUser);
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
        private void productsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow dgRow = (DataGridRow)(gridUser.ItemContainerGenerator.ContainerFromItem(gridUser.SelectedItem));
            dgRow.DetailsVisibility = Visibility.Collapsed;
        }


    }
}
