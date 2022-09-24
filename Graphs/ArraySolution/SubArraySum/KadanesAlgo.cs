using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySolution.SubArraySum
{
    public class KadanesAlgo
    {
        public int GetMaxSubArraySum(int[] input)
        {
            int sum = 0;
            int n = input.Length;
            int ans = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                sum = sum + input[i];
                ans = Math.Max(sum, ans);
                if (sum < 0)
                    sum = 0;
            }
            return ans;

        }
    }
}
