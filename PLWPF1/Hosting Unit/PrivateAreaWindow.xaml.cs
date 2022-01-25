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
    /// Interaction logic for PrivateAreaWindow.xaml
    /// </summary>
    public partial class PrivateAreaWindow : Window
    {
        public PrivateAreaWindow()
        {
            InitializeComponent();
        }
        private void UpdateUnitButton_Click(object sender, RoutedEventArgs e)
        {
            Window UpdateUnitWindow = new UpdateUnitWindow();
            UpdateUnitWindow.Show();
        }
        private void RemoveUnitButton_Click(object sender, RoutedEventArgs e)
        {
            Window RemoveUnitWindow = new RemoveUnitWindow();
            RemoveUnitWindow.Show();
        }
        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            Window OrderWindow = new OrderWindow();
            OrderWindow.Show();
        }
    }
}
