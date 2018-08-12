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
using Backend2;
using pbu = Backend2.ProgressBarStatic;

namespace Backend2
{
    /// <summary>
    /// Interaction logic for ProgressBarUI.xaml
    /// </summary>
    public partial class ProgressBarUI : Window
    {
        public ProgressBarUI()
        {
            InitializeComponent();

        }

        int pbuHandle3 = pbu.InvalidHandle;

        public void actionbtn_Click(object sender, RoutedEventArgs e)
        {
            pbu.TimerReset(pbuHandle3);

            Process();
        }

        public int getH()
        {
            return pbu.New(pb1, 0, 100, 0, -1); ;
        }

        private void Process()
        {

            var pbuHandle2 = pbu.New(pb1, 0, 100, 0, -1); // Update by update demand.
            // END

            int cur2 = 0;
            int max2 = 100;
            do
            {

                // Update by value change:
                pbu.CurValue[pbuHandle2] += 0.01;
                // END
                pb1.Value += 0.01;
                //  pbu.CurValue[pbuHandle2, pbuHandle3] = pbu.CurValue[pbuHandle1];

                if (++cur2 < max2) continue;
                cur2 = 0;

                // Update demand:
                pbu.Update(pbuHandle2);
                // END

            }
            while (!pbu.Complete(pbuHandle2)); // Can check for completion of multiple progress bars at one time.

            MessageBox.Show("Process succeeded!");
            this.Close();

        }

        public bool isComplete()
        {
            return pbu.Complete(getH());
        }


    }
}