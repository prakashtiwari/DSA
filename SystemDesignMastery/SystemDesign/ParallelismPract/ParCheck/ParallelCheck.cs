using System.Diagnostics;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public void ParallelLibTest()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            //CAlcOne();
            //CalTwo();
            Parallel.Invoke(() => { CAlcOne(); },
               () => { CalTwo(); });

            Console.WriteLine($"Elapsed ms {stopwatch.ElapsedMilliseconds}");
        }

        private void CAlcOne()
        {
            int sun = 0;
            for (int i = 0; i < 100000000; i++)
            {

                sun += i;
            }


        }
        private void CalTwo()
        {
            int sun = 0;
            for (int i = 100000000; i > 0; i--)
            {

                sun += i;
            }


        }
        public void ParallelForLoop()
        {
            GenerateStock();
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            Console.WriteLine($"Data count is {stockDatas.Count}");
            try
            {
                var result = Parallel.ForEach(
                      stockDatas, new ParallelOptions { MaxDegreeOfParallelism = 1 }, (element, parallelLoppState) =>
                      {
                          if (element.Price > 1000)
                          {
                              parallelLoppState.Break();
                              return;
                          }
                          parallelLoppState.Break();
                          Calculate(element);
                      });
            }
            catch (Exception ex)
            {
                //Parallel operation throws aggregate exception.
            }
            Console.WriteLine($"Elapsed time is in ms: {stopwatch.ElapsedMilliseconds}");
        }
        public void NormalForLoop()
        {
            GenerateStock();
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            Console.WriteLine($"Data count is {stockDatas.Count}");
            foreach (var data in stockDatas)
            {
                Calculate(data);
            }
            Console.WriteLine($"Normal loop Elapsed time is {stopwatch.ElapsedMilliseconds}");

        }
        private void Calculate(StockData data)
        {

            if (data.Company == "MSFT")
                data.Price = data.Price + (data.Price) * (decimal)(.5);
            else if (data.Company == "AZ")
                data.Price = data.Price + (data.Price) * (decimal)(.5);
            else if (data.Company == "Goog")
            {
                data.Price = data.Price + (data.Price) * (decimal)(.5);
                if (data.Price > 100)
                {
                    // throw new Exception();
                }
            }
        }
        List<StockData> stockDatas = new List<StockData>();
        public void GenerateStock()
        {
            string[] str = new string[] { "MSFT", "AZ", "Goog" };
            Random randon = new Random();
            int num = randon.Next(0, 10000000);
            for (int i = 0; i < 100000; i++)
            {
                stockDatas.Add(new StockData { Name = "MSFT" + num, Company = "MSFT", Price = num });
            }
            for (int i = 0; i < 10000; i++)
            {
                stockDatas.Add(new StockData { Name = "AZ" + num, Company = "AZ", Price = num });
            }
            for (int i = 0; i < 100000; i++)
            {
                stockDatas.Add(new StockData { Name = "Goog" + num, Company = "Goog", Price = num });
            }
        }
    }
}
