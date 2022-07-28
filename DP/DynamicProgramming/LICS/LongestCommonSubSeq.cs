using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.LICS
{
    public class LongestCommonSubSeq
    {
        int[,] dp;
        public int GetLongestCommonSubSeq(string s1, string s2)
        {
            int i = s1.Length;
            int j = s2.Length;
            dp = new int[s1.Length, s2.Length];
            for (int m = 0; m < i; m++)
            {
                for (int n = 0; n < j; n++)
                {
                    dp[m, n] = -1;

                }
            }
            // int longestLics = GetLongestSubsequence(s1, s2, i - 1, j - 1);
            int longestLics = GetLongestSubsequenceIterative(s1, s2, i - 1, j - 1);
            //   var output = GetLicsString(i - 1, j - 1, s1, s2, longestLics).Reverse<char>();
            return longestLics;
        }
        string GetLicsString(int i, int j, string s1, string s2, int longestLics)
        {
            string s = "";
            while (i > 0 && j > 0 && longestLics >= 0)
            {
                if (s1[i] == s2[j])
                {
                    s = s + s1[i];
                    i--;
                    j--;
                }
                else if (s1[i] != s2[j])
                {
                    if ((dp[i, j - 1] == dp[i - 1, j]) && dp[i, j - 1] != -1 && dp[i - 1, j] != -1)
                    {
                        // s = s + s1[i];
                        i--;
                        //longestLics--;
                    }
                    if (dp[i, j - 1] > dp[i - 1, j])
                    {
                        // s = s + s1[i];
                        j--;
                        longestLics--;
                        Console.WriteLine(i);
                    }
                    else if (dp[i - 1, j] > dp[i, j - 1])
                    {
                        //  s = s + s2[j];
                        Console.WriteLine("J is" + j);
                        i--;
                        longestLics--;
                    }
                }

                Console.WriteLine("J is" + j + "I is" + i);

            }
            return s;
        }
        //Recursive solution
        private int GetLongestSubsequence(string s1, string s2, int i, int j)
        {
            //string is empty.
            if (i == -1 || j == -1)
                return 0;
            if (dp[i, j] != -1)
                return dp[i, j];
            if (s1[i] == s2[j])
            {
                dp[i, j] = 1 + GetLongestSubsequence(s1, s2, i - 1, j - 1);
            }
            else
            {
                dp[i, j] = Math.Max(GetLongestSubsequence(s1, s2, i, j - 1), GetLongestSubsequence(s1, s2, i - 1, j));
            }
            return dp[i, j];
        }
        private int GetLongestSubsequenceIterative(string s1, string s2, int i, int j)
        {
            for (int p = 0; p <= j; p++)
            {
                if (s1[0] == s2[p])
                {
                    dp[0, p] = 1;
                }
                else
                {
                    dp[0, p] = 0;
                }
            }
            for (int p = 0; p <= i; p++)
            {
                if (s2[0] == s1[p])
                {
                    dp[p, 0] = 1;
                }
                else
                {
                    dp[p, 0] = 0;
                }
            }

            for (int m = 1; m <= i; m++)
            {
                for (int n = 1; n <= j; n++)
                {
                    if (s1[m] == s2[n])
                    {

                        dp[m, n] = 1 + dp[m - 1, n - 1];
                    }
                    else
                    {
                        dp[m, n] = Math.Max(dp[m, n - 1], dp[m - 1, n]);

                    }

                }
            }


            return dp[i, j];
        }
    }
}


