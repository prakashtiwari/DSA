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
            ZeroOneKnapsack zeroOneKnapsack = new ZeroOneKnapsack();
            int[] weights = new int[] { 3, 6, 5, 2, 4 };
            int[] values = new int[] { 12, 20, 15, 6, 10 };
            int happiness = zeroOneKnapsack.GetMaxVal(weights, values, 8, 5);
            Console.WriteLine("Max happiness: " + happiness);
            Console.ReadLine();
        }
    }
}
