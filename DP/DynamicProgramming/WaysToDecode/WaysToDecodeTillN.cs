using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.WaysToDecode
{
    public class WaysToDecodeTillN
    {

        public int GetWaysToDecodeTillN(int A)
        {
            int[] dp = new int[A + 1];
            if (A == 1)
                dp[1] = 2;
            if (A == 2)
            {
                dp[2] = 3;
            }
            for (int i = 3; i <= A; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[A];
        }
    }
}
