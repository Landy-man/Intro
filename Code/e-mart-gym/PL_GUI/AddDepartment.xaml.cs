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
    /// Interaction logic for AddDepartment.xaml
    /// </summary>
    public partial class AddDepartment : UserControl
    {
        private IBL itsBL;
        private string aName;

        public AddDepartment(IBL BL)
        {
            this.itsBL = BL; 
            InitializeComponent();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            aName = AName.Text;
            try
            {
                Department departmentToAdd = new Department(aName);       // create department
                itsBL.add(departmentToAdd);                       // add department
                itsBL.saveDataToFile();
                MessageBox.Show("successfully saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
