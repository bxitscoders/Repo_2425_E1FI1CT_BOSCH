using System.Windows;

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
            new IPV4("0,0,0,0");
        }

        private void btnBerechne_Click(object sender, RoutedEventArgs e)
        {
            //    dgSubnetze.ItemsSource = null;
            subnetze.BerechneSubnetze((bool) chbVLSM.IsChecked, txbStartIP.Text);
            //    dgSubnetze.ItemsSource = subnetze.DataGridFormats;
        }
    }
}