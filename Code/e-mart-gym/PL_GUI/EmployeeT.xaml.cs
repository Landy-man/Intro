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
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class EmployeeT : UserControl
    {
        private IBL itsBL;
        private User whoUse;
        private List<Employee> empoList;
        private List<object> Permanent;


        public EmployeeT(IBL BL, List<object> employee, User user)
        {
            if (employee.Count == 0) { MessageBox.Show("there are no item to show"); }
            else if (employee == null) { MessageBox.Show("wrong"); }
            this.itsBL = BL;
            this.whoUse= user;
            this.Permanent = employee;
            InitializeComponent();
            try
            {
                this.empoList = employee.Cast<Employee>().ToList();
                this.gridEmployee.ItemsSource = empoList;
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
            DataGridRow dgRow = (DataGridRow)(gridEmployee.ItemContainerGenerator.ContainerFromItem(gridEmployee.SelectedItem));
            Employee selectedEmpo = gridEmployee.Items[gridEmployee.SelectedIndex] as Employee;

            if (dgRow == null) return;

            DataGridDetailsPresenter dgdPresenter = FindVisualChild<DataGridDetailsPresenter>(dgRow);

            DataTemplate template = dgdPresenter.ContentTemplate;
            TextBox textBoxFName = (TextBox)template.FindName("editFirstName", dgdPresenter);
            TextBox textBoxLName = (TextBox)template.FindName("editLastName", dgdPresenter);
            TextBox textBoxDepID = (TextBox)template.FindName("editDepID", dgdPresenter);
            TextBox textBoxSalary = (TextBox)template.FindName("editSalary", dgdPresenter);
            TextBox textBoxSuper = (TextBox)template.FindName("editSuper", dgdPresenter);

            if (whoUse.Hierarchy == Hierarchy.Clubmember || whoUse.Hierarchy == Hierarchy.Customer || whoUse.Hierarchy == Hierarchy.Worker)
            {
                textBoxFName.IsReadOnly = true;
                textBoxLName.IsReadOnly = true;
                textBoxDepID.IsReadOnly = true;
                textBoxSalary.IsReadOnly = true;
                textBoxSuper.IsReadOnly = true;
                MessageBox.Show("You are not allowed to edit this field");
            }
            else
            {
                if (textBoxFName == null || textBoxLName == null || textBoxDepID == null || textBoxSalary == null || textBoxSuper == null)
                {
                    MessageBox.Show("you have to fill all the empty fields");
                }
                else
                {
                    try
                    {
                        if (textBoxFName.Text.Length < 1) throw new Exception("Invalid First Name, Must Have Atleast One Character");
                        selectedEmpo.FirstName = textBoxFName.Text;
                        if (textBoxFName.Text.Length < 1) throw new Exception("Invalid Last Name, Must Have Atleast One Character");
                        selectedEmpo.LastName = textBoxLName.Text;
                        InputCheck.isInt(textBoxDepID.Text, " department ID ");
                        selectedEmpo.DepartmentID = Convert.ToInt32(textBoxDepID.Text);
                        InputCheck.isDouble(textBoxSalary.Text, " salary ");
                        selectedEmpo.Salary = Convert.ToDouble(textBoxSalary.Text);
                        InputCheck.isInt(textBoxSuper.Text, " supervisor ID ");
                        selectedEmpo.SupervisorID = Convert.ToInt32(textBoxSuper.Text);

                        itsBL.edit(selectedEmpo);
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
            DataGridRow dgRow = (DataGridRow)(gridEmployee.ItemContainerGenerator.ContainerFromItem(gridEmployee.SelectedItem));
            Employee selectedEmpo = gridEmployee.Items[gridEmployee.SelectedIndex] as Employee;

            string textToFind = Convert.ToString(selectedEmpo.TeudatZehute);

            if (whoUse.Hierarchy == Hierarchy.Clubmember || whoUse.Hierarchy == Hierarchy.Customer || whoUse.Hierarchy == Hierarchy.Worker)
            {
                MessageBox.Show("You are not allowed to delete this item");
            }
            else
            {


                try
                {
                    List<object> wentedList = itsBL.queryByString(Classes.Employee, stringFields.teudatZehute, textToFind);
                    if (wentedList == null) { throw new Exception("there is no item to delete"); }
                    Employee deleteEmpo = wentedList.Cast<Employee>().ElementAt(0);
                    itsBL.remove(deleteEmpo);
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
