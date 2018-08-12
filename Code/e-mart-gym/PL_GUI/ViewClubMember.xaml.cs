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
    /// Interaction logic for ViewClubMember.xaml
    /// </summary>
    public partial class ViewClubMember : UserControl
    {
        private IBL itsBL;
        List<object> wentedList;
        private string nfield;
        private string toFind;
        private string fromString;
        private User isUse; 

        public ViewClubMember(IBL BL, User user)
        {
            this.isUse = user; 
            this.itsBL = BL;
            InitializeComponent();
        }

        private void allClubMember_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<ClubMember> newList7 = itsBL.getAllClubMembers().ClubMemberss; 
                List<object> allList = newList7.Cast<object>().ToList();
                ShowTable(allList);
                stringPanel.Visibility = System.Windows.Visibility.Collapsed;
                rangePanel.Visibility = System.Windows.Visibility.Collapsed;
                DatePanel1.Visibility = System.Windows.Visibility.Collapsed;
                DatePanel2.Visibility = System.Windows.Visibility.Collapsed;
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
            DatePanel1.Visibility = System.Windows.Visibility.Collapsed;
            DatePanel2.Visibility = System.Windows.Visibility.Collapsed;
            AddClubMember addEmployee = new AddClubMember(itsBL,isUse);
            tableShow.Children.Clear();
            tableShow.Children.Add(addEmployee);
        }

        private void searchBy_Click(object sender, RoutedEventArgs e)
        {
            tableShow.Children.Clear();
            stringPanel.Visibility = System.Windows.Visibility.Collapsed;
            rangePanel.Visibility = System.Windows.Visibility.Collapsed;
            DatePanel1.Visibility = System.Windows.Visibility.Collapsed;
            DatePanel2.Visibility = System.Windows.Visibility.Collapsed;
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

        private void sMembID_Click(object sender, RoutedEventArgs e)
        {
            stringPanel.Visibility = System.Windows.Visibility.Visible;
            nfield = "fMem";
        }

        private void sDateOB1_Click(object sender, RoutedEventArgs e)
        {
            DatePanel1.Visibility = System.Windows.Visibility.Visible;
            nfield = "fDob1";
        }

        private void sDateOB2_Click(object sender, RoutedEventArgs e)
        {
            DatePanel2.Visibility = System.Windows.Visibility.Visible;
            nfield = "fDob2";
        }

        private void male_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wentedList = itsBL.queryByString(Classes.ClubMember, stringFields.gender, "Male");
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
                wentedList = itsBL.queryByString(Classes.ClubMember, stringFields.gender, "Female");
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
                if (nfield == "fTz") { wentedList = itsBL.queryByString(Classes.ClubMember, stringFields.teudatZehute, textToFind); }
                else if (nfield == "fFn") { wentedList = itsBL.queryByString(Classes.ClubMember, stringFields.firstName, textToFind); }
                else if (nfield == "fLn") { wentedList = itsBL.queryByString(Classes.ClubMember, stringFields.lastName, textToFind); }
                else if (nfield == "fMem") { wentedList = itsBL.queryByString(Classes.ClubMember, stringFields.memberID, textToFind); }   

                if (wentedList == null)
                {
                    MessageBox.Show("there are no items to show");
                }
                else
                {
                    ShowTable(wentedList);
                    stringPanel.Visibility = System.Windows.Visibility.Collapsed;
                    rangePanel.Visibility = System.Windows.Visibility.Collapsed;
                    DatePanel1.Visibility = System.Windows.Visibility.Collapsed;
                    DatePanel2.Visibility = System.Windows.Visibility.Collapsed;
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
                if (nfield == "fDob1") { wentedList = itsBL.queryByRange(Classes.ClubMember, rangeFields.date_of_birth, textToFind, textToFind); }
                else if (nfield == "fDob2") { wentedList = itsBL.queryByRange(Classes.ClubMember, rangeFields.date_of_birth, fromToFind, textToFind); }
                if (wentedList == null)
                    {
                        MessageBox.Show("there are no items to show");
                    }
                else
                    {
                        ShowTable(wentedList);
                        stringPanel.Visibility = System.Windows.Visibility.Collapsed;
                        rangePanel.Visibility = System.Windows.Visibility.Collapsed;
                        DatePanel1.Visibility = System.Windows.Visibility.Collapsed;
                        DatePanel2.Visibility = System.Windows.Visibility.Collapsed;
                    }
                }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DateSearch_Click(object sender, RoutedEventArgs e)
        {
            toFind = DtoFind.Text;
            fromString = DtoFind.Text;
            CreateList(fromString, toFind);
        }

        private void DateSearch2_Click(object sender, RoutedEventArgs e)
        {
            toFind = DToFind.Text;
            fromString = DFromFind.Text;
            CreateList(fromString, toFind);
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
                ClubMemberT showClubMember = new ClubMemberT(itsBL, table,isUse);
                tableShow.Children.Add(showClubMember);
            }

        }
    }
}
