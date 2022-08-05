using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.DistinctSubSeq
{
    public class DistinctSubSeqCal
    {

        int[,] dp;
        public int GetDistinctSub(string input, string pattern)
        {
            dp = new int[input.Length + 1, pattern.Length + 1];
            for (int m = 0; m <= input.Length; m++)
            {
                for (int n = 0; n <= pattern.Length; n++)
                {
                    dp[m, n] = -1;
                }
            }
            int result = GetDistinctSubSeq(input, pattern, input.Length, pattern.Length);
            return result;
        }
        public int GetDistinctSubSeq(string input, string pattern, int i, int j)
        {
            if (j == 0)
            {
                return 1;
            }
            if (i<j)
                return 0;

            if (dp[i, j] != -1)
                return dp[i, j];
            int ans = 0;
            if (input[i - 1] == pattern[j - 1])
            {
                ans = dp[i - 1, j - 1] != -1 ? dp[i - 1, j - 1] :
                    GetDistinctSubSeq(input, pattern, i - 1, j - 1);
            }
            ans += dp[i - 1, j] != -1 ? dp[i - 1, j] : GetDistinctSubSeq(input, pattern, i - 1, j);
            dp[i, j] = ans;
            return ans;
        }
        public int GetDistinctSubSeqIterative(string input, string pattern, int i, int j)
        {
            return 1;
        }

    }
}
