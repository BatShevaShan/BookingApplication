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
    /// Interaction logic for HostingUnitWindow.xaml
    /// </summary>
    public partial class HostingUnitWindow : Window
    {
        public HostingUnitWindow()
        {
            InitializeComponent();
        }
        private void AddHostingUnitButton_Click(object sender, RoutedEventArgs e)
        {
            Window AddHostingUnit = new AddHostingUnit();
            AddHostingUnit.Show();
        }
        private void PrivateAreaButton_Click(object sender, RoutedEventArgs e)
        {
            Window PrivateAreaWindow = new PrivateAreaWindow();
            PrivateAreaWindow.Show();
        }
        
    }
}
