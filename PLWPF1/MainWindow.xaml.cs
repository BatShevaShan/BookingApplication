using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLWPF1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void GustRequestButton_Click(object sender, RoutedEventArgs e)
        {
            Window GustRequestWindow = new GustRequestWindow();
            GustRequestWindow.Show();
        }
        private void HostingUnitButton_Click(object sender, RoutedEventArgs e)
        {
            Window HostingUnitWindow = new HostingUnitWindow();
            HostingUnitWindow.Show();
        }
        private void DirectorButton_Click(object sender, RoutedEventArgs e)
        {
            Window DirectorWindow = new DirectorWindow();
            DirectorWindow.Show();
        }
        


    }
}