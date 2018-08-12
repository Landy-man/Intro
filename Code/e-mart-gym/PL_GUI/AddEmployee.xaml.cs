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
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : UserControl
    {
        private IBL itsBL;
        private string aTz;
        private string aFn;
        private string aLn;
        private string aGender;
        private string aDepid;
        private string aSuprid;
        private string aSalary;
        private string aPassword;
        private User user;

        public AddEmployee(IBL BL,User user)
        {
            this.user=user;
            InitializeComponent();
            this.itsBL = BL;
            if (user.Hierarchy == Hierarchy.Manager)
            {
                admin.Visibility = Visibility.Collapsed;
                
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            aTz = Atz.Text;
            aFn=Afn.Text;
            aLn = Aln.Text;
            aGender = Age.Text;
            aDepid = Adi.Text;
            aSuprid = Asi.Text; 
            aSalary = Asa.Text;
            aPassword = Aps.Text;
            Hierarchy hierarchy;

            if (worker.IsChecked == true)
                hierarchy = Hierarchy.Worker;
            else if (manager.IsChecked == true)
                hierarchy = Hierarchy.Manager;
            else
                hierarchy = Hierarchy.Adminstor;
            //  להוסיף לפונקציה של יצירת עובד חדש 

            try
            {
                Employee employeeToAdd = new Employee(aTz, aFn, aLn, aDepid, aSalary, aSuprid, aGender);       // create employee
                itsBL.add(employeeToAdd);                       // add employee
                User userToAdd = new User(aTz, aPassword, hierarchy);//////////////
                itsBL.add(userToAdd);

                itsBL.saveDataToFile();
                MessageBox.Show("successfully asved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      
    }
}
