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
using BL;

namespace PLWPF1
{
    /// <summary>
    /// Interaction logic for OthersLinq.xaml
    /// </summary>
    public partial class OthersLinq : Window
    {
        public static IBL MyBl;
        public OthersLinq()
        {
            InitializeComponent();
            MyBl = FactoryBL.GetBL();
        }

        private void HostingUnitByAreaButton_Click(object sender, RoutedEventArgs e)
        {
            HostingUnitByArea ho = new HostingUnitByArea();
            ho.Source = MyBl.HostingUnitByArea().ToList();
            this.Content = ho;
        }
        private void GustRequestByAreaButton_Click(object sender, RoutedEventArgs e)
        {
            GuestRequestByArea g = new GuestRequestByArea();
            g.Source = MyBl.GuestRequestByArea().ToList();
            this.Content = g;
        }
        private void GuestRequestByNumOfGuestButton_Click(object sender, RoutedEventArgs e)
        {
            GuestRequestByNumOfGuest g = new GuestRequestByNumOfGuest();
            g.Source = MyBl.GuestRequestByNumOfGuest().ToList();
            this.Content = g;
        }
    }
}
