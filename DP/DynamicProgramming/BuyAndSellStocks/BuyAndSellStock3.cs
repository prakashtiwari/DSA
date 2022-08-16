using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.BuyAndSellStocks
{
    public class BuyAndSellStock3
    {
        public int GetMaxProfiForNTransact(int[] daysPrice, int buySell, int maxTransCap)
        {
            int totalDays = daysPrice.Length;
            int[,,] dp = new int[totalDays + 1, 2, maxTransCap];
            for (int days = totalDays - 1; days >= 0; days--)
            {
                for (int buy = 0; buy < 2; buy++)
                {
                    for (int cap = 1; cap <= 2; cap++)
                    {
                        if (buy == 1)
                        {
                            dp[days, buy, cap] = Math.Max(-daysPrice[days] + dp[days + 1, 0, cap], 0 + dp[days + 1, 1, cap]);
                        }
                        else
                        {
                            dp[days, buy, cap] = Math.Max(daysPrice[days] + dp[days + 1, 1, cap - 1], 0 + dp[days + 1, 0, cap]);
                        }
                    }
                }
            }
            return dp[0, 1, 2];
        }
        public int GetMaxProfiForKTransact(int[] daysPrice, int buySell, int maxTransCap)
        {
            int totalDays = daysPrice.Length;
            int[,,] dp = new int[totalDays + 1, 2, maxTransCap + 1];
            for (int days = totalDays - 1; days >= 0; days--)
            {
                for (int buy = 0; buy <= 1; buy++)
                {
                    for (int cap = 1; cap <= maxTransCap; cap++)
                    {
                        if (buy == 1)
                        {
                            dp[days, buy, cap] = Math.Max(-daysPrice[days] + dp[days + 1, 0, cap], 0 + dp[days + 1, 1, cap]);
                        }
                        else
                        {
                            dp[days, buy, cap] = Math.Max(daysPrice[days] + dp[days + 1, 1, cap - 1], 0 + dp[days + 1, 0, cap]);
                        }
                    }
                }
            }
            return dp[0, 1, maxTransCap];
            //TC: O(days*2*k)
        }
        //Using 2D Array
        public int GetMaxProfiForKTransactUsingTransactNo(int[] daysPrice, int buySell, int maxTransCap)
        {
            ///4 Transact: 8 Activity
            int totalDays = daysPrice.Length;
            int[,] dp = new int[totalDays + 1, 2 * maxTransCap + 1];
            for (int days = totalDays - 1; days >= 0; days--)
            {
                for (int cap = 2*maxTransCap-1; cap >=0; cap--)
                {
                    if (cap % 2 == 0)//Buy
                    {
                        dp[days, cap] = Math.Max(-daysPrice[days] + dp[days + 1, cap + 1], 0 + dp[days + 1, cap]);
                    }
                    else//Sell
                    {
                        dp[days, cap] = Math.Max(daysPrice[days] + dp[days + 1, cap + 1], 0 + dp[days + 1, cap]);
                    }

                }
            }
            return dp[0, 0];
        }
        //Space optimized.
        public int GetMaxProfiForKTransactUsingTransactNoSO(int[] daysPrice, int buySell, int maxTransCap)
        {
            int totalDays = daysPrice.Length;
            //1D DP for the space optimization.
            int[] after = new int[2 * maxTransCap + 1];
            int[] curr = new int[2 * maxTransCap + 1];
            for (int days = totalDays - 1; days >= 0; days--)
            {
                for (int cap = 2 * maxTransCap - 1; cap >= 0; cap--)
                {
                    if (cap % 2 == 0)//Buy
                    {
                        curr[ cap] = Math.Max(-daysPrice[days] + after[cap + 1], 0 + after[ cap]);
                    }
                    else//Sell
                    {
                        curr[cap] = Math.Max(daysPrice[days] + after[ cap + 1], 0 + after[cap]);
                    }
                    after = curr;

                }
            }
            return curr[0];
        }
    }
}
