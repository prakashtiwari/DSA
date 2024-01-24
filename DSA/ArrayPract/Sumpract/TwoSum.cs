using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayPract.Sumpract
{
    public class TwoSum
    {

        public bool IsTwoSum(int[] arr, int k)
        {
            bool result = false;
            if (arr.Length == 0)
            {
                return result;
            }
            HashSet<int> set = new HashSet<int>();
            int diff = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (k > arr[i])
                {
                    diff = k - arr[i];
                    if (set.Contains(diff))
                        return true;
                    set.Add(arr[i]);
                }
            }
            return result;

        }

    }
}
