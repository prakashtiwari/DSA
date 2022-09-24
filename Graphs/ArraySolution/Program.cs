using ArraySolution.DiffK;
using ArraySolution.MissingNextElement;
using ArraySolution.NextGreater;
using ArraySolution.SubArraySum;
using System;

namespace ArraySolution
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //NextGreaterElementInArray nextGreater = new NextGreaterElementInArray();
            //int[] input = new int[] {4,12,5,3,1,2,5,3,1,2,4,6 };
            //nextGreater.GetNextGreaterElement(input);
            //DiffKSoln diffKSoln = new DiffKSoln();
            //bool result = diffKSoln.IsDiffK(new int[] { 2, 4, 7, 6, 3 },1);
            FindNextMissingPosInt findNextMissingPosInt = new FindNextMissingPosInt();
            //Console.WriteLine("Missing is :" + findNextMissingPosInt.GetNextMissing(new int[] { -2, 1, 2, 3, 0, 4,5,6 }));
            // Console.WriteLine("Missing is :" + findNextMissingPosInt.GetNextMissingOptimized(new int[] { -2, 5, 6, 1, 2, 3, 4 }));
            //GetNextMissingOptimized
            //MaxSubArraySum sum = new MaxSubArraySum();
            //Console.WriteLine("Mx is:" + sum.GetMaxSubArraySum(new int[] { -1, 4, 2, 6, 2, -5, 1, 2 }));
            KadanesAlgo kadanesAlgo = new KadanesAlgo();
            Console.WriteLine("Max sum is: " +kadanesAlgo.GetMaxSubArraySum(new int[] { 10, -20, -12, 6, 5, -3, 8, -2 }));
            // Console.WriteLine(result ? "Yes" : "No");
            Console.ReadLine();
        }
    }
}
