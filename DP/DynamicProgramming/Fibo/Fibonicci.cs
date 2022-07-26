using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Fibo
{
    public class Fibonicci
    {
        int number = 0;
        int[] fib;
        public Fibonicci(int N)
        {
            number = N;
            fib = new int[number+1];
            fib[0] = 0; fib[1] = 1;
            for (int i = 2; i <= number; i++)
            {
                fib[i] = -1;
            }
           
        }

        public int GetFibo(int n)
        {
            //if (n <= 0)
            //    return 1;
            if (fib[n] != -1)
                return fib[n];
            for (int i = 2; i <= number; i++)
            {

                fib[i] = fib[i - 2] + fib[i - 1];
            }
            return fib[n];
        }
    }
}
