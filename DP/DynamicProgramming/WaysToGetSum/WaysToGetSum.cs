using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.WaysToGetSumSol
{
    public class WaysToGetSum
    {
        int[] dp;
        public int GetWays(int[] data, int target)
        {
            dp = new int[target+ 1];
            dp[0] = 1;//Theere is one way to get Sum upto 0
            for (int i = 1; i <= target; i++)
            {
                foreach (int eachArrItem in data)
                {
                    if (i - eachArrItem >= 0)
                    {
                        dp[i] += dp[i- eachArrItem];
                    }

                }
            }
            return dp[target];
        }
    }
}
