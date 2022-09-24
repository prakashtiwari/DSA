using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySolution.SubArraySum
{
    public class MaxSubArraySum
    {
        public int GetMaxSubArraySum(int[] input)
        {
            int maxSum = int.MinValue;
            int n = input.Length;

            for (int i = 0; i < n; i++)
            {
                int sum = 0;
               
                for (int j = i; j < n; j++)
                {
                    Console.WriteLine("Sum:" + sum);
                    sum = sum + input[j];
                    maxSum = Math.Max(sum, maxSum);
                }

            }
            return maxSum;
        }
    }
}
