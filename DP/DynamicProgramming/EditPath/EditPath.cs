using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.EditPath
{
    public class EditDist
    {
        int[,] dp;
        public int GetEditDistanceCost(string s1, string s2)
        {
            int cost = 0;
            //If both strings are empty, then distance to edit will be 0;
            if (string.IsNullOrEmpty(s1) && string.IsNullOrEmpty(s1))
            {
                cost = s2.Length;
                return cost;
            }
            //If s1 is empty then no of character in s2 should be added.
            if (string.IsNullOrEmpty(s1))
            {
                cost = s2.Length;
                return cost;
            }
            //If s2 is empty then no of characters in s1 should be deleted to make s1 equal to s2.
            else if (string.IsNullOrEmpty(s2))
            {
                cost = s1.Length;
                return cost;
            }
            dp = new int[s1.Length, s2.Length];
            int l1 = s1.Length;
            int l2 = s2.Length;
            cost = GetMinCostDistance(s1, s2, l1 - 1, l2 - 1);
            return cost;

        }
        private int GetMinCostDistance(string s1, string s2, int m, int n)
        {

            if (m == -1 && n == -1)
                return 0;//Both string matched, then no cost.
            else if (m == -1 && n != -1)
                return n + 1;// s2 string still have characters, but s1 is ended.
                             // So we need to add remaining characters of s2  into S1 to make it equal.
                             //s1="abc" s2="[p-0,m-1,s-2,a-3,b-4,c-5" until index 3 both will match from index  2,
                             //from where 3 chars needs to be added to s2.
            else if (m != -1 && n == -1)
                return m + 1; //m+1 chars have to be deleted to match s2
            if (dp[m, n] != 0)
                return dp[m, n];
            if (s1[m] == s2[n])
            {
                dp[m, n] = GetMinCostDistance(s1, s2, m - 1, n - 1);

            }
            else
            {
                int replacement = 1 + GetMinCostDistance(s1, s2, m - 1, n - 1);
                int del = 1 + GetMinCostDistance(s1, s2, m - 1, n);
                int insert = 1 + GetMinCostDistance(s1, s2, m, n - 1);
                dp[m, n] = Math.Min(replacement, Math.Min(del, insert));
            }




            //for (int i = 1; i <= m; i++)
            //{
            //    for (int j = 1; j <= n; j++)
            //    {
            //        if (s1[i] == s2[j])
            //        {
            //            dp[i, j] = 1 + dp[i - 1, j - 1];
            //        }
            //        else
            //        {
            //            //When replacing the last s1's last character to match s2's last character. Size of both string will declease.
            //            int replacement = 1 + dp[i - 1, j - 1];
            //            //When deleting the last s1's last character to match s2's last character. Size of s1 string will decrease.
            //            int del = 1 + dp[i - 1, j];
            //            int insert = 1 + dp[i, j - 1];
            //            dp[i, j] = Math.Min(replacement, Math.Min(del, insert));
            //        }

            //    }

            //}
            return dp[m, n];

        }
    }
}
