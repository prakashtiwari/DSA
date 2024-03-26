using DataAcces.DataConnect;
using DataAcces.DomainObject;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace AsyncPracticeDepth
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            DataConnection dataConnection = new DataConnection();
            var bag = new ConcurrentBag<List<Stocks>>();
            Stopwatch stopwatch = Stopwatch.StartNew();
            //Without async
            //Parallel.Invoke(() =>
            //{
            //    var result = dataConnection.GetStocks("Car");
            //    bag.Add(result);
            //},

            //() =>
            //{
            //    var result = dataConnection.GetStocks("LUV");
            //    bag.Add(result);
            //},
            // () =>
            // {
            //     var result = dataConnection.GetStocks("KUV");
            //     bag.Add(result);
            // },
            //  () =>
            //  {
            //      var result = dataConnection.GetStocks("MUV");
            //      bag.Add(result);
            //  },
            //   () =>
            //   {
            //       var result = dataConnection.GetStocks("TUV");
            //       bag.Add(result);
            //   },
            //   () =>
            //   {
            //       var result = dataConnection.GetStocks("SUV");
            //       bag.Add(result);
            //   }
            //);

            //This will run on differnt thread
            await Task.Run(() =>
             {
                 try
                 {
                     Parallel.Invoke(async () =>
                     {
                         var result = await dataConnection.GetStocks("Car");
                         bag.Add(result);
                         //  throw new Exception();
                     },

                     async () =>
                     {
                         var result = await dataConnection.GetStocks("LUV");
                         bag.Add(result);
                         //throw new Exception();
                     },
                      async () =>
                      {
                          var result = await dataConnection.GetStocks("KUV");
                          bag.Add(result);
                          // throw new Exception();
                      },
                       async () =>
                       {
                           var result = await dataConnection.GetStocks("MUV");
                           bag.Add(result);
                       },
                        async () =>
                        {
                            var result = await dataConnection.GetStocks("TUV");
                            bag.Add(result);
                        },
                        async () =>
                        {
                            var result = await dataConnection.GetStocks("SUV");
                            bag.Add(result);
                        }
                     );
                 }
                 catch (Exception ex)
                 {

                 }
             });
            var b = bag;
            stopwatch.Stop();
            label2.Text = stopwatch.ElapsedMilliseconds.ToString();

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            DataConnection dataConnection = new DataConnection();
            var bag = new ConcurrentBag<List<Stocks>>();
            var stocks = new Dictionary<string, List<Stocks>>
            {
                { "Car",await dataConnection.GetStocks("Car") },
                { "LUV",await dataConnection.GetStocks("LUV") },
                 { "KUV",await dataConnection.GetStocks("KUV") },
                  { "MUV",await dataConnection.GetStocks("MUV") },
                   { "TUV",await dataConnection.GetStocks("TUV") },
                   { "SUV",await dataConnection.GetStocks("SUV") }};
            Stopwatch stopwatch = Stopwatch.StartNew();
            Parallel.ForEach(stocks, (eachStk) =>
            {
                var result = ProcessEachStock(eachStk.Key, eachStk.Value);
                bag.Add(result);
            });
            stopwatch.Stop();
            label2.Text = stopwatch.ElapsedMilliseconds.ToString();
        }
        private List<Stocks> ProcessEachStock(string stk, List<Stocks> stocks)
        {
            stocks.ForEach((stk) =>
            {
                stk.Quantity = 8;
            });
            return stocks;
        }

    }
}

//LUV
//KUV       
//MUV       
//Car       
//TUV       
//SUV       