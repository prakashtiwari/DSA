using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.NoOfWaysTravel
{
    public class NoOfWaysTravelMatrix
    {

        int[,] dp;
        public int GetWaysToMatrix(int[,] arr, int i, int j)
        {
            dp = new int[i, j];
            return GetWaysToTraverseMaatrix(i - 1, j - 1);
        }
        //private int GetWaysToTraverseMaatrix( int i,int j)
        //{
        //    //Base case
        //    if (i == 1 || j == 1)
        //        return 1;
        //    //dp[i, j] = 
        //      return  GetWaysToTraverseMaatrix(i - 1, j) + GetWaysToTraverseMaatrix(i, j - 1);
        //    //return dp[i, j];
        //}
        private int GetWaysToTraverseMaatrix(int i, int j)
        {
            //Base case
            if (i == 1 || j == 1)
            {

                dp[i, j] = 1;
                //   Console.WriteLine($"Base: Data ri is {i} and cj is {j}: " + dp[i, j]);
                return dp[i, j];
            }
            if (dp[i, j] == 0)
            {
                //  Console.WriteLine($"Recur start: Data i is {i} and j is {j}: " + dp[i, j]);

                dp[i, j] = GetWaysToTraverseMaatrix(i - 1, j) + GetWaysToTraverseMaatrix(i, j - 1);
                //  Console.WriteLine($"\n Recur end: Data i is {i} and j is {j}: " + dp[i, j]);
            }
            // Console.WriteLine($"\n Data i is {i} and j is {j}: " + dp[i, j]);
            return dp[i, j];
        }
        int[,] dpObs;
        public int GetWaysToMatrixWithObstacle(int[,] arr, int i, int j)
        {
            dpObs = new int[i, j];
            return GetWaysToTraverseMaatrixWithObs(arr, arr.GetLength(0)-1, arr.GetLength(1) - 1);
        }
        //private int GetWaysToTraverseMaatrixWithObs(int[,] arr, int i, int j)
        //{

        //    if (arr[i, j] == 0)
        //    {

        //        return dpObs[i, j] = 0;
        //        // Console.WriteLine($"\n Mat val: Row i is {i} and Col j is {j}: Mat {arr[i, j]} dp is {  dpObs[i, j]}");
        //    }
        //    else
        //    {
        //        if (i == 0 || j == 0)
        //        {                    
        //            return dpObs[i, j]=1;
        //        }
        //        if (dpObs[i, j] != 0)
        //            return dpObs[i, j];

        //        Console.WriteLine($"Recur start: Row i is {i} and Col j is {j}: " + dpObs[i, j]);
        //        dpObs[i, j] = GetWaysToTraverseMaatrixWithObs(arr, i - 1, j) + GetWaysToTraverseMaatrixWithObs(arr, i, j - 1);
        //        Console.WriteLine($"\n Recur end: Data row i is {i} and col j is {j}: Dp Mat is   {dpObs[i, j]} mat is {arr[i, j]}");


        //    }
        //    return dpObs[i, j];
        //}
        private int GetWaysToTraverseMaatrixWithObs(int[,] arr, int p, int q)
        {
            if (arr[0, 0] == 0)
                return 0;//If beginning is blocked, matrix cannot be traversed.
            arr[0, 0] = 1;
            bool isBlocked = false;
            for (int m = 0; m <= p; m++)
            {
                //If encountered blockage in the row, remaining row of a column will be blocked.
                if (arr[m, 0] == 0 || isBlocked)
                {
                    dpObs[m, 0] = 0;
                    Console.WriteLine("Zero");
                    isBlocked = true;
                }
                else
                    dpObs[m, 0] = 1;
            }
            //If encountered blockage in the column, remaining column of a row will be blocked.
            isBlocked = false;
            for (int n = 0; n <= q; n++)
            {
                if (arr[0, n] == 0 || isBlocked)
                {
                    dpObs[0, n] = 0;
                    isBlocked = true;


                }
                else
                {
                    dpObs[0, n] = 1;
                }
            }
            for (int i = 1; i <= p; i++)
            {
                for (int j = 1; j <= q; j++)
                {
                    if (arr[i, j] == 1)
                    {
                        // Console.WriteLine($"\n Mat val: Row  is {i} and Col  is {j}: Mat {dpObs[i - 1, j] } dp is {  dpObs[i, j - 1]}");
                        dpObs[i, j] = dpObs[i - 1, j] + dpObs[i, j - 1];



                    }
                    else
                    {
                        dpObs[i, j] = 0;
                    }
                    Console.WriteLine($"\n Mat val: Row  is {i} and Col  is {j}: Mat {dpObs[i - 1, j] } dp is {  dpObs[i, j - 1]}");
                    Console.WriteLine("Dp is" + dpObs[i, j]);
                }
            }
            
            return dpObs[p, q];
        }
    }
}
