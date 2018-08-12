using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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



namespace PL_GUI
{
    /// <summary>
    /// Interaction logic for ProductDTG.xaml
    /// </summary>
    public partial class ProductDTG : UserControl
    {
        private IBL itsBL;
        private List<Product> listP;
        public delegate Point GetPosition(IInputElement element);
        public static int rowIndex = -1;

        public ProductDTG(IBL itsBL, List<object> listP)
        {
            InitializeComponent();
            this.listP = listP.Cast<Product>().ToList();
            this.itsBL = itsBL;


            this.gridProduct.ItemsSource = listP;
            gridProduct.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(productsDataGrid_PreviewMouseLeftButtonDown);
            // gridProduct.Drop += new DragEventHandler(productsDataGrid_Drop);
        }

        void productsDataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            rowIndex = GetCurrentRowIndex(e.GetPosition);
            if (rowIndex < 0)
                return;
            gridProduct.SelectedIndex = rowIndex;
            Product selectedEmp = gridProduct.Items[rowIndex] as Product;
            if (selectedEmp == null)
                return;
            DragDropEffects dragdropeffects = DragDropEffects.Move;
            if (DragDrop.DoDragDrop(gridProduct, selectedEmp, dragdropeffects)
                                != DragDropEffects.None)
            {
                gridProduct.SelectedItem = selectedEmp;
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
            if (gridProduct.ItemContainerGenerator.Status
                    != GeneratorStatus.ContainersGenerated)
                return null;
            return gridProduct.ItemContainerGenerator.ContainerFromIndex(index)
                                                            as DataGridRow;
        }

        private int GetCurrentRowIndex(GetPosition pos)
        {
            int curIndex = -1;
            for (int i = 0; i < gridProduct.Items.Count; i++)
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


    }
}
