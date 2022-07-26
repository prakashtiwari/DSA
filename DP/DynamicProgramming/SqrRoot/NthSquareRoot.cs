using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.SqrRoot
{
    public class NMinSquareRoot
    {
        int number = 0;
        public int[] minStore;
        public NMinSquareRoot(int num)
        {
            number = num;
            minStore = new int[num + 1];
            for (int i = 0; i <= num; i++)
            {
                minStore[i] = -1;
            }


        }
        public int MinNoOfSqrt(int n)
        {

            if (n == 0)
                return 0;

            if (minStore[n] != -1)
            {
                return minStore[n];
            }
            minStore[n] = 1;
            int ans = int.MaxValue;
            Console.WriteLine("N is: " + n);
            for (int i = 1; i * i <= n; i++)
            {
                Console.WriteLine("Choosen path is: remain is n-i*i: " + (n - i * i));
                ans = Math.Min(ans, MinNoOfSqrt(n - i * i));
            }
            minStore[n] += ans;
            Console.WriteLine("Min is: " + minStore[n]);
            return minStore[n];
        }
    }
}
