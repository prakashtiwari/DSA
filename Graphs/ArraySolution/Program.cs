using ArraySolution.NextGreater;
using System;

namespace ArraySolution
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            NextGreaterElementInArray nextGreater = new NextGreaterElementInArray();
            int[] input = new int[] {4,12,5,3,1,2,5,3,1,2,4,6 };
            nextGreater.GetNextGreaterElement(input);
        }
    }
}
