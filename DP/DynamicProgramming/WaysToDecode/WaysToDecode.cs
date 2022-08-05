using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.WaysToDecode
{
    public class WaysToDecodeSoln
    {
        int[] dp;
        public int GetWaysToBedecoded(string s)
        {
            int length = s.Length;
            dp = new int[s.Length + 1];
            dp[0] = 1;
            dp[1] = s[0] != '0' ? 1 : 0;
            if (length == 0)
                return 0;
            else if (length == 1 && s[length - 1] == '0')
                return 0;

            //dp[length - 1] = 0;
            for (int i = 2; i < dp.Length; i++)
            {
                if (s[i-1] != '0')
                {
                    dp[i] = dp[i - 1];
                }
                int twoDigit = Convert.ToInt32(s.Substring( i-2,2));
                if (twoDigit >= 10 && twoDigit<=26)
                {
                    dp[i] += dp[i - 2];
                }
            }
            return dp[length];

        }
    }
}
