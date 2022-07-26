using Backtracking.BTSolutions;
using System;
using System.Collections.Generic;

namespace Backtracking
{
    class Program
    {
        static void Main(string[] args)
        {
            //AllPermutations allpermutation = new AllPermutations();
            //int[] arr = new int[] { 1, 2, 3 };
            //IList<IList<int>> result = new List<IList<int>>();
            //allpermutation.GetAllPermutations(arr, 0, arr.Length, result);
            AllSubsets allSubsets = new AllSubsets();
            List<List<int>> result = allSubsets.GetAllSubset(new List<int> { 11,12 });
            Console.ReadLine();// ("Hello World!");
        }
    }
}
