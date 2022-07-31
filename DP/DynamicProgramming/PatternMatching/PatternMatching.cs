using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.PatternMatching
{
    public class PatternMatchingSol
    {
        Boolean[,] dp;
        int[,] dpComp;
        public bool IsMatch(string s1, string s2)
        {
            int l1 = s1.Length;
            int l2 = s2.Length;
            dp = new Boolean[l1, l2];
            dpComp = new int[l1, l2];
            return IsPatternMatchIteration(s1, s2, l1 - 1, l2 - 1);
        }
        public int MatchPattern(string s1, string s2)
        {
            int l1 = s1.Length;
            int l2 = s2.Length;
            dp = new Boolean[l1, l2];
            return PatternMatchIteration(s1, s2, l1 - 1, l2 - 1);
        }
        int PatternMatchIteration(string s1, string s2, int m, int n)
        {
            if (m == -1 && n == -1)
                return 1;
            if (m < 0)//string is empty but pattern is still having characters.
            {
                for (int i = 0; i < n; i++)
                {
                    if (s2[i] != '*')
                        return 0;

                }
                return 1;
            }
            if (n < 0)
            {
                Console.WriteLine($"Second string length is:{ n}");
                return 0;
            }
            if (dpComp[m, n] == 1)
                return dpComp[m, n];

            if (s1[m] == s2[n] || s2[n] == '?')
            {
                Console.WriteLine($"Return is when 2 char equal :left {m - 1} right {n - 1}");
                return PatternMatchIteration(s1, s2, m - 1, n - 1);
            }
            if (s2[n] == '*')
            {

               return  PatternMatchIteration(s1, s2, m - 1, n)==1?1: PatternMatchIteration(s1, s2, m, n - 1);
               // return dpComp[m, n];
            }
            Console.WriteLine($"Return is is:{ dp[m, n]}");           
            return dpComp[m,n]=0;

        }
        public bool IsPatternMatchIteration(string s1, string s2, int m, int n)
        {
            if (m == -1 && n == -1)
                return true;
            //s1="", s2="*?"
            if (m < 0)//string is empty but pattern is still having characters.
            {
                for (int i = 0; i < n; i++)
                {
                    if (s2[i] != '*')
                        return false;

                }
                return true;
            }
            //s2="", s1="ab"
            if (n < 0)
            {
                Console.WriteLine($"Second string length is:{ n}");
                return false;
            }
            if (dp[m, n] == true)
                return dp[m, n];

            if (s1[m] == s2[n] || s2[n] == '?')
            {
                Console.WriteLine($"Return is when 2 char equal :left {m - 1} right {n - 1}");
                return IsPatternMatchIteration(s1, s2, m - 1, n - 1);
            }
            if (s2[n] == '*')
            {
                // s1="abc",s2="ab*"
                // s1="abc",s2="ab"
                return IsPatternMatchIteration(s1, s2, m - 1, n) || IsPatternMatchIteration(s1, s2, m, n - 1);
            }
            Console.WriteLine($"Return is is:{ dp[m, n]}");
            return dp[m, n] = false;
        }
    }
}
