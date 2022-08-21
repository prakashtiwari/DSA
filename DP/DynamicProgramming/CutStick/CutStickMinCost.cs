using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.CutStick
{
    public class CutStickMinCost
    {
        public int GetMinCost(int[] cuts, int n, int noOfCuts)
        {

            //noOfCuts + 2: Because we have added 0 and length of rod to array.
            //Sort the array
            int[,] dp = new int[noOfCuts + 2, noOfCuts + 2];
            //Starting from the last row.
            for (int i = noOfCuts; i >= 1; i--)
            {
                //J is from left to right,
                for (int j = 1; j <= noOfCuts; j++)
                {

                    if (i > j)
                    {
                        Console.WriteLine($"i {i} j {j}");
                        continue;
                    }
                    int min = int.MaxValue;
                    for (int ind = i; ind <= j; ind++)
                    {
                        Console.WriteLine("Cut point is:"+ ind+ " J is "+j+ " Cut val is:" +cuts[ind] );
                        //Length of total rope =cuts[j + 1] - cuts[i - 1].
                        //dp[i, ind - 1]: Calculated value of the left cut.
                        //dp[ind + 1, j]: Calculated value of right cut.
                        int cost = (cuts[j + 1] - cuts[i - 1]) + dp[i, ind - 1] + dp[ind + 1, j];
                        Console.WriteLine("Cut cost is:" + " cuts[j + 1] is: "+(cuts[j + 1]) + " cuts[i - 1] is "+  cuts[i - 1]+ "  Length is : " + (cuts[j + 1] - cuts[i - 1]));
                        Console.WriteLine("dp[i, ind - 1] : " + (dp[i, ind - 1]) + " dp[ind + 1, j]: " + dp[ind + 1, j]
                            +" i is "+i+ "  j is "+ j
                            );
                        min = Math.Min(min, cost);
                    }
                    Console.WriteLine($"Cost min  i :{i} j:{j} min :{min}");
                    dp[i, j] = min;

                }
            }
            return dp[1, noOfCuts];
        }
    }
}
