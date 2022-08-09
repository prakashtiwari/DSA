using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.MinFallingPathSum
{
    public class MinFallingPathSumSoln
    {       
        public int GetMinFallingPathSum(int[,] path, int r, int c)
        {
           
            int result = 0;
            result = GetMinFallingPath(path, r, c);
            return result;
        }
        public int GetMinFallingPath(int[,] path, int m, int n)
        {
          
           
            for (int i = 1; i < m; i++)
            {
               
                for (int j = 0; j < n; j++)
                {
                    int min = int.MaxValue;
                    for (int k = 0; k < n; k++)
                    {
                        if (k != j && path[i-1,k] <min)
                        {
                            min = Math.Min(min, path[i-1,k]); //Getting the min of above row
                           
                        }
                    }
                    Console.WriteLine("Min is : " + min);

                   path[i, j] += min;//Min of above row is getting added to current row
                    Console.WriteLine("I and J is I is : " + i + " j:  " + j + "  Min is: " + path[i, j]);
                }
                
            }
           int minPath = int.MaxValue;
            for (int j = 0; j < n; j++)
            {
                minPath = Math.Min(minPath, path[m - 1, j]);


            }
            return minPath;

        }

    }
}
