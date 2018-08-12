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
using System.Windows.Shapes;

namespace PL_GUI
{
    /// <summary>
    /// Interaction logic for PopUpAmount.xaml
    /// </summary>
    public partial class PopUpAmount : Window
    {
        public int amount;
        public PopUpAmount()
        {
            InitializeComponent();
        }
        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                amount = Convert.ToInt32(this.txtBlock.Text);
            }
            catch (Exception) { MessageBox.Show("Amount Of Products Must Be A Number"); }
            this.Close();
        }

        private void txtBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            this.txtBlock.Text = "";
        }


    }
}
