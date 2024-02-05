// See https://aka.ms/new-console-template for more information
using ArrayPract.ArrayReverse;
using ArrayPract.MaxSubarray;
using ArrayPract.Sumpract;

Console.WriteLine("Hello, World!");
//TwoSum twoSum = new TwoSum();
//bool result = twoSum.IsTwoSum(new int[] { 2, 6, 5, 8, 11 }, 14);
//Console.WriteLine($"Two sum: {result}");

//ReverseArray reverseArray = new ReverseArray();
//int[] rev = reverseArray.Reverse(new int[] { 1, 3, 2,4 });
//MaxSubarraySum maxSubarraySum = new MaxSubarraySum();
//int result = maxSubarraySum.MaxSubArraySum(new int[] { -2, -3, 4, -1, -2, 1, 5, -3 });
//Console.WriteLine($"Result is: {result}");

MaxSumDistinctElementK maxSumDistinctElementK = new MaxSumDistinctElementK();
int maxSum = maxSumDistinctElementK.GetMaxSum(new int[] {1, 5, 4, 2, 9, 9, 9 }, 3);
Console.WriteLine($"Max sum: {maxSum}");

Console.ReadLine();
