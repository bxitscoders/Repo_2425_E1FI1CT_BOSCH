using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace LottoStatistik;

/// <summary>
/// Interaktionslogik für MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    Dictionary<int, int> lottoZahlen = new();

    public MainWindow()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Arbeitszeitbetrugs methode
    /// </summary>
    /// <param name="sender">Der Arbeitszeitbetrüger</param>
    /// <param name="e">Weitere Informationen zum Arbeitszeitbetrug</param>
    private void btnEinlesen_Click(object sender, RoutedEventArgs e)
    {

        OpenFileDialog ofd = new OpenFileDialog()
        {
            InitialDirectory = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName
        };
        ofd.ShowDialog();

        Stopwatch sw = Stopwatch.StartNew();

        for (int i = 1; i < 50; i++)
        {
            lottoZahlen[i] = 0;
        }

        foreach (string line in File.ReadAllLines(ofd.FileName))
        {
            try
            {
                int[] zahlen = line.Split(",")[1].Split("-").Select(int.Parse).ToArray();

                foreach (int zahl in zahlen)
                {
                    if (!lottoZahlen.TryGetValue(zahl, out int count))
                    {
                        count = 0;
                    }

                    lottoZahlen[zahl] = count + 1;
                }
            }
            catch(Exception)
            {

            }
        }

        sw.Stop();
        MessageBox.Show($"Took {sw.ElapsedMilliseconds}ms", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

        //Ausgabe
        //.Length gibt die aktuelle Länge des Arrays an. Hier also 50.
        foreach (var (zahl, anzahl) in lottoZahlen)
        {
            txbAusgabe.Text += $"Lottozahl: {zahl} -> Häufigkeit: {anzahl}" + Environment.NewLine;
        }


    }
}
