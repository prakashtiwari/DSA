using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPractice.GraphProblems
{
    public class LongestConsequitiveSequence
    {
        public int GetLongestConsequitiveSequence(int[] nums)
        {
            IDictionary<int, bool> map = new Dictionary<int, bool>();

            int max = 0, curr = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (!map.ContainsKey(nums[i]))
                {
                    //Adding each array element in the hash map.
                    map.Add(nums[i], false);
                }
            }
            foreach (int entry in map.Keys.ToList())
            {
                //If value is true it means already checked.
                if (map[entry])
                {
                    continue;
                }
                // Search Back-ward values
                for (int back = entry - 1; map.ContainsKey(back); --back, ++curr)
                {
                    map[back] = true;
                    Console.WriteLine("Previous Current" + curr);
                }
                //Search forward values.
                for (int front = entry + 1; map.ContainsKey(front); ++front, ++curr)
                {
                    map[front] = true;
                    Console.WriteLine("Next Current" + curr);
                }
                max = max > curr ? max : curr;
                curr = 1;
            }
            Console.WriteLine("Max is:" + max);
            return max;
        }
    }
}
