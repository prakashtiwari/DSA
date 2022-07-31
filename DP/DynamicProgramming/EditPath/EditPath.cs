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
        public int GetEditDistanceCost(string A, string B)
        {
            int cost = 0;
            //If both strings are empty, then distance to edit will be 0;
            if (string.IsNullOrEmpty(A) && string.IsNullOrEmpty(B))
            {
               // cost = s2.Length;
                return cost;
            }
            //If s1 is empty then no of character in s2 should be added.
            if (string.IsNullOrEmpty(A))
            {
                cost = B.Length;
                return cost;
            }           
            dp = new int[A.Length, B.Length];
            int l1 = A.Length;
            int l2 = B.Length;
            // cost = GetMinCostDistanceRecursive(s1, s2, l1 - 1, l2 - 1);
            cost = GetMinCostIterative(A, B, l1 - 1, l2 - 1);            
            return cost;

        }
        private int GetMinCostDistanceRecursive(string s1, string s2, int m, int n)
        {

            if (m == -1 && n == -1)
                return 0;//Both string matched, then no cost.
            else if (m == -1 && n != -1)
                return n + 1;// s2 string still have characters, but s1 is ended.
                             // So we need to add remaining characters of s2  into S1 to make it equal.
                             //s1="abc" s2="[p-0,m-1,s-2,a-3,b-4,c-5" until index 3 both will match from index  2,
                             //from where 3 chars needs to be added to s2.
            else if (m != -1 && n == -1)
                return m + 1; //m+1 chars have to be deleted to match s2, because s2 is empty but s1 is still having characters.
            if (dp[m, n] != 0)
                return dp[m, n];
            if (s1[m] == s2[n])
            {
                dp[m, n] = GetMinCostDistanceRecursive(s1, s2, m - 1, n - 1);

            }
            else
            {
                int replacement = 1 + GetMinCostDistanceRecursive(s1, s2, m - 1, n - 1);
                int del = 1 + GetMinCostDistanceRecursive(s1, s2, m - 1, n);
                int insert = 1 + GetMinCostDistanceRecursive(s1, s2, m, n - 1);
                dp[m, n] = Math.Min(replacement, Math.Min(del, insert));
            }            
            return dp[m, n];

        }
        private int GetMinCostIterative(string s1, string s2, int m, int n)
        {
            int r = s1.Length + 1;
            int c = s2.Length + 1;
            dp = new int[r, c];
            //Initialize row and column
            //Why extra row and column? Because formulae is i-1,j-1 so first row and first column should be pre calculated
            for (int i = 0; i < r; i++)
            {
                dp[i, 0] = i;
            }
            for (int j = 0; j < c; j++)
            {
                //Why
                dp[0, j] = j;
            }

            for (int i = 1; i <r; i++)
            {
                for (int j = 1; j <c; j++)
                {
                    if (s1[i-1] == s2[j-1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        //When replacing the last s1's last character to match s2's last character. Size of both string will declease.
                        int replacement = 1 + dp[i - 1, j - 1];
                        //When deleting the last s1's last character to match s2's last character. Size of s1 string will decrease.
                        int del = 1 + dp[i - 1, j];
                        int insert = 1 + dp[i, j - 1];
                        dp[i, j] = Math.Min(replacement, Math.Min(del, insert));
                    }

                }

            }
            return dp[r-1, c-1];
        }
    }
}
