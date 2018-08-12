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
    /// Interaction logic for ViewEmployee.xaml
    /// </summary>
    public partial class ViewEmployee : UserControl
    {
        private IBL itsBL;
        List<object> wentedList;
        private string nfield;
        private string toFind;
        private string fromString;
        private User user;
        List<Employee> newList8 = null;

        public ViewEmployee(IBL BL,User user)
        {
            this.itsBL = BL;
            this.user = user;
            InitializeComponent();
            if ((user.Hierarchy == Hierarchy.Manager) || (user.Hierarchy == Hierarchy.Adminstor))
                add.Visibility = Visibility.Visible;
            else
                add.Visibility = Visibility.Collapsed;
        }

        private void allEmployee_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                
                if (user.Hierarchy==Hierarchy.Manager)
                     newList8=itsBL.queryByString(Classes.Employee,stringFields.supervisorID,user.UserName).Cast<Employee>().ToList();
                if (user.Hierarchy==Hierarchy.Adminstor)
                    newList8 = itsBL.getAllEmployees().Employeess;
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
            AddEmployee addEmployee = new AddEmployee(itsBL,user);
            tableShow.Children.Clear();
            tableShow.Children.Add(addEmployee);
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

        private void sTZ_Click(object sender, RoutedEventArgs e)
        {
            stringPanel.Visibility = System.Windows.Visibility.Visible;
            nfield = "fTz";
        }

        private void sFN_Click(object sender, RoutedEventArgs e)
        {
            stringPanel.Visibility = System.Windows.Visibility.Visible;
            nfield = "fFn";
        }

        private void sLN_Click(object sender, RoutedEventArgs e)
        {
            stringPanel.Visibility = System.Windows.Visibility.Visible;
            nfield = "fLn";
        }

        private void sDepID_Click(object sender, RoutedEventArgs e)
        {
            stringPanel.Visibility = System.Windows.Visibility.Visible;
            nfield = "fDep";
        }

        private void sSalary1_Click(object sender, RoutedEventArgs e)
        {
            stringPanel.Visibility = System.Windows.Visibility.Visible;
            nfield = "fSa";
        }

        private void sSalary2_Click(object sender, RoutedEventArgs e)   // search by range
        {
            rangePanel.Visibility = System.Windows.Visibility.Visible;
            nfield = "fSa";
        }

        private void male_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wentedList = itsBL.queryByString(Classes.Employee, stringFields.gender, "Male");
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

        private void female_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wentedList = itsBL.queryByString(Classes.Employee, stringFields.gender, "Female");
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

        private void sSupID_Click(object sender, RoutedEventArgs e)
        {
            stringPanel.Visibility = System.Windows.Visibility.Visible;
            nfield = "fSup";
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
                EmployeeT showEmployee = new EmployeeT(itsBL, table,user);
                tableShow.Children.Add(showEmployee);
            }

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
                if (nfield == "fTz") { wentedList = itsBL.queryByString(Classes.Employee, stringFields.teudatZehute, textToFind); }
                else if (nfield == "fFn") { wentedList = itsBL.queryByString(Classes.Employee, stringFields.firstName, textToFind); }
                else if (nfield == "fLn") { wentedList = itsBL.queryByString(Classes.Employee, stringFields.lastName, textToFind); }
                else if (nfield == "fDep") { wentedList = itsBL.queryByString(Classes.Employee, stringFields.departmentID, textToFind); }
                else if (nfield == "fSup") { wentedList = itsBL.queryByString(Classes.Employee, stringFields.supervisorID, textToFind); }
                else if (nfield == "fSa") { wentedList = itsBL.queryByRange(Classes.Employee, rangeFields.salary, textToFind, textToFind); }

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
                if (nfield == "fSa") 
                { 
                    wentedList = itsBL.queryByRange(Classes.Employee, rangeFields.salary, fromToFind, textToFind);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}