using System.Diagnostics;

namespace ParallelismPract.ParCheck
{
    public class ParallelCheck
    {

        public void ParallelTest()
        {
            Stopwatch sw = Stopwatch.StartNew();
            int res = 0;
            Parallel.For(0, 100000000, (i) =>
            {
                res += i;
            });
            sw.Stop();
            Console.WriteLine($"Time elapsed par {sw.Elapsed}");

        }
        public void NonParTest()
        {
            Stopwatch sw = Stopwatch.StartNew();
            int res = 0;
            for (int i = 0; i < 100000000; i++)
            {

                res += i;
            };
            sw.Stop();
            Console.WriteLine($"Time  elapsed non par {sw.Elapsed}");

        }
    }
}
