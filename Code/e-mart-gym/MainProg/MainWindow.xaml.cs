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
using DAL;
using PL_GUI;


namespace MainProg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        //[STAThread]
        public MainWindow()
        {
            InitializeComponent();
           



            IDAL adal = new LINQ_DAL();
            IBL abl = new E_Mart_BL(adal);
            // INewPL anpl = new NewPL_CLI(abl);
            EnterScreen letsBegin = new EnterScreen(abl);
            letsBegin.Show();
            //App test = new App();
            //test.Run();
            this.Close();

            //anpl.Run();
        }
    }
}
    
