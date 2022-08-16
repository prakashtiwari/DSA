using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.BuyAndSellStocks
{
    public class BuyAndSellStocks2
    {
        public long GetMaxProfit(int[] stocks)
        {
            int len = stocks.Length;
            long[,] dp = new long[len + 1, 2];
            dp[len, 0] = 0;//At the last day we cannot buy.
            dp[len, 1] = 0;//There will not be any profit on the last day. We can only sell on last day.
            for (int day = (len - 1); day >= 0; day--)
            {
                for (int buy = 0; buy < 2; buy++)
                {
                    long profit = 0;
                    if (buy == 1)
                    {
                        //-stocks[day] + dp[day + 1, 0]: When buying the stock on the particular day, so spending money thats why negative.
                        //0 + dp[day + 1, 1]: Not buying stock next day, so amount is 0 but stock can be bought.
                        profit = Math.Max(-stocks[day] + dp[day + 1, 0], 0 + dp[day + 1, 1]);
                        Console.WriteLine("Left Expression on buy :" +(-stocks[day] + dp[day + 1, 0])
                            +" Right "+ (0 + dp[day + 1, 1]));
                    }
                    else
                    {
                        //stocks[day] + dp[day + 1, 1] : If selling the stock on the next day, will get the profit but can buy the stock.
                        //0 + dp[day + 1, 0] : If not selling the stock on the next day, will not get the profit. But can be sold for further day.
                        profit = Math.Max(stocks[day] + dp[day + 1, 1], 0 + dp[day + 1, 0]);
                        Console.WriteLine("Left Expression on Sell :" + (stocks[day] + dp[day + 1, 1])
                           + " Right " + (0 + dp[day + 1, 0]));

                    }
                    dp[day, buy] = profit;
                }
            }
            return dp[0, 1];
        }
    }
}
