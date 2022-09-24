using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySolution.DiffK
{
    public class DiffKSoln
    {
        public bool IsDiffK(int[] arr, int k)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {

                dict[arr[i]] = dict.GetValueOrDefault(arr[i], 0) + 1;

                //If given K is 0, they there are 2 elements with same value then produce 0
                if (k == 0 && dict[arr[i]] > 1)
                    return true;

            }
            if (k == 0)
                return false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (dict.ContainsKey(k + arr[i]))
                {
                    Console.WriteLine("Yes Pair");
                    return true;
                }

            }

            return false;
        }
    }
}
