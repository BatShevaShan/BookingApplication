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
    /// Interaction logic for GustRequestWindow.xaml
    /// </summary>
    public partial class GustRequestWindow : Window
    {
        BE.GuestRequest gust;
        BL.IBL bl;


        public GustRequestWindow()
        {
            InitializeComponent();
            gust = new BE.GuestRequest();
            this.DataContext = gust;
            bl = BL.FactoryBL.GetBL();
            this.StatusGustRequestComboBox.ItemsSource = Enum.GetValues(typeof(BE.StatusGuestRequest));
            this.AreaComboBox.ItemsSource = Enum.GetValues(typeof(BE.Area));
            this.PoolComboBox.ItemsSource = Enum.GetValues(typeof(BE.Request));
            this.JacuzziComboBox.ItemsSource = Enum.GetValues(typeof(BE.Request));
            this.GardenComboBox.ItemsSource = Enum.GetValues(typeof(BE.Request));
            this.ChildrensAttractionsComboBox.ItemsSource = Enum.GetValues(typeof(BE.Request));
            this.TypeOfUnitComboBox.ItemsSource = Enum.GetValues(typeof(BE.TypeOfUnit));
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addGuestRequest(gust);
                gust = new BE.GuestRequest();
                this.DataContext = gust;
                if (gust.CollectionClearance == false)
                    gust.statusGuestRequest = StatusGuestRequest.ClosedBecauseExpired;
                else
                    gust.statusGuestRequest = StatusGuestRequest.CloseThroughTheSite;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Label_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}
