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
            IList<IList<int>> result = allSubsets.GetAllSubset(new int[] { 1, 2, 3 });
            Console.ReadLine();// ("Hello World!");
        }
    }
}
