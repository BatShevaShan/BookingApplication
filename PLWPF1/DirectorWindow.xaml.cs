using BL;
using System.Linq;
using System.Windows;
namespace PLWPF1
{
    /// <summary>
    /// Interaction logic for DirectorWindow.xaml
    /// </summary>
    public partial class DirectorWindow : Window
    {
         BL.IBL MyBl;
        public DirectorWindow()
        {
            InitializeComponent();
            MyBl = FactoryBL.GetBL();
        }
        private void OthersButton_Click(object sender, RoutedEventArgs e)
        {
            Window OthersLinq = new OthersLinq();
            OthersLinq.Show();
        }
        private void AllGuestRequestButton_Click(object sender, RoutedEventArgs e)
        {
            AllGuestRequestUserControl g = new AllGuestRequestUserControl();
            g.Source = MyBl.AllGuestRequest().ToList();
            this.Content = g;
        }

        private void AllHostingUnitButton_Click(object sender, RoutedEventArgs e)
        {
            AllHostingUnitUserControl ho = new AllHostingUnitUserControl();
            ho.Source = MyBl.AllHostingUnit().ToList();
            this.Content = ho;
        }

        private void AllOrderButton_Click(object sender, RoutedEventArgs e)
        {
            AllOrderUserControl o = new AllOrderUserControl();
            o.Source = MyBl.AllOrder().ToList();
            this.Content = o;
        }
    }
}
