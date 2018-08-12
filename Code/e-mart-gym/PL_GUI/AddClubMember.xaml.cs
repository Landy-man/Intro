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
    /// Interaction logic for AddClubMember.xaml
    /// </summary>
    public partial class AddClubMember : UserControl
    {
        private IBL itsBL;
        private string aTz;
        private string aFn;
        private string aLn;
        private string aGender;
        private string aDob;
        private User isUse; 

        public AddClubMember(IBL BL, User user)
        {
            this.itsBL = BL;
            this.isUse = user;
            InitializeComponent();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            aTz = Atz.Text;
            aFn = Afn.Text;
            aLn = Aln.Text;
            aGender = Age.Text;
            aDob = Adate.Text;
            try
            {
                ClubMember clubMemberToAdd = new ClubMember(aTz, aFn, aLn, aGender, aDob);       // create club member
                itsBL.add(clubMemberToAdd);                       // add employee
                

                

                if (isUse.Hierarchy == Hierarchy.Customer)
                {
                    isUse.UserName = aTz;
                    isUse.Hierarchy = Hierarchy.Clubmember;
                    itsBL.edit(isUse);
                }
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
