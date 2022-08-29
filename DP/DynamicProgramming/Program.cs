using DynamicProgramming.Decoding;
using DynamicProgramming.DpSubsequenceMaxSum;
using DynamicProgramming.Fibo;
using DynamicProgramming.LICS;
using DynamicProgramming.NoOfWaysTravel;
using DynamicProgramming.Party;
using DynamicProgramming.PrincessAndDungeon;
using DynamicProgramming.SqrRoot;
using System;
using System.Collections.Generic;
using DynamicProgramming.EditPath;
using DynamicProgramming.PatternMatching;
using DynamicProgramming.Knapsack;
using DynamicProgramming.LongestIncreasingSubseq;
using DynamicProgramming.DistinctSubSeq;
using DynamicProgramming.MinFallingPathSum;
using DynamicProgramming.WaysToDecode;
using DynamicProgramming.WaysToGetSumSol;
using DynamicProgramming.PalinPartition;
using DynamicProgramming.DivideIntoSubset;
using DynamicProgramming.BuyAndSellStocks;
using DynamicProgramming.CutStick;
using DynamicProgramming.BurstBaloon;
using DynamicProgramming.PartitionArray;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Fibonicci fibonicci = new Fibonicci(5);
            //int nthFibo = fibonicci.GetFibo(5);
            //Console.WriteLine("Fibo is:" + nthFibo);
            //Nth
            int n = 1;
            //NMinSquareRoot nMinSquareRoot = new NMinSquareRoot(n);
            //Console.WriteLine("Min square root:" + nMinSquareRoot.MinNoOfSqrt(n));
            //WaysOfParty waysOfParty = new WaysOfParty();
            //int wayOfParty = waysOfParty.solve(17);
            //Console.WriteLine("Way of party:" + wayOfParty);
            //NumOfDecoding decoding = new NumOfDecoding();
            //Console.WriteLine("No of ways decode: " + decoding.numDecodings("226"));
            //  SubsequenceMaxSum subsequenceMaxSum = new SubsequenceMaxSum();
            //// int sum = subsequenceMaxSum.GetMaxSubSeqSum(new int[] { 3, 6, 2, 4, 5, 9, 10 }); //21
            //  int sum = subsequenceMaxSum.GetMaxSubSeqSum(new int[] { 3 });
            //  Console.WriteLine("Sum is " + sum);
            //NoOfWaysTravelMatrix noOfWaysTravelMatrix = new NoOfWaysTravelMatrix();
            //int[,] mat = new int[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
            //int i = noOfWaysTravelMatrix.GetWaysToMatrix(mat, 4, 4);
            //Console.WriteLine("Number of ways:" + i);

            //Second variations
            //int[,] matVariant = new int[,] { { 1, 1, 1, 1 }, { 1, 0, 1, 0 }, { 0, 1, 1, 1 }, { 1, 0, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 0, 1 } };
            //NoOfWaysTravelMatrix noOfWaysTravelMatrix = new NoOfWaysTravelMatrix();
            //int i = noOfWaysTravelMatrix.GetWaysToMatrixWithObstacle(matVariant, 6, 4);
            //Console.WriteLine("Number of ways to reach M*n matrix:" + i);

            //PrincessInDungeon princessInDungeon = new PrincessInDungeon();
            //List<List<int>> input = new List<List<int>>();
            //List<int> r1 = new List<int>() { -3, 2, 4, -5 };
            //input.Add(r1);
            //List<int> r2 = new List<int>() { -6, 5, -4, 6 };
            //input.Add(r2);
            //List<int> r3 = new List<int>() { -15, -7, 5, -6 };
            //input.Add(r3);
            //List<int> r4 = new List<int>() { 2, 10, -8, -5 };
            //input.Add(r4);
            //int minEnergey = princessInDungeon.calculateMinimumHP(input);
            //Console.WriteLine("Min energy needed: "+ minEnergey);
            //LongestCommonSubSeq longestCommonSubSeq = new LongestCommonSubSeq();
            //int result = longestCommonSubSeq.GetLongestCommonSubSeq("mapyak", "samyak");
            //Console.WriteLine("LICS is: " + result);

            //EditDist editPath = new EditDist();
            //int result = editPath.GetEditDistanceCost("abnluftan", "kaspbft");
            //Console.WriteLine("Distance is result:"+ result);
            //PatternMatchingSol patternMatching = new PatternMatchingSol();
            //bool isMatched = patternMatching.IsMatch("abc", "?*?b?");
            //Console.WriteLine("Is Pattern matched:" + isMatched);
            //int Matched = patternMatching.MatchPattern("abc", "*?");
            //Console.WriteLine("Pattern matched:" + Matched);
            //Knapsakc
            //ZeroOneKnapsack zeroOneKnapsack = new ZeroOneKnapsack();
            //int[] weights = new int[] { 3, 6, 5, 2, 4 };
            //int[] values = new int[] { 12, 20, 15, 6, 10 };
            //int happiness = zeroOneKnapsack.GetMaxVal(weights, values, 8, 5);
            //Console.WriteLine("Max happiness: " + happiness);

            //LongestIncreasingSubSeq longestIncreasingSubSeq = new LongestIncreasingSubSeq();
            //int[] arr = new int[] { 10, 3, 12, 7, 2, 9, 11, 20, 11, 13, 6, 8 };
            //int maxIncSeq = longestIncreasingSubSeq.GetLongestIncreasingSubSeq(arr);

            // DistinctSubSeqCal distinctSubSeqCal = new DistinctSubSeqCal();
            //int maxWay =distinctSubSeqCal.GetDistinctSub("babgbag", "bag");
            // Console.WriteLine(maxWay);
            //MinFallingPathSumSoln minFallingPathSum = new MinFallingPathSumSoln();
            //int[,] data = new int[4, 5] { { 3, 7, 2, 3, 6 }, { 9, 2, 8, 4, 4 }, { 3, 10, 1, 2, 6 }, { 16, 15, 2, 11, 12 } };
            //int minResult = minFallingPathSum.GetMinFallingPathSum(data, 4, 5);
            //int waysToGetSum = 0;
            //WaysToGetSum objwaysToGetSum = new WaysToGetSum();
            //int[] input = new int[] { 1, 2, 3 };
            //waysToGetSum = objwaysToGetSum.GetWays(input, 4);
            //Console.WriteLine(waysToGetSum);

            //PalinPartitioningSol palinPartitioning = new PalinPartitioningSol();
            //int result = palinPartitioning.minCutPalindrome("bcaaacb");//--"ababc");
            //Console.WriteLine("Length of cut:"+ result);
            //WaysToDecodeSoln waysToDecode = new WaysToDecodeSoln();
            //int waysDecoded = waysToDecode.GetWaysToBedecoded("226");
            //Console.WriteLine(waysDecoded);
            //DevideIntoEqualSum devideIntoEqualSum = new DevideIntoEqualSum();
            //bool response = devideIntoEqualSum.canDivideEqualSubset(new int[] { 1, 3, 4 });
            //Console.WriteLine("Can be divided:"+ (response?"Yes":"No"));

            //TargetK target = new TargetK();
            //bool canAchieved = target.CanTargetBeAchieved(new int[] { 2,3,1,1 }, 4);
            //Console.WriteLine("Can be achieved:" + canAchieved);
            int[] arr = new int[] { 2, 3, 1, 1, 7 };
            //DevideIntoEqualSum devideIntoEqualSum = new DevideIntoEqualSum();
            //bool canBedivided = devideIntoEqualSum.canDivideEqualSubset(arr);
            //Console.WriteLine("Can be divided equally: "+ canBedivided);
            //TargetK objTargetK = new TargetK();
            //int min = objTargetK.MinDiff(arr, 14);
            //Console.WriteLine("Min is:"+ min);
            //WaysToDecodeTillN waysToDecodeTillN = new WaysToDecodeTillN();
            //Console.WriteLine(waysToDecodeTillN.GetWaysToDecodeTillN(7));
            /////////////Buy and sell stock 2

            //BuyAndSellStocks2 buyAndSellStocks = new BuyAndSellStocks2();
            //int[] stocks = new int[] { 7, 1, 5, 6, 3, 8,2,1,7 };
            //long maxProfit = buyAndSellStocks.GetMaxProfit(stocks);
            //Console.WriteLine("Max profit is:"+ maxProfit);
            //BuyAndSellStock3 buy = new BuyAndSellStock3();
            //int[] stocks = new int[] { 7, 1, 5, 6, 3, 8, 2, 0,1, 7 };
            //int profitOnLimitedTransact = buy.GetMaxProfiForKTransactUsingTransactNoSO(stocks, 2, 3);
            //Console.WriteLine($"Max profit on the limited transaction :" + profitOnLimitedTransact);
            //
            //CutStickMinCost cutStickMinCost = new CutStickMinCost();
            //int[] cuts = new int[] { 0, 5, 6, 1, 4, 2, 9 };
            ////1,2,4,5,6
            //Array.Sort(cuts);
            //int minCost = cutStickMinCost.GetMinCost(cuts, 9, 5);
            // Console.WriteLine("Min cost is:" + minCost);

            BurstBallonMaxCostSoln ballloon = new BurstBallonMaxCostSoln();
            //int[] ball2 = new int[] { 1,2,3,4 };
            int[] ball = new int[] { 3, 1, 5, 8 ,6,9};
            //int balloonCost = ballloon.GetBurstBallonMaxCost(ball);
            //Console.WriteLine("Cost is :"+ balloonCost);
            PartitionArraySol partitionArray = new PartitionArraySol();
            int response = partitionArray.maxSubArray(ball, 3);
            Console.WriteLine("MAx is: " + response);
            Console.ReadLine();
        }
    }
}
