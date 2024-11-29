using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "CSV Files | *.csv",
                Multiselect = false,
                InitialDirectory = "C:\\Users\\QEJ1FE\\source\\repos\\github\\LottoStatistik_VORLAGE\\LottoStatistik\\"
            };
            ofd.ShowDialog();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Dictionary<int, int> dict = new Dictionary<int, int>();

            //Timecomplexity O(n^2)
            int aProc = 0, sProc = 0;
            foreach (var line in File.ReadAllLines(ofd.FileName).Select(line => line.Split(',')[1].Split('-')))
            {
                foreach (var item in line)
                {
                    try
                    {
                        aProc++;
                        dict[int.Parse(item)] = dict.TryGetValue(int.Parse(item), out int val) ? val + 1 : 1;
                        sProc++;
                    }
                    catch (Exception) { }
                }
            }
            int[] ints = dict.Keys.ToArray();
            Array.Sort(ints);

            stopwatch.Stop();

            lblStatistik.Content = $"Algorithim complexity 'O(n^2)'     Took: {stopwatch.ElapsedMilliseconds}ms     Objects: {sProc}/{aProc}";
            foreach (int key in ints.Reverse())
            {
                txbAusgabe.Text += $"Lottozahl: {key} -> Häufigkeit: {dict[key]}" + Environment.NewLine;
            }
        }
    }
}
