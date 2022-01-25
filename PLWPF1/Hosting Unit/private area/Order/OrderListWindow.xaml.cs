using BE;
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

namespace PLWPF1
{
    /// <summary>
    /// Interaction logic for OrderListWindow.xaml
    /// </summary>
    public partial class OrderListWindow : Window
    {
        BL.IBL bl;
        BE.Order order = new Order();
        public OrderListWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            this.OrderComboBox.ItemsSource = bl.AllOrder();
            this.OrderComboBox.SelectedValuePath = "OrderKey";
            this.StatusComboBox.ItemsSource = Enum.GetValues(typeof(BE.StatusOrder));
            this.StatusComboBox.SelectedIndex = 0;
        }
        private void OrderDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dg = sender as DataGrid;
                if (dg.SelectedIndex > -1)
                {
                    order = dg.SelectedItem as BE.Order;
                }
                else
                {
                    order = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private long GetSelectedOrder()
        {
            try
            {
                object result = this.OrderComboBox.SelectedValue;
                if (result == null)
                    throw new Exception("must select order first");
                return (long)result;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 1;
        }
       
        private void OrderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
                this.refreshDataGridOrder(GetSelectedOrder());
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                long orderKey = GetSelectedOrder();
                order = bl.getOrder(orderKey);
                order.statusOrder = (BE.StatusOrder)this.StatusComboBox.SelectedItem;
                bl.updateOrder(order);
                order = new BE.Order();
                this.DataContext = order;
                refreshDataGridOrder(orderKey);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void refreshDataGridOrder(long key)
        {
            try
            {
                OrderDataGrid.ItemsSource = bl.TheOrder(key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
       
        
    }
}
