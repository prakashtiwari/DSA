using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.DivideIntoSubset
{
    public class TargetK
    {
        bool[,] dp;
        public bool CanTargetBeAchieved(int[] arr, int k)
        {
            int n = arr.Length;
            //Base cases
            dp = new bool[arr.Length, k + 1];
            dp[0, arr[0]] = true;
            Console.WriteLine("Base case:" + arr[0]);
            for (int i = 0; i < n; i++)
            {
                dp[i, 0] = true;

            }
            for (int i = 1; i < n; i++)
            {
                for (int target = 1; target <= k; target++)
                {
                    bool notPick = dp[i - 1, target];
                    bool pick = false;
                    //Console.WriteLine("Check indexes: Target is :" + target + " Index is:" + (i-1) + "notPick val: "+ notPick);
                    //Console.WriteLine("Target j to be achieved: " + target + " Available Value in array:" + arr[i]);
                    if (target >= arr[i])
                    {
                        pick = dp[i - 1, target - arr[i]];
                        Console.WriteLine("Picked: " + dp[i - 1, target - arr[i]] + " row is: " + (i - 1) + " target - arr[i] is " + (target - arr[i]));
                    }

                    // Console.WriteLine("For item i: " + i + "  target value j: "+target+" Item val  "+arr[i]+" can be:" + (pick ? " Picked" : " Not Picked"));
                    dp[i, target] = notPick || pick;

                }
            }
            return dp[n - 1, k];
        }
        public int MinDiff(int[] arr, int totalSum)
        {
            int min = int.MaxValue;
            if (this.CanTargetBeAchieved(arr, totalSum))
            {
             
                for (int i = 0; i <= totalSum; i++)
                {
                    if (dp[arr.Length - 1, i] == true)
                    {
                        int s1 = i;
                        int s2 = totalSum - i;
                        min = Math.Min(min, s2 - s1);
                    }
                
                }            
            }
            return min;        
        }

    }
}
