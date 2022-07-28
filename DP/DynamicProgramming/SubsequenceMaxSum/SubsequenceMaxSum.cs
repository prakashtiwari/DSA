using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.DpSubsequenceMaxSum
{
    public class SubsequenceMaxSum
    {
        int[] dpArr;
        public int GetMaxSubSeqSum(int[] arr)
        {
            dpArr = new int[arr.Length + 1];
            for (int i = 0; i <= arr.Length; i++)
            {
                dpArr[i] = -1;
            }
            return SubSeqSum(arr, arr.Length-1);

        }
        private int SubSeqSum(int[] arr, int n)
        {
            if (n == 0)
                return Math.Max(0, arr[0]);
            if (n == 1)
                //return Math.Max(0, arr[0]), arr[1]);
                return Math.Max(Math.Max(0, arr[0]), arr[1]);
            if (dpArr[n] != -1)
                return dpArr[n];
            dpArr[n] = Math.Max(arr[n] + SubSeqSum(arr, n - 2), SubSeqSum(arr, n - 1));
            return dpArr[n];

        }
    }
}
