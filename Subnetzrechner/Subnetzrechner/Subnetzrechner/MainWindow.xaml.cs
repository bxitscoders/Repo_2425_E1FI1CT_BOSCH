using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Subnetzrechner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SubnetzVerwaltung subnetze = new SubnetzVerwaltung();
        public MainWindow()
        {
            InitializeComponent();

            dgSubnetze.ItemsSource = subnetze.DataGridFormats;
        }

        private void btnBerechne_Click(object sender, RoutedEventArgs e)
        {
        //    dgSubnetze.ItemsSource = null;
            subnetze.BerechneSubnetze((bool)chbVLSM.IsChecked, txbStartIP.Text);
        //    dgSubnetze.ItemsSource = subnetze.DataGridFormats;
        }
    }
}