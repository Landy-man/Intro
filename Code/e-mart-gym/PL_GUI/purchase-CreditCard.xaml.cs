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
using System.Windows.Forms;
using Backend;
using BL;
using E_Mart_GYM;

namespace PL_GUI
{
    /// <summary>
    /// Interaction logic for purchase_CreditCard.xaml
    /// </summary>
    public partial class purchase_CreditCard
    {
        private User user;
        private ClubMember clbMember;
        private IBL itsBL;

        public purchase_CreditCard(IBL itsBL,User user) //מניחה שהיוזר חבר מועדון
        {
            this.itsBL = itsBL;
            this.user = user;
            List<ClubMember> temp = itsBL.queryByString(Classes.ClubMember, stringFields.teudatZehute, user.UserName).Cast<ClubMember>().ToList();
            if (temp.Count != 0 && temp != null)
                this.clbMember = temp[0];
            InitializeComponent();
        }


        private void DateString_GotFocus(object sender, RoutedEventArgs e)
        {
            this.monthString.Text = "";
            this.yearDate.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string month = monthString.Text;
            string year=yearDate.Text;
            string crc = crcBox.Text;
            string threePin=threeDig.Text;
            if (clbMember.CreditCard == null)
            {
                try
                {
                    this.clbMember.CreditCard = new CreditCard(crc, month, year, threePin);
                    System.Windows.MessageBox.Show("Creditcard added");

                } catch (Exception g)
                {
                    System.Windows.MessageBox.Show(g.Message);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("You already have a CreditCard in store");
            }

        }


        
    }


}
