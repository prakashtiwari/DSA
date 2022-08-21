using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.BurstBaloon
{
    public class BurstBallonMaxCostSoln
    {
        public int GetBurstBallonMaxCost(int [] baloonsI)
        {
            int len = baloonsI.Length+2;
            int[] baloons = new int[len];
            Array.Copy(baloonsI,0, baloons,1, baloonsI.Length);
            baloons[0] = 1;
            baloons[len-1] = 1;
            int[,] dp = new int[len , len ];
            //Starting from bottom up
            for (int left = len - 2; left >= 1; left--)
            {
                for (int right = left; right <= len - 2; right++)
                {
                    //Window
                   // int maxGain = 0;
                    for (int i = left; i <= right; i++)
                    {
                        //Formula=(i-1)*i*(i+1)
                        int gain = baloons[left - 1] * baloons[i] * baloons[right+1];
                        Console.WriteLine($"Taversing Matrix: left - 1: {left - 1} value is {baloons[left - 1]}" +
                            $" i ={i} value is {baloons[i]} right+1:{right + 1} value is {baloons[right + 1]} gain is : {gain}");
                        int remaining = dp[left, i - 1] + dp[i + 1, right];
                        dp[left, right] = Math.Max(gain+remaining,dp[left,right]);
                    }
                }
            }
            return dp[1,len-2];
        }
    }
}
