using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.LongestIncreasingSubseq
{
    public class LongestIncreasingSubSeq
    {
        int[] dp;
        public int GetLongestIncreasingSubSeq(int[] arr)
        {
            int arLen = arr.Length;
            int maxSub = 0;
            dp = new int[arr.Length];
            //For 0th element longest increasing subsequence will be 1
            dp[0] = 1;
            for (int i = 1; i < arLen; i++)
            {
                maxSub = 0;//For each element get the max LIS.
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] < arr[i])//Get the max subsequence of th number, smaller yhan the current one.
                        maxSub = Math.Max(maxSub, dp[j]);

                }
                dp[i] = maxSub + 1;
            }
            maxSub = 0;
            for (int i = 0; i < dp.Length; i++)
            {
                maxSub = Math.Max(maxSub, dp[i]);
            }
            return maxSub;
        }
    }
}
