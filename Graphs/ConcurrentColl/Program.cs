using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentColl
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            // var orderQueue = new Queue();
            var orderQueue = new ConcurrentQueue<string>();
            Task t1 = Task.Run(() => PlaceOrder(orderQueue, "Xavier", 5));
            Task t2 = Task.Run(() => PlaceOrder(orderQueue, "Ramadevi", 5));
            Task.WaitAll(t1,t2);
            foreach (string s in orderQueue)
            {
                Console.WriteLine("Order is:" + s);
            }

        }
        static void PlaceOrder(ConcurrentQueue<string> queue, string customerName, int noOforders)
        { 
          for(int i=0;i<noOforders;i++)
            {
                Thread.Sleep(1);
                string orderName = $"{customerName} wants no of orders {i}";
                queue.Enqueue(orderName);

            }
        
        }


    }
}
