using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentCollection
{
    class Program
    {
        static void Main(string[] args)
        {

            //PlaceOrder(queue, "Ram", 5);
            //PlaceOrder(queue, "Shyam", 5);
            //This is buggy code
            // BuildOrder();
            BuildConcurrentOrder();
            Console.ReadLine();


        }
        static void BuildOrder()
        {
            var queue = new Queue<string>();
            Task t1 = Task.Run(() => PlaceOrder(queue, "Ram", 5));
            Task t2 = Task.Run(() => PlaceOrder(queue, "Shyam", 5));
            Task.WhenAll(t1, t2);

            foreach (var data in queue)
            {
                Console.WriteLine("Order is: " + data);
            }
            Console.ReadLine();
        }
        static void PlaceOrder(Queue<string> queue, string customerName, int noOfOrders)
        {
            for (int i = 1; i <= noOfOrders; i++)
            {
                Thread.Sleep(1);
                queue.Enqueue($"Customer name {customerName} - orde numb {i}");
            }
        }
        static void PlaceConcurrentOrder(ConcurrentQueue<string> queue, string customerName, int noOfOrders)
        {
            for (int i = 1; i <= noOfOrders; i++)
            {
                // Thread.Sleep(1);
                queue.Enqueue($"Customer name {customerName} - orde numb {i}");
            }
        }

        static async void BuildConcurrentOrder()
        {
            var queue = new ConcurrentQueue<string>();
            Task t1 = Task.Run(() => PlaceConcurrentOrder(queue, "Ram", 5));
            Task t2 = Task.Run(() => PlaceConcurrentOrder(queue, "Shyam", 5));
            await Task.WhenAll(t1, t2);
            int i = 1;
            Interlocked.Increment(ref i);
            Console.WriteLine(i);
            foreach (var data in queue)
            {
                Console.WriteLine("Order is: " + data);
               
            }

        }
    }
}
