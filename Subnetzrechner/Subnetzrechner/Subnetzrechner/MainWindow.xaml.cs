using System.Windows;
using System.Windows.Controls;

namespace Subnetzrechner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SubnetzVerwaltung subnetze = new SubnetzVerwaltung();
        private IPV4 ipv4 = new IPV4();
        public MainWindow()
        {
            InitializeComponent();

            dgSubnetze.ItemsSource = subnetze.DataGridFormats;
        }

        private void btnBerechne_Click(object sender, RoutedEventArgs e)
        {
            bool richtigeAnzahl = false;
            foreach (var item in subnetze.DataGridFormats)
            {
                if (int.TryParse(item.GeraeteAnzahl, out int i))
                {
                    richtigeAnzahl = true;
                }
                else
                {
                    richtigeAnzahl = false;
                }
            }

            if (richtigeAnzahl)
            {
                lblFehler.Content = "";
                dgSubnetze.ItemsSource = null;
                subnetze.BerechneSubnetze((bool)chbVLSM.IsChecked, txbStartIP.Text);
                dgSubnetze.ItemsSource = subnetze.DataGridFormats;
            }
            else
            {
                lblFehler.Content = "Falsche Anzahl an Geraeten eingegeben";
            }

        }

        private void txbStartIP_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ipv4.CheckIP(txbStartIP.Text))
            {
                btnBerechne.IsEnabled = true;
                lblFehler.Content = "";
            }
            else
            {
                btnBerechne.IsEnabled = false;
                lblFehler.Content = "Falsche Start IP";
            }
        }
    }
}