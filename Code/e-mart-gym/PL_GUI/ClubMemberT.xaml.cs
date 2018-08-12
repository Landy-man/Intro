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
    /// Interaction logic for ClubMember.xaml
    /// </summary>
    public partial class ClubMemberT : UserControl
    {
        private IBL itsBL;
        private User whoUse;
        private List<object> Permanent;

        public ClubMemberT(IBL BL, List<object> clubMembers, User user)
        {
            if (clubMembers.Count == 0) { MessageBox.Show("there are no item to show"); }
            else if (clubMembers == null) { MessageBox.Show("wrong"); }
            this.itsBL = BL;
            this.Permanent = clubMembers;
            this.whoUse = user;
            InitializeComponent();
            try
            {
                List<ClubMember> clubList = clubMembers.Cast<ClubMember>().ToList();
                this.gridClubMember.ItemsSource = clubList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
       

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            DataGridRow dgRow = (DataGridRow)(gridClubMember.ItemContainerGenerator.ContainerFromItem(gridClubMember.SelectedItem));
            ClubMember selectedClub = gridClubMember.Items[gridClubMember.SelectedIndex] as ClubMember;

            if (dgRow == null) return;

            DataGridDetailsPresenter dgdPresenter = FindVisualChild<DataGridDetailsPresenter>(dgRow);

            DataTemplate template = dgdPresenter.ContentTemplate;
            TextBox textBoxFName = (TextBox)template.FindName("editFirstName", dgdPresenter);
            TextBox textBoxLName = (TextBox)template.FindName("editLastName", dgdPresenter);

            if (whoUse.Hierarchy == Hierarchy.Clubmember || whoUse.Hierarchy == Hierarchy.Customer || whoUse.Hierarchy == Hierarchy.Worker)
            {
                textBoxFName.IsReadOnly = true;
                textBoxLName.IsReadOnly = true;
                MessageBox.Show("You are not allowed to edit this field");
            }
            else
            {
                if (textBoxFName == null || textBoxLName == null)
                {
                    MessageBox.Show("you have to write somthing");
                }
                else
                {
                    if (textBoxFName.Text.Length < 1) throw new Exception("Invalid First Name, Must Have Atleast One Character");
                    selectedClub.FirstName = textBoxFName.Text;
                    if (textBoxLName.Text.Length < 1) throw new Exception("Invalid Last Name, Must Have Atleast One Character");
                    selectedClub.LastName = textBoxLName.Text;
                    try
                    {
                        itsBL.edit(selectedClub);
                        itsBL.saveDataToFile();
                        MessageBox.Show("Changes have been done");
                        dgRow.DetailsVisibility = Visibility.Collapsed;
                        gridClubMember.Items.Refresh();


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
            DataGridRow dgRow = (DataGridRow)(gridClubMember.ItemContainerGenerator.ContainerFromItem(gridClubMember.SelectedItem));
            ClubMember selectedClub = gridClubMember.Items[gridClubMember.SelectedIndex] as ClubMember;
            string textToFind = Convert.ToString(selectedClub.MemberID);

            if (whoUse.Hierarchy == Hierarchy.Clubmember || whoUse.Hierarchy == Hierarchy.Customer || whoUse.Hierarchy == Hierarchy.Worker)
            {
                MessageBox.Show("You are not allowed to delete this item");
            }
            else
            {
                try
                {
                    List<object> wentedList = itsBL.queryByString(Classes.ClubMember, stringFields.memberID, textToFind);
                    if (wentedList == null) { throw new Exception("there is no item to delete"); }
                    ClubMember deleteClub = wentedList.Cast<ClubMember>().ElementAt(0);
                    itsBL.remove(deleteClub);
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
            DataGridRow dgRow = (DataGridRow)(gridClubMember.ItemContainerGenerator.ContainerFromItem(gridClubMember.SelectedItem));
            dgRow.DetailsVisibility = Visibility.Collapsed;
        }

    }
}
