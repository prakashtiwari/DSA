using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TPL
{
    class Program
    {
        static void Main(string[] args)
        {

            Parallel.For(0, 10000, x => Concat(x));
        }
        static void Concat(int x)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string s = "";
            //s = s + " " + x;
            for (Int64 i = 0; i < 10000; i++)
            {

                s = s + " " + i;
            }
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine(s);
            Console.ReadLine();
        }
    }
}
