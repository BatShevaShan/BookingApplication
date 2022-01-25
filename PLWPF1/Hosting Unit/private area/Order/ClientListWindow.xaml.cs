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
using BE;

namespace PLWPF1
{
    /// <summary>
    /// Interaction logic for ClientListWindow.xaml
    /// </summary>
    public partial class ClientListWindow : Window
    {
        BL.IBL bl;
        BE.Order order = new Order();
        BE.GuestRequest g = new GuestRequest();
        BE.HostingUnit h = new HostingUnit();
        public ClientListWindow()
        {
            InitializeComponent();
            this.DataContext = order;
            bl = BL.FactoryBL.GetBL();
            this.ClientsComboBox.ItemsSource = bl.AllGuestRequest();
            this.ClientsComboBox.SelectedValuePath = "GuestRequestKey";
            this.UnitComboBox.ItemsSource = bl.AllHostingUnit();
            this.UnitComboBox.SelectedValuePath = "HostingUnitKey";

        }
        private void refreshDataGridUnit(long key)
        {
            try
            {
                UnitsDataGrid.ItemsSource = bl.TheHostingUnit(key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void refreshDataGridClient(long key)
        {
            try
            {
                ClientsDataGrid.ItemsSource = bl.TheGuestRequest(key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                order.HostingUnitKey = (long)this.ClientsDataGrid.SelectedValue;
                order.GuestRequestKey = (long)this.UnitsDataGrid.SelectedValue;
                bl.addOrder(order);
                order = new BE.Order();
                this.DataContext = order;
                refreshDataGridClient(order.GuestRequestKey);
                refreshDataGridUnit(order.HostingUnitKey);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClientsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dg = sender as DataGrid;
                if (dg.SelectedIndex > -1)
                {
                    g = dg.SelectedItem as BE.GuestRequest;
                    order.GuestRequestKey = g.GuestRequestKey;
                }
                else
                {
                    g = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UnitsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dg = sender as DataGrid;
                if (dg.SelectedIndex > -1)
                {
                    h = dg.SelectedItem as BE.HostingUnit;
                    order.HostingUnitKey = h.HostingUnitKey;
                }
                else
                {
                    h = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private long GetSelectedClient()
        {
            try
            {
                object result = this.ClientsComboBox.SelectedValue;
                if (result == null)
                    throw new Exception("must select client first");
                return (long)result;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 1;
        }
        private long GetSelectedUnit()
        {
            try
            {
                object result = this.UnitComboBox.SelectedValue;
                if (result == null)
                    throw new Exception("must select unit first");
                return (long)result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return (long)1;
        }

        private void ClientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
                this.refreshDataGridClient(GetSelectedClient());
        }
        private void UnitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
                this.refreshDataGridUnit(GetSelectedUnit());
        }

    }

}
