using StringPractice.ProbAndSolution;
using System;

namespace StringPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            ReverseString reverseString = new ReverseString();
            string result = reverseString.GetReverseString("prakash");
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
