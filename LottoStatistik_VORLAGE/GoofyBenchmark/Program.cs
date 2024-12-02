using System.Diagnostics;

namespace GoofyBenchmark;

internal class Program
{
    static void Main(string[] args)
    {
        long best = long.MaxValue;
        while (true)
        {
            Stopwatch sw = Stopwatch.StartNew();

            Dictionary<int, int> dict = [];

            //Timecomplexity O(n^2)
            foreach (var line in File.ReadAllLines(@"C:\Users\QGS1FE\source\repos\LottoStatistik_VORLAGE\LottoStatistik\lottozahlen_archiv.csv").Select(line => line.Split(',')[1].Split('-')))
            {
                foreach (var item in line)
                {
                    try
                    {
                        dict[int.Parse(item)] = dict.TryGetValue(int.Parse(item), out int val) ? val + 1 : 1;
                    }
                    catch (Exception) { }
                }
            }

            sw.Stop();

            
            if (sw.ElapsedMilliseconds < best)
            {
                best = sw.ElapsedMilliseconds;
            }
            
            Console.WriteLine($"Best: {best}ms Elapsed time: {sw.ElapsedMilliseconds} ms");


            Thread.Sleep(100);
        }
    }
}
