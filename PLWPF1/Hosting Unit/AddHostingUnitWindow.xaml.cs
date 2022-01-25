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
    /// Interaction logic for AddHostingUnit.xaml
    /// </summary>
    public partial class AddHostingUnit : Window
    {
        BE.HostingUnit unit;
        BL.IBL bl;
        public AddHostingUnit()
        {
            InitializeComponent();
            unit = new BE.HostingUnit();
            this.DataContext = unit;
            bl = BL.FactoryBL.GetBL();
            this.AreaHostingUnitComboBox.ItemsSource = Enum.GetValues(typeof(BE.Area));
            this.typeHostingUnitComboBox.ItemsSource = Enum.GetValues(typeof(BE.TypeOfUnit));
           

        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //add code from BE + BL to here
                bl.addHostingUnit(unit);
                unit = new BE.HostingUnit();
                this.DataContext = unit;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
