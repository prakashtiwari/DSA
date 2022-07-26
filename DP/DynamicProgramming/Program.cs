using DynamicProgramming.Fibo;
using DynamicProgramming.Party;
using DynamicProgramming.SqrRoot;
using System;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Fibonicci fibonicci = new Fibonicci(5);
            //int nthFibo = fibonicci.GetFibo(5);
            //Console.WriteLine("Fibo is:" + nthFibo);
            //Nth
            int n = 1;
            //NMinSquareRoot nMinSquareRoot = new NMinSquareRoot(n);
            //Console.WriteLine("Min square root:" + nMinSquareRoot.MinNoOfSqrt(n));
            WaysOfParty waysOfParty = new WaysOfParty();
            int wayOfParty = waysOfParty.solve(17);
            Console.WriteLine("Way of party:" + wayOfParty);
            Console.ReadLine();

        }
    }
}
