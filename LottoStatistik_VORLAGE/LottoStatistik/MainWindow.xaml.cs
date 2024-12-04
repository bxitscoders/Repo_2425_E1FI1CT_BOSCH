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
            HandleMethod2();
        }

        private void HandleMethod1()
        {
            OpenFileDialog ofd = new()
            {
                Filter = "CSV Files | *.csv",
                Multiselect = false,
                InitialDirectory = "C:\\Users\\QEJ1FE\\source\\repos\\github\\LottoStatistik_VORLAGE\\LottoStatistik\\",

            };
            ofd.ShowDialog();

            Dictionary<int, int> dict = [];
            Stopwatch stopwatch = new();
            int aProc = 0, sProc = 0;

            stopwatch.Start();

            for (int i = 1; i <= 50; i++)
            {
                dict.Add(i, 0);
            }

            foreach (var line in File.ReadAllLines(ofd.FileName).Select(line => line.Split(',')[1].Split('-')))
            {
                foreach (var item in line)
                {
                    try
                    {
                        aProc++;
                        if (int.Parse(item) > 50 || int.Parse(item) < 1) continue;
                        dict[int.Parse(item)] = dict.TryGetValue(int.Parse(item), out int val) ? val + 1 : 1;
                        sProc++;
                    }
                    catch (Exception) { }
                }
            }

            //int[] keys = [.. dict.Keys.ToArray().OrderByDescending(i => i)];

            stopwatch.Stop();

            lblStatistik.Content = $"Algorithm complexity 'O(n^2)'     Took: {stopwatch.Elapsed.TotalNanoseconds}ns / {stopwatch.Elapsed.TotalMilliseconds}ms     Objects: {sProc}/{aProc}";

            foreach (int key in dict.Keys)
            {
                txbAusgabe.Text += $"Lottozahl: {key} -> Häufigkeit: {dict[key]}" + Environment.NewLine;
            }
        }

        private void HandleMethod2()
        {
            OpenFileDialog ofd = new()
            {
                Filter = "CSV Files | *.csv",
                Multiselect = false,
                InitialDirectory = "C:\\Users\\QEJ1FE\\source\\repos\\github\\LottoStatistik_VORLAGE\\LottoStatistik\\",

            };
            ofd.ShowDialog();

            int[] arr = new int[50];
            int aProc = 0, sProc = 0;

            Stopwatch stopwatch = new();
            stopwatch.Start();

            foreach (var line in File.ReadAllLines(ofd.FileName).Select(line => line.Split(',')[1].Split('-')))
            {
                foreach (var item in line)
                {
                    try
                    {
                        aProc++;
                        sProc++;
                        if (int.Parse(item) > 50 || int.Parse(item) < 1) continue;
                        arr[int.Parse(item)]++;
                    }
                    catch (Exception) 
                    {
                        sProc--;
                    }
                }
            }

            stopwatch.Stop();

            lblStatistik.Content = $"Algorithm complexity 'O(n^2)'     Took: {stopwatch.Elapsed.TotalNanoseconds}ns / {stopwatch.Elapsed.TotalMilliseconds}ms     Objects: {sProc}/{aProc}";

            for(int i = 1; i < arr.Length; i++) {
                txbAusgabe.Text += $"Lottozahl: {i} -> Häufigkeit: {arr[i]}" + Environment.NewLine;
            }
        }
    }
}
