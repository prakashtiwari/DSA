using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.PrincessAndDungeon
{
    public class PrincessInDungeon
    {

        int rowLen = 0;
        int colLen = 0;
        int[,] dp;
        public int calculateMinimumHP(List<List<int>> A)
        {
            rowLen = A.Count;
            colLen = A[0].Count;
            dp = new int[rowLen, colLen];
            for (int m = 0; m < rowLen; m++)
            {
                for (int n = 0; n < colLen; n++)
                {
                    dp[m, n] = -1;
                }
            }
            return calculateMin(A, 0, 0);
        }
        public int calculateMin(List<List<int>> A, int i, int j)
        {
            if (i == rowLen - 1 && j == colLen - 1)
            {
                return dp[i, j];
            }
            if (i == A.Count || j == A[0].Count)
                return int.MaxValue;
            if (dp[i, j] != -1)
                return dp[i, j];
           

            dp[i, j] = Math.Max(1,
                                 Math.Min(calculateMin(A, i + 1, j), calculateMin(A, i, j + 1)) - A[i][j]);
            return dp[i, j];
        }

    }
}
