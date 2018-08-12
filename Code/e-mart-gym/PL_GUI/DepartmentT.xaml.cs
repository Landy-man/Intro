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
using System.Threading;
//using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using UserControl = System.Windows.Controls.UserControl;
using TextBox = System.Windows.Controls.TextBox;
using BL;
using Backend;

namespace PL_GUI
{
    /// <summary>
    /// Interaction logic for DepartmentT.xaml
    /// </summary>
    public partial class DepartmentT : UserControl
    {
        private IBL itsBL;
        private List<object> Permanent;
        private User whoUse;

        public DepartmentT(IBL BL, List<object> department, User user)
        {
            this.whoUse = user;
            this.itsBL = BL;
            InitializeComponent();
            this.Permanent = department;


            try
            {
                List<Department> empoList = department.Cast<Department>().ToList();
                this.gridDepartment.ItemsSource = empoList;
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


        private void edit_Click(object sender, RoutedEventArgs e)
        {
            DataGridRow dgRow = (DataGridRow)(gridDepartment.ItemContainerGenerator.ContainerFromItem(gridDepartment.SelectedItem));
            Department selectedDep = gridDepartment.Items[gridDepartment.SelectedIndex] as Department;
            if (dgRow == null) return;

            DataGridDetailsPresenter dgdPresenter = FindVisualChild<DataGridDetailsPresenter>(dgRow);

            DataTemplate template = dgdPresenter.ContentTemplate;
            TextBox textBoxName = (TextBox)template.FindName("editName", dgdPresenter);

            if (whoUse.Hierarchy == Hierarchy.Clubmember || whoUse.Hierarchy == Hierarchy.Customer || whoUse.Hierarchy == Hierarchy.Worker)
            {
                textBoxName.IsReadOnly = true;
                MessageBox.Show("You are not allowed to edit this field");
            }
            else {
                if (textBoxName == null)
                {
                    MessageBox.Show("you have to write somthing");
                }
                else
                {
                    if (textBoxName.Text.Length < 1) throw new Exception("Invalid First Name, Must Have Atleast One Character");
                    selectedDep.Name = textBoxName.Text;
                    try
                    {
                        itsBL.edit(selectedDep);
                        itsBL.saveDataToFile();
                        MessageBox.Show("Changes have been done");
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
            DataGridRow dgRow = (DataGridRow)(gridDepartment.ItemContainerGenerator.ContainerFromItem(gridDepartment.SelectedItem));
            Department selectedDep = gridDepartment.Items[gridDepartment.SelectedIndex] as Department;
            string textToFind =Convert.ToString(selectedDep.DepartmentID);
            if (whoUse.Hierarchy == Hierarchy.Clubmember || whoUse.Hierarchy == Hierarchy.Customer || whoUse.Hierarchy == Hierarchy.Worker)
            {
                MessageBox.Show("You are not allowed to delete this item");
            }
            else
            {

                try
                {
                    List<object> wentedList = itsBL.queryByString(Classes.Department, stringFields.departmentID, textToFind);
                    if (wentedList == null) { throw new Exception("there is no item to delete"); }
                    Department deleteDep = wentedList.Cast<Department>().ElementAt(0);
                    itsBL.remove(deleteDep);
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


    }
 }

