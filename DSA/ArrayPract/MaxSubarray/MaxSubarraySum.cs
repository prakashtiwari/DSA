namespace ArrayPract.MaxSubarray
{
    public class MaxSubarraySum
    {
        public int MaxSubArraySum(int[] arr)
        {
            int len = arr.Length; ;
            int max = int.MinValue;
            int sum = 0;
            int startIndex = 0, endIndex = 0;
            for (int i = 0; i < len; i++)
            {
                if (sum == 0)
                    startIndex = i;
                sum += arr[i];
                if (sum > max)
                {
                    max = sum;
                    endIndex = i;
                }
                if (sum < 0)
                {
                    sum = 0;
                }
            }
            return max;
        }
    }
}
