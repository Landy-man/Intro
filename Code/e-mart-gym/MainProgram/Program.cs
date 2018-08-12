using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using DAL;
using NewPL;
using System.Windows.Markup; 



namespace MainProgram
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            IDAL adal = new LINQ_DAL();
            IBL abl = new E_Mart_BL(adal);
           // INewPL anpl = new NewPL_CLI(abl);
            EnterScreen letsBegin = new EnterScreen(abl);
            //letsBegin.Show();
            App test = new App();
            test.Run();
          

            //anpl.Run();
        }
    }
}
