using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace LottoStatistik
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEinlesen_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "CSV Files | *.csv",
                Multiselect = false,
                InitialDirectory = "C:\\Users\\QEJ1FE\\source\\repos\\github\\LottoStatistik_VORLAGE\\LottoStatistik\\"
            };
            ofd.ShowDialog();
            try
            {
                foreach (var line in File.ReadAllLines(ofd.FileName).Select(line => line.Split(',')[1].Split('-')))
                {
                    foreach (int i in line.Select(int.Parse))
                    {
                        if (dict.ContainsKey(i))
                        {
                            dict[i] = dict[i] + 1;
                        }
                        else
                        {
                            dict.Add(i, 1);
                        }
                    }
                }
            }
            catch { }

            foreach (int key in dict.Keys)
            {
                txbAusgabe.Text += $"Lottozahl: {key} -> Häufigkeit: {dict[key]}" + Environment.NewLine;
            }
        }
    }
}
