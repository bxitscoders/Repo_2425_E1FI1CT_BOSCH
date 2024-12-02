using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace LottoStatistik
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] _lottozahlen = new int[50];
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEinlesen_Click(object sender, RoutedEventArgs e)
        {
            int lineCounter = 0;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();

            FileStream fs =...
            StreamReader sr =...
            
            while ()
            {
                ...
            }

            //Ausgabe
            //.Length gibt die aktuelle Länge des Arrays an. Hier also 50.
            for (int lz = 1; lz < _lottozahlen.Length; lz++)
            {
                txbAusgabe.Text += $"Lottozahl: {lz} -> Häufigkeit: {_lottozahlen[lz]}" + Environment.NewLine;
            }


        }
    }
}
