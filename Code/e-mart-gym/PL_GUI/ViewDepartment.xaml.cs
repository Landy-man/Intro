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
    /// Interaction logic for ViewDepartment.xaml
    /// </summary>
    public partial class ViewDepartment : UserControl
    {
        private IBL itsBL;
        List<object> allList;
        private string nfield;
        private string toFind;
        List<object> wentedList;
        private User user;

        public ViewDepartment(IBL BL, User user)
        {
            this.itsBL = BL;
            this.user = user;
            InitializeComponent();
            if (user.Hierarchy != Hierarchy.Adminstor)
                add.Visibility = Visibility.Collapsed;
            else
                add.Visibility = Visibility.Visible;
        }

        private void allDepartment_Click(object sender, RoutedEventArgs e)
        {
            List<Department> newList3 = null;
            Employee employee=null;                
            try
            {
                if (user.Hierarchy == Hierarchy.Manager)
                {
                    List<Employee> emp = itsBL.queryByString(Classes.Employee, stringFields.teudatZehute, user.UserName).Cast<Employee>().ToList();
                    if (emp.Count == 1)
                        employee = (Employee)emp.ElementAt(0);

                    newList3 = itsBL.queryByString(Classes.Department, stringFields.departmentID, employee.DepartmentID.ToString()).Cast<Department>().ToList();
                }
                else if (user.Hierarchy == Hierarchy.Adminstor)
                    newList3 = itsBL.getAllDepartments().Departmentss;
                allList = newList3.Cast<object>().ToList();
                ShowTable(allList);
                stringPanel.Visibility = System.Windows.Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddDepartment addDepartment = new AddDepartment(itsBL);
            tableShow.Children.Clear();
            stringPanel.Visibility = System.Windows.Visibility.Collapsed;
            tableShow.Children.Add(addDepartment);
        }

        private void searchBy_Click(object sender, RoutedEventArgs e)
        {
            tableShow.Children.Clear();
            stringPanel.Visibility = System.Windows.Visibility.Collapsed;
            ContextMenu cm = this.FindResource("search") as ContextMenu;
            cm.PlacementTarget = sender as Button;
            cm.IsOpen = true;
        }

        private void sName_Click(object sender, RoutedEventArgs e)
        {
            stringPanel.Visibility = System.Windows.Visibility.Visible;
            nfield = "Name";
        }

        private void sDepID_Click(object sender, RoutedEventArgs e)
        {
            stringPanel.Visibility = System.Windows.Visibility.Visible;
            nfield = "fDep";
        }

        private void stringSearch_Click(object sender, RoutedEventArgs e)
        {
            toFind = toSearch.Text;
            CreateList(toFind);
        }

        private void CreateList(string textToFind)
        {
            try
            {
                if (nfield == "Name") { wentedList = itsBL.queryByString(Classes.Department, stringFields.name, textToFind); }
                else if (nfield == "fDep") { wentedList = itsBL.queryByString(Classes.Department, stringFields.departmentID, textToFind); }
                if (wentedList == null)
                {
                    MessageBox.Show("there are no items to show");
                }
                else
                {
                    ShowTable(wentedList);
                    stringPanel.Visibility = System.Windows.Visibility.Collapsed;
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
                //List<object> showList = table;
                DepartmentT showDepartment = new DepartmentT(itsBL, table,user);
                tableShow.Children.Clear();
                tableShow.Children.Add(showDepartment);
            }
        }


    }
 }



