using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.PartitionArray
{
    public class PartitionArraySol
    {
        public int maxSubArray(int [] input, int k)
        {

            int n = input.Length;
            int[] dp = new int[input.Length+1];
            for (int ind = n - 1; ind >= 0; ind--)
            {
                int l = 0;
               // int sum = 0;
                int maxSum = int.MinValue;
                int maxSAns = int.MinValue;
                for (int j = ind; j < Math.Min((ind + k), n); j++)
                {
                    l++;
                    maxSum = Math.Max(maxSum, input[j]);
                    //dp[j + 1]: Max is already calculated
                    int sum = l * maxSum + dp[j + 1];
                    maxSAns = Math.Max(maxSAns, sum);

                }
                dp[ind] = maxSAns;
            
             
            }
            return dp[0];
        }
    }
}
