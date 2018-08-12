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
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : UserControl
    {
        private IBL itsBL;
        private string aName;
        private string aType;
        private string aLoc;
        private string aUnits;
        private string aPrice;
        private string aOrder;


        public AddProduct(IBL BL)
        {
            this.itsBL = BL;
            InitializeComponent();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            aName = Aname.Text;
            aLoc = Aloc.Text;
            aUnits = Auis.Text;
            aPrice = Apri.Text;
            aOrder = Aorder.Text;

            try
            {
                Product productToAdd = new Product(aName, aType, aLoc, aUnits, aPrice, aOrder);     // unite all the information into one product
                itsBL.add(productToAdd);                                // add the prodect   
                itsBL.saveDataToFile();
                MessageBox.Show("successfully asved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void electra_Selected(object sender, RoutedEventArgs e)
        {
            aType = "Electronics";

        }

        private void fashion_Selected(object sender, RoutedEventArgs e)
        {
            aType = "Fashion";

        }

        private void food_Selected(object sender, RoutedEventArgs e)
        {
            aType = "Food";

        }

        private void HoAGa_Selected(object sender, RoutedEventArgs e)
        {
            aType = "HomeAndGarden"; 

        }
    }
    
}


  