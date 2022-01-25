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
    /// Interaction logic for RemoveUnitWindow.xaml
    /// </summary>
    public partial class RemoveUnitWindow : Window
    {

        BL.IBL bl;
        BE.HostingUnit unit = new HostingUnit();
        public RemoveUnitWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            this.UnitComboBox.ItemsSource = bl.AllHostingUnit();
            this.UnitComboBox.SelectedValuePath = "HostingUnitKey";
        }
        private void UnitDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dg = sender as DataGrid;
                if (dg.SelectedIndex > -1)
                {
                    unit = dg.SelectedItem as BE.HostingUnit;
                }
                else
                {
                    unit = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            return 1;
        }

        private void UnitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
                this.refreshDataGridUnit(GetSelectedUnit());
        }
        private void refreshDataGridUnit(long key)
        {
            try
            {
                UnitDataGrid.ItemsSource = bl.TheHostingUnit(key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                long unitKey = GetSelectedUnit();
                bl.removeHostingUnit(unitKey);
                unit = new BE.HostingUnit();
                this.DataContext = unit;
                refreshDataGridUnit(unitKey);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
