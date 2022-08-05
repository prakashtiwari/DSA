﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Knapsack
{
    public class ZeroOneKnapsack
    {
        int[,] dp;
        int[] happiness;
        int[] availableWeights;
        int[] selectedWeights;
        public int GetMaxVal(int[] weights, int[] val, int maxWeight, int numOfItems)
        {
            int totalWeight = maxWeight + 1;
            int numbOfItems = numOfItems + 1;
            availableWeights = weights;
            happiness = val;
            dp = new int[numbOfItems, totalWeight];
            int max = 0;
            max = GetMaxHappiness(numOfItems, maxWeight);
            // max = GetMaxZeroInfiniteKnapsack(numOfItems, maxWeight);
            selectedWeights = new int[availableWeights.Length];
            SelectedItems(numOfItems, maxWeight);
            return max;
        }
        private void SelectedItems(int n, int givenWeight)
        {
            while (n >= 1 && givenWeight >= 1)
            {
                if (dp[n, givenWeight] == dp[n - 1, givenWeight])
                {

                    n = n - 1;
                    selectedWeights[n] = availableWeights[n]; //dp[n, givenWeight];
                }
                else
                {
                    n = n - 1;
                    givenWeight = givenWeight - availableWeights[n];
                    selectedWeights[n] = availableWeights[givenWeight];// dp[n, givenWeight];

                }


            }
        }
        public int GetMaxHappiness(int n, int givenWeight)
        {
            if (n == 0 || givenWeight == 0)
            {   //No item or no weight, so return 0
                return 0;
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= givenWeight; j++)
                {
                    dp[i, j] = dp[i - 1, j];
                    if (j >= availableWeights[i - 1])
                    {
                        Console.WriteLine("Current weight:" + availableWeights[i - 1]);
                        dp[i, j] = Math.Max(dp[i, j], (dp[i - 1, j - availableWeights[i - 1]] + happiness[i - 1]));
                        Console.WriteLine("J is " + j);
                    }
                }
            }//Final result will be stored at last row and last column.
            return dp[n, givenWeight];
        }
        /// <summary>
        /// Zero infinite knapsack
        /// </summary>
        /// <param name="n"></param>
        /// <param name="givenWeight"></param>
        /// <returns></returns>
        public int GetMaxZeroInfiniteKnapsack(int n, int givenWeight)
        {

            if (n == 0 || givenWeight == 0)
            {   //No item or no weight, so return 0
                return 0;
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= givenWeight; j++)
                {
                    dp[i, j] = dp[i - 1, j];
                    if (j >= availableWeights[i - 1])
                    {
                        Console.WriteLine("Current weight:" + availableWeights[i - 1]);
                        //we can pick same item multiple times, so no need i-1
                        dp[i, j] = Math.Max(dp[i, j], (dp[i, j - availableWeights[i - 1]] + happiness[i - 1]));
                        Console.WriteLine("J is " + j);
                    }
                }
            }//Final result will be stored at last row and last column.
            return dp[n, givenWeight];
        }
    }
}