namespace ArrayPract.MaxSubarray
{
    public class MaxSumDistinctElementK
    {
        public int GetMaxSum(int[] nums, int k)

        {
            int ans = 0;
            int len = nums.Length;
            int i = 0;
            int sum = 0;
            Dictionary<int, int> mapFreq = new Dictionary<int, int>();
            while (i < k && i < len) //Add initially k elements
            {
                if (!mapFreq.ContainsKey(nums[i]))
                {
                    mapFreq.Add(nums[i], 1);
                }
                else
                {
                    mapFreq[nums[i]]++;
                }
                sum += nums[i];
                i++;
            }
            if (mapFreq.Count == k)
            {
                Console.WriteLine($"Sum is:{sum}");
                ans = sum;
            }//If all elements are distinct

            while (i < len)
            {
                //Remove previous item, add new item
                if (!mapFreq.ContainsKey(nums[i]))
                {
                    mapFreq.Add(nums[i], 1);
                }
                else
                {
                    mapFreq[nums[i]]++;//Increase frequency
                }
                Console.WriteLine($"Added elements: {nums[i]}");
                mapFreq[nums[i - k]]--;
                Console.WriteLine($"Reduced, Element is:{nums[i - k]}");
                if (mapFreq[nums[i - k]] == 0)// If frequency is 0
                {
                    Console.WriteLine($"Removing the element: {nums[i - k]}");
                    mapFreq.Remove(mapFreq[nums[i - k]]);
                }
                sum += nums[i]; //Add current               
                sum -= nums[i - k];
                Console.WriteLine($"Sum is: {sum}");//Removeprevious
                if (mapFreq.Count == k)// When there are k elements in the map
                    ans = Math.Max(sum, ans);
                i++;

            }
            return ans; ;

        }
    }
}
