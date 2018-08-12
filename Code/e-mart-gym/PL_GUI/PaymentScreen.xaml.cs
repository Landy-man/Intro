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
using System.Windows.Controls.Primitives;
using Backend;
using BL;
using Backend2;

namespace PL_GUI
{
    /// <summary>
    /// Interaction logic for PaymentScreen.xaml
    /// </summary>
    public partial class PaymentScreen : UserControl
    {
        public static int rowIndex = -1;
        private List<ProductSale> listPS = new List<ProductSale>();
        private IBL itsBL;
        private Receipt receipt;
        private ViewShopDnD vsDND;
        private User user;
        private double sum = 0;
        public delegate Point GetPosition(IInputElement element);

        public PaymentScreen(IBL itsBL,Receipt receipt, ViewShopDnD vsDND ,User user)
        {
            InitializeComponent();
            this.vsDND = vsDND;
            this.receipt = receipt;
            this.sum = totleSum(this.receipt);
            this.itsBL = itsBL;
            this.listPS = this.receipt.Data;
            this.user = user;
            
            this.receiptDTG.ItemsSource = listPS;
            receiptDTG.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(receiptDTG_PreviewMouseLeftButtonDown);
          
        }
        public void clearReceipt()
        {
            this.receipt = new Receipt();
            this.listPS = new List<ProductSale>();
            this.receiptDTG.ItemsSource = listPS;
            vsDND.clearReceipt();
           // this.receiptDTG,itemsour
        }

        

        void receiptDTG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            rowIndex = GetCurrentRowIndex(e.GetPosition);
            if (rowIndex < 0)
                return;
            receiptDTG.SelectedIndex = rowIndex;
            ProductSale selectedEmp = receiptDTG.Items[rowIndex] as ProductSale;
            if (selectedEmp == null)
                return;
            DragDropEffects dragdropeffects = DragDropEffects.Move;
            if (DragDrop.DoDragDrop(receiptDTG, selectedEmp, dragdropeffects)
                                != DragDropEffects.None)
            {
                receiptDTG.SelectedItem = selectedEmp;
            }
        }

        private bool GetMouseTargetRow(Visual theTarget, GetPosition position)
        {
            Rect rect = VisualTreeHelper.GetDescendantBounds(theTarget);
            Point point = position((IInputElement)theTarget);
            return rect.Contains(point);
        }

        private DataGridRow GetRowItem(int index)
        {
            if (receiptDTG.ItemContainerGenerator.Status
                    != GeneratorStatus.ContainersGenerated)
                return null;
            return receiptDTG.ItemContainerGenerator.ContainerFromIndex(index)
                                                            as DataGridRow;
        }

        private int GetCurrentRowIndex(GetPosition pos)
        {
            int curIndex = -1;
            for (int i = 0; i < receiptDTG.Items.Count; i++)
            {
                DataGridRow itm = GetRowItem(i);
                if (GetMouseTargetRow(itm, pos))
                {
                    curIndex = i;
                    break;
                }
            }
            return curIndex;
        }

       

        private void btn_Trash_Drop(object sender, DragEventArgs e)
        {
            btn_Trash.Visibility = Visibility.Collapsed;
            btn_Trash2.Visibility = Visibility.Visible;
            btn_Trash2_Drop(sender, e);
        }

        private void btn_Trash2_Drop(object sender, DragEventArgs e)
        {
            ProductSale tempPS = (ProductSale)listPS.ElementAt(rowIndex);

            PopUpAmount temp = new PopUpAmount();
            temp.ShowDialog();
            int amount = temp.amount;
            temp.Close();

            if (amount > tempPS.Amount)
            {
                MessageBox.Show("Cannot Return More Then You Have.");
                return;
               // throw new Exception("Cannot Return More Then You Have.");
            }

           // Product tempProduct = new Product(tempPS.PRODUCT);
            //tempProduct.StockCount += amount;
            tempPS.PRODUCT.StockCount += amount;
            if(tempPS.PRODUCT.StockCount == 0)
            {
                tempPS.PRODUCT.INStock = InStock.False;
            }
            else if(tempPS.PRODUCT.StockCount > tempPS.PRODUCT.WhenToOrder)
            {
                tempPS.PRODUCT.INStock = InStock.True;
            }else tempPS.PRODUCT.INStock = InStock.NeedToOrder;
            tempPS.Amount -= amount;
           

            if(tempPS.Amount == 0)
            {
                listPS.RemoveAt(rowIndex);
            }
            
           // itsBL.edit(tempProduct);


           // this.receiptDTG.
            vsDND.reloadData();
            vsDND.tableShow.Children.Clear();
            vsDND.tableShow.Children.Add(new PaymentScreen(itsBL, receipt, vsDND,user));
            
            //changedProduct.StockCount -= amount;
            //itsBL.edit(changedProduct);
            //listP = itsBL.queryByString(Classes.Product, stringFields.inStock, "True", listP);
            ////Product tempP = new Product(changedProduct);
            //// tempP.StockCount -= amount;
            //// itsBL.edit(tempP)
            //ShowTable(listP);

            //MessageBox.Show(this.receipt.toString());
        }

        private void btn_Pay_Click(object sender, RoutedEventArgs e)
        {
            ProgressBarUI psbu = new ProgressBarUI();
            psbu.Show();
            psbu.actionbtn_Click(sender, e);
            while (!psbu.isComplete())
            {

            }
            Purchase a=new Purchase(itsBL,user,receipt,sum,this);
            vsDND.reloadData();
            vsDND.tableShow.Children.Clear();
            vsDND.tableShow.Children.Add(a);
        }


        private double totleSum(Receipt rec)
        {
            double sum=0;
            foreach(ProductSale ps in rec.Data)
            {
                sum = (ps.Price * ps.Amount) + sum;
            }
            return sum;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.sumlbl.Content = "Your Sum is: " + sum.ToString();
        }

    }
}
