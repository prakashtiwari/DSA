using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.DivideIntoSubset
{
    public class DevideIntoEqualSum
    {
        //public bool canDivideEqualSubset(int[] nums)
        //{
        //    int n = 0;
        //    int sum = 0;
        //    int eleCount = nums.Length;
        //    for (int i = 0; i < eleCount; i++)
        //    {
        //        sum = sum + nums[i];
        //    }
        //    if (sum % 2 != 0)
        //    {
        //        return false;

        //    }
        //    bool[,] dp = new bool[eleCount+1, sum / 2 + 1];
        //    for (int i = 0; i <= eleCount; i++)
        //    {
        //        for (int j = 0; j <= sum / 2; j++)
        //        {
        //            if (i == 0 || j == 0)
        //                dp[i, j] = false;
        //            else if (nums[i - 1] > j)
        //            {
        //                Console.WriteLine("Num is:" + nums[i - 1] +"J is"+ j);
        //                dp[i, j] = dp[i - 1, j];
        //            }
        //            else if (nums[i - 1] == j)
        //            {
        //                Console.WriteLine("Num is:" + nums[i - 1] + "J is" + j);
        //                dp[i, j] = true;
        //            }
        //            else
        //            {
        //                dp[i, j] = dp[i - 1, j] || dp[i - 1, j - nums[i-1]];
        //            }

        //        }
        //    }
        //    return dp[eleCount, sum / 2];
        //}
        public bool canDivideEqualSubset(int[] nums)
        {
            int n = 0;
            int sum = 0;
            int eleCount = nums.Length;
            for (int i = 0; i < eleCount; i++)
            {
                sum = sum + nums[i];
            }
            if (sum % 2 != 0)
            {
                return false;

            }
            TargetK targetK = new TargetK();
            return targetK.CanTargetBeAchieved(nums, sum / 2);


        }


    }
}
